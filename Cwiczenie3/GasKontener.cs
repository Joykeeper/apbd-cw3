namespace Cwiczenie3;

public class GasKontener: Kontener, IHazardNotifier
{
    
    public double Pressure { get; }

    public GasKontener(double maxLoad, double pressure) : base("G", maxLoad, 200, 150, 500)
    {
        Pressure = pressure;
    }

    public override void Unload()
    {
        Console.WriteLine("Unloading gas container " + SerialNumber);
        CurrentLoad *= 0.05;
    }
    
    public void NotifyHazard(string message)
    {
        Console.WriteLine($"HAZARD in {SerialNumber}: " + message);
    }
}