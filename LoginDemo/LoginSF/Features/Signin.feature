Feature: Sign In 

@mytag
Scenario: Sign in to the browser
    
    Given Chrome browser is opened
    When user open Login Page 
        And user enter the username 'user1', password '123456' and confirm_password '123456'
    When user enter different password '12345' and confirm_password '123456'
    Then user receives Error message

    When user enter same password '123456' and confirm_password '123456'
    Then user receives Success message
   
