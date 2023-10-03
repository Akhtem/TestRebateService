using Smartwyre.DeveloperTest.Services.Calculators.Interfaces;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services.Calculators.Concrete
{
    public class FixedCashAmountRebateCalculator : IRebateCalculator
    {
        public CalculateRebateResult CalculateRebate(Rebate rebate, Product product, CalculateRebateRequest request)
        {
            var result = new CalculateRebateResult();

            if (rebate == null || !product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedCashAmount) || rebate.Amount == 0)
            {
                result.Success = false;
            }
            else
            {
                result.Success = true;
                result.RebateAmount = rebate.Amount;
            }

            return result;
        }
    }
}
