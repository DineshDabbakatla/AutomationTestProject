Feature: Login

A short summary of the feature

@loginForValidUser
Scenario: Verify login for a valid user credentials
	Given I am on the Sauce demo login page
	When I enter 'standard_user' and 'secretsauce' in the login page
	And I click on login
	Then Product label should be displayed

@loginForInValidUser
Scenario: Verify login for an invalid user credentials
	Given I am on the Sauce demo login page
	When I enter 'secret' and 'secret_sauce' in the login page
	And I click on login
	Then It should show message Epic sadface: Username and password do not match any user in this service

@loginForLockedOutUser
Scenario: Verify login for a locked out user
	Given I am on the Sauce demo login page
	When I enter 'locked_out_user' and 'secret_sauce' in the login page
	And I click on login
	Then It should show message Epic sadface: Sorry, this user has been locked out

@loginWithEmptyUsernamea
Scenario: Verify login with empty username
	Given I am on the Sauce demo login page
	When I enter '' and 'secret_sauce' in the login page
	And I click on login
	Then It should show message Epic sadface: Username is required

@loginWithEmptypassword
Scenario: Verify login with empty password
	Given I am on the Sauce demo login page
	When I enter 'standard_user' and '' in the login page
	And I click on login
	Then It should show message Epic sadface: Password is required
