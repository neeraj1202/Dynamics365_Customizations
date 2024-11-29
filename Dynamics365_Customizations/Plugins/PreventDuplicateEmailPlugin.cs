using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Purpose: Prevent users from creating a contact with the same email address as an existing contact.
//Trigger: Pre - Validation on Contact Create.

namespace Dynamics365_Customizations
{
    public class PreventDuplicateEmailPlugin : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            // Obtain the execution context from the service provider.
            IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));

            // Check if the plugin is triggered on Contact create.
            if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity entity && entity.LogicalName == "contact")
            {
                // Ensure the email field is present in the Target entity.
                if (entity.Attributes.Contains("emailaddress1") && entity["emailaddress1"] is string email)
                {
                    // Obtain the organization service.
                    IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
                    IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

                    // Check for duplicates
                    if (IsDuplicateEmail(email, service))
                    {
                        throw new InvalidPluginExecutionException($"A contact with the email address '{email}' already exists. Please use a different email.");
                    }
                }
            }
        }

        private bool IsDuplicateEmail(string email, IOrganizationService service)
        {
            // Query for a contact with the same email address.
            QueryExpression query = new QueryExpression("contact")
            {
                ColumnSet = new ColumnSet("emailaddress1"),
                Criteria =
                {
                    Conditions =
                    {
                        new ConditionExpression("emailaddress1", ConditionOperator.Equal, email)
                    }
                }
            };

            EntityCollection results = service.RetrieveMultiple(query);
            return results.Entities.Count > 0;
        }
    }
}
