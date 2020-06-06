using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MONEYfy
{
    static class App
    {
        static int width = 9;
        static int length = 0;

        

        public static void AddIncome(List<string> currency, Account account )
        {
           
            ///////
            Console.Write("Amount:");
            do
            {

                account.Income = Convert.ToDouble(Console.ReadLine());
                if (account.Income < 0) Console.WriteLine("\aError!Enter again");

            } while (account.Income<0);
            Console.Clear();
            /////////////
            Console.Write("Currency:");
            string money = Menu.Options(currency, ref width, ref length);
            switch (money)
            {
                case "USD":
                    account.Income *= 1.7;
                    break;
                case "EUR":
                    account.Income *= 1.88;
                    break;
                default:
                    break;
            }
            ///////////
            Console.WriteLine("Category:");
            Category category = Menu.Options(account.Categories, ref width, ref length);
          category.Money1 = account.Income;
            ///////////
            Console.Write("Comment:");
            string comment = Console.ReadLine();
            Console.Clear();
            ////////////////////
            ///
           
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("ADD INCOME");
            Console.ResetColor();
            Console.Write($"\nAmount:{account.Income}\n");
            Console.WriteLine("Currency:" + money);
            Console.WriteLine("Category:" + category);
            Console.WriteLine("Comment:" + comment);

            Console.ReadKey(true);

            Console.Clear();

            
        }
        public static void AddExpense(List<string> currency,Account account)
        {

            ///////
            Console.Write("Amount:");
            do
            {

                account.Expense = Convert.ToDouble(Console.ReadLine());
                if (account.Expense < 0) Console.WriteLine("\aError!Enter again");
                else if (account.Expense > account.Income) Console.WriteLine("\aError!Enter again");


            } while (account.Expense > account.Income||account.Expense<0);
            Console.Clear();
            /////////////
            Console.Write("Currency:");
            string money = Menu.Options(currency, ref width, ref length);
            switch (money)
            {
                case "USD":
                    account.Income *= 1.7;
                    break;
                case "EUR":
                    account.Income *= 1.88;
                    break;
                default:
                    break;
            }
            ///////////
            Console.WriteLine("Category:");
            Category category = Menu.Options(account.Categories, ref width, ref length);
            category.Money2 = account.Expense;
            ///////////
            Console.Write("Comment:");
            string comment = Console.ReadLine();
            Console.Clear();
            ////////////////////
            ///
           
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("ADD EXPENSE");
            Console.ResetColor();
            Console.Write($"\nAmount:{account.Expense}\n");
            Console.WriteLine("Currency:" + money);
            Console.WriteLine("Category:" + category);
            Console.WriteLine("Comment:" + comment);

            Console.ReadKey(true);

            Console.Clear();

            
        }
        public static void ManageCategories(Account account)
        {
            List<string> operations = new List<string>()
            {
                "Add category",
                "Remove category"
            };
            //Console.Clear();
            Console.Clear();
            for (int i = 0; i < account.Categories.Count; i++)
            {
                Console.WriteLine($"{i + 1}-{account.Categories[i].Name}");

            }
           
           string res= Menu.MainDraw<string>(operations);
            switch (res)
            {
                case "Add category":
                    Console.Clear();
                    Category category = new Category();
                    Console.WriteLine("Enter category:");
                    category.Name = Console.ReadLine();
                    category.Id = Program.GenerateID();
                    account.Categories.Add(category);
                    break;
                case "Remove category":
                    Console.Clear();
                    Console.WriteLine("Enter category:");
                    string remove = Console.ReadLine();
                    for (int i = 0; i < account.Categories.Count; i++)
                    {
                        if (account.Categories[i].Name==remove || account.Categories[i].Name.ToLower()==remove || account.Categories[i].Name.ToUpper()==remove)
                        {
                            account.Categories.RemoveAt(i);
                        }
                    }
                    break;
                default:
                    break;
            }
            //Console.WriteLine("Enter Category:");
            //Console.ReadLine();

            Console.ReadKey();
        }

        public static void ChangePeriod(Account account)
        {
            Console.WriteLine("From\n");
            try
            {
            account.From = DateTime.Parse(Console.ReadLine()).ToShortDateString();

            }
            catch 
            {
                Console.ReadKey(true);
                Console.Clear();   
            }

            Console.WriteLine("To\n");

            try
            {
                do
                {
                    account.To = DateTime.Parse(Console.ReadLine()).ToShortDateString();
                    if (DateTime.Parse(account.From) > DateTime.Parse(account.To))
                    {
                        Console.WriteLine("Incorrect Date!Input again");
                    }

                } while (DateTime.Parse(account.From)> DateTime.Parse(account.To));

            }
            catch
            {
                Console.ReadKey();
                Console.Clear();
            }

            Console.Clear();

           
        }
       
        public static Account ?ManageAccounts(List<Account> accounts,Account acc)
        {
            Account account1 = new Account();
            List<string> operations = new List<string>()
            {
                "Add account",
                "Choose account",
                "Remove account"
            };
            //Console.Clear();
            Console.Clear();
            for (int i = 0; i < accounts.Count; i++)
            {
                Console.WriteLine($"{i + 1}-{accounts[i]}");

            }
            string res = Menu.MainDraw<string>(operations);
            switch (res)
            {
                case "Add account":
                    Console.Clear();
                    Account account = new Account();
                    Console.WriteLine("Enter account:");
                    account.Name = Console.ReadLine();
                    //account.Id = Program.GenerateID();
                    accounts.Add(account);
                    account.Categories = accounts[0].Categories;
                    Console.Clear();
                    return acc;
                    break;
                case "Choose account":
                   
                    Console.Clear();
                    account1=Menu.MainDraw<Account>(accounts);
                     acc = account1;
                    dynamic ret_acc=acc;
                    return ret_acc;
                    break;
                case "Remove account":
                    int index = 0;
                    if (accounts.Count != 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Enter account:");
                        string remove = Console.ReadLine();
                        for (int i = 0; i < accounts.Count; i++)
                        {
                            if (accounts[i].Name == remove || accounts[i].Name.ToLower() == remove || accounts[i].Name.ToUpper() == remove)
                            {
                                if (accounts.Count > 1) accounts.RemoveAt(i);
                                index = i;
                                break;

                            }
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Can't remove your last acc!");
                        Console.ReadKey(true);
                        Console.Clear();

                    }
                    Console.Clear();
                   
                    return acc;
                    break;
                default:
                    return null;
                    break;
                    
            }
            //Console.WriteLine("Enter day:");
            //Period.Day =Convert.ToInt32( Console.ReadLine());
            //Console.WriteLine("Enter month:");
            //Period.Month = Convert.ToInt32(Console.ReadLine());
        }

        public static void FullInfo(Account account)
        {
            Console.Clear();
            Console.Write("Period:");
            Console.WriteLine($"{account.From}  -  {account.To}\n\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Expenses:");
            Console.ResetColor();
            foreach (var item in account.Categories)
            {
                Console.WriteLine($"{item.Name}-{item.Money2}");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Incomes:");
            Console.ResetColor();
            foreach (var item in account.Categories)
            {
                Console.WriteLine($"{item.Name}-{item.Money1}");
            }
            Console.ReadKey();
        }

        public static void ExportToCSV(Account account)
        {
            StringBuilder text_2 = new StringBuilder();


            Console.ReadKey();
            foreach (var item in account.Categories)
            {

                text_2.Append($"{item}-{ item.Money1}\n");
                
            }
            File.WriteAllText("Categories.json", text_2.ToString());
        }

    }
}