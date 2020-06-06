using System;
using System.Collections.Generic;

namespace MONEYfy
{
    class Account
    {


        private  double income = 0;

        public  double Income
        {
            get { return income; }
            set
            {
                if (value > 0)
                    income = value;
                else
                    income = 0;
            }
        }

        private  double expense = 0;

        public override string ToString() => $"{Name}";
        public  double Expense
        {
            get { return expense; }
            set
            {
                if (value > 0)
                    expense = value;
                else
                    expense = 0;
            }
        }



       

        public string ?From { get; set; }

        public string ?To { get; set; }


        private   string name;

        public  string Name
        {
            get { return name; }
            set { name = value; }
        }

        private static Currency currency = new Currency();

        public  string CurrencyName 
        { 
            get
            { return currency.Name; }

            set { currency.Name = value; }
        }

        public double? Balance = null;

        public List<Category> Categories { get; set; }

        
        //public  decimal CurrencyRate { get {currency.Rate; } set; }


    }
}