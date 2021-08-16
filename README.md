# FlexeraConsoleApp
**How to build the code**

The easiest way to build to code is to **open the solution in Visual Studio**. For this project I used Visual Studio 2019, Community Version.
Once the solution is open, it can be built by click on **Debug > Build Solution** or its shortcut **Ctrl + Alt + B**.

**How to run the output**

The application runs by pressing the **play button** at the upper-middle side in Visual Studio, or by pressing **F5**.
A Console/Terminal will appear with a few instructions to interact with the application. These instructions are:
    - Type **"exit" to exit the application**.
    - Type **any other string referencing a path** og the file you want to read and analyse.
When trying to obtain the information inside the file, you may get different results>
    - The number of licenses needed. This is the case where the workflow was successful.
    - Error warning that the path is wrong or the file doesn't exists. In this case, the app checked whether the file exists or not, and such call returned false.
Either way the app won't terminate its run until the user types "exit" or closes the console, even when typing a wrong path.

**How to run the tests**

The easiest way to run the tests is:
    - Clicking on **Test > Run All Tests**. The **Test Explorer should appear** with information about the test run.
    - Alternatively, under the test project, you can find the classes with tests inside. **You can trigger the tests by going to each method > right click on the name > Run Test**.
