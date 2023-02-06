using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ConsoleAppWithEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                context.Database.EnsureCreated();

                while (true)
                {
                    Console.WriteLine("1. Add a new product");
                    Console.WriteLine("2. Update an existing product");
                    Console.WriteLine("3. Delete a product");
                    Console.WriteLine("4. View all products");
                    Console.WriteLine("5. Exit");

                    Console.WriteLine("Enter your choice:");
                    var choice = Console.ReadLine();
                    Console.Clear();

                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine("Enter a new product name:");
                            var productName = Console.ReadLine();
                            var inputProduct = new Product { Name = productName };
                            context.Products.Add(inputProduct);
                            context.SaveChanges();
                            Console.WriteLine("Added new product to database.");
                            break;
                        case "2":
                            Console.WriteLine("Enter the product id to update:");
                            var productId = int.Parse(Console.ReadLine());
                            var productToUpdate = context.Products.Find(productId);
                            if (productToUpdate == null)
                            {
                                Console.WriteLine("Product not found.");
                                break;
                            }
                            Console.WriteLine("Enter the updated product name:");
                            productToUpdate.Name = Console.ReadLine();
                            context.SaveChanges();
                            Console.WriteLine("Product updated.");
                            break;
                        case "3":
                            Console.WriteLine("Enter the product id to delete:");
                            productId = int.Parse(Console.ReadLine());
                            var productToDelete = context.Products.Find(productId);
                            if (productToDelete == null)
                            {
                                Console.WriteLine("Product not found.");
                                break;
                            }
                            context.Products.Remove(productToDelete);
                            context.SaveChanges();
                            Console.WriteLine("Product deleted.");
                            break;
                        case "4":
                            Console.WriteLine("All products in database:");
                            var products = context.Products.ToList();
                            foreach (var product in products)
                            {
                                Console.WriteLine($"Id: {product.Id} - Name: {product.Name}");
                            }
                            break;
                        case "5":
                            return;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
            }
        }
    }
    

    
}
