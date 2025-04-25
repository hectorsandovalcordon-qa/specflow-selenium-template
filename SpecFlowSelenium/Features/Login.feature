Feature: Login

This feature allows users to register and log into the application, verifying required fields and handling login errors.

#Scenario: Successful user login
#    Given "login" page is open 
#    And User clicks on New User button
#    When User fills "FirstName", "LastName", "UserNameTest" and "P@ssw0rd"
#    And User clicks recaptcha checkbox
#    And User clicks on Register button
#    Then User should be redirected to the login page
#    And UserName "UserNameTest" is entered
#    And Password "P@ssw0rd" is entered

Scenario: Required fields user login
    Given "login" page is open 
    When User clicks on Login button
    Then User verifies required fields

Scenario: UserName required field user login
    Given "login" page is open 
    And Password "P@ssw0rd" is entered
    When User clicks on Login button
    Then User verifies username required field

Scenario: Password required field user login
    Given "login" page is open 
    And UserName "UserNameTest" is entered
    When User clicks on Login button
    Then User verifies password required field

#Scenario: Invalid user login
#    Given "login" page is open 
#    And UserName "aa" is entered
#    And Password "aa" is entered
#    When User clicks on Login button
#    Then User shows "Invalid username or password!" message

