Feature: Sign In 

@mytag
Scenario: Sign in to the browser
    
    Given Chrome browser is opened
    When I open Login Page 
        And I enter the username 'user1', password '123456' and confirm_password '123456'
    When password '12345' and confirm_password '123456' are not same
    Then user receives Error message

    When password '123456' and confirm_password '123456' are same
    Then user receives Success message
   
