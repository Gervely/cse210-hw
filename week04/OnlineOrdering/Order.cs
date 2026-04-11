using System.Collections.Generic;

public class Order
{
    private List<Product> Products;
    private Customer Customer;

    public Order(Customer customer)
    {
        Customer = customer;
        Products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    public double GetTotalPrice()
    {
        double total = 0;
        foreach (Product p in Products)
        {
            total += p.GetTotalCost();
        }

        // Shipping cost
        total += Customer.LivesInUSA() ? 5 : 35;
        return total;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (Product p in Products)
        {
            label += $" - {p.GetPackingInfo()}\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{Customer.GetName()}\n{Customer.GetAddressString()}";
    }
}
