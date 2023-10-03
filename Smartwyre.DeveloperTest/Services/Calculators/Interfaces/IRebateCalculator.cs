using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services.Calculators.Interfaces
{
    public interface IRebateCalculator
    {
        CalculateRebateResult CalculateRebate(Rebate rebate, Product product, CalculateRebateRequest request);
    }
}
