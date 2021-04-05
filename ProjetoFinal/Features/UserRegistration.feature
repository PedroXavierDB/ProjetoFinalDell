Feature: UserRegistration
	As a new customer I'd like to be able to access the Sign in page
and be able to register at the online store.

@mytag
Scenario: Complete a new registration
	Given That I'm a new client without registration
	When I click on the Sign In button
	Then I'll be redirected to the Login page
	When I click on the Create an Account button
	Then I'll be redirected to the Registration page
	When I insert all mandatory values
	Then I'll be able to complete my registration at the online store

Scenario: Fail to complete a new registration
	Given That I'm a new client without registration
	When I access the Sign In page
	And I don't write in at least one of the mandatory fields
	Then A message should be displayed informing that all mandatory fields must be completed