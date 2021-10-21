using KomodoProjectLibrary;
using KomodoPOCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoConsole
{
    class ConsoleUI
    {
        private DeveloperRepo _newDevRepo = new DeveloperRepo();
        
        //Method that starts UI
        public void Run()
        {
            SeedDevelopersList();
            Menu();
        }

        //Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //display options to user
                Console.WriteLine("select a menu option:\n" + 
                    "1. Create new Developer\n" + 
                    "2. view all content\n" + 
                    "3. View Content by Title\n" + 
                    "4. Update Existing Content\n" + 
                    "5. Delete Existing Content\n" + 
                    "6. Exit");

                //get users input
                string input = Console.ReadLine();
                //Evalutate user imput then act
                switch (input)
                {
                    case "1":
                        CreateNewDev();
                        
                        break;
                    case "2":
                        DisplayDevList();
                        
                        break;
                    case "3":
                        DisplayDevById();
                        
                        break;
                    case "4":
                        UpdateDevList();
                       
                        break;
                    case "5":
                        DeleteDevMember();
                        
                        break;
                    case "6":
                        //exit
                        Console.WriteLine("Confirm you want to end program (Y/N)");
                        string Leave = Console.ReadLine().ToLower();
                        if (Leave == "y")
                        {
                            keepRunning = false;
                            Console.Clear();
                            Console.WriteLine("Thank you good bye.");
                        }
                        else
                        {
                            keepRunning = true;
                        }
                        break;
                    default:
                        Console.WriteLine("please enter valid option");
                        break;


                }
                Console.WriteLine("Please Press any key to continue...");
                Console.ReadKey();
                Console.Clear();

            }
        }
        //create add dev to list
        private void CreateNewDev()
        {
            Console.Clear();
            bool keepRunning = true;
            while (keepRunning)
            {
                DeveloperPOCO newDeveloper = new DeveloperPOCO();
                //developer ID

                //ERROR if string has letters int.parse fails

                Console.WriteLine("please enter developers ID.");
                string devIdString = Console.ReadLine();
                newDeveloper.DeveloperId = int.Parse(devIdString);
                //developer first name
                Console.WriteLine("Please enter developers first Name");
                newDeveloper.FirstName = Console.ReadLine();
                //developer last name
                Console.WriteLine("Please enter developers last Name");
                newDeveloper.LastName = Console.ReadLine();
                
                bool keepRunning1 = true;
                while (keepRunning1)
                {
                    //access to pluralsight
                    
                    Console.WriteLine("Does developer have Puralsight access? (y/n)");
                    string pluralTrue = Console.ReadLine().ToLower();
                    if (pluralTrue == "y")
                    {
                        newDeveloper.PluralSightAccess = true;
                        keepRunning1 = false;
                    }
                    else if (pluralTrue == "n")
                    {
                        newDeveloper.PluralSightAccess = true;
                        keepRunning1 = false;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Please Answer (y/n)");
                        keepRunning1 = true;
                    }
                    
                    
                }
                Console.Clear();
                //check for accuracy
                Console.WriteLine(" " + newDeveloper.DeveloperId + " DeveloperId\n" + 
                    " " + newDeveloper.FirstName + ", " + newDeveloper.LastName + " (first name, last name)\n" +
                    " " + "Plural Sight Access = " + newDeveloper.PluralSightAccess + "\n Is this Correct (Y/N)?");
                //submit to DevRepo or restart
                string correctDevInfo = Console.ReadLine().ToLower();
                if (correctDevInfo == "y")
                {
                    keepRunning = false;
                    _newDevRepo.AddDeveloper(newDeveloper);
                }
                else
                {
                    keepRunning = true;
                }

            }
            
        }
        //view current dev list
        private void DisplayDevList()
        {
            Console.Clear();

            List<DeveloperPOCO> listOfDevelopers = _newDevRepo.GetDeveloper();

            foreach(DeveloperPOCO newDeveloper in listOfDevelopers)
            {
                Console.WriteLine($"Developer ID: {newDeveloper.DeveloperId}\n" +
                    $"Developer Name: {newDeveloper.FirstName}, {newDeveloper.LastName}\n" +
                    $"PluralSight Access: {newDeveloper.PluralSightAccess}");
            }
        }
        //view existing dev list
        private void DisplayDevById()
        {
            Console.Clear();
            //promt user
            Console.WriteLine("Enter Developers ID");
            
            //get user input
            string devIdString = Console.ReadLine();
            Console.Clear();
            bool isParsable = int.TryParse(devIdString, out int result);
            DeveloperPOCO DeveloperId = _newDevRepo.GetDeveloperById(result);
            if (DeveloperId != null)
            {
                Console.WriteLine($"Developer ID: {DeveloperId.DeveloperId}\n" +
                    $"Developer Name: {DeveloperId.FirstName}, {DeveloperId.LastName}\n" +
                    $"PluralSight Access: {DeveloperId.PluralSightAccess}");
            }
            else
            {
                Console.WriteLine("Incorrect ID.");
            }


        }
        //update dev list
        private void UpdateDevList()
        {
            //display the content
            DisplayDevList();
            //ask for the Developer
            Console.WriteLine("\n Enter Dev ID you need to update.");
            //get the dev
            string devIdString = Console.ReadLine();
            bool isParsable = int.TryParse(devIdString, out int result);
            //build new object
            DeveloperPOCO newDeveloper = new DeveloperPOCO();
            //developer ID

            //ERROR if string has letters int.parse fails

            Console.WriteLine("please enter developers ID.");
            string devIdString1 = Console.ReadLine();
            newDeveloper.DeveloperId = int.Parse(devIdString1);
            //developer first name
            Console.WriteLine("Please enter developers first Name");
            newDeveloper.FirstName = Console.ReadLine();
            //developer last name
            Console.WriteLine("Please enter developers last Name");
            newDeveloper.LastName = Console.ReadLine();

            bool keepRunning1 = true;
            while (keepRunning1)
            {
                //access to pluralsight

                Console.WriteLine("Does developer have Puralsight access? (y/n)");
                string pluralTrue = Console.ReadLine().ToLower();
                if (pluralTrue == "y")
                {
                    newDeveloper.PluralSightAccess = true;
                    keepRunning1 = false;
                }
                else if (pluralTrue == "n")
                {
                    newDeveloper.PluralSightAccess = true;
                    keepRunning1 = false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please Answer (y/n)");
                    keepRunning1 = true;
                }

                _newDevRepo.UpdateDevInfo(result, newDeveloper);


            }
            Console.Clear();
            //check for accuracy
            Console.WriteLine(" " + newDeveloper.DeveloperId + " DeveloperId\n" +
                " " + newDeveloper.FirstName + ", " + newDeveloper.LastName + " (first name, last name)\n" +
                " " + "Plural Sight Access = " + newDeveloper.PluralSightAccess + "\n Is this Correct (Y/N)?");
            //submit to DevRepo or restart
            string correctDevInfo = Console.ReadLine().ToLower();
            
        }
        //delete dev from list
        private void DeleteDevMember()
        {
            
            DisplayDevById();

            //get the DevID they want to remove
            Console.WriteLine("\n Confirm Developer ID you want to remove,\n or (n) to cancel ");
            string devIdString = Console.ReadLine();
            bool isParsable = int.TryParse(devIdString, out int result);

            //Call the delet Method
            bool wasDeleted = _newDevRepo.RemoveDeveloper(result);
            // if the contect was deleted ,result
            if (wasDeleted)
            {
                Console.WriteLine("Developer deleted.");
            }
            else
            {
                Console.WriteLine("Action could not be deleted.");
            }
            //otherwise cant be deleted

        }
        //see method
        private void SeedDevelopersList()
        {
            DeveloperPOCO DevMember1 = new DeveloperPOCO(8675309, "John", "Adams", true);
            DeveloperPOCO DevMember2 = new DeveloperPOCO(4099940, "Tim", "Smith", true);
            DeveloperPOCO DevMember3 = new DeveloperPOCO(1231232, "Hanna", "Harley", false);

            _newDevRepo.AddDeveloper(DevMember1);
            _newDevRepo.AddDeveloper(DevMember2);
            _newDevRepo.AddDeveloper(DevMember3);
        }


    }

}
