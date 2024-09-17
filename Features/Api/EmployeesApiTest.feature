Feature: Api Employees Test

@regression @Api
Scenario: Get Employee List
    Given a list of employess

@regression @Api
Scenario: Get Employee
    Given a list of employess
    When I request an employee from employees list

@regression @Api
Scenario: Delete valid Employee
    Given a list of employess
    When I delete an employee from employees list

@regression @Api
Scenario: Delete invalid employee
    Given a list of employess
    When I delete a non valid employee

@regression @Api
Scenario: Update Employee
    Given a list of employess
    When I update an employee from employees list

@regression @Api
Scenario: Update invalid employee
    Given a list of employess
    When I update a non valid employee

@regression @Api
Scenario: Post Employee
    Given a random employee
    When I post an employee from employees list

@regression @Api
Scenario: Post employee invalid firstname max length
    Given a random employee
    When I post invalid firstname max length

@regression @Api
Scenario: Post employee max firstname max length
    Given a random employee
    When I post max firstname max length

@regression @Api
Scenario: Post employee firstname empty
    Given a random employee
    When I post firstname empty

@regression @Api
Scenario: Post employee invalid length
    Given I post invalid <FirstName>" "<LastName>" "<Dependents>" invalid length
Examples:
      | FirstName |  LastName | Dependents |
      |           |           |            |