
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muhasebe
{
    public partial class ReportsForm : Form
    {

        SQLiteConnection connection = MainForm.connection;
        List<int> listEmployees = new List<int>();
        List<ProductModel> listProducts = new List<ProductModel>();
        List<DealModel> listDeals;
        long totalPriceTL=0, totalPriceUSD=0, totalAmountUSD=0, totalAmountTL=0;

        public ReportsForm()
        {
            InitializeComponent();
            listDeals = new List<DealModel>();
            dtpDate.Visible = false;
        }

        private void fillCbProducts()
        {
            listProducts.Clear();
            cbProducts.Items.Clear();
            connection.Open();
            SQLiteCommand query = new SQLiteCommand("Select * From mhsb_product", connection);
            query.ExecuteNonQuery();
            SQLiteDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                ProductModel product = new ProductModel(reader["proCode"].ToString());
                product.amount=long.Parse(reader["adet"].ToString());
                string image=reader["image"].ToString();
                int mod4 = image.Length % 4;
                if (mod4 > 0)
                {
                    image += new string('=', 4 - mod4);
                }
                product.image = (Bitmap)((new ImageConverter()).ConvertFrom(Convert.FromBase64String(image)));
                product.description = reader["description"].ToString();
                cbProducts.Items.Add(product.proCode);
                listProducts.Add(product);
            }
            connection.Close();
            cbProducts.DropDownStyle = ComboBoxStyle.DropDown;
            cbProducts.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbProducts.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        public void fillCbEmployee()
        {
            listEmployees.Clear();
            cbEmployee.Items.Clear();
            connection.Open();
            SQLiteCommand query = new SQLiteCommand("Select * From mhsb_employee", connection);
            query.ExecuteNonQuery();
            SQLiteDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                listEmployees.Add(int.Parse(reader["id"].ToString()));
                cbEmployee.Items.Add(reader["name"].ToString() + " " + reader["surName"].ToString());
            }
            connection.Close();
            cbEmployee.DropDownStyle = ComboBoxStyle.DropDown;
            cbEmployee.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbEmployee.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        public void fillList()
        {
            totalPriceUSD = 0;
            totalPriceTL = 0;
            totalAmountTL = 0;
            totalAmountUSD = 0;
            lvReport.Clear();
            lvReport.View = View.Details;
            lvReport.FullRowSelect = true;
            lvReport.Columns.Add("Ürün Kodu", 100, HorizontalAlignment.Left);
            lvReport.Columns.Add("Tarih", 180, HorizontalAlignment.Left);
            lvReport.Columns.Add("Miktar", 100, HorizontalAlignment.Left);
            lvReport.Columns.Add("Fiyat", 100, HorizontalAlignment.Left);
            lvReport.Columns.Add("Birim", 100, HorizontalAlignment.Left);
            lvReport.Columns.Add("Satış Elemanı", 140, HorizontalAlignment.Left);
            if (chbSale.Checked)
                lvReport.Columns.Add("Müşteri", 140, HorizontalAlignment.Left);
            for(int i=0; i < listDeals.Count; i++)
            {
                DealModel deal = listDeals[i];
                string[] itemArrayLv = new string[7];
                ListViewItem lviPayments;
                itemArrayLv[0] = deal.proCode;
                itemArrayLv[1] = UnixTimeStampToDateTime(deal.date).ToString();
                itemArrayLv[2] = deal.amount.ToString();
                itemArrayLv[3] = deal.price + "";
                if (deal.type == Utils.paymentTypeTL)
                {
                    itemArrayLv[4] = "TL";
                    totalPriceTL += long.Parse(deal.price + "");
                    totalAmountTL += deal.amount;
                }
                else
                {
                    itemArrayLv[4] = "USD";
                    totalPriceUSD += long.Parse(deal.price + "");
                    totalAmountUSD += deal.amount;
                }
                itemArrayLv[5] = getSellerName(deal.sellerID);
                if (chbSale.Checked)
                    itemArrayLv[6] = deal.customer;
                lviPayments = new ListViewItem(itemArrayLv);
                lvReport.Items.Insert(lviPayments.IndentCount, lviPayments);
            }

        }

        public void getDeals()
        {
            Console.WriteLine(cbProducts.SelectedIndex + "/" + cbProducts.SelectedItem+"/"+cbProducts.SelectedValue);
            Console.WriteLine(cbEmployee.SelectedIndex + "/" + cbEmployee.SelectedItem + "/" + cbEmployee.SelectedValue);
            listDeals.Clear();
            connection.Open();
            String queryString;
            if (chbPurchase.Checked)
                queryString = "Select * From mhsb_purchase ";
            else
                queryString = "Select * From mhsb_sale";
            if (cbProducts.SelectedIndex != -1 || cbEmployee.SelectedIndex != -1 || chbDate.Checked)
                queryString += " WHERE ";
            if (cbProducts.SelectedIndex != -1)
                queryString += "proCode = '" + cbProducts.SelectedItem + "'";
            if (cbProducts.SelectedIndex != -1 && (cbEmployee.SelectedIndex != -1))
                queryString += " and ";
            if (cbEmployee.SelectedIndex != -1)
                queryString += "sellerId = '" + listEmployees[cbEmployee.SelectedIndex] + "'";
            if ((cbProducts.SelectedIndex != -1 || cbEmployee.SelectedIndex != -1) && chbDate.Checked)
                queryString += " and ";
            if (chbDate.Checked)
            {
                queryString+=" date >= "+ getDate();
            }
            queryString += " ORDER BY date";
            SQLiteCommand query = new SQLiteCommand(queryString, connection);
            query.ExecuteNonQuery();
            SQLiteDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                DealModel deal = new DealModel(int.Parse(reader["id"].ToString()));
                deal.proCode = reader["proCode"].ToString();
                Console.WriteLine("Code : "+reader["proCode"].ToString());
                deal.date = long.Parse(reader["date"].ToString());
                deal.amount = long.Parse(reader["amount"].ToString());
                deal.price = float.Parse(reader["price"].ToString());
                deal.type = int.Parse(reader["type"].ToString());
                deal.sellerID = int.Parse(reader["sellerId"].ToString());
                if (chbSale.Checked)
                {
                    deal.customer = reader["buyer"].ToString();
                }
                listDeals.Add(deal);
            }
            reader.Close();
            query.Dispose();
            connection.Close();
            Console.WriteLine(listDeals.Count.ToString());
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            fillCbEmployee();
            fillCbProducts();
        }

        private void chbPurchase_Click(object sender, EventArgs e)
        {
            chbPurchase.Checked = true;
            chbSale.Checked = false;
        }

        private void chbSale_Click(object sender, EventArgs e)
        {
            chbSale.Checked = true;
            chbPurchase.Checked = false;
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime.AddHours(-3);
        }

        private void cbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbProducts.SelectedIndex != -1)
            {
                pbProduct.Image = listProducts[cbProducts.SelectedIndex].image;
            }
        }

        private void chbDate_CheckStateChanged(object sender, EventArgs e)
        {
            if (dtpDate.Visible==true)
                dtpDate.Visible = false;
            else
                dtpDate.Visible = true;
        }

        public long getDate()
        {
            DateTime date = dtpDate.Value.Date;
            return (long)(date.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        public string getSellerName(int id)
        {
            string name=null;       
            connection.Open();
            try
            {
                SQLiteCommand query = new SQLiteCommand("Select * From mhsb_employee WHERE id="+id, connection);
                query.ExecuteNonQuery();
                SQLiteDataReader reader = query.ExecuteReader();
                while (reader.Read())
                {
                    name = reader["name"].ToString() + " " + reader["surName"].ToString();
                    break;
                }
                reader.Close();
                query.Dispose();
            }catch(SQLiteException error)
            {
                connection.Close();
                Console.WriteLine(error.ToString());
            }
            connection.Close();
            if (name != null)
                return name;
            else
                return id + "";
        }

        public void createBill()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path = path + @"\Çizelgeler";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            #region Font seç
            BaseFont STF_Helvetica_Turkish = BaseFont.CreateFont("Helvetica", "Cp1254", BaseFont.NOT_EMBEDDED);
            //BaseFont trArial = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            iTextSharp.text.Font fontArialHL = new iTextSharp.text.Font(STF_Helvetica_Turkish, 9, iTextSharp.text.Font.NORMAL, BaseColor.DARK_GRAY);
            iTextSharp.text.Font fontArial = new iTextSharp.text.Font(STF_Helvetica_Turkish, 10, iTextSharp.text.Font.NORMAL, BaseColor.DARK_GRAY);
            iTextSharp.text.Font fontArialHeader = new iTextSharp.text.Font(STF_Helvetica_Turkish, 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font fontArialTableHeader = new iTextSharp.text.Font(STF_Helvetica_Turkish, 11, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font fontArialbold = new iTextSharp.text.Font(STF_Helvetica_Turkish, 9, iTextSharp.text.Font.BOLD, BaseColor.DARK_GRAY);
            iTextSharp.text.Font fontArialboldgeneral = new iTextSharp.text.Font(STF_Helvetica_Turkish, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            #endregion

            iTextSharp.text.Document pdfFile = new iTextSharp.text.Document();
            try
            {
                path += "\\";
                if (cbProducts.SelectedIndex != -1)
                    path += cbProducts.SelectedItem.ToString();
                if (cbEmployee.SelectedIndex != -1 && cbProducts.SelectedIndex == -1)
                    path += " / "+cbEmployee.SelectedItem.ToString();
                PdfWriter.GetInstance(pdfFile, new FileStream(path + ".pdf", FileMode.Create));
                pdfFile.Open();

                #region Fatura oluşturan bilgileri
                pdfFile.AddCreator("Tamer Collection"); //Oluşturan kişinin isminin eklenmesi
                pdfFile.AddCreationDate();//Oluşturulma tarihinin eklenmesi
                pdfFile.AddAuthor("ITrack v.1.0"); //Yazarın isiminin eklenmesi
                pdfFile.AddHeader("Başlık", "Stok Kontrol");
                pdfFile.AddTitle(cbProducts.SelectedItem + "Stok Çizelgesi"); //Başlık ve title eklenmesi
                #endregion

                PdfPTable pdfTableHeader = new PdfPTable(3);
                pdfTableHeader.TotalWidth = 500f;
                pdfTableHeader.LockedWidth = true;
                pdfTableHeader.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                string header1 = "";
                if (cbProducts.SelectedIndex != -1)
                    header1 = "Ürün Kodu : "+cbProducts.SelectedItem.ToString();
                if (cbEmployee.SelectedIndex != -1)
                    header1 += "\nSatış Elemanı : " + cbEmployee.SelectedItem.ToString();
                if (chbDate.Checked)
                    header1 += "\n"+dtpDate.Value.ToShortDateString()+" Tarihinden İtibaren";
                PdfPCell cellheader1 = new PdfPCell(new Phrase(header1, fontArialHL));
                cellheader1.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cellheader1.VerticalAlignment = PdfPCell.ALIGN_BOTTOM;
                cellheader1.FixedHeight = 60f;
                cellheader1.Border = 0;
                pdfTableHeader.AddCell(cellheader1);

                PdfPCell cellheader2 = new PdfPCell(new Phrase("Tamer Collection Stok Kontrol", fontArialHeader));
                cellheader2.HorizontalAlignment = PdfPCell.ALIGN_TOP;
                cellheader2.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellheader2.FixedHeight = 60f;
                cellheader2.Border = 0;
                pdfTableHeader.AddCell(cellheader2);


                PdfPCell cellheader3 = new PdfPCell(new Phrase(DateTime.Now.ToShortDateString(), fontArial));
                cellheader3.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                cellheader3.VerticalAlignment = PdfPCell.ALIGN_BOTTOM;
                cellheader3.FixedHeight = 60f;
                cellheader3.Border = 0;
                pdfTableHeader.AddCell(cellheader3);


                Phrase p = new Phrase("\n");

                #region Tabloyu Oluştur
                PdfPTable pdfTable = new PdfPTable(3);
                pdfTable.TotalWidth = 500f;
                pdfTable.LockedWidth = true;
                pdfTable.DefaultCell.Padding = 5;
                pdfTable.DefaultCell.BorderColor = BaseColor.GRAY;

                pdfTable.AddCell(new Phrase("Tarih", fontArialTableHeader));
                pdfTable.AddCell(new Phrase("Adet", fontArialTableHeader));
                pdfTable.AddCell(new Phrase("Fiyat", fontArialTableHeader));

                for (int i = 0; i < listDeals.Count; i++)
                {
                    DealModel dm = listDeals.ElementAt(i);
                    if (cbProducts.SelectedIndex != -1 && cbEmployee.SelectedIndex != -1)
                        pdfTable.AddCell(new Phrase(UnixTimeStampToDateTime(dm.date).ToString(), fontArial));
                    else if (cbEmployee.SelectedIndex != -1)
                        pdfTable.AddCell(new Phrase(UnixTimeStampToDateTime(dm.date).ToString() + "\n" + dm.proCode, fontArial));
                    else if (cbProducts.SelectedIndex != -1)
                        pdfTable.AddCell(new Phrase(UnixTimeStampToDateTime(dm.date).ToString() + "\n" + getSellerName(dm.sellerID), fontArial));
                    else
                        pdfTable.AddCell(new Phrase(UnixTimeStampToDateTime(dm.date).ToString() + "\n" + dm.proCode + "\n" + getSellerName(dm.sellerID)));
                    pdfTable.AddCell(new Phrase(dm.amount + "", fontArial));
                    if (dm.type==Utils.paymentTypeTL)
                        pdfTable.AddCell(new Phrase(dm.price + " TL", fontArial));
                    else
                        pdfTable.AddCell(new Phrase(dm.price + " USD", fontArial));
                }

                pdfTable.AddCell(new Phrase("GENEL TOPLAM", fontArialboldgeneral));
                pdfTable.AddCell(new Phrase(lblAmount.Text, fontArialboldgeneral));
                pdfTable.AddCell(new Phrase(lblPrice.Text, fontArialboldgeneral));

                #endregion

                PdfPTable pdfTableBottom = new PdfPTable(1);
                pdfTableHeader.TotalWidth = 500f;
                pdfTableHeader.LockedWidth = true;
                pdfTableHeader.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                PdfPCell cellbottom3 = new PdfPCell(new Phrase("Imza", fontArialHeader));
                cellbottom3.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                cellbottom3.VerticalAlignment = PdfPCell.ALIGN_BOTTOM;
                cellbottom3.FixedHeight = 60f;
                cellbottom3.Border = 0;
                pdfTableBottom.AddCell(cellbottom3);

                #region Pdfe yaz ve dosyayı kapat
                if (pdfFile.IsOpen() == false) pdfFile.Open();
                pdfFile.Add(pdfTableHeader);
                pdfFile.Add(p);
                pdfFile.Add(pdfTable);
                pdfFile.Add(p);
                pdfFile.Add(pdfTableBottom);
                pdfFile.Close();
                #endregion
                System.Diagnostics.Process.Start("explorer.exe", path+".pdf");
            }
            catch (IOException e)
            {
                Console.WriteLine(e.ToString());
                MessageBox.Show("Fatura şuan kullanımda olduğu için değiştirilemşyor.Lütfen kullanıma son verip tekrar deneyiniz.");
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            getDeals();
            fillList();
            lblAmount.Text = totalAmountTL + "\n" + totalAmountUSD;
            lblPrice.Text = totalPriceTL + " TL\n" + totalPriceUSD + " USD";
        }

        private void btnCreateReport_Click(object sender, EventArgs e)
        {
            if (listDeals.Count != 0)
                createBill();
            else
                MessageBox.Show("Raporlanacak veri bulunamadı.Lütfen kriterlerinizi kontrol ediniz.");
        }

    }
}
