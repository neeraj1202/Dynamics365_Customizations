using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Purpose:A Custom API that calculates a discount based on the total amount passed in the request and returns the discounted amount.
//Request Parameters (Input): TotalAmount: Decimal(Required) – The total amount for the discount calculation.
//Response Parameters (Output): DiscountedAmount: Decimal – The calculated discounted amo
namespace Dynamics365_Customizations.CustomAPI
{
    public class CalculateDiscountPlugin : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            // Obtain the execution context from the service provider.
            IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));

            // Ensure the Custom API is triggered.
            if (context.MessageName == "CalculateDiscount")
            {
                // Retrieve the TotalAmount input parameter.
                if (context.InputParameters.Contains("TotalAmount") && context.InputParameters["TotalAmount"] is decimal totalAmount)
                {
                    // Business logic: Apply a 10% discount.
                    decimal discountPercentage = 10m; // 10%
                    decimal discountedAmount = totalAmount - (totalAmount * discountPercentage / 100);

                    // Return the DiscountedAmount as an output parameter.
                    context.OutputParameters["DiscountedAmount"] = discountedAmount;
                }
                else
                {
                    throw new InvalidPluginExecutionException("TotalAmount is required and must be a valid decimal.");
                }
            }
        }
    }
}
