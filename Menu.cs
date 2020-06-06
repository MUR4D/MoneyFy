using System;
using System.Collections.Generic;

namespace MONEYfy
{
    static class Menu
    {

        public static T MainDraw<T>(List<T> items)
        {

            int choose = 0;
            while (true)
            {

                Console.SetCursorPosition(0, 10);
                for (int i = 0; i < items.Count; i++)
                {
                    if (choose == i) Console.BackgroundColor = ConsoleColor.Red;




                    Console.WriteLine($"{i + 1}-{items[i]}");
                    Console.ResetColor();

                }

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        if (choose < items.Count - 1) choose++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (choose > 0) choose--;
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        dynamic ret = items[choose];
                        return ret;
                    default:
                        break;
                }

            }

        }

       
        public static T Options<T>(List<T> options, ref int dx, ref int dy) 
        {
            int choose = 0;

            while (true)
            {
                Console.SetCursorPosition(dx, dy);

                for (int i = 0; i < options.Count; i++)
                {
                    if (choose == i)
                    {
                        Console.WriteLine("                    ");
                        Console.SetCursorPosition(dx, dy);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{options[i].ToString()}");
                        Console.ResetColor();
                    }

                }

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        if (choose < options.Count - 1) choose++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (choose > 0) choose--;
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        return options[choose];
                    default:
                        break;
                }

            }

        }
    }
}