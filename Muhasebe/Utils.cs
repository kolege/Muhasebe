﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muhasebe
{
    class Utils
    {
        public static int paymentTypeTL=1;
        public static int paymentTypeUSD = 2;

        static LoadingForm loadingForm = new LoadingForm();

        public static void show()
        {
            loadingForm.Show();
        }

        public static void hide()
        {
            loadingForm.Hide();
        }

    }
}
