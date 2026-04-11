public class Product
{
    private string Name;
    private string ProductId;
    private double PricePerUnit;
    private int Quantity;

    public Product(string name, string productId, double pricePerUnit, int quantity)
    {
        Name = name;
        ProductId = productId;
        PricePerUnit = pricePerUnit;
        Quantity = quantity;
    }

    public double GetTotalCost()
    {
        return PricePerUnit * Quantity;
    }

    public string GetPackingInfo()
    {
        return $"{Name} (ID: {ProductId})";
    }
}
