Feature: Product

A short summary of the feature


Background: 
	Given I am on the Sauce demo login page
	When I enter 'standard_user' and 'secret_sauce' in the login page
	And I click on login

	
@product
Scenario Outline: Verify products details is displayed
	Given I am on product page
	When I click on a "<product>" displayed on home page
	Then Details of the product displayed
Examples: 
	| product                           |
	| Sauce Labs Backpack               |
	| Sauce Labs Bike Light             |
	| Sauce Labs Bolt T-Shirt           |
	| Sauce Labs Fleece Jacket          |
	| Sauce Labs Onesie                 |
	| Test.allTheThings() T-Shirt (Red) |
