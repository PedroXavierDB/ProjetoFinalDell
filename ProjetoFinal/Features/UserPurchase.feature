Feature: UserPurchase
	As a new user I'd like to complete a purchase in the store

@mytag
Scenario: Complete a purchase
	Given That I am a client on the Home page
	When I search by "Dress" in the store
	And I add one item to my cart
	And I go to Checkout page by the popup window
	And I click on checkout on the Cart page
	And I access the Registration page using an unregistered email
	And I try to register a new account
	And I confirm my address
	And I complete the paymente 
	And I select a payment method
	And I confirm my purchase
	Then I will be able to complete my purchase