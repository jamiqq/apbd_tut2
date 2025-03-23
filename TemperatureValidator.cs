using APBD_Task2.Enums;

namespace APBD_Task2;

public static class TemperatureValidator
{
    public static bool IsValid(ProductType productType, double temperature)
    {
        var allowedTemperature = GetTemperature(productType);
        return temperature <= allowedTemperature;
    }

    public static double GetTemperature(ProductType productType)
    {
        var temperature = productType switch
        {
            ProductType.Bananas => 13.3,
            ProductType.Chocolate => 18,
            ProductType.Meat => 2,
            ProductType.Fish => -15,
            ProductType.IceCream => -18,
            ProductType.FrozenPizza => -30,
            ProductType.Cheese => 7.2,
            ProductType.Sausages => 5,
            ProductType.Butter => -20.5,
            ProductType.Eggs => 19,
            _ => throw new ArgumentException("Unknown productType")
        };
        return temperature;
    }    
}