# Dynamics365_Customizations

# Prevent Duplicate Emails Plugin
A plugin to validate email uniqueness for Contact records.

## Features
- Prevents the creation of duplicate contacts with the same email.
- Executes during Pre-Validation of Contact Create.

## Deployment
- Register using the Plugin Registration Tool.
- Target: Pre-Validation, Contact Create.

## Code
[PreventDuplicateEmailPlugin.cs](PreventDuplicateEmailPlugin.cs)


# Calculate Discount Custom API
A Custom API for calculating a 10% discount on a given amount.

## Features
- Input Parameter: `TotalAmount` (Decimal).
- Output Parameter: `DiscountedAmount` (Decimal).

## Deployment
- Define the Custom API in Dynamics 365.
- Register the `CalculateDiscountPlugin` using the Plugin Registration Tool.

## Code
[CalculateDiscountPlugin.cs](CalculateDiscountPlugin.cs)
