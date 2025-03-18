using APBD_Task2.Enums;

namespace APBD_Task2;

public class TemperatureValidator
{
    public static bool isValid(ProductType productType, double temperature)
    {
        var allowedTemperature = GetTemperature(productType);
        return temperature >= allowedTemperature;
    }

    public static double GetTemperature(ProductType productType)
    {
        var temperature = productType switch
        {
            ProductType.Bananas => 13,
            ProductType.Chocolate => 10,
            ProductType.Meat => -15,
            ProductType.Fish => -12,
            ProductType.IceCream => -5,
            ProductType.FrozenPizza => -10,
            ProductType.Cheese => 4,
            ProductType.Sausages => 12,
            ProductType.Butter => -3,
            ProductType.Eggs => 90,
            _ => throw new ArgumentException("Uknown productType")
        };
        return temperature;
    }    
}