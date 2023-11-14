# TFLCodeChallenge
This project contains a working examples of how to test web application using SpecFlow and .NET 6.

The UI interactions are performed using SpecFlow.Actions.Selenium.

Projects
PlanYourJourney
TFL web application. The Plan a journey has core functionality - valid/invalid journey, joruney options, edit journey, and recent planned journey. This application is the subject under test.

SpecFlowCalculator.Specs
A test project using the NUnit framework containing 5 simple example tests in Calculator.feature and step definitions defined in PlanYourJourneyStepDefinitions.cs

Notes
Version
This project was built using .NET6 SDK version 6.0.100-preview.7.21379.14

Launching the web application from the test project
The test project creates the web host (https://tfl.gov.uk/) during execution CreateHostBuilder Kestrel (default webserver for ASP.NET Core), and stops the host once the tests have completed.

