Feature: Benefits Dashboard

@regression
Scenario Outline: Log Out
    Given an Employer "<Employer>"
    And I am on the Benefits Dashboard page
    When I Log Out
    Then benefits dashboard login page is displayed
Examples:
      | Employer    |
      | Paylocity   |


Scenario Outline: Add Employee
    Given an Employer "<Employer>"
    And I am on the Benefits Dashboard page
    When I select Add Employee
    Then I should be able to enter employee details
    And the employee should save
    And I should see the employee in the table
    And the benefit cost calculations are correct
Examples:
      | Employer    |
      | Paylocity   |

Scenario Outline: Add Random Employee
    Given an Employer "<Employer>"
    And I am on the Benefits Dashboard page
    When I select Add Employee
    Then I enter random employee data
    And the employee should save
    And I should see the employee in the table

Examples:
      | Employer    |
      | Paylocity   |


Scenario Outline: Add Employee Test
    Given an Employer "<Employer>"
    And I am on the Benefits Dashboard page
    When I select Add Employee
    Then I add a new employee with the following details:
      | FirstName       |  LastName  | Dependents     |
      | John            |   Smith    |       3        |

Examples:
      | Employer    |
      | Paylocity   |
