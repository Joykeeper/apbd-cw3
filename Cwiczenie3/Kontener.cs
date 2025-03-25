namespace Cwiczenie3;

public abstract class Kontener
{
    public double CurrentLoad {get; set;}
    private float height;
    public double WeightOfSelf;
    private float depth;

    public string SerialNumber { get; }

    public double MaxLoad { get; }
    
    private static int counter = 1;

    public Kontener(string type, double maxLoad, float height, float depth, double weightOfSelf)
    {
        this.CurrentLoad = 0;
        this.height = height;
        this.depth = depth;
        this.SerialNumber = $"KON-{type}-{counter++}";
        this.MaxLoad = maxLoad;
        this.WeightOfSelf = weightOfSelf;
    }

    public virtual void Unload()
    {
        CurrentLoad = 0;
        Console.WriteLine("Unloaded container " + SerialNumber);

    }
    public virtual void Load(double mass)
    {
        Console.WriteLine("Loading container " + SerialNumber);
        
        if (CurrentLoad + mass > MaxLoad)
            throw new OverfillException($"Container {SerialNumber} overfilled!");
        CurrentLoad += mass;
    }
    
    public override string ToString()
    {
        return $"Serial: {SerialNumber}, Load: {CurrentLoad}/{MaxLoad}";
    }
    
}