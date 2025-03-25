using System.Collections;

namespace Cwiczenie3;

public class ContainerHandler
{
    List<Kontener> Konteners;
    private int MaxSpeed;
    private int MaxKonteners;
    private int MaxWeight;
    
    public static void Main(string[] args)
        {
            ContainerHandler ship = new ContainerHandler(100, 5, 1000);

            // 1. Test CreateKontener (Liquid, Gas, Freezing)
            Kontener liquidContainer = ship.CreateKontener(TypeOfKontener.LIQUID);
            Kontener gasContainer = ship.CreateKontener(TypeOfKontener.GAS);
            Kontener freezingContainer = ship.CreateKontener(TypeOfKontener.FREEZING);

            Console.WriteLine("Created containers:");
            Console.WriteLine(liquidContainer);
            Console.WriteLine(gasContainer);
            Console.WriteLine(freezingContainer);

            // 2. Test PutKontener (Add containers to ship)
            Console.WriteLine("\nTest putting containers on the ship:");
            try
            {
                ship.PutKontener(liquidContainer);
                ship.PutKontener(gasContainer);
                ship.PutKontener(freezingContainer);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while putting containers: {ex.Message}");
            }
            Console.WriteLine(ship);

            // 3. Test LoadKontener (Load mass into containers)
            Console.WriteLine("\nTest loading mass into containers:");
            try
            {
                ship.LoadKontener(liquidContainer, 150);
                ship.LoadKontener(gasContainer, 200);
                ship.LoadKontener(freezingContainer, 100);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while loading containers: {ex.Message}");
            }
            Console.WriteLine(ship);

            // 4. Test RemoveKontener (By object)
            Console.WriteLine("\nTest removing container by object:");
            try
            {
                ship.RemoveKontener(liquidContainer);
                Console.WriteLine($"Removed container: {liquidContainer.SerialNumber}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while removing container: {ex.Message}");
            }
            Console.WriteLine(ship);

            // 5. Test RemoveKontener (By serial number)
            Console.WriteLine("\nTest removing container by serial number:");
            try
            {
                ship.RemoveKontener(gasContainer.SerialNumber);
                Console.WriteLine($"Removed container by serial number: {gasContainer.SerialNumber}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while removing container: {ex.Message}");
            }
            Console.WriteLine(ship);

            // 6. Test UnloadKontener (Unload a container)
            Console.WriteLine("\nTest unloading container:");
            try
            {
                ship.UnloadKontener(freezingContainer);
                Console.WriteLine($"Unloaded container: {freezingContainer.SerialNumber}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while unloading container: {ex.Message}");
            }
            Console.WriteLine(ship);

            // 7. Test TransportKontenerToShip (Transport container between ships)
            ContainerHandler anotherShip = new ContainerHandler(100, 5, 1000);
            Kontener k = ship.CreateKontener(TypeOfKontener.LIQUID);
            k.Load(200);
            ship.PutKontener(k);
            Console.WriteLine("\nTest transporting container to another ship:");
            try
            {
                ship.TransportKontenerToShip(k, anotherShip);
                Console.WriteLine($"Transported container {k.SerialNumber} to another ship.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while transporting container: {ex.Message}");
            }
            Console.WriteLine("\nShip states after transport:");
            Console.WriteLine(ship);
            Console.WriteLine(anotherShip);

            // 8. Test PutKontener (Exceeding ship capacity)
            Console.WriteLine("\nTest exceeding ship capacity when adding containers:");
            try
            {
                ContainerHandler overloadedShip = new ContainerHandler(100, 5, 100);
                overloadedShip.PutKontener(liquidContainer);
                overloadedShip.PutKontener(gasContainer);
                overloadedShip.PutKontener(freezingContainer);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while exceeding ship capacity: {ex.Message}");
            }

            // 9. Test ShipOverloadException (Overload the ship)
            Console.WriteLine("\nTest ship overload:");
            try
            {
                ship.LoadKontener(gasContainer, 2000);
            }
            catch (ShipOverloadException ex)
            {
                Console.WriteLine($"Ship overload exception: {ex.Message}");
            }

            // 10. Test loading over container's capacity (Liquid container overfill)
            Console.WriteLine("\nTest liquid container overfill:");
            try
            {
                ship.LoadKontener(liquidContainer, 300);
            }
            catch (OverfillException ex)
            {
                Console.WriteLine($"Overfill exception: {ex.Message}");
            }

            // 11. Test LiquidKontener hazard notification
            Console.WriteLine("\nTest LiquidKontener hazard notification:");
            LiquidKontener hazardousContainer = ship.CreateLiquidKontener(400, true);
            try
            {
                hazardousContainer.Load(250); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            // 12. Test WrongTemperatureException (Freezing container with incorrect temperature)
            Console.WriteLine("\nTest FreezingKontener temperature exception:");
            try
            {
                FreezingKontener wrongTempContainer = new FreezingKontener(300, "Bananas", 10f);
            }
            catch (WrongTemperatureException ex)
            {
                Console.WriteLine($"Wrong temperature exception: {ex.Message}");
            }

            // 13. Test UnloadKontener by serial number
            Console.WriteLine("\nTest unloading container by serial number:");
            try
            {
                ship.UnloadKontener(gasContainer.SerialNumber);
                Console.WriteLine($"Unloaded container with serial: {gasContainer.SerialNumber}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while unloading container by serial: {ex.Message}");
            }
            Console.WriteLine(ship);
        }
    public ContainerHandler(int maxSpeed, int maxKontenerCount, int maxWeight)
    {
        this.Konteners = new List<Kontener>();
        this.MaxSpeed = maxSpeed;
        this.MaxKonteners = maxKontenerCount;
        this.MaxWeight = maxWeight;
    }

    public Kontener CreateKontener(TypeOfKontener type)
    {
        Kontener kontener = null;
        switch (type)
        {
            case TypeOfKontener.LIQUID: kontener =  new LiquidKontener(200, true); 
                break;
            case TypeOfKontener.GAS: kontener = new GasKontener(300, 7); 
                break;
            case TypeOfKontener.FREEZING: kontener = new FreezingKontener(250, "Bananas", 14f);
                break;
        }

        return kontener;
    }

    public LiquidKontener CreateLiquidKontener(double maxload, bool isHazardous)
    {
        return new LiquidKontener(maxload, isHazardous);
    }

    public GasKontener CreateGasKontener(double maxload, double pressure)
    {
        return new GasKontener(maxload, pressure);
    }

    public FreezingKontener CreateFreezingKontener(double maxload, string productName, double temperature)
    {
        return new FreezingKontener(maxload, productName, temperature);
    }

    public void LoadKontener(Kontener kontener, double mass)
    {
        double remainingCapacity = MaxWeight - TotalWeight();
        if (mass > remainingCapacity)
        {
            throw new ShipOverloadException("Cannot load more mass: ship capacity exceeded");
        }
        kontener.Load(mass);
    }
    
    public void LoadKontener(string serialNumber, double mass)
    {
        double remainingCapacity = MaxWeight - TotalWeight();
        if (mass > remainingCapacity)
        {
            throw new ShipOverloadException("Cannot load more mass: ship capacity exceeded");
        }

        foreach (Kontener kontener in Konteners)
        {
            if (kontener.SerialNumber == serialNumber)
            {
                kontener.Load(mass);
                break;
            }
        }
    }

    public void PutKontener(Kontener kontener)
    {
        if (Konteners.Count >= MaxKonteners || 
            TotalWeight() + kontener.MaxLoad + kontener.WeightOfSelf > MaxWeight)
        {
            throw new ShipOverloadException("Cannot load container: ship capacity exceeded");
        }
        Konteners.Add(kontener);
    }

    public void PutKonteners(List<Kontener> newContainers)
    {
        foreach (var container in newContainers)
        {
            PutKontener(container);
        }
    }

    public void RemoveKontener(Kontener kontener)
    {
        this.Konteners.Remove(kontener);
    }
    public void RemoveKontener(string serialNumber)
    {
        Konteners.RemoveAll(c => c.SerialNumber == serialNumber);
    }

    public void UnloadKontener(Kontener kontener)
    {
        kontener.Unload();
    }
    public void UnloadKontener(string serialNumber)
    {
        foreach (var kontener in Konteners)
        {
            if (kontener.SerialNumber == serialNumber)
            {
                kontener.Unload();
                break;
            }
        }
    }
    
    public void SubstituteKontener(string serialNumber, Kontener newContainer)
    {
        RemoveKontener(serialNumber);
        PutKontener(newContainer);
    }

    public void TransportKontenerToShip(Kontener kontener, ContainerHandler ship)
    {
        ship.PutKontener(kontener);
        RemoveKontener(kontener);
    }
    
    public void TransportKontenerToShip(ContainerHandler targetShip, string serialNumber)
    {
        var container = Konteners.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container != null)
        {
            targetShip.PutKontener(container);
            RemoveKontener(serialNumber);
        }
    }

    public void PrintContainers()
    {
        foreach (var container in Konteners)
        {
            Console.WriteLine(container);
        }
    }
    private double TotalWeight() => Konteners.Sum(c => c.CurrentLoad + c.WeightOfSelf);
    
    public override string ToString()
    {
        return $"Ship : {Konteners.Count}/{MaxKonteners} containers, {TotalWeight()}/{MaxWeight} tons";
    }

}