using Microsoft.Extensions.DependencyInjection;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Services.Factories;
using Smartwyre.DeveloperTest.Services.Factories.Concrete;
using Smartwyre.DeveloperTest.Types;
using System;

namespace Smartwyre.DeveloperTest.Runner;

class Program
{
    static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddScoped<IRebateService, RebateService>()
            .AddScoped<IRebateCalculatorFactory, RebateCalculatorFactory>()
            .BuildServiceProvider();

        var rebateService = serviceProvider.GetService<IRebateService>();

        var request = new CalculateRebateRequest
        {
            RebateIdentifier = "TestRebateId",
            ProductIdentifier = "TestProductId",
            Volume = 5 
        };

        var result = rebateService.Calculate(request);

        Console.WriteLine("Calculation Result:");
        Console.WriteLine($"Success: {result.Success}"); //true
        Console.WriteLine($"Rebate Amount: {result.RebateAmount}");  // Expected Resul 5 * 10 = 50.
        Console.ReadKey();
    }
}
