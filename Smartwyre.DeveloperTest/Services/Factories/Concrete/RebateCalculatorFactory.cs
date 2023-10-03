using Smartwyre.DeveloperTest.Services.Calculators.Concrete;
using Smartwyre.DeveloperTest.Services.Calculators.Interfaces;
using Smartwyre.DeveloperTest.Types;
using System;

namespace Smartwyre.DeveloperTest.Services.Factories.Concrete
{
    public class RebateCalculatorFactory : IRebateCalculatorFactory
    {
        public IRebateCalculator GetRebateCalculator(IncentiveType incentiveType)
        {
            switch (incentiveType)
            {
                case IncentiveType.FixedCashAmount:
                    return new FixedCashAmountRebateCalculator();
                case IncentiveType.FixedRateRebate:
                    return new FixedRateRebateCalculator();
                case IncentiveType.AmountPerUom:
                    return new AmountPerUomRebateCalculator();
                default:
                    throw new ArgumentException("Unsupported incentive type");
            }
        }
    }
}
