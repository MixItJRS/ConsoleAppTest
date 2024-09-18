using System.Reflection;
using System.Resources;
using System;
using System.Collections;
using ConsoleAppTest.Models;
using ConsoleAppTest.Models.SQL;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        string fileImportPath = "Import.xml";
        var context = new ShopDbContext();
        using (TextReader reader = new StreamReader(fileImportPath))
        {
            try
            {
                ImportOrdersFromXml(context, reader);
                Console.WriteLine("Импорт завершен");
            }
            catch (Exception e) 
            {
                Console.WriteLine($"Ошибка импорта: {e.Message}");
            }
        }

        Console.ReadKey();

    }

    static public void ImportOrdersFromXml(ShopDbContext context, TextReader xmlFilePath)
    {
        XDocument xdoc = XDocument.Load(xmlFilePath);

        var orders = xdoc.Descendants("order");

        foreach (var orderElement in orders)
        {

            int orderNo = int.Parse(orderElement.Element("no").Value);
            DateOnly regDate = DateOnly.Parse(orderElement.Element("reg_date").Value);
            decimal sum = decimal.Parse(orderElement.Element("sum").Value);

            var userElement = orderElement.Element("user");
            string fio = userElement.Element("fio").Value;
            string email = userElement.Element("email").Value;

            var user = context.Users.FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                user = new User
                {
                    FIO = fio,
                    Email = email
                };
                context.Users.Add(user);
                context.SaveChanges();
            }

            var order = new Order
            {
                No = orderNo,
                RegDate = regDate,
                Sum = sum,
                UserId = user.Id
            };
            context.Orders.Add(order);
            context.SaveChanges();

            var products = orderElement.Descendants("product");

            foreach (var productElement in products)
            {
                int quantity = int.Parse(productElement.Element("quantity").Value);
                string productName = productElement.Element("name").Value;
                decimal price = decimal.Parse(productElement.Element("price").Value);

                var product = context.Products.FirstOrDefault(p => p.Name == productName);
                if (product == null)
                {
                    product = new Product
                    {
                        Name = productName,
                        Price = price
                    };
                    context.Products.Add(product);
                    context.SaveChanges();
                }

                var orderPosition = new OrderPosition
                {
                    OrderId = order.Id,
                    ProductId = product.Id,
                    Quantity = quantity
                };
                context.OrderPositions.Add(orderPosition);
                context.SaveChanges();
            }
        }
    }
}