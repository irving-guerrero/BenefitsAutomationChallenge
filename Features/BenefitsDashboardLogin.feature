Feature: Benefits Dashboard Login

@regression
Scenario Outline: Validate requirements for login input fields
    Given I am on the Benefits Dashboard login page
    When I enter username "<Username>" and password "<Password>"
    And I click on log in button
    Then username "<Username>" and password "<Password>" are required
    And username "<Username>" and password "<Password>" have min and max Length
Examples:
      | Username    | Password  |
      |             |           |
      | RandomUser  |           |
      |             | RandPass  |
      | U           |           |
      |             | P         |


@regression
Scenario Outline: Validate login with invalid credentials
    Given I am on the Benefits Dashboard login page
    When I enter username "<Username>" and password "<Password>"
    And I click on log in button
    Then bad credentials error message should be displayed
Examples:
      | Username    | Password  |
      | WrongUser   | WrongPass |
      | TestUser438 | WrongPass |

@regression
Scenario Outline: Validate login with valid credentials
    Given I am on the Benefits Dashboard login page
    When I enter username "<Username>" and password "<Password>"
    And I click on log in button
    Then benefits dashboard page is displayed

Examples:
      | Username    |   Password    |
      | TestUser438 | !4xAFYaDO.u$ |