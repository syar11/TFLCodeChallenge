Feature: PlanMyJourney

@mytag
Scenario: 1 Verify that a valid journey
	Given the user enter plan journey from Euston Square Underground Station
	And the user enter plan journey to Milton Keynes Central Rail Station
	When the user clicks the plan my journey button
	And the user clicks the accept all cookies button
	Then the user should verify the results
	Then the user should see the results as "Euston Square Underground Station"
	Then the user should see the results as "Milton Keynes Central Rail Station"

@mytag
Scenario: 2 Verify that the widget is unable to provide results when an invalid journey is planned.
	Given the user enter plan journey from abcd
	And the user enter plan journey to abcdefg
	When the user clicks the plan my journey button
	And the user clicks the accept all cookies button
	Then the user should not see the results

@mytag
Scenario: 3 Verify that the widget is unable to plan a journey if no locations are entered into the widget.
	When the user clicks the plan my journey button
	Then the user should see the error as "The From field is required."
	And the user should see the error as "The To field is required."

@mytag
Scenario: 4 Verify change time link on the journey planner displays “Arriving” option and plan a journey based on arrival time
	Given the user enter plan journey from Euston Square Underground Station
	And the user enter plan journey to Wembley Park Underground Station
	And the user clicks the change time link
	When the user selects the arriving option
	And the user clicks the plan my journey button
	Then the user should see the results as "Arriving"

@mytag
Scenario: 5 On the Journey results page, verify that a journey can be amended by using the “Edit Journey” button.
	Given the user enter plan journey from Euston Square Underground Station
	And the user enter plan journey to Milton Keynes Central Rail Station
	When the user clicks the plan my journey button
	And the user clicks the accept all cookies button
	Then the user should verify the results
	Then the user should see the results as "Euston Square Underground Station"
	Then the user should see the results as "Milton Keynes Central Rail Station"
	When the user clicks edit journey
	And the user enter plan journey from Wembley Park Underground Station
	And the user enter plan journey to Euston Square Underground Station
	And the user clicks the update journey button
	Then the user should verify the results
	Then the user should see the results as "Wembley Park Underground Station"
	Then the user should see the results as "Euston Square Underground Station"

@mytag
Scenario: 6 Verify that the “Recents” tab on the widget displays a list of recently planned journeys.
	Given the user enter plan journey from Euston Square Underground Station
	And the user enter plan journey to Milton Keynes Central Rail Station
	When the user clicks the plan my journey button
	When the user clicks the accept all cookies button	
	Then the user should verify the results
	Then the user should see the results as "Euston Square Underground Station"
	Then the user should see the results as "Milton Keynes Central Rail Station"
	When the user clicks the home
	Given the user enter plan journey from Euston Square Underground Station
	And the user enter plan journey to Milton Keynes Central Rail Station
	When the user clicks the plan my journey button
	Then the user should verify the results
	Then the user should see the results as "Euston Square Underground Station"
	Then the user should see the results as "Milton Keynes Central Rail Station"
	When the user clicks the home
	And the user clicks the recents tab
	Then the user should see the results as "Euston Square Underground Station to Milton Keynes Central Rail Station"
