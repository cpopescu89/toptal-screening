# UI Testing using Selenium and Specflow
## Installation instructions

In order to have a working test execution environment, some pre-requisites must be fullfilled:

- Install [Visual Studio](https://visualstudio.microsoft.com/downloads/) 
- DotNetCore3.1 installed (should be installed when Visual Studio installation is performed)
- Specflow extension for Visual Studio - instructions [here](https://docs.specflow.org/projects/getting-started/en/latest/GettingStarted/Step1.html)
- Version of Chromedriver (which is installed as a nuget package in the solution), to be the same as the Chrome version installed on the machine that's executing the tests

## Features

- Supports Gherkin style syntax for writing test cases
- Page Object Model design pattern
- Test execution in the cloud
- Easy to add new features

## Structure

The framework is split as follows:
+ AutomationFramework
    + Framework
        + Extensions 
    + Page Objects
    + Tests
        + Features
        + Steps

_Framework_ folder contains basic skeleton for starting and closing Selenium Webdriver, hooks, extension methods and other useful methods.
_PageObjects_ holds the classes that correspond to the pages being tested.
_Tests_ folder, split into _Features_ and _Steps_ holds the Specflow (Gherkin) feature files where you can define and add new tests, alongside with the C# implementation of those steps 

## Development
Adding new tests should be fairly easy. 
1. Go to Tests -> Features -> Right Click on folder and click Add New Item.
2. From the left side category select Specflow, enter a name and click Add
3. Write your scenario 
4. Right click on the scenario -> select _Generate Step Definitions_ and then click on _Generate_
5. Select the Steps folder and then you should have your automated generated file ready to implement

## Testing
Testing is being done through a CI/CD Pipeline in the cloud by using AWS Services (AWS Codebuild and AWS Pipeline). Each time a commit is made, the pipeline is triggered and a new test execution is being performed