using System;
using System.Collections.Generic;

namespace MONEYfy
{
    static class ClassProfile
    {
        private static void DrawLogo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\t\t\t\t\t\t__________________________________________________________\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\t\t\t\t\t\t*       *   *******    *    * *****  *    * ");
            Console.WriteLine("\t\t\t\t\t\t\t* *   * *  *       *   **   * *       *  *  ******  *   *");
            Console.WriteLine("\t\t\t\t\t\t\t*   *   * *         *  * *  * *****    *    *        **");
            Console.WriteLine("\t\t\t\t\t\t\t*       *  *       *   *  * * *       *     ******   *");
            Console.WriteLine("\t\t\t\t\t\t\t*       *   ******     *    * *****  *      *       *");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\t\t\t\t\t\t__________________________________________________________\n");
        }
        public static void Profile(Account res,List<string> menu, List<string> currency,List<Account> accounts)
        {
            while (true)
            {

                Console.Write("Account:");
                Console.WriteLine($"{res.Name}\n");
                Console.WriteLine(@"/--------------------------------------------------\");
                Console.Write("\t\tTOTAL BALANCE:");
                Console.WriteLine(Program.Balance(res.Income, res.Expense));
                Console.WriteLine(@"\--------------------------------------------------/");
                Console.Write("\nEXPENSES:");
                Console.WriteLine(res.Expense);
                Console.Write("INCOMES:");
                Console.WriteLine(res.Income);
                Console.Write("Period:");

                Console.WriteLine($"{res.From}  -  {res.To}");
                DrawLogo();
                Console.SetCursorPosition(15, 20);
                
                Console.ResetColor();

                Console.WriteLine();


                string str = Menu.MainDraw<string>(menu);

                switch (str)
                {
                    case "Add expense":
                        if (Program.Balance(res.Income, res.Expense) > 0)
                            App.AddExpense(currency, res);
                        break;
                    case "Add income":
                        App.AddIncome(currency, res);
                        break;
                    case "Manage categories":
                        Console.Clear();
                        App.ManageCategories(res);
                        Console.Clear();
                        break;
                    case "Change period":
                        App.ChangePeriod(res);
                        break;
                    case "Manage accounts":
                        res = App.ManageAccounts(accounts, res);
                        break;
                    case "Full info":
                        Console.Clear();
                        App.FullInfo(res);
                        Console.Clear();
                        break;
                    case "Export to CSV":
                        App.ExportToCSV(res);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}