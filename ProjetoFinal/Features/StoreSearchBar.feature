Feature: StoreSearchBar
	Like a client I'd like to search for my products by a search bar.

Scenario: To search with success
	Given That I am a client on the Home page
	When I search by "Dress" in the store
	Then A list of products should be displayed on the Search page

Scenario Outline: To search
	Given That I am a client on the Home page
	When I search by "<Element>" in the store
	Then The message "<Message>" should be displayed on the Search page
	Examples: 
	| TestCase                          | Element  | Message                               |
	| with empty search bar             |          | Please enter a search keyword         |
	| for a product that does not exist | @%$#!!!* | No results were found for your search |