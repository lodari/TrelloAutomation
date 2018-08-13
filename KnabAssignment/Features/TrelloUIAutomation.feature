Feature: TrelloUIAutomation
	Inorder to reduce the manual effort of executing
	test scenarios for creating the boards in Trello
	As a automation engineer
	I want to automate this complete process

@SmokeTest
Scenario: Creation of board in Trello
	Given User has loaded the browser and navigated to Trello  home page 
	And logged in to Trello successfully
	And Navigated to the right hand of the screen and clicks on + create board button
	And Provide the board name in the board title section
	When User clicks on Create Board button
	Then Board should be created successfully
