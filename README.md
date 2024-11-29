# Dynamics365_Customizations

## Purpose:
This repository is dedicated to providing simple, clean, and easy-to-understand code examples for Dynamics 365 developers and consultants. 
The goal is to make it easier for others to learn, implement, and **customize their solutions without being overwhelmed by unnecessary complexities or dependencies.

## Why This Repository?
Beginner-Friendly: Code is designed to be straightforward and easy to follow, even for those new to Dynamics 365.
Minimal Dependencies: Focus on using out-of-the-box features and avoiding unnecessary external libraries.
Reusable Solutions: The examples provided here can be quickly adapted for real-world scenarios.
Educational: Each example is documented to help you understand not just how it works, but also why it works.


## How to Use
Browse the folders for examples like plugins, workflows, custom APIs, and more.
Read the accompanying documentation (README.md) for each example to understand its purpose and deployment instructions.
Use the provided code as-is or modify it to suit your specific needs.

## How You Can Contribute
Add Your Examples: Share easy-to-understand code solutions or customizations.
Improve Documentation: Enhance clarity or add additional context to existing files.
Suggest Enhancements: Propose new ideas to improve this repository and make it even more helpful.
Let’s build a community resource that empowers everyone working with Dynamics 365!

## Examples

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
