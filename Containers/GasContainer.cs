namespace APBD_Task2.Containers;

public class GasContainer : HazardousContainer
{   
    protected GasContainer(
        double height, double depth, double tareWeight, double maxPayload, double pressure)
        : base(
            height, depth, tareWeight, maxPayload, 'G')
    {
        Pressure = pressure > 0 ? pressure : throw new AggregateException("Pressure must be greater than zero");
        
    }
    
    public double Pressure { get; }

    public override void EmptyCargo()
    {
        CargoMass = CargoMass / 100 * 5;
    }
}