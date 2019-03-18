# Word Search Kata by Zack Peterson

In this exercise I built a program to complete a word search problem.

Given a text file consisting of a list of words, and a series of rows of single-character lists representing the word search grid, this program searches for the words in the grid and returns a set of x,y coordinates for each word found.

See file *kata.md* for the full assignment instructions.

## Challenge

I'd never programmed using an Apple computer, so I decided to give that a try for this kata. So therefore I used Visual Studio Code for this project rather than Visual Studio and I used .NET Core rather than .NET Framework.

This was my first time programming on macOS. This was my first time programming with the Visual Studio Code editor. This was my first time using .NET Core.

## Purpose

Please study the source code and commit history to get a sense of how I think about and work to solve a problem such as this.

See file *log.md* for a record of the steps I took.

## Installation

### .NET Core

Download and install the .NET Core SDK from Microsoft.

 * https://dotnet.microsoft.com/download

Open a Terminal window and make sure it is working

    dotnet

### Application

Clone or download the source code from GitHub.

Open a Terminal window and navigate to the `WordSearch` project directory.

Make sure the program builds and executes with this command.

    dotnet run

### Test

Open a Terminal window and navigate to the `kata-word-search` solution directory. Run the unit test with this command.

    dotnet test

## Usage

The application accepts a filename as a command line argument. Example:

    dotnet run puzzle-02-presidents.txt

If no filename is provided then the `puzzle-01-given-example.txt` default is assumed.

See file *kata.md* for a description of the file format.

Found words and the positions of their letters are written to the console and then the application exits.
