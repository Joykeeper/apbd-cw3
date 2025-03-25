using System.Collections;

namespace Cwiczenie3;

public class ContainerHandler
{
    List<Kontener> Konteners;
    private int MaxSpeed;
    private int MaxKonteners;
    private int MaxWeight;

    // public static void Main()
    // {
    //     Console.WriteLine("Starting ContainerHandler Tests...");
    //
    //     ContainerHandler ship1 = new ContainerHandler(30, 5, 10000);
    //     ContainerHandler ship2 = new ContainerHandler(25, 5, 800);
    //
    //     // Creating Containers
    //     var liquidContainer = ship1.CreateLiquidKontener(500, true);
    //     var gasContainer = ship1.CreateGasKontener(700, 10);
    //     
    //     FreezingKontener freezingContainer = null;
    //     try
    //     {
    //         freezingContainer = ship1.CreateFreezingKontener(600, "Fish", -18f);
    //     }
    //     catch (WrongTemperatureException e)
    //     {
    //         Console.WriteLine($"Temperature error: {e.Message}");
    //     }
    //     freezingContainer = ship1.CreateFreezingKontener(600, "Fish", 2);
    //
    //
    //     // Testing Loading Containers
    //     try
    //     {
    //         ship1.LoadKontener(liquidContainer, 200);
    //         ship1.LoadKontener(gasContainer, 300);
    //         if (freezingContainer != null)
    //             ship1.LoadKontener(freezingContainer, 400);
    //     }
    //     catch (Exception e)
    //     {
    //         Console.WriteLine(e.Message);
    //     }
    //
    //     // Testing Adding Containers to Ship
    //     try
    //     {
    //         ship1.PutKontener(liquidContainer);
    //         ship1.PutKontener(gasContainer);
    //         if (freezingContainer != null)
    //             ship1.PutKontener(freezingContainer);
    //     }
    //     catch (Exception e)
    //     {
    //         Console.WriteLine(e.Message);
    //     }
    //
    //     // Testing Unloading
    //     ship1.UnloadKontener(liquidContainer);
    //     ship1.UnloadKontener(gasContainer);
    //     if (freezingContainer != null)
    //         ship1.UnloadKontener(freezingContainer);
    //     
    //     // Testing Gas Container
    //     Console.WriteLine("Before Unloading Gas Container: " + gasContainer);
    //     gasContainer.Unload();
    //     Console.WriteLine("After Unloading Gas Container: " + gasContainer);
    //
    //     // Testing Substituting Containers
    //     try
    //     {
    //         var newFreezingContainer = ship1.CreateFreezingKontener(650, "Meat", -15);
    //         ship1.SubstituteKontener(freezingContainer?.SerialNumber ?? "", newFreezingContainer);
    //     }
    //     catch (WrongTemperatureException e)
    //     {
    //         Console.WriteLine($"Temperature error: {e.Message}");
    //     }
    //
    //     // Testing Hazard Notification
    //     try
    //     {
    //         ship2.LoadKontener("KON-L-1", 200);
    //     }
    //     catch (Exception e)
    //     {
    //         Console.WriteLine(e.Message);
    //     }
    //
    //     // Testing Transport Between Ships
    //     try
    //     {
    //         ship1.TransportKontenerToShip(ship2, liquidContainer.SerialNumber);
    //         ship1.TransportKontenerToShip(ship2, gasContainer.SerialNumber);
    //     }
    //     catch (Exception e)
    //     {
    //         Console.WriteLine(e.Message);
    //     }
    //     
    //     // Testing Ship Overload Exception
    //     try
    //     {
    //         ship2.LoadKontener(freezingContainer, 500);
    //     }
    //     catch (ShipOverloadException e)
    //     {
    //         Console.WriteLine("Ship Overload Exception Caught: " + e.Message);
    //     }
    //     
    //     if (freezingContainer != null)
    //         ship1.TransportKontenerToShip(ship2, freezingContainer.SerialNumber);
    //
    //     // Printing Ship Status
    //     Console.WriteLine("Ship 1 status:");
    //     Console.WriteLine(ship1);
    //     ship1.PrintContainers();
    //     
    //     Console.WriteLine("Ship 2 status:");
    //     Console.WriteLine(ship2);
    //     ship2.PrintContainers();
    // }
    
    
    public static void Main(string[] args)
        {
            ContainerHandler ship = new ContainerHandler(100, 5, 1000);

            // Creating different types of containers
            Kontener liquidContainer = ship.CreateKontener(TypeOfKontener.LIQUID);
            Kontener gasContainer = ship.CreateKontener(TypeOfKontener.GAS);
            Kontener freezingContainer = ship.CreateKontener(TypeOfKontener.FREEZING);
            
            Console.WriteLine(ship);

            // Test putting containers on the ship
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
            
            Console.WriteLine("\nShip state after adding containers:");
            Console.WriteLine(ship);

            // Test loading mass into containers
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
            
            Console.WriteLine("\nShip state after loading containers:");
            Console.WriteLine(ship);

            // Test unloading a container
            try
            {
                ship.UnloadKontener(liquidContainer);
                Console.WriteLine($"Unloaded container: {liquidContainer.SerialNumber}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while unloading container: {ex.Message}");
            }
            
            Console.WriteLine("\nShip state after unloading a container:");
            Console.WriteLine(ship);

            // Test transporting container to another ship
            ContainerHandler anotherShip = new ContainerHandler(100, 5, 1000);
            try
            {
                ship.TransportKontenerToShip(liquidContainer, anotherShip);
                Console.WriteLine($"Transported container {liquidContainer.SerialNumber} to another ship.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while transporting container: {ex.Message}");
            }
            
            Console.WriteLine("\nShip states after transporting container:");
            Console.WriteLine(ship);
            Console.WriteLine(anotherShip);

            // Test exception handling: overload the ship
            try
            {
                ship.LoadKontener(gasContainer, 2000); // Try to overload the ship
            }
            catch (ShipOverloadException ex)
            {
                Console.WriteLine($"Ship overload exception: {ex.Message}");
            }
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