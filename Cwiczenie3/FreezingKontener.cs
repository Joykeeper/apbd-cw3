namespace Cwiczenie3;

public class FreezingKontener: Kontener
{
    static int FreezingKontenerCount = 0;

    private string typeOfProduct;
    private float temperature;

    public FreezingKontener(float weightOfBaggage, float height, float depth, float maxWeight, string typeOfProduct,
        float temperature) :
        base(weightOfBaggage, height, depth, FreezingKontenerCount++, "C", maxWeight)
    {
        this.typeOfProduct = typeOfProduct;
        this.temperature = temperature;
    }

    public override void extractBaggage()
    {
        
    }

    public override void loadBaggage(string baggage)
    {
        
    }
}