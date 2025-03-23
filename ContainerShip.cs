using APBD_Task2.Containers;

namespace APBD_Task2;

public class ContainerShip
{
    public ContainerShip(string name, double maxSpeed, int maxContainerCount, double maxWeightCapacity)
    {
        Name = name;
        MaxSpeed = maxSpeed > 0 ? maxSpeed : throw new ArgumentException("MaxSpeed must be greater than zero");
        MaxContainerCount = maxContainerCount > 0 ? maxContainerCount : throw new ArgumentException("MaxContainerCount must be greater than zero");
        MaxWeightCapacity = maxWeightCapacity > 0 ? maxWeightCapacity : throw new ArgumentException("MaxWeightCapacity must be greater than zero");
        Containers = new List<Container>(); 
    }

    public string Name { get; set; }
    public double MaxSpeed { get; set; }
    public int MaxContainerCount { get; set; }
    public double MaxWeightCapacity { get; set; }
    public ICollection<Container> Containers { get; set; }

    public bool LoadContainers(Container container)
    {
        if (Containers.Count >= MaxContainerCount ||
            TotalWeight() + container.TareWeight + container.CargoMass > MaxWeightCapacity * 1000)
        {
            throw new InvalidOperationException("Container is full");
        }
        Containers.Add(container);
        return true;
    }

    public bool UnloadContainers(string containerNumber)
    {
        var container = Containers.FirstOrDefault(c => c.SerialNumber == containerNumber);
        if (container != null)
        {
            Containers.Remove(container);
            return true;
        }

        return false;
    }

    public void TransferContainer(ContainerShip targetShip, string containerNumber)
    {
        var container = Containers.FirstOrDefault(c => c.SerialNumber == containerNumber);
        if (container != null && targetShip.LoadContainers(container))
        {  
            Containers.Remove(container);
        }
    }
    public double TotalWeight()
    {
        double totalWeight = 0;
        foreach (var cont in Containers)
        {
            totalWeight += cont.TareWeight + cont.CargoMass;
        }
        return totalWeight;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Ship Name: {Name}, Speed: {MaxSpeed} knots, Max Containers: {MaxContainerCount}, Max Weight : {MaxWeightCapacity} tons");
        Console.WriteLine("Loaded Containers:");
        foreach (var container in Containers)
        {
            Console.WriteLine($" - {container.SerialNumber}: {container.TareWeight + container.CargoMass} kg");
        }
    } 
}