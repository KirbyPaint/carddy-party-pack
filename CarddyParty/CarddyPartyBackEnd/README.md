# _Carddy Party - Back End - Server_

#### By _Nick Lindau, Ash Porter, Dani Renner, Logan Roth,_

## Description

_Server-side installation for Carddy Party. This server maintains the database to store all player cards for the operation of the game. This is a backend piece of a full-stack repo. See the front end here: https://github.com/Lo-GR/CarddyPartyFrontEnd_

------------------------------
### <u>Table of Contents</u>
* <a href="#setup-and-installation-requirements">Setup/Installation Requirements</a>
  * <a href="#cloning-with-git">Cloning with Git</a>
  * <a href="#configuration-file-setup">Configuration File Setup</a>
  * <a href="#after-everything-is-set-up">After everything is set up</a>
* <a href="#how-to-use-the-program">How To Use The Program</a>
* <a href="#known-bugs-and-issues">Known Bugs and Issues</a>
* <a href="#support-and-contact-details">Support and Contact Details</a>
* <a href="#technologies-used">Technologies Used</a>
------------------------------

## Setup and Installation Requirements

### Cloning with Git:

* Open Git Bash, or your preferred terminal
* Navigate to your directory for Git projects (not within an existing project)
* Type the following: `git clone https://github.com/Lo-GR/CarddyPartyBackEnd.git`

This program was built with and requires .NET version 5.0.102. You may install the 64-bit version for Windows [using this link](https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-5.0.102-windows-x64-installer)  

Once the installation of .NET 5 is complete, you may check that the proper version was installed by opening up Git Bash and typing:  

`dotnet --version`  

Then, open your Git Bash terminal and navigate to:

`C:<filepath the files are installed at>\CarddyPartyBackEnd.Solution`

where "filepath the files are installed at" will be the location you saved your copy of the project at, or alternatively:  

You may navigate to the folder in the project labeled "CarddyPartyBackEnd.Solution".  
Right-click inside the File Explorer window, and in the right-click menu, choose "Open Git Bash Here," or Shift+Right-click and choose "Open Powershell Window Here."  
This will open a Powershell/Git Bash window that is already inside the proper directory.

[Click here for tips on navigating the terminal](https://docs.microsoft.com/en-us/powershell/scripting/samples/managing-current-location?view=powershell-7.1)

### Configuration File Setup

First, you will need to ensure you navigate into the `\CarddyPartyBackEnd.Solution\CarddyPartyBackEnd` directory. Create a file named `appsettings.json` and paste the following code into the newly created `appsettings.json` file:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=carddy_party;uid=root;pwd=[YOUR PASSWORD];"
  }
}
```

You will then need to make a change to the appsettings.json file:  
Where the text says `database=carddy_party`, this name is provided for user convenience. You may change `carddy_party` to anything you would like, and if the naming scheme is valid, the installation will create a database schema with your custom name.  
Where the text says `pwd=[YOUR PASSWORD]`, enter your own secure password, and remove the brackets. If your password is `SafePassword123` this code will look like `pwd=SafePassword123`  
This ensures that the program will be able to read and write to your own local database.

### After everything is set up

Once you have properly navigated to the project directory (`<your directory>\CarddyPartyBackEnd.Solution\CarddyPartyBackEnd`), your appsettings.json file has been created, and your local server has been set up, type:

`dotnet restore`

The program should automatically restore all necessary packages.  

Note: This program does come with a "Migrations" folder, but if that folder is missing, please run the following command:

`dotnet ef migrations add Initial`

If the Migrations folder already exists in the project structure, skip this step and enter this next command:

`dotnet ef database update`

to fully apply the database structure.

Once all of the previous steps are applied, enter the following:

`dotnet run`

This will run the web application on a local server. Look for terminal output containing these lines:  

```
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://localhost:5000
```

Once you see this in the terminal, you will be able to use this server alongside the front-end server.  

## How To Use The Program

This server is designed to host the game. Once the server is up and running, do not touch it. To close the server, click in that window and press ctrl + c.  

## Known Bugs and Issues

This project is a proof of concept project. There will be multiple 

## Support and contact details

_Ash Porter - Discord: @KirbyPaint#0751_

_Logan Roth - diamondintheroth@gmail.com - [GitHub(Lo-GR)](https://github.com/Lo-GR)_

## Technologies Used

*  ASP.NET Core
*  ASP.NET CORS
*  Entity Framework Core
*  MySQL/MySQL Workbench
*  .NET 5
*  Swashbuckle

### License Information

[![MIT license](https://img.shields.io/badge/License-MIT-blue.svg)](https://opensource.org/licenses/MIT)

Copyright (c) 2021, Logan Roth, Ash Porter, Dani Renner, Nick Lindau.

Please contact Contributor for further use information or if you would like to make a contribution.
