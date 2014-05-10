## [Viniculture](github.com/wqxhouse/PORTNEW) - An online wine management center
=======================================================================
 
## GENERAL USAGE NOTES

1. ===Software Operating System:===
 1. The program does not support Mac OS, Linux or Unix systems
 2. The program only support the Windows series operating system 

2. ===Software System Library Dependency:===
 1. The program running environment is .Net framework 4.0, please be sure that the computer has already installed the .Net framework 4.0 before installing the program. 

 2. The official link to .Net 4.0 runtime library is: [download](http://www.microsoft.com/en-us/download/details.aspx?id=17718)
    The install folder also has a standalone .Net framework 4.0 installing package that you can choose to install.

	
## INSTALLATION
1.	Go into Installation folder, Double click “setup.exe”.
2.	Continue clicking “Next” button, until you see the installer installing. (You’d better remember where you install the program)
 1. If you encounter User Account Control Prompt, Click Yes to continue;
3. If the installation process goes smoothly, after the install is complete, you should be able to see a “WiniCulture” icon appeared on your desktop. 
 1. If there isn’t an icon appeared on the desktop, go to the Installation Path that you remembered in Step 2. And double click PORTAPP.exe in order to boot the program.

## IMPORTANT NOTES
1. Be aware that the program relies on internet connection since our database is online, using Windows Azure. Therefore, please run the program with a good internet environment.
IMPORTANT: The Windows Azure SQL database needs UCSD Protected network, rather than UCSD Guest. This is very important; if the software is running on UCSD Guest, it cannot reach the SQL database and will crash after a connection timeout.

2. Also, the installation process involves running an installer on the computer, so please be sure that the user has authorization to install programs. Note: The school library computer and computer lab's computers are not supported, since it does not allow anyone to install any software using an installer.

## Potential Issue of this Release
1. The date of a newly created journal entry is 1 day later than the current time. After users save the newly created journal entry, the last letter at the end of each line may disappear.
2. Since the database is online, the program is highly sensitive to your network connections. If anything does not display after you navigate to a new page, wait for 10 or more seconds, or try to reopen it (this occurs most often with pictures).
3. Due to performance issue, the main window is locked in the center; thus do not try to move the main window.

## Architectural Pattern 

- The program architecture is based on the MVVM pattern, which is an acronym for Model-View-ViewModel. 
MVVM is essentially a specialized version of MVC pattern that you are looking for. In this project, the WineDataDomain includes all the Models, which deals with the business logic, and provides interfaces to communicate between the client PORTAPP, and the Database, ServiceDataLib.

- The Model is responsible for the business layer which manages the data searching and invoking by communicating with the database directly. At the same time, it also implements the interfaces which are in the "WineDataDomain" folder. For this program, the files that start with "Sql-" belong to this level. 

- The ViewModel includes the role of a Controller in MVC architectural pattern. For example, the ViewModelLocator.cs acts as a container controlling the lifetime of other ViewModels. Different from MVC pattern, ViewModel communicates with Views via DataBinding, which is data transmission property implemented by Microsoft. For this level, the View keeps a reference of ViewModel; however, the viewModel is not aware of the view. The Databinding is achieved by using event firing mechanism. 
On the other side, it calls functions defined by interfaces in Model part to access Business Logic.
- More details: The ViewModel is the layer that transfers the data between the View and Model layers. More concretely, the ViewModel updates the properties which are bind with the View (.xaml files) in order to realize data synchronization. On the other side, it uses the declared methods in the interfaces to handle events and data. For this program, the files with suffix "...VM.cs" belong to this level.

- The View is the layer containing the functions that display the information visually and manage styles and animations applied on control components. For this program, the files with suffix ".xaml" or ".xaml.cs" belong to this level. 


Note that, for convenience, we separate each Module (UserSystem, WineJournal, etc…) in a single folder. But within each folder, the ViewModel and View are separated by a keyword appearing in the name of files,”VM”, which indicates it is a ViewModel rather than View.

Structure: (folders)
PORTNEW is the outmost folder.
PORTNEW \ PORTAPP 

## BRIEF_DESCRIPTION

- "ViniCulture" is a program that helps users find wines, manage their personal wine collections, and even expand their palate and appetite for wine. There are over 600 kinds of wines in the program database, giving the user a wide range of choices to discover and learn about. The program consists of four main components: wine recommendations, wine cellar, wine journal and wine tour.
- In the recommendation portion, users are shown the highest recommended wines (based on ratings collected from wine.com) to give them a taste of which wines are popular at the time. The user can manually switch between the various featured wines to view more information about each one.
- In the cellar portion, any wine can be added into a user's personal cellar. To facilitate organization and ease of use, the user can create and delete multiple racks to categorize and sort their collections.
- In the journal portion, the user can write about their experiences or thoughts about wine. The software is able to generate a list of journal entries organized by the entry date, making it easy for the user to browse through and search for previous journal entries.
- In the winery tour portion, the user can plan a route between various wineries in California. The system automatically displays pins representing locations of various existing wineries in California. The user has the option of selecting as many wineries as they want, and the system will generate an optimal path to tour these wineries.
