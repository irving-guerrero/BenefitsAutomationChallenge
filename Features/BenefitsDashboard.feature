Feature: Benefits Dashboard

@regression @UI
Scenario Outline: Log Out
    Given an Employer "<Employer>"
    And I am on the Benefits Dashboard page
    When I Log Out
    Then benefits dashboard login page is displayed
Examples:
      | Employer    |
      | Paylocity   |

Scenario Outline: Validate required Add Employee modal input fields
    Given an Employer "Paylocity"
    And I am on the Benefits Dashboard page 
    When I select Add Employee
    And I should be able to enter employee "<FirstName>" "<LastName>" and "<Dependents>"
    Then required  add employee modal imput fields are required
Examples:
      | FirstName       |  LastName  | Dependents     |
      |                 |            |               |
      | John            |            |               |
      |                 |   Smith    |               |
      |                 |            |       3        |
      | John            |   Smith    |               |
      | John            |            |       3        |
      |                 |   Smith    |       3        |

@regression @UI
Scenario Outline: Add Employee
    Given an Employer "<Employer>"
    And I am on the Benefits Dashboard page
    When I select Add Employee
    Then I should be able to enter employee details
    And the employee should save
    And I should see the employee in the table
    And the benefit cost calculations are correct
    And the net pay calculations is correct
Examples:
      | Employer    |
      | Paylocity   |

@regression @UI
Scenario Outline: Add and Edit Employee
    Given an Employer "<Employer>"
    And I am on the Benefits Dashboard page
    When I select Add Employee
    Then I should be able to enter employee details
    And the employee should save
    And I should see the employee in the table
    When I select the Action Edit
    Then I can edit employee details
    And the data should change in the table
Examples:
      | Employer    |
      | Paylocity   |

@regression @UI
Scenario Outline: Edit Employee
    Given an Employer "<Employer>"
    And I am on the Benefits Dashboard page
    When I select the Action Edit
    Then I can edit employee details
    And the data should change in the table
Examples:
      | Employer    |
      | Paylocity   |

@regression @UI
Scenario Outline: Delete Employee
    Given an Employer "<Employer>"
    And I am on the Benefits Dashboard page
    When I select the Action X
    Then the employee should be deleted
Examples:
      | Employer    |
      | Paylocity   |

@regression @UI
Scenario Outline: Add and Delete Employee
    Given an Employer "<Employer>"
    And I am on the Benefits Dashboard page
    When I select Add Employee
    Then I should be able to enter employee details
    And the employee should save
    And I should see the employee in the table
    When I select the Action X
    Then the employee should be deleted
Examples:
      | Employer    |
      | Paylocity   |

@regression @UI
Scenario Outline: Add Edit and Delete Employee
    Given an Employer "<Employer>"
    And I am on the Benefits Dashboard page
    When I select Add Employee
    Then I should be able to enter employee details
    And the employee should save
    And I should see the employee in the table
    When I select the Action Edit
    Then I can edit employee details
    And the data should change in the table
    When I select the Action X
    Then the employee should be deleted
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