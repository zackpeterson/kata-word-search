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