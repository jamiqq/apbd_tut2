using APBD_Task2.Enums;

namespace APBD_Task2.Containers;

public class RefrigeratedContainer : Container
{
    protected RefrigeratedContainer(
        double height, double depth, double tareWeight, double maxPayload, double maintainedTemperature, ProductType productType)
        : base(
            height, depth, tareWeight, maxPayload, 'C')
    {
        if (TemperatureValidator.isValid(productType, maintainedTemperature))
        {
            ProductType = productType;
            MaintainedTemperature = maintainedTemperature;
        }
        else
        {
            throw new ArgumentException("Maintained temperature is invalid");
        }
    }
    
    
    public double MaintainedTemperature { get; }
    public ProductType ProductType { get; }
}