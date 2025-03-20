namespace Cwiczenie3;

public class GasKontener: Kontener
{
    static int GasKontenerCount = 0;
    
    private float pressure;

    public GasKontener(float weightOfBaggage, float height, float depth, float maxWeight, float pressure) :
        base(weightOfBaggage, height, depth, GasKontenerCount++, "G", maxWeight)
    {
        this.pressure = pressure;
    }

    public override void extractBaggage()
    {
        
    }

    public override void loadBaggage(string baggage)
    {

    }
}