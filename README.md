Technical Test
==============

## Prerequisites

Visual Studio 2017
.Net Core 2.0+

Git - https://www.atlassian.com/git/tutorials/install-git#windows

NodeJs and Npm - https://nodejs.org/en/ (make sure you restart after install)

## Setup Instructions

1) Open up a command window and run 'npm install -g @angular/cli'

2) Create a folder where you wish to deploy the code e.g. c:\users\<your user>\source\PhilHine

3) In a command prompt open the folder you created above and run 'git clone https://github.com/philhine/InvestmentForecaster.git'

4) In the command prompt window, navigate to the newly created InvestmentForecaster\WebApp directory and run 'npm install'

5) In the same folder run 'ng build'

6) Still using the console navigate to the root folder InvestmentForecaster and run'dotnet restore'

7) Still using the console navigate to the root folder InvestmentForecaster and run 'dotnet run'

8) Open visual studio and open the solution file.

9) Right click on the solution in solution explorer and select properties and on the startup section set multiple start up projects to 'InvestmentForecast.api' and 'WebApp' and press play to run. If you are running this for the first time it is possible it might take a while to load.

10) You will get a pop up asking you about IIS Express SSL Certificate - select yes. This will shortly be followed by a security warning asking you if you want to install the certificate - select yes.

* If you have any problems with the web app not spinning up, close visual studio, delete the .vs hidden folder in the root directory of the project and try again. 

## Features

- Angular 6 + jasmine tests
- .Net Core 2.0 
- Dependency injection
- Client side restricted user entry
- Chart JS
- Model binding and validation
- Integration and unit tests
- Test builder and factory pattern
- Bootstrap

## Questions

## How long did you spend on the code test?
15-20 hours

### What went well?
I enjoyed writing the angular 6 app as I have limited experience in it. I thought the integration tests and unit tests helped give me confidence in the results and helped me with several refactors. 

### Was there anything that was attempted but was not possible to get working in the time so is not visible in the code?
I wrote some jasmine tests that execute with karma (cross browser testing) and to get them to work I needed to add a component declaration on a model. However that causes an issue with the command ng build -aot which runs the web app. So I will figure out a workaround a future time. 

### What would you do to improve it / continue development?
I developed it on an Azure VM and I tested it on another vm which highlighted a couple of issues that I fixed. Ideally with more time I would have put it in a docker container so that I can guarantee it will work on most machines and perhaps deployed it to AWS or Azure.

Also towards the end I found out about Protractor.js which runs end 2 end tests using the browser, with more time I would get a few tests in here. Additionally although I have added validation and error messages in future development I would improve the messages. A logging component would have also been good in the places where I have commented about logging. I've left the business validation blank but present so that upon learning business rules I could implement them e.g. monthly must be less than lump sum etc.

Ideally I would have preferred the web application would be pure angular 6 without the dot net core integration as it adds unnecessary bloating but I made the decision to integrate it to fit the requirement 'visual studio solution'.

Also I would look to make it possible to get the bound rates from I/O such as a database or from user input.