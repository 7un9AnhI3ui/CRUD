using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Xml.Linq;

namespace CRUD
{
	public class DefaultProduct : IProduct
	{
        string filePath  = "/Users/Tung/Projects/CreateReplaceUpdateDelete/CreateReplaceUpdateDelete/Storage/storage.txt";

        private List<ProductModels> _products = new List<ProductModels>();

        public void Add()
        {
            Console.WriteLine("Enter product name: ");
            string? name = Console.ReadLine();
            name = replace(name);
            Console.WriteLine("Enter product color: ");
            string? color = Console.ReadLine();
            color = replace(color);
            Console.WriteLine("Enter product type: ");
            string? type = Console.ReadLine();
            type = replace(type);
            Console.WriteLine("Enter product quantity: ");

            if (!int.TryParse(Console.ReadLine(), out int quantity))
            {
                Console.WriteLine("Error");
                return;
            }
            Console.WriteLine("Enter product money: ");
            if (!double.TryParse(Console.ReadLine(), out double money))
            {
                Console.WriteLine("Error");
                return;
            }

            //ProductModels newProduct = new ProductModels(name, color, type, quantity, money);
            _products.Add(new ProductModels(name, color, type, quantity, money));
        }

        public void Edit()
        {
            List();
            Console.WriteLine("Choose product number to edit: ");
            if (int.TryParse(Console.ReadLine(), out int num))
            {
                if (num > 0 && num <= _products.Count)
                {
                    Update();
                    ProductModels productToEdit = _products[num - 1];
                    Console.WriteLine("Change name into ... ");
                    productToEdit.Name = Console.ReadLine();
                    productToEdit.Name = replace(productToEdit.Name);
                    Console.WriteLine("Change color into ... ");
                    productToEdit.Color = Console.ReadLine();
                    productToEdit.Color = replace(productToEdit.Color);
                    Console.WriteLine("Change type into ... ");
                    productToEdit.Type = Console.ReadLine();
                    productToEdit.Type = replace(productToEdit.Type);
                    Console.WriteLine("Change quantity into ... ");
                    if (!int.TryParse(Console.ReadLine(), out int Quantity))
                    {
                        Console.WriteLine("Error");
                        return;
                    }
                    productToEdit.Quantity = Quantity;
                    Console.WriteLine("Change money into ... ");
                    if (!double.TryParse(Console.ReadLine(), out double Money))
                    {
                        Console.WriteLine("Error");
                        return;
                    }
                    productToEdit.Money = Money;
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        private string replace(string part)
        {
             return part.Replace(" ", "_");
        }

        public void Delete()
        {
            List();
            Console.WriteLine("Choose product number to delete: ");
            if (int.TryParse(Console.ReadLine(), out int num))
            {
                if (num > 0 && num <= _products.Count)
                {
                    _products.RemoveAt(num - 1);
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        public void Update()
        {
            if (filePath.Length > 0)
            {
                try
                {
                    StreamReader reader = new StreamReader(filePath, true);
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(' ');
                        if (parts.Length == 5)
                        {
                            string name = parts[0];
                            string color = parts[1];
                            string type = parts[2];
                            if (int.TryParse(parts[3], out int quantity) && double.TryParse(parts[4], out double money))
                            {
                                _products.Add(new ProductModels(name, color, type, quantity, money));
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occurred: " + e.Message);
                }
            }
        }

        public void Save()
        {

            Console.WriteLine("Do you want to save(Y/N)");
            char save = Console.ReadKey().KeyChar;
            if (save == 'Y' || save == 'y')
            {
                File.WriteAllText(filePath, String.Empty);
                string text = "";
                for (int words = 0; words < _products.Count; words++)
                {
                    text += $"{_products[words].Name} {_products[words].Color} {_products[words].Type} {_products[words].Quantity} {_products[words].Money}\n";
                }
                File.WriteAllText(filePath, text);
            }
        }

        public void List()
        {
            Console.WriteLine("Products:");
            for (int i = 0; i < _products.Count; i++)
            {
                Console.WriteLine((i + 1) + ". Name: " + _products[i].Name);
                Console.WriteLine("   Color: " + _products[i].Color);
                Console.WriteLine("   Type: " + _products[i].Type);
                Console.WriteLine("   Quantity: " + _products[i].Quantity);
                Console.WriteLine("   Money: " + _products[i].Money + "$");
            }
            Console.WriteLine();
        }
    }
}

