using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Data;

public class RebateDataStore
{
    public Rebate GetRebate(string rebateIdentifier)
    {
        // Access database to retrieve account, code removed for brevity 
        ///test object
        return new Rebate
        {
            Identifier = rebateIdentifier,
            Incentive = IncentiveType.AmountPerUom,
            Amount = 10,
            Percentage = 0
        };
    }

    public void StoreCalculationResult(Rebate account, decimal rebateAmount)
    {
        // Update account in database, code removed for brevity
    }
}
