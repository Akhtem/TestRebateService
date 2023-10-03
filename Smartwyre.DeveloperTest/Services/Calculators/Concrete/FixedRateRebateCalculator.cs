using Smartwyre.DeveloperTest.Services.Calculators.Interfaces;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services.Calculators.Concrete
{
    public class FixedRateRebateCalculator : IRebateCalculator
    {
        public CalculateRebateResult CalculateRebate(Rebate rebate, Product product, CalculateRebateRequest request)
        {
            var result = new CalculateRebateResult();

            if (rebate == null || product == null || !product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedRateRebate)
                || rebate.Percentage == 0 || product.Price == 0 || request.Volume == 0)
            {
                result.Success = false;
            }
            else
            {
                result.Success = true;
                result.RebateAmount = product.Price * rebate.Percentage * request.Volume;
            }

            return result;
        }
    }
}
