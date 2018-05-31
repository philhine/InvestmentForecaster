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

9) Make sure the following projects are set up to run 'InvestmentForecast.api' and 'WebApp' and press play to run. If you are running this for the first time it is possible it might take a while to load.



