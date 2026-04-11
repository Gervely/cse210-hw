using System;

class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        Address addr1 = new Address("123 Main St", "New York", "NY", "USA");
        Address addr2 = new Address("45 Rue de Rivoli", "Paris", "Île-de-France", "France");

        // Create customers
        Customer cust1 = new Customer("Alice Johnson", addr1);
        Customer cust2 = new Customer("Pierre Dupont", addr2);

        // Create orders
        Order order1 = new Order(cust1);
        order1.AddProduct(new Product("Laptop", "P001", 1200, 1));
        order1.AddProduct(new Product("Mouse", "P002", 25, 2));

        Order order2 = new Order(cust2);
        order2.AddProduct(new Product("Camera", "P010", 500, 1));
        order2.AddProduct(new Product("Tripod", "P011", 75, 1));
        order2.AddProduct(new Product("Memory Card", "P012", 20, 3));

        // Display results
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice()}\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice()}");
    }
}
