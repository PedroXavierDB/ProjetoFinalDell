Feature: UserLogin
	As a customer with an registred account I'd like to access 
the Sign In page and do my login during my shoppings.

@mytag
Scenario: Login success
	Given That I am a user with a registered account
	And That I am on the Sign In page
	When I write correctly my email and password
	And I try to do my login
	Then I will login in my account

Scenario: Login without email and password
	Given That I am on the Sign In page
	When I try to do my login without writing my email and password
	Then The message "An email address required." should be displayed on the Sign In page

Scenario: Login without password
	Given That I am on the Sign In page
	When I write only my email
	And I try to do my login
	Then The message "Password is required." should be displayed on the Sign In page

Scenario: Login with an invalid email
	Given That I am on the Sign In page
	When I write an invalid email
	And I try to do my login
	Then The message "Invalid email address." should be displayed on the Sign In page

Scenario: Login with an invalid password
	Given That I am on the Sign In page
	When I write a valid email and an invalid password
	And I try to do my login
	Then The message "Invalid password." should be displayed on the Sign In page

Scenario: Login with wrong email or password
	Given That I am on the Sign In page
	When I write incorrectly my email or password
	And I try to do my login
	Then The message "Authentication failed." should be displayed on the Sign In page