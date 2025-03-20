using System.Collections;

namespace Cwiczenie3;

public class ContainerHandler
{
    List<Kontener> konteners;
    private int maxSpeed;
    private int maxKontenerCount;
    private int maxWeight;

    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Cwiczenie3!");
    }

    public ContainerHandler(int maxSpeed, int maxKontenerCount, int maxWeight)
    {
        this.konteners = new List<Kontener>();
        this.maxSpeed = maxSpeed;
        this.maxKontenerCount = maxKontenerCount;
        this.maxWeight = maxWeight;
    }

    public Kontener CreateKontener(TypeOfKontener type)
    {
        Kontener kontener = null;
        switch (type)
        {
            case TypeOfKontener.LIQUID: kontener =  new LiquidKontener(200, 100, 70, 1500); 
                break;
            case TypeOfKontener.GAS: kontener = new LiquidKontener(200, 100, 70, 1500); 
                break;
            case TypeOfKontener.FREEZING: kontener = new LiquidKontener(200, 100, 70, 1500);
                break;
        }

        return kontener;
    }

    public void LoadKontener(Kontener kontener, string baggage)
    {
        kontener.loadBaggage(baggage);
    }

    public void PutKontener(Kontener kontener)
    {
        this.konteners.Add(kontener);
    }

    public void PutKonteners(List<Kontener> konteners)
    {
        this.konteners.AddRange(konteners);
    }

    public void RemoveKontener(Kontener kontener)
    {
        this.konteners.Remove(kontener);
    }

    public void UnloadKontener(Kontener kontener)
    {
        kontener.extractBaggage();
    }


    public void SubstituteKontener(int kontenerId, Kontener kontener)
    {
        this.konteners[kontenerId] = kontener;
    }

    public void TransportKontenerToShip(Kontener kontener, ContainerHandler ship)
    {
        ship.PutKontener(kontener);
        this.RemoveKontener(kontener);
    }

    public void KontenerInfo(Kontener kontener)
    {
        Console.WriteLine(kontener.ToString());
    }

    public void shipInfo()
    {
        //ship info
        Console.WriteLine(this);

        foreach (var kontener in konteners)
        {
            KontenerInfo(kontener);
        }
    }

}