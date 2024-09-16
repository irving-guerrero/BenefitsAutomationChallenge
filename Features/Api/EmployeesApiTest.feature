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
Scenario: Post Employee
    Given a random employee
    When I post an employee from employees list