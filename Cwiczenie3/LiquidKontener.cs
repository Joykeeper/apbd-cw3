using System.Transactions;

namespace Cwiczenie3;

public class LiquidKontener: Kontener, IHazardNotifier
{
    static int LiquidKontenerCount = 0;
    
    public LiquidKontener(float weightOfBaggage, float height, float depth, float maxWeight): 
        base(weightOfBaggage, height, depth, LiquidKontenerCount++, "L", maxWeight){}

    public override void extractBaggage()
    {
        
    }

    public override void loadBaggage(string baggage)
    {
        
    }

    public void sendNotification()
    {
        
    }
}