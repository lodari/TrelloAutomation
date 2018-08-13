Feature: TrelloAPIAutomation
	Inorder to reduce the manual effort of executing
	test scenarios for executing CURD operations on Trello boards
	As a automation engineer
	I want to automate this complete process

@api
Scenario: Verify the completeness of existing Trello board using API call
	Given User has BoardID of existing Trello board and valid Acess key, OAuth token & endpoint url
	When User submit the API GET request using the above parameters
	Then API should return success HTTP response code along with the board name 

@api
Scenario: Create and verify the trello board using API call
	Given User having valid Access_Key, OAuth token & Resource url
	And By using them user creates a board on Trello
	When User submits the API request to verify newly created board
	Then API should return success response message along with the board name

@api
Scenario: Delete the trello board using API call
	Given User having valid BoardID, Access_Key, OAuth token & Resource url
	When User submit the API DELETE request using the above parameters
	Then API should return success HTTP response code


