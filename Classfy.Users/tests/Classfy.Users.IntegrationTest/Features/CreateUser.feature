Feature: CreateUser

Scenario: Create a user successfully
	Given I am a logged user
	When I request user creation
		| Name   | Email                     | Password |
		| Wilson | contato@wilsonneto.com.br | 123456   |
	Then I receive a 201 status code
	And I receive a created user with email "contato@wilsonneto.com.br"
	And In the users table we have a user with email "contato@wilsonneto.com.br"
		
