
using System;
using System.Collections.Generic;
using System.Text;


namespace MONEYfy
{
    class Program
    {

        static List<string> menu = new List<string>()
        {
            "Add expense",
            "Add income",
            "Change period",
            "Manage accounts",
            "Manage categories",
            "Full info",
            "Export to CSV",
            "Exit"
        };
        static List<string> currency = new List<string>()
            {
               "AZN",
               "USD",
               "EUR"
            };
        static List<Category> categories1 = new List<Category>()
            {
               new Category{Name="Food",Id=GenerateID()},
               new Category{Name="Taxi",Id=GenerateID()},
               new Category{Name="Home",Id=GenerateID()},
               new Category{Name="Shopping",Id=GenerateID()},
               new Category{Name="Salary",Id=GenerateID()},
               new Category{Name="Freelance",Id=GenerateID()},

            };
        static List<Category> categories2 = new List<Category>()
            {
               new Category{Name="Food",Id=GenerateID()},
               new Category{Name="Taxi",Id=GenerateID()},
               new Category{Name="Home",Id=GenerateID()},
               new Category{Name="Shopping",Id=GenerateID()},
               new Category{Name="Salary",Id=GenerateID()},
               new Category{Name="Freelance",Id=GenerateID()},

            };

        static List<Category> categories3 = new List<Category>()
            {
               new Category{Name="Food",Id=GenerateID()},
               new Category{Name="Taxi",Id=GenerateID()},
               new Category{Name="Home",Id=GenerateID()},
               new Category{Name="Shopping",Id=GenerateID()},
               new Category{Name="Salary",Id=GenerateID()},
               new Category{Name="Freelance",Id=GenerateID()},

            };
        static List<Account> accounts = new List<Account>()
        {
            new Account{ Name="Cash",Categories=categories1},
            new Account{Name="CardEUR",Categories=categories2},
            new Account{Name="CardAZN",Categories=categories3}
        };
        

        public static string GenerateID()
        {
            StringBuilder id = new StringBuilder("");
            Random rand = new Random();
            string generate = "1234567890qwertyuiopasdf9876543210";
            for (int i = 0; i < 15; i++)
            {
                id.Append(generate[rand.Next(0, generate.Length - 1)]);
            }
            return id.ToString();


        }

       
        public static double Balance(double income, double expense) 
        {
            if (income >= expense)
            {
                //dynamic d1 = income, d2 = expense;
                return income - expense;
            }
            else return 0;
        }
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            bool flag = true;
            
            Account res = new Account();
            while (flag)
            {

                 res=Menu.MainDraw<Account>(accounts);
                flag = false;
            }

            ClassProfile.Profile(res, menu, currency, accounts);
          
        }
    }
}