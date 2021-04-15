Feature: UserRegistration
	As a new customer I'd like to be able to access the Sign in page
and be able to register at the online store.

@mytag
Scenario: Complete a new registration
	Given That I am a new client without registration
	When I access the Registration page using an unregistered email
	And I insert all mandatory values
	And I click on Create an Account on the Registration page
	Then I will be able to complete my registration at the online store

Scenario: Fail to complete a new registration
	Given That I am a new client without registration
	When I access the Registration page using an unregistered email
	And I do not write in at least one of the mandatory fields
	And I click on Create an Account on the Registration page
	Then A message should be displayed informing that all mandatory fields must be completed