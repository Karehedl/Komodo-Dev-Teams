using static System.Console;

public class Program_UI
{
    //Calling databases 
        private DeveloperUI _devUI;
        private DeveloperTeamUI _devTeamUI;
        private DeveloperRepository _devRepo;
        
        
        public Program_UI() 
        {
            _devRepo = new DeveloperRepository();
            _devUI = new DeveloperUI();
            _devTeamUI = new DeveloperTeamUI(_devRepo);
        }

        public void Run()
        {
            RunApplication();
        }

    //Runs application menu
        private void RunApplication()
        {

            while (DTUtils.isRunning)
            {
                WriteLine("== Welcome to Komodo DevTeams ==\n" +
                    "Please Make a Selection:\n" +
                    "1. Developer Menu\n" +
                    "2. Developer Teams Menu\n" +
                    "-------------------------------\n" +
                    "0. Close Application\n");

                string userInputMenuSelection = ReadLine();
                switch (userInputMenuSelection)
                {
                    case "1":
                        DeveloperMenu();
                        break;
                    case "2":
                        DeveloperTeamsMenu();
                        break;
                    case "0":
                        DTUtils.isRunning = CloseApplication();
                        break;
                    default:
                        WriteLine("Invalid Selection");
                        DTUtils.PressAnyKey();
                        break;
                }
            }
        }
    //MAIN BRANCH 
            private bool CloseApplication()
            {
                WriteLine("Thanks, for using Komodo Dev Teams.");
                DTUtils.PressAnyKey();
                return false;
            }

        //Calls for DevTeamUI.cs 
            private void DeveloperTeamsMenu()
            {
                Clear();
                _devTeamUI.Run();
            }

        //Calls for DeveloperUI.cs 
            private void DeveloperMenu()
            {
                Clear();
                _devUI.Run();
            }


    }


// using static System.Console;

// public class Program_UI
// {
//     public readonly DeveloperRepository _devRepo = new DeveloperRepository();
//     public readonly TeamRepository _teamRepo = new TeamRepository();

//     public void Run()
//     {
//         RunApplication();
//     }

     
//     private void RunApplication()
//     {
//         bool isRunning = true;
//         while (isRunning)
//         {
//             WriteLine("== Welcome Database! ==\n" +
//                       "1. Add Developer\n" +
//                       "2. View All Developers\n" +
//                       "3. View A Single Developer\n" +
//                       "4. Update An Existing Developer\n" +
//                       "5. Delete An Existing Developer\n" +
//                       "6. Add Team\n" +
//                       "7. Add Team Member\n" +
//                       "8. View All Teams\n" +
//                       "0. Exit Application\n");

//             string userInput = Console.ReadLine();

//             switch (userInput)
//             {
//                   case "1":
//                     AddDeveloper();
//                     break;
//                   case "2":
//                     ViewAllDevelopers();
//                     break;
//                   case "3":
//                     ViewASingleDeveloper();
//                     break;
//                   case "4":
//                     UpdateAnExistingDeveloper();
//                     break;
//                   case "5":
//                     DeleteAnExistingDeveloper();
//                     break;
//                   case "6":
//                     AddTeam();
//                     break;
//                   case "7":
//                     AddTeamMember();
//                     break;
//                   case "8":
//                     ViewAllTeams();
//                     break;
//                   case "0":
//                     Exit_Application();
//                     break;
//                 default:
//                     WriteLine("Invalid Input");
//                     Press_AnyKey(); 
//                     break;
//             }

//         }
//     }

// //DEVELOPERS 
//        private void AddDeveloper()
//     {
//         Clear();
//         //empty form -> empty version of the Author obj
//         Developer developer = new Developer();

//         WriteLine("Please enter the Developer's First Name:");
//         developer.FirstName = ReadLine();

//         WriteLine("Please enter the Developer's Last Name:");
//         developer.LastName = ReadLine();
        
//         WriteLine("Does this Developer have Pluralsight? \n" +
//                   "yes or no? ");

//         string userInput = ReadLine();
//         if (userInput == "Yes".ToLower())
//         {
//              developer.HasPluralsightAccount = true;
            

//                 //access the database(AuthorRepository)....
//                 if (_devRepo.AddDeveloperToDatabase(developer))
//                 {
//                     WriteLine("Success");
//                 }
//                 else
//                 {
//                     WriteLine("Failed");
//                 }
//         }
//         else
//         {

//             //access the database(AuthorRepository)....
//             if (_devRepo.AddDeveloperToDatabase(developer))
//             {
//                 WriteLine("Success");
//             }
//             else
//             {
//                 WriteLine("Failed");
//             }
//         }

//         ReadKey();
//     }

//         private void ViewAllDevelopers()
//     {
//         Clear();
//         WriteLine("== Developer Listing ==");
//         //grab authors in the database
//         foreach (Developer developer in _devRepo.GetDevelopers())
//         {
//             DisplayDeveloperData(developer);
//         }

