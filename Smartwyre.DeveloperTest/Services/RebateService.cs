using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Services.Factories;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services;

public class RebateService : IRebateService
{
    private readonly IRebateCalculatorFactory _calculatorFactory;

    public RebateService(IRebateCalculatorFactory calculatorFactory)
    {
        _calculatorFactory = calculatorFactory;
    }

    public CalculateRebateResult Calculate(CalculateRebateRequest request)
    {
        var rebateDataStore = new RebateDataStore();
        var productDataStore = new ProductDataStore();

        Rebate rebate = rebateDataStore.GetRebate(request.RebateIdentifier);
        Product product = productDataStore.GetProduct(request.ProductIdentifier);

        var result = new CalculateRebateResult();

        if (rebate != null && product != null)
        {
            var calculator = _calculatorFactory.GetRebateCalculator(rebate.Incentive);
            result = calculator.CalculateRebate(rebate, product, request);
        }

        if (result.Success)
        {
            var storeRebateDataStore = new RebateDataStore();
            storeRebateDataStore.StoreCalculationResult(rebate, result.RebateAmount);
        }

        return result;
    }
}
