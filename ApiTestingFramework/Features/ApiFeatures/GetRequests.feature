@Api
Feature: Get Requests
 
 Scenario: Get available gym equipment
    Given I call the "equipment" endpoint
    When I retrieve the results
    Then I get 10 result
    And the "Bench" is one of them

Scenario: Get non existing endpoint
    Given I call the "invalid" endpoint
    When I retrieve the results
	Then I get a "404" response

Scenario: Get using invalid token
    Given I call an endpoint using using an invalid token
    When I retrieve the results
    Then I get a "403" response