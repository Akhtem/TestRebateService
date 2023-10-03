using Smartwyre.DeveloperTest.Services.Calculators.Interfaces;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services.Factories
{
    public interface IRebateCalculatorFactory
    {
        IRebateCalculator GetRebateCalculator(IncentiveType incentiveType);
    }
}
