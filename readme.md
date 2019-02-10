# .NET Code Challenge

You've been provided with the shell of a .Net application in Visual Studio with some sample inputs 

Create an application which outputs the horse names in price ascending order. 

The code should be at a standard you'd feel comfortable with putting in production.

## Background

The source data reflects how BetEasy has different providers of data which feed our website.

The data files are used allows creation of different races:
* Caulfield_Race1.xml https://beteasy.com.au/racing-betting/horse-racing/caulfield/20171216/race-1-798068-25502504  
* Wolferhampton_Race1.json https://beteasy.com.au/racing-betting/horse-racing/wolverhampton/20171213/race-1-797507-25500650

## Solution

The solution is .net core console application using Repository Pattern to get Horse and their Price data. Repository pattern provides flexibility to choose data source for Horse and Price which is right now in XML and Json files.

Controller gathers data from variuos repositories and then sorts and displays the data on console.

I have used MoQ framework to test Controller and Contexts.
