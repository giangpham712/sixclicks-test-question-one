# Question 1: OOPS skills

## Problem Statement

Basic sales tax is applicable at a rate of 10% on all goods, except books, food, and medical products are exempt from this tax. Import duty is an additional sales tax applicable on all imported goods at a rate of 5%, with no exemptions.

When I purchase the below items, I receive a receipt which lists the name of all the items and their price (including tax), as well as the total cost of the items, and the total amount of sales tax paid.

Write an application that prints out the receipt details for the below shopping baskets:

#### Input 1:
1 book at $12.49
1 music CD at $14.99
1 chocolate bar at $0.85

#### Input 2:
1 imported box of chocolates at $10.00
1 imported bottle of perfume at $47.50


## Notes

The program is written with .NET Core 3.1. The solution consists of two projects:

* SixClicksTest.ConsoleApp - The console app program
* SixClicksTest.ConsoleApp.Tests - Unit tests project

### Considerations:

* Product and CartItem should be two separate classes
* Whether to use subclass for each product type - This seems unnecessary because in the scope of this problem, each type doesn't have its own characteristics so using an Enum would suffice

### Assumptions:

* the type of a product can be identified by its name containing any of these keywords, otherwise its type is Other
	* book - Book product
	* chocolate, chocolates - Food product
* any product whose name contains the word 'imported' is an imported product
