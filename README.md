# DnD Battler Testing

This folder contains unit tests for the **DnD Battler** project using **NUnit**. The tests ensure that the core game logic works as expected, including character attacks, team health management, and battle outcomes.

## Test Framework

- **NUnit** is used for writing and running the tests.
- **Microsoft.NET.Test.Sdk** is used to execute tests in the .NET environment.


## Running the Tests
1. Restore dependencies and build the test project:

    ``` dotnet restore ``` 

    ```dotnet build ```

2. Run the tests:

    ```dotnet test```


## What is tested
- Character Actions: Attacks, health changes, and special abilities.
- Team Management: Team creation, health tracking, and interactions between team members.
- Battle Logic: Turn order, win/loss conditions, and battle outcomes.