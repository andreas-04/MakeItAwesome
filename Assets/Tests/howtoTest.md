# How to Use Test Runner
> The Unity Test Framework or UTF (Experienced through the Test Runner) is a way to automate all of your tests and execute them from a single place. There are two different types of the test runner, Edit Mode and Player Mode (discussed below). 

## Getting Started

### Note: 
- The below instructions for using Test Runner apply to both boundary and stress testing. Although stress tests don't need to be automated or used in the Test Runner, for simplicities sake, its much easier this way. 
- The Test Runner now comes default with the Unity Editor so you don't need to download. 

### Pre-Step: Creating Testing Assembly Folder (Edit/Play Mode)
> I've already done this so just add C# Testing Files to your personal testing directories. Here is the general structure on what I created: 
- ~/Test (all of the tests)
    - /Test/TestEditMode
        - EditMode (Assembly)
        - (Individual Testing Folders)
    - /Test/TestPlayMode
        - PlayMode (Assembly)
        - (Individual Testing Folders)

> The reason for creating it this way is so we can house all of our tests in the same place and use the same assemblies. We could all make individual assemblies but since we can select specific directories to test, that would be redundant. 

### Step 1: Decide Player Mode or Edit Mode
- Edit Mode:
> If you are wanting to unit test a function that isn't reliant on the game playing, this would be the option. This could look like testing the logic within a function which modifies some value. 
- Player Mode: 
> Use Player Mode if you require a running instance of the game. This is commonly used for testing the movement of objects within the game. 

### Step 2: Locate Testing Folder
- Within this directory, ~/Tests, you have a directory with titled with your name. All of your tests will be here.  

### Step 3: Create Assembly for your Code to link to the test assembly
1. Follow these steps for both the Play and Edit Mode:
    - Go to "Assembly References". 
    - Click the "+" button.
    - Add the one you just created. 
2. Now your code will be visible to your tests

### Step 4: Create Testing Files for your Code
1. Go to either ~/TestEditMode or ~/TestPlayMode depending on the test that you want to write. 
2. Right Click > Create > Testing > C# Test Script

## Creating Boundary Tests
> Boundary tests are designed to test the strength of your code at its weakest points. They typically take the form of mocking some input to an scene the testing within the range of that scene, at its boundary and just past it. The test should pass if the boundary is not passed and fail it it is passed. 
> Since any testing has many different ways to create the test and they are all relative to the code, I will provide examples and an outline to get you started. 

### Examples
- Testing the range of an object (ex. array). Try filling it one past capacity and seeing what happens. 
- Testing object collisions: If a play can move past the boundary of the wall or not. The range would be the x, y, or z-axis. Try going just past the boundary and see what happens. 

### Outline 
1. Arrage: Gather all the references that you need for the test (functions, objects, etc) and set all values for the test. 
2. Act: Perform the actual test and keep track of the values produced in the test. 
3. Assert: Compare the result to the expected result and respond accordingly. 

## Creating Stress Tests
- As I mentioned before, these will be automated to make things simple. 
- Again, I will not walk through how to write the tests because of the infinite amount of possiblities but I will provide an outline and examples to get you started.

### Examples
- Testing how many objects can be rendered before the game breaks. 
- Testing the speed of an object against a barrier. 
- Testing how much audio can be played at once before the game or your speakers break. 

### Outline
1. Arrange: Gather all the references that you need for the test (functions, objects, etc) and set all values for the test. 
2. Loop: Loop this unitl the "Check" stage returns. 
    1. Act: Perform the actual test and keep track of the values produced in the test. 
    2. Assert/Check: Check to see if the expected failed condition is met. 
    3. Change: If nothing is broken yet, change something and repeat. 
3. Final Assertion: You may or may not want to double check the assertion or comment the final result. 