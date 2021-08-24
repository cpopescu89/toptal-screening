# UI Testing using Selenium and Specflow
## Installation instructions

In order to have a working test execution environment, some pre-requisites must be fullfilled:

- Install [Visual Studio](https://visualstudio.microsoft.com/downloads/) 
- DotNetCore3.1 installed (should be installed when Visual Studio installation is performed)

## Features

- Supports Gherkin style syntax for writing test cases
- Test execution in the cloud
- Easy to add new features

## Structure

The framework is split as follows:
+ ApiTestingFramework
    + Apis
        + Models 
    + Features
    + Steps
    + Utils

_Apis_ folder contains methods used throughout the tests, like Authentication methods, endpoint callers and results retrievers. It also contains the models for each endpoint objects used for testing.

_Features_ folder holds the Specflow (Gherkin) feature files where you can define and add new tests.
 _Steps_ holds C# implementation of the Specflow steps 

## Development
Adding new tests should be fairly easy. 
1. Go to Tests -> Features -> Right Click on folder and click Add New Item.
2. From the left side category select Specflow, enter a name and click Add
3. Write your scenario 
4. Right click on the scenario -> select _Generate Step Definitions_ and then click on _Generate_
5. Select the Steps folder and then you should have your automated generated file ready to implement

## Testing
Testing is being done through a CI/CD Pipeline in the cloud by using AWS Services (AWS Codebuild and AWS Pipeline). Each time a commit is made, the pipeline is triggered and a new test execution is being performed