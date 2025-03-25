using System.Security.AccessControl;
using System.Transactions;

namespace Cwiczenie3;

public class LiquidKontener: Kontener, IHazardNotifier
{
    public bool IsHazardous { get; }
    
    public LiquidKontener(double maxLoad, bool isHazardous) : base("L", maxLoad, 100, 70, 300)
    {
        IsHazardous = isHazardous;
    }

    public override void Load(double mass)
    {
        double limit = IsHazardous ? MaxLoad * 0.5 : MaxLoad * 0.9;
        if (CurrentLoad + mass > limit)
            NotifyHazard($"Hazardous overfill attempt!");
        base.Load(mass);
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"HAZARD in {SerialNumber}: " + message);
    }
}