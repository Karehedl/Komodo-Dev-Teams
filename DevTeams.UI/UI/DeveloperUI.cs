using static System.Console;

public class DeveloperUI
{
    private DeveloperRepository _devRepo;
    private bool isRunningDevUI;
    private DeveloperTeamUI _dtUI;

    public DeveloperUI()
    {
        _devRepo = new DeveloperRepository();
    }

    public void Run()
    {
        RunApplication();
    }

    private void RunApplication()
    {
        isRunningDevUI = true;
        while (isRunningDevUI)
        {
            Clear();
            WriteLine("== Komodo DevTeams Developer UI ==\n" +
                  "Please Make a Selection:\n" +
                  "1. Add A Developer\n" +
                  "2. View All Developers\n" +
                  "3. View Developer By ID\n" +
                  "4. Update Existing Developer\n" +
                  "5. Delete Existing Developer\n" +
                  "6. (challenge) View All Developers with a Pluralsight Acct.\n" +
                  "-------------------------------\n" +
                  "7. Back To Main Menu\n" +
                  "-------------------------------\n" +
                  "0. Close Application\n");

            string userInputMenuSelection = ReadLine();
            switch (userInputMenuSelection)
            {
                case "1":
                    AddADeveloper();
                    break;
                case "2":
                    ViewAllDevelopers();
                    break;
                case "3":
                    ViewDeveloperByID();
                    break;
                case "4":
                    UpdateAnExistingDeveloper();
                    break;
                case "5":
                    DeleteAnExistingDeveloper();
                    break;
                case "6":
                    ViewDevsWithPluralsight();
                    break;
                case "7":
                    BackToMainMenu();
                    break;
                case "0":
                    CloseApplication();
                    break;
                default:
                    WriteLine("Invalid Selection");
                    DTUtils.PressAnyKey();
                    break;
            }
        }
    }

//Main Branch
    private void AddADeveloper()  // Switch 1
        {
            Clear();
            try
            {
                Developer dev = InitialDevCreationSetup();
                if (_devRepo.AddDevToDb(dev))
                {
                    WriteLine($"Successfully Added {dev.FullName} to the Database!");
                }
                else
                {
                    SomethingWentWrong();
                }
            }
            catch
            {

                SomethingWentWrong();
            }
            ReadKey();
        }

    private void ViewAllDevelopers() // Switch 2
        {
            Clear();
            ShowEnlistedDevs();
            ReadKey();
        }
  
     private void ViewDeveloperByID() // Swtich 3 
    {
        Clear();
        ShowEnlistedDevs();
        WriteLine("----------\n");
        try
        {
            WriteLine("Select developer by Id.");
            int userInputDevId = int.Parse(ReadLine());
            ValidateDeveloperInDatabase(userInputDevId);
        }
        catch
        {
            SomethingWentWrong();
        }
        ReadKey();
    }

    private void UpdateAnExistingDeveloper() // Switch 4
        {
            Clear();
            ShowEnlistedDevs();
            WriteLine("----------\n");
            try
            {
                WriteLine("Select developer by Id.");
                int userInputDevId = int.Parse(ReadLine());
                Developer devInDb = GetDeveloperDataFromDb(userInputDevId);
                bool isValidated = ValidateDeveloperInDatabase(devInDb.Id);

                if (isValidated)
                {
                    WriteLine("Do you want to Update this Developer? y/n?");
                    string userInputDeleteDev = ReadLine();
                    if (userInputDeleteDev == "Y".ToLower())
                    {
                        Developer updatedDevData = InitialDevCreationSetup();

                        if (_devRepo.UpdateDeveloperData(devInDb.Id, updatedDevData))
                        {
                            WriteLine($" The Developer {updatedDevData.FullName}, was Successfully Updated.");
                        }
                        else
                        {
                            WriteLine($"The Developer {updatedDevData.FullName}, was NOT Updated.");
                        }
                    }
                    else
                    {
                        WriteLine("Returning to Developer Menu.");
                    }
                }
            }
            catch
            {
                SomethingWentWrong();
            }
            ReadKey();
        }

    private void DeleteAnExistingDeveloper() // Switch 5
        {
            Clear();
            ShowEnlistedDevs();
            WriteLine("----------\n");
            try
            {
                WriteLine("Select developer by Id.");
                int userInputDevId = int.Parse(ReadLine());
                ValidateDeveloperInDatabase(userInputDevId);
                WriteLine("Do you want to Delete this Developer? y/n?");
                string userInputDeleteDev = ReadLine();
                if (userInputDeleteDev == "Y".ToLower())
                {
                    if (_devRepo.DeleteDeveloperData(userInputDevId))
                    {
                        WriteLine($" The Developer with the Id: {userInputDevId}, was Successfully Deleted.");
                    }
                    else
                    {
                        WriteLine($"The Developer with the Id: {userInputDevId}, was NOT Deleted.");
                    }
                }
            }
            catch
            {
                SomethingWentWrong();
            }

            ReadKey();
        }

 private void ViewDevsWithPluralsight() // Switch 6
    {
        Clear();
        WriteLine("== Devs Without Pluralsight ==\n");
        ShowDevsWithOutPs();
        ReadKey();
    }

    private void BackToMainMenu() // Switch 7
        {
            Clear();
            isRunningDevUI = false;
        }

    private void CloseApplication() // Switch 0
        {
            isRunningDevUI = false;
            DTUtils.isRunning = false;
            WriteLine("Closing Application");
            DTUtils.PressAnyKey();
        }


//Side branch 
    private void ShowDevsWithOutPs() //Called in Switch 6 
    {
        List<Developer> devsWoPS = _devRepo.DevsWithOutPluralsight();
        if (devsWoPS.Count > 0)
        {
            foreach (var Developer in devsWoPS)
            {
                DisplayDevData(Developer);
            }
        }
        else
        {
            WriteLine("There Are No Developers at this time with out a Pluralsight Membership.");
        }
    }

    private void SomethingWentWrong() //Called in Switch 1,3,4,5, 
    {
        WriteLine("Something went wrong.\n" +
                       "Please try again\n" +
                       "Returning to Developer Menu.");
    }

    private bool ValidateDeveloperInDatabase(int userInputDevId) //Called in Switch 3,4,5 
    {
        Developer dev = GetDeveloperDataFromDb(userInputDevId);
        if (dev != null)
        {
            Clear();
            DisplayDevData(dev);
            return true;
        }
        else
        {
            WriteLine($"The Developer with the Id: {userInputDevId} doesn't Exist!");
            return false;
        }
    }

    private Developer GetDeveloperDataFromDb(int userInputDevId) //Called in Switch 4 
    {
        return _devRepo.GetDeveloper(userInputDevId);
    }

    private void ShowEnlistedDevs() //Called in Switch 2,3,4,5, 
    {
        Clear();
        WriteLine("== Developer Listing ==");
        List<Developer> devsInDb = _devRepo.GetDevelopers();
        ValidateDeveloperDatabaseData(devsInDb);
    }

    private Developer InitialDevCreationSetup() //Called in Switch 1,4 
    {
        Developer dev = new Developer();

        WriteLine("== Add Develper Menu ==");

        WriteLine("What is the Developers first name?");
        dev.FirstName = ReadLine();

        WriteLine("What is the Developers Last name?");
        dev.LastName = ReadLine();

        bool hasMadeSelection = false;

        while (!hasMadeSelection)
        {
            WriteLine("Does this Developer have a Pluralsight Account?\n" +
                "1. yes\n" +
                "2. no\n");

            string userInputPsAcct = ReadLine();

            switch (userInputPsAcct)
            {
                case "1":
                    dev.HasPluralsight = true;
                    hasMadeSelection = true;
                    break;

                case "2":
                    dev.HasPluralsight = false;
                    hasMadeSelection = true;
                    break;

                default:
                    WriteLine("Invalid Selection");
                    DTUtils.PressAnyKey();
                    break;
            }
        }

        return dev;
    }

    private void ValidateDeveloperDatabaseData(List<Developer> devsInDb)
    {
        if (devsInDb.Count > 0)
        {
            Clear();
            foreach (var dev in devsInDb)
            {
                DisplayDevData(dev);
            }
        }
        else
        {
            WriteLine("There are no Developers in the Database.");
        }
    }

    private void DisplayDevData(Developer dev)
    {
        WriteLine(dev);
    }

}