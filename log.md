# Log

## Created a new repository using the GitHub website

 * owner: zackpeterson
 * repository name: kata-word-search
 * description: search for words in a grid of letters
 * private
 * initialize with a readme
 * .gitignore: VisualStudio
 * no license

repository url: https://github.com/zackpeterson/kata-word-search

## Updated an Apple computer with the latest version of macOS; Installed Git; Installed Microsoft Visual Studio Code

 * https://www.apple.com/macos/how-to-upgrade/
 * https://git-scm.com/download
 * https://code.visualstudio.com

## Setup Git credentials; Cloned the repository; Committed and pushed changes

I generated a new personal access token using the GitHub website.

 * https://github.com/settings/tokens

I opened the Terminal and instructed Git to use the KeyChain to store credentials:

    git config --global credential.helper osxkeychain

Within VS Code I cloned the repository:

 * Pressed ⇧⌘P to open the command palette.
 * Entered "Git: Clone".
 * Entered the repository url.
 * Selected a folder for the repository location.
 * Entered my GitHub username.
 * Entered my personal access token.

Then I made changes:

 * Created the kata file
 * Created this log file

I committed and pushed my changes to GitHub.

## Created a .NET Core solution and projects

I downloaded and installed the .NET Core SDK.

 * https://dotnet.microsoft.com/download

I pressed ⇧⌘X to open the Extensions pane. Then I searched for and installed the C# extension. It downloaded and installed several packages.

 * https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp

I pressed ⌃~ to open the VS Code terminal and typed the command to create a new .NET Core solution.

    dotnet new sln

I created a new console application project in a new folder.

    dotnet new console -o WordSearch

I added the console application project to the solution.

    dotnet sln add WordSearch/WordSearch.csproj

To get debugging to work I had to update the generated `launch.json` file and create a new `tasks.json` file.

I created a new tests project in a new folder.

    dotnet new mstest -o WordSearch.Tests

I added the console application project as a dependency to the tests project.

    cd WordSearch.Tests
    dotnet add reference ../WordSearch/WordSearch.csproj

I added the tests project to the solution.

    cd ..
    dotnet sln add WordSearch.Tests/WordSearch.Tests.csproj

I created sample methods in the `Program.cs` and `UnitTest1.cs` files to make sure tests execute.