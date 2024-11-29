using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Purpose: This Custom API retrieves sales orders for a given customer, returning details
//like the order ID, name, status, and total amount.
namespace Dynamics365_Customizations.CustomAPI
{
    public class GetCustomerOrdersPlugin : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            // Obtain the execution context
            IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

            // Retrieve input parameter (customerId)
            if (!context.InputParameters.Contains("customerId") || !(context.InputParameters["customerId"] is string customerId))
            {
                throw new InvalidPluginExecutionException("CustomerId is required.");
            }

            // Query the SalesOrder entity for the specified customer
            QueryExpression query = new QueryExpression("salesorder")
            {
                ColumnSet = new ColumnSet("salesorderid", "name", "statuscode", "totalamount"),
                Criteria = new FilterExpression
                {
                    Conditions =
                    {
                        new ConditionExpression("customerid", ConditionOperator.Equal, new Guid(customerId))
                    }
                }
            };

            EntityCollection orders = service.RetrieveMultiple(query);

            // Transform the results into a list of dictionaries for JSON serialization
            var orderList = orders.Entities.Select(order => new Dictionary<string, object>
            {
                { "OrderID", order.Id.ToString() },
                { "CustomerName", order.GetAttributeValue<string>("name") },
                { "OrderStatus", order.FormattedValues["statuscode"] },
                { "TotalValue", order.GetAttributeValue<Money>("totalamount")?.Value ?? 0 }
            }).ToList();

            // Serialize the results to JSON
            string jsonResponse = Newtonsoft.Json.JsonConvert.SerializeObject(orderList);

            // Return the JSON response as an output parameter
            context.OutputParameters["customerOrders"] = jsonResponse;
        }
    }
}
