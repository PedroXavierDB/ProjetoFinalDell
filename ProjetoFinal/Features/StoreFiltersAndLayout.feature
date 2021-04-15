Feature: StoreFiltersAndLayout
	Like a client, when I access the category "Women"
I'd like to apply filters and change how products will be displayed

@mytag
Scenario: To go to Category Search page
	Given That I am a client on the Home page
	When I select the category Women
	Then I will be redirected to the Womem Category Search page

Scenario: To filter by category
	Given That I am a client on the Women Category Search page
	When I select the category Dresses
	Then The message "There are 5 products." should be displayed on the Category Search page

Scenario: To filter by size
	Given That I am a client on the Women Category Search page
	When I select the size M
	Then The message "There are 7 products." should be displayed on the Category Search page

Scenario: To filter by color
	Given That I am a client on the Women Category Search page
	When I select the color White
	Then The message "There are 2 products." should be displayed on the Category Search page

Scenario: To filter by composition
	Given That I am a client on the Women Category Search page
	When I select the composition Polyester
	Then The message "There are 2 products." should be displayed on the Category Search page

Scenario: To filter by style
	Given That I am a client on the Women Category Search page
	When I select the style Casual
	Then The message "There are 3 products." should be displayed on the Category Search page

Scenario: To filter by propertie
	Given That I am a client on the Women Category Search page
	When I select the propertie Colorful Dress
	Then The message "There is 1 product." should be displayed on the Category Search page

Scenario: To filter by availability
	Given That I am a client on the Women Category Search page
	When I select the availability In stock
	Then The message "There are 7 products." should be displayed on the Category Search page

Scenario: To filter by manufacturer
	Given That I am a client on the Women Category Search page
	When I select the manufacturer Fashion Manufacturer
	Then The message "There are 7 products." should be displayed on the Category Search page

Scenario: To filter by condition
	Given That I am a client on the Women Category Search page
	When I select the condition New
	Then The message "There are 7 products." should be displayed on the Category Search page