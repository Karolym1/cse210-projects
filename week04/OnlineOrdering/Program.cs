using System;

class Program
{
    static void Main(string[] args)
    {
        // -------- ORDER #1 (USA) --------
        Address address1 = new Address("123 Main St", "Bismarck", "ND", "USA");
        Customer customer1 = new Customer("Karolina Lym", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Photo Editing - 100 images", "P100", 120.00, 1));
        order1.AddProduct(new Product("Retouching - 10 images", "R010", 15.00, 10));

        // -------- ORDER #2 (International) --------
        Address address2 = new Address("55 Queen St", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Maria Lopez", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Social Media Content Pack", "S030", 60.00, 2));
        order2.AddProduct(new Product("Backdrop Extension", "B005", 25.00, 4));

        // -------- DISPLAY ORDER #1 --------
        Console.WriteLine("ORDER 1");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());

        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());

        Console.WriteLine($"Total Cost: ${order1.GetTotalCost()}");
        Console.WriteLine("--------------------------------");

        // -------- DISPLAY ORDER #2 --------
        Console.WriteLine("ORDER 2");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());

        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());

        Console.WriteLine($"Total Cost: ${order2.GetTotalCost()}");
        Console.WriteLine("--------------------------------");
    }
}
