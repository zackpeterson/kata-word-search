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

## Reading and writing files

I copied a text file to the output directory during build. I loaded and read the text file from the output directory. I created and saved a new text file into the output directory.

## Validation

I created several unit tests and methods to analyze and validate the format of a puzzle.

 * allow only capital letters A through Z, commas, carriage return and line feed
 * there must be words
 * words cannot be shorter than 2 letters
 * words cannot be longer than the grid size
 * words cannot repeat
 * each letter string must be a single character long
 * each line must contain as many letters as there are rows of the grid

## Prepare the puzzle

I processed the puzzle text and got ready to find the solution.

A *Puzzle* type object has three properties:

 * *Words* is a list of strings
 * *Grid* is a 2-D array of characters
 * *Solution* is a list of *FoundWord* type objects

The *Puzzle* constructor method takes a text string parameter and then populates those three properties.

Grid coordinates:

          x
          0 1 2 3 4 5
          -----------
    y 0 | E,S,Q,Y,K,G
      1 | N,G,V,H,R,R
      2 | I,P,R,B,A,I
      3 | A,D,F,O,M,F
      4 | L,Y,R,R,E,J
      5 | E,J,G,K,R,G

    The letter B is at position (y:2,x:3)

 *FoundWord* is a simple class with two properties:
  
 * *Word* is a string
 * *Positions* is a list of letter position coordinate tuples

 ## Solve the puzzle

 I created the enumeration *Direction* that consists of the eight cardinal and intercardinal directions: north, northeast, east, southeast, south, southwest, west, and northwest.

 I created the *IsRoom()* method to determine if a word of a given length that starts from a given position and continues toward a given direction will fit in a puzzle of a given size.

    X   X   X   X   X

    X   X   X   X   X
          +---------------+
    X   X | X   X   X     |
          +---------------+
    X   X   X   X   X

    X   X   X   X   X

    A word of length 4 that starts from position (2, 2) and continues toward the east cannot fit in a 5-by-5 size puzzle.

I created the *Candidates()* method to find all possible strings of a given length from a given position in every direction of a given grid.

    A   B   C   D   E
    
    F  [G]--H---I   J
        | \ 
    K   L   M   N   O
        |     \
    P   Q   R   S   T
         
    U   V   W   X   Y

    From position (1, 1) three 3-letter long words are possible to the east, southeast, and south: "GHI", "GMS", and "GLQ".

    No 3-letter long words are possible in any of the other five directions.

I created a method *Solve()* that finds all instances of a single word starting from a single position.

I created another method *Solve()* that searches all positions to find all instances of a single word.

I created a third method *Solve()* that searches all positions to find all instances of any of several words.

I created a unit test using DynamicData with complex objects to test that the *Puzzle* constructor correctly populates the *Solution* list of *FoundWord* type objects.

## Input and output

I made the program output the puzzle solution to the console.

I made the program accept a filename as an optional command line argument.

I added a tiny bit of error checking and hints:
 * `failed to load file`
 * `failed to parse puzzle`

## Finishing touches

I added additional puzzle text files.

I made the GitHub source code repository public.

I tested download, installation, and execution on a second computer.

I updated the *README.md* file.