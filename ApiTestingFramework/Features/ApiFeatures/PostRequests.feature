@Api
Feature: PostRequests

Scenario: Post new Weight
	Given I set the current date and a "70" weight
	When I post to the "weightentry" endpoint
	Then the request is successfully made
	And I get a "201" response
	And the data is there

Scenario: Post invalid data
	Given I set the current date and a "20" weight
	When I post to the "weightentry" endpoint
	Then the request is not successfully made
	And I get a "400" response
	And my data is not there