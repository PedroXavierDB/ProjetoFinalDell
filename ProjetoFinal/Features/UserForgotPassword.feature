﻿Feature: UserForgotPassword
	Like a client already registered but with a long time since my last shopping, 
	I'd like a way to recover my password to do my login.

@mytag
Scenario: To access the Forgot Password page with success
	Given That I am on the Sign In page
	When I click on Forgot Your Password
	Then I will be redirected to the Forgot Password page

Scenario: Password recover with success
	Given That I am on the Forgot Password page
	When I write my already registered email on the Forgot Password page
	And I click on Retrieve Password 
	Then The message "A confirmation email has been sent to your address" should be displayed on the Forgot Password page

Scenario: Password recover with an invalid email
	Given That I am on the Forgot Password page
	When I write an invalid email on the Forgot Password page
	And I click on Retrieve Password  
	Then The message "Invalid email address." should be displayed on the Forgot Password page

Scenario: Password recover with an unregistered email
	Given That I am on the Forgot Password page
	When I write an unregistered email on the Forgot Password page
	And I click on Retrieve Password  
	Then The message "There is no account registered for this email address." should be displayed on the Forgot Password page