﻿Feature: StoreSearchBar
	Like a client I'd like to search for my products by a search bar.

@mytag
Scenario: To search with success
	Given That I am a client on the Home page
	When I search by "Dress" in the store
	Then I will be redirected to the Search page
	And A list of products should be displayed on the Search page

Scenario: To search with empty search bar
	Given That I am a client on the Home page
	When I search by "" in the store
	Then I will be redirected to the Search page
	And The message "Please enter a search keyword" should be displayed on the Search page

Scenario: To search for a product that does not exist
	Given That I am a client on the Home page
	When I search by "@%$#!!!*" in the store
	Then I will be redirected to the Search page
	And The message "No results were found for your search" should be displayed on the Search page