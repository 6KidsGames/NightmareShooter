# NightmareShooter - 6KidsGames 2017-2018 Project

![6KidsGames Logo](https://github.com/6KidsGames/ZombAttack/blob/master/Sprites/6KidsLogo.png "6KidsGames")


# About This Repo
This repo contains the second large-scale game created by the kid-developers at 6 Kids Games,
from September, 2017 onward. This time we use Unity Personal Edition for the platform.

The game is based initially on the Survival Shooter tutorial at https://unity3d.com/learn/tutorials/projects/survival-shooter-tutorial .


# Using This Repo

## Getting started - First Time Setup

1. Install Git from https://git-scm.com/download/win (for Windows), or https://git-scm.com/download for other operating systems. You'll need at least version 2.14.1 (which contains a fix for a serious security vulnerability).
1. Install Unity Personal Edition from https://store.unity.com/download?ref=personal . This will also install Visual Studio Community Edition. You will have to create a Unity ID, and answer a questionnaire about how you are going to use Unity (as a student...).
1. Open a Windows console: Windows+R (to open the Run box), then type `cmd` and press Enter.
1. Create a new folder: `mkdir c:\Nightmare`
1. Move to that folder: `cd c:\Nightmare`
1. Clone the Git repo to your new folder: `git clone https://github.com/6KidsGames/NightmareShooter.git .`

## Every day - syncing code and running in Unity
When you're developing code with a team, you're going to need to get their code as well as upload your code. A good time to do this is at the start of each day, unless you're in the middle of something.

1. (If you don't already have a console open) Open a Windows console: Windows+R (to open the Run box), then type `cmd` and press Enter.
1. Change location to the code folder: `cd c:\Nightmare`
1. Type `Init` and press Enter to create some helpful short commands to make life easier. 
1. See if you have any files changed locally, and if you're in a working branch: `stat` (which is short for `git status`).
1. If you are not on the `master` branch, run `master` (short for `git checkout master`)
1. If you have other files changed, get it committed and run `master`, or talk to the teacher.
1. Pull down the latest code: `pull` (short for `git pull`)
1. Run Setup.cmd (which installs the latest helper code from the Internet) by entering: `Setup`
1. Start the main project in Unity using the `Start` script.

### Changing the Code
When you want to make changes that others in your team will get to see, you need to use Git to create
what's called a "topic branch," which tells Git to create a container for your changes.
When you are done with your changes you'll use GitHub to send the changes for teacher approval. 

1. To create a topic branch (container) - be sure you've run Init.cmd, and type: `cb WhatYouAreWorkingOn` where "WhatYouAreWorkingOn" is a short description of the work you are doing (without spaces). For example, it could be AddSprites or FixNetworkErrors or something else.
1. Now you're ready to make changes to the code, graphics, sounds, and other parts of the system, using Unity, Visual Studio, and any other tools you might need to use to create content.
1. When you have something done that you want to check in, use `git commit -a` and give a good description of the changes you made.
1. When you are done with everything in your change, it is time to push your topic branch to the cloud (GitHub.com). Use `push`.
1. Now you can request that the team accept the changes in your topic branch. In your browser go to https://github.com/6KidsGames/NightmareShooter and click the `New pull request` button.
1. Select your topic branch name from the list.
1. On the next page, click the "Create pull request" button.
1. Add some information into the pull request instructions if you need to, then click "Create pull request"

The team can now see a pull request waiting. Tell the teacher as well. The teacher can merge your pull request into master.

## Building code
We use Unity to run the build for us.

## Running code on your machine
Use Unity in play mode to run your changes.

## Useful Links
