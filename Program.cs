using System;
using System.Collections.Generic;

namespace CRUD
{
    class Program
    {
        public void Start(IProduct productServices)
        {
            bool endProgram = false;
            while (!endProgram)
            {
                Console.WriteLine(" __________________");
                Console.WriteLine("| 1. Add product   |");
                Console.WriteLine("| 2. Edit product  |");
                Console.WriteLine("| 3. Delete product|");
                Console.WriteLine("| 4. View product  |");
                Console.WriteLine("| 5. Exit          |");
                Console.WriteLine(" ------------------");
                Console.WriteLine("Choose a number: ");
                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        productServices.Add();
                        break;
                    case "2":
                        productServices.Edit();
                        break;
                    case "3":
                        productServices.Delete();
                        break;
                    case "4":
                        productServices.List();
                        break;
                    case "5":
                        productServices.Save();
                        endProgram = true;
                        break;
                    default:
                        Console.WriteLine("Error");
                        break;
                }
            }
        }

        static void Main(string[] args)
        {
            DefaultProduct product = new DefaultProduct();
            product.Update();
            Program program = new Program();
            program.Start(product);
        }
    }
}
