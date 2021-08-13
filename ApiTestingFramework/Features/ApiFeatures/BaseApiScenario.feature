@Api
Feature: Test Twitter Tweets
 
  Scenario: 01 Get recent tweets from our Home Timeline
    Given I post a tweet of "Hello World! This is a test tweet."
    When I retrieve the resource of "/home_timeline.json"
    Then the latest tweet is my message of "Hello World. This is a test tweet."
