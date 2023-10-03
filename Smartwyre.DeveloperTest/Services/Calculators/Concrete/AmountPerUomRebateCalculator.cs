using Smartwyre.DeveloperTest.Services.Calculators.Interfaces;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services.Calculators.Concrete
{
    public class AmountPerUomRebateCalculator : IRebateCalculator
    {
        public CalculateRebateResult CalculateRebate(Rebate rebate, Product product, CalculateRebateRequest request)
        {
            var result = new CalculateRebateResult();

            if (rebate == null || product == null || !product.SupportedIncentives.HasFlag(SupportedIncentiveType.AmountPerUom)
                || rebate.Amount == 0 || request.Volume == 0)
            {
                result.Success = false;
            }
            else
            {
                result.Success = true;
                result.RebateAmount = rebate.Amount * request.Volume;
            }

            return result;
        }
    }
}
