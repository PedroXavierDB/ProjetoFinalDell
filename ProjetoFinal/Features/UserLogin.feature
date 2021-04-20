Feature: UserLogin
	As a customer with an registred account I'd like to access 
the Sign In page and do my login during my shoppings.

Scenario: Login success
	Given That I am on the Sign In page
	When I try to do my login writing my registered email and password
	Then I will login in my account

Scenario: Login without email and password
	Given That I am on the Sign In page
	When I try to do my login without writing my email and password
	Then The message "An email address required." should be displayed on the Sign In page

Scenario: Login without password
	Given That I am on the Sign In page
	When I try to do my login writing only my email
	Then The message "Password is required." should be displayed on the Sign In page

Scenario: Login with an invalid email
	Given That I am on the Sign In page
	When I try to do my login writing an invalid email
	Then The message "Invalid email address." should be displayed on the Sign In page

Scenario: Login with an invalid password
	Given That I am on the Sign In page
	When I try to do my login writing a valid email and an invalid password
	Then The message "Invalid password." should be displayed on the Sign In page

Scenario: Login with wrong email or password
	Given That I am on the Sign In page
	When I try to do my login writing incorrectly my email or password
	Then The message "Authentication failed." should be displayed on the Sign In page