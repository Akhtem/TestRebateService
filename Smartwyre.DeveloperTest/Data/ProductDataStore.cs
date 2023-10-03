using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Data;

public class ProductDataStore
{
    public Product GetProduct(string productIdentifier)
    {
        // Access database to retrieve account, code removed for brevity 

        ///Test Object
        return new Product 
        { 
            Identifier = productIdentifier,
            Id = 1,
            SupportedIncentives = SupportedIncentiveType.AmountPerUom
        };
    }
}
