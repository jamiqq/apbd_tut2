using APBD_Task2.Containers;
using APBD_Task2.Enums;

namespace APBD_Task2;

public class Program
{
    static void Main()
    {
        ContainerShip ship1 = new ContainerShip("Atlantis", 20, 5, 2000);
        Console.WriteLine("ship1 was created");
        ship1.PrintInfo();
        
        ContainerShip ship2 = new ContainerShip("Paccifics", 25, 7, 1500);
        Console.WriteLine("ship2 was created");
        ship2.PrintInfo();

        Container container1 = new RefrigeratedContainer(5, 2, 500, 1200, -10, ProductType.Bananas);
        Console.WriteLine("\ncontainer1 was created");
        Container container2 = new GasContainer(5, 2, 500, 1200, 1010);
        Console.WriteLine("container2 was created");
        Container container3 = new LiquidContainer(5, 2, 500, 1800, true);
        Console.WriteLine("container3 was created\n");
        
        container1.LoadCargo(500);
        container2.LoadCargo(600);
        container3.LoadCargo(500);
        
        ship1.LoadContainers(container1);
        ship2.LoadContainers(container2);
        ship2.LoadContainers(container3);
        
        Console.WriteLine("Ship1 after loading:");
        ship1.PrintInfo();
        Console.WriteLine("Ship2 after loading:");
        ship2.PrintInfo();
        
        ship2.TransferContainer(ship1, container3.SerialNumber);
        Console.WriteLine("\nContainer 3 was transferred to ship1");
        ship1.PrintInfo();
        ship1.UnloadContainers(container3.SerialNumber);
        Console.WriteLine("\nContainer 3 was unloaded from ship1");
        ship1.PrintInfo();
        container3.EmptyCargo();
        
        Console.WriteLine("\nContainer 3 was emptied");
        container3.PrintInfo();
    }
}