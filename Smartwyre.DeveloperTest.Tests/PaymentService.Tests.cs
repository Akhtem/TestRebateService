using Smartwyre.DeveloperTest.Services.Calculators.Concrete;
using Smartwyre.DeveloperTest.Types;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests;

public class PaymentServiceTests
{
    [Fact]
    public void AmountPerUomRebateCalculator_ValidData_CalculatesRebateAmount()
    {
        var calculator = new AmountPerUomRebateCalculator();
        var rebate = new Rebate { Amount = 5 };
        var product = new Product { SupportedIncentives = SupportedIncentiveType.AmountPerUom };
        var request = new CalculateRebateRequest { Volume = 10 };

        var result = calculator.CalculateRebate(rebate, product, request);

        Assert.True(result.Success);
        Assert.Equal(50, result.RebateAmount);
    }

    [Fact]
    public void AmountPerUomRebateCalculator_InvalidData_ReturnsFailure()
    {
        var calculator = new AmountPerUomRebateCalculator();
        var rebate = new Rebate { Amount = 0 };
        var product = new Product { SupportedIncentives = SupportedIncentiveType.FixedCashAmount };
        var request = new CalculateRebateRequest { Volume = 10 };

        var result = calculator.CalculateRebate(rebate, product, request);

        Assert.False(result.Success);
        Assert.Equal(0, result.RebateAmount);
    }

    [Fact]
    public void FixedCashAmountRebateCalculator_ValidData_CalculatesRebateAmount()
    {
        var calculator = new FixedCashAmountRebateCalculator();
        var rebate = new Rebate { Amount = 5 };
        var product = new Product { SupportedIncentives = SupportedIncentiveType.FixedCashAmount };
        var request = new CalculateRebateRequest();

        var result = calculator.CalculateRebate(rebate, product, request);

        Assert.True(result.Success);
        Assert.Equal(5, result.RebateAmount);
    }

    [Fact]
    public void FixedCashAmountRebateCalculator_InvalidData_ReturnsFailure()
    {
        var calculator = new FixedCashAmountRebateCalculator();
        var rebate = new Rebate { Amount = 0 };
        var product = new Product { SupportedIncentives = SupportedIncentiveType.AmountPerUom };
        var request = new CalculateRebateRequest();

        var result = calculator.CalculateRebate(rebate, product, request);

        Assert.False(result.Success);
        Assert.Equal(0, result.RebateAmount);
    }

    [Fact]
    public void FixedRateRebateCalculator_ValidData_CalculatesRebateAmount()
    {
        var calculator = new FixedRateRebateCalculator();
        var rebate = new Rebate { Percentage = 0.1m };
        var product = new Product
        {
            SupportedIncentives = SupportedIncentiveType.FixedRateRebate,
            Price = 100
        };
        var request = new CalculateRebateRequest { Volume = 5 };

        var result = calculator.CalculateRebate(rebate, product, request);

        Assert.True(result.Success);
        Assert.Equal(50, result.RebateAmount);
    }

    [Fact]
    public void FixedRateRebateCalculator_InvalidData_ReturnsFailure()
    {
        var calculator = new FixedRateRebateCalculator();
        var rebate = new Rebate { Percentage = 0 };
        var product = new Product { SupportedIncentives = SupportedIncentiveType.FixedCashAmount };
        var request = new CalculateRebateRequest { Volume = 5 };

        var result = calculator.CalculateRebate(rebate, product, request);

        Assert.False(result.Success);
        Assert.Equal(0, result.RebateAmount);
    }
}
