Feature: UserLogin
	As a customer with an registred account I'd like to access 
the Sign In page and do my login during my shoppings.

@mytag
Scenario: Login success
	Given That I'm a user with a registered account
	And I'm at the Sign In page
	When I write correctly my email and password
	And I try to do my login
	Then I will login in my account

Scenario: Login without email and password
	Given That I'm at the Sign In page
	When I don't both write my email and password
	And I try to do my login
	Then The error message "An email address required." should be displayed

Scenario: Login without password
	Given That I'm at the Sign In page
	When I write only my email
	And I try to do my login
	Then The error message "Password is required." should be displayed

Scenario: Login with an invalid email
	Given That I'm at the Sign In page
	When I write an invalid email
	And I try to do my login
	Then The error message "Invalid email address." should be displayed

Scenario: Login with an invalid password
	Given That I'm at the Sign In page
	When I write a valid email and an invalid password
	And I try to do my login
	Then The error message "Invalid password." should be displayed

Scenario: Login with wrong email or password
	Given That I'm at the Sign In page
	When I write incorrectly my email or password
	And I try to do my login
	Then The error message "Authentication failed." should be displayed