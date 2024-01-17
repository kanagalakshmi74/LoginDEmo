Feature: Sign In 

@mytag
Scenario: Sign in to the browser

	Given Load the browser
	When login page opens
	Then enter username password confirm password

    When Attempt log in using incorrect '<username>','<password>' and '<cpassword>'
    Then the user receives access invalid


    When Attempt log in using correct '<username>','<password>' and '<cpassword>'
    Then the user receives log in success message

    
