namespace Cwiczenie3;

public abstract class Kontener
{
    private float weightOfBaggage;
    private float height;
    private float weightOfSelf;
    private float depth;
    
    private string serialNumber;

    private float maxWeight;

    public Kontener(float weightOfBaggage, float height, float depth, int serialNumber, string typeOfContainer, float maxWeight)
    {
        this.weightOfBaggage = weightOfBaggage;
        this.height = height;
        this.depth = depth;
        this.serialNumber = "KON-" + serialNumber + "-" + typeOfContainer;
        this.maxWeight = maxWeight;
    }

    public abstract void extractBaggage();
    public abstract void loadBaggage(string baggage);
    
}