using APBD_Task2.Exceptions;
using APBD_Task2.Interfaces;

namespace APBD_Task2.Containers;

public abstract class HazardousContainer : Container, IHazardNotifier
{
    protected HazardousContainer(
        double height, double depth, double tareWeight, double maxPayload, char containerType)
        : base(
            height, depth, tareWeight, maxPayload, containerType)
    {
        
    }

    public override void LoadCargo(double mass)
    {
        if (mass <= 0) throw new ArgumentException("Invalid mass");

        if (!CanLoadCargo(mass))
        {   
            NotifyHazard("Loading cargo will cause overfill");
            throw new OverfillException("Cargo mass exceeds max payload");
        } 
        
    }
    public void NotifyHazard(string message)
    {
        Console.WriteLine($"Hazardous situation appeared for container {SerialNumber}" + 
                          $"\nMessage: {message}");
    }
}