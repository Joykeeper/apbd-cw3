namespace Cwiczenie3;

public class FreezingKontener: Kontener
{
    public string ProductType { get; }
    public double Temperature { get; }

    public static Dictionary<string, float> ProdsTemp = new()
    {
        {"Bananas", 13.3f},
        {"Chocolate", 18f},
        {"Fish", 2f},
        {"Meat", -15f},
        {"Ice cream", -18},
        {"Frozen pizza", -30},
        {"Cheese", 7.2f},
        {"Sausages", 5f},
        {"Butter", 20.5f},
        {"Eggs", 19f}
    };

    public FreezingKontener(double maxLoad, string productType, double temperature) : base("C", maxLoad, 250, 200, 300)
    {
        
        if (temperature < ProdsTemp[productType])
        {
            throw new WrongTemperatureException($"Temperature {temperature} C is too low for {productType}, requires {ProdsTemp[productType]} C or higher.");
        }
        this.ProductType = productType;
        this.Temperature = temperature;
    }
}