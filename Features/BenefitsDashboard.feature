Feature: Benefits Dashboard

@regression
Scenario Outline: Log Out
    Given an Employer "<Employer>"
    And I am on the Benefits Dashboard page
    When I Log Out
    Then benefits dashboard login page is displayed

Examples:
      | Employer    |
      | Paylocity |