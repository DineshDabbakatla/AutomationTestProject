Feature: Cart

A short summary of the feature
Background: 
	Given I am on the Sauce demo login page
	When I enter 'standard_user' and 'secret_sauce' in the login page
	And I click on login
@cart
Scenario Outline: Verify the products are present in Cart
	Given I am on Peoduct page
	When click on the add to cart button of "<no of products>" products
	And I click on cart icon
	Then I should see the "<no of products>" products that are added
Examples: 
| no of products |
| 2              |
| 3              |
| 4              |