//         ReadKey();
//     }
//             private void DisplayDeveloperData(Developer developer)
//     {
//         WriteLine($"DeveloperId: {developer.Id}\n" +
//                   $"Developer Name: {developer.FullName}" );
//         if (developer.HasPluralsightAccount)
//         {
//             WriteLine($"{developer.FullName} has Pluralsight.");
//         }
//         else
//         {
//             WriteLine($"{developer.FullName} doesn't have Pluralsight.");
//         }
//     }

//         private void ViewASingleDeveloper()
//     {
//         Clear();
//         WriteLine("== Developer Data == ");
//         WriteLine("Please enter an Developer Id.");
//         int userInput = int.Parse(ReadLine());

//         Developer developer = _devRepo.GetDeveloper(userInput);
//         if (developer is null)
//         {
//             System.Console.WriteLine($"The Developer with the id: {userInput} doesn't exist!");
//         }
//         else
//         {
//             DisplayDeveloperData(developer);
//         }
//         ReadKey();
//     }

//          private void UpdateAnExistingDeveloper()
//     {
//           Clear();
//         //empty form -> empty version of the Author obj
//         Developer developer = new Developer();

//         WriteLine("Please enter the Developer's First Name:");
//         developer.FirstName = ReadLine();

//         WriteLine("Please enter the Developer's Last Name:");
//         developer.LastName = ReadLine();
        
//         WriteLine("Does this Developer have Pluralsight? \n" +
//                   "yes or no? ");

//         string userInput = ReadLine();
//         if (userInput == "Yes".ToLower())
//         {
//              bool HasPluralsightAccount = true;
            

//                 //access the database(AuthorRepository)....
//                 if (_devRepo.AddDeveloperToDatabase(developer))
//                 {
//                     WriteLine("Success");
//                 }
//                 else
//                 {
//                     WriteLine("Failed");
//                 }
//         }
//         else
//         {
//            bool HasPluralsightAccount = false;

//             //access the database(AuthorRepository)....
//             if (_devRepo.AddDeveloperToDatabase(developer))
//             {
//                 WriteLine("Success");
//             }
//             else
//             {
//                 WriteLine("Failed");
//             }
//         }

//         ReadKey();
        
//     }

//        private void DeleteAnExistingDeveloper()
//        {
//         Clear();
//         WriteLine("Please enter an Developer Id.");
//         int userInput = int.Parse(ReadLine());

//         Developer developer = _devRepo.GetDeveloper(userInput);
//         if (developer is null)
//         {
//             System.Console.WriteLine($"The Developer with the id: {userInput} doesn't exist!");
//         }
//         else
//         {
//             if (_devRepo.DeleteDeveloper(developer.Id))
//             {
//                 WriteLine("Success");
//             }
//             else
//             {
//                 WriteLine("Fail");
//             }
//         }

//         ReadKey();
//     }
   


// //TEAMS    
//         private void AddTeam()
//         {
//           Clear();
//         //empty form -> empty version of the Author obj

//         Team team = new Team(); 

//         WriteLine("Please enter the Team Name:");
//         team.GroupName = ReadLine();
            

//         ReadKey();
//         }

//         private void AddTeamMember()
//         {

//             Team team = new Team(); 

//              WriteLine("Please enter an Developer Id.");
//              int userInput = int.Parse(ReadLine());

//                 Developer developer = _devRepo.GetDeveloper(userInput);
//                     if (developer is null)
//                     {
//                         System.Console.WriteLine($"The Developer with the id: {userInput} doesn't exist!");
//                     }
//                     else
//                     {
//                          //access the database(AuthorRepository)....
//                 if (_teamRepo.AddTeamToDatabase(team))
//                 {
//                     WriteLine("Success");
//                 }
//                 else
//                 {
//                     WriteLine("Failed");
//                 }
//                        WriteLine("Success");
//                     }
//             ReadKey();
//         }
       
       
//         private void ViewAllTeams() 
//         {
//         Clear();
//         WriteLine("== Teams Listing ==");
//         //grab teams in the database
//         foreach (Team team in _teamRepo.GetTeams())
//         {
//             DisplayTeamData(team);
//         }

//         ReadKey();
//          }
//             private void DisplayTeamData(Team team)
//                 {
//                     WriteLine($"Team Id: {team.team_Id}\n" +
//                             $"Team Name: {team.GroupName}" );
//                 }
    





//         private bool Exit_Application()
//     {
//         Clear();
//         WriteLine("Thank you for shopping...");
//         Press_AnyKey();
//         return false;
//     }

//         private void Press_AnyKey()
//         {
//             WriteLine("Press Any Key To Continue.");
//             ReadKey();
//         }


// }