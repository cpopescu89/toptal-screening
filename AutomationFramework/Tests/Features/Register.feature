Feature: Register
	
Scenario Outline: Register
	Given I register
	And I Log in
	When I add 2 products ot the basket
	And I checkout the purchased items
	Then I order them successfully using delivery option "<number>"

Examples: 
 | number |
 | 0      |
 | 1      |
 | 2      |

 Scenario: Change Username
 	Given I register
	And I Log in
	When I go to the Profile page
	Then I can change my username to "Terminator"
	And my username is displayed on my profile page

 Scenario: Link Image
  	Given I register
	And I Log in
	When I go to the Profile page
	Then I can link an image "http://static.playtech.ro/wp-content/uploads/2013/12/Terminator-Arnold-as-Terminator.jpeg"