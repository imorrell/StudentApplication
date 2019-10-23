/*Prorammer: Ivoire Morrell
 *Program: Student application
 *Date: 10/22/19
 *Description: The student applications stores information about 
 * students in a classroom and allows users to find out information about that student
 * 
 * 
 */


using System;

namespace StudentApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //create three different arrays that contains 
            //information about the different students
            string[] studentNames = {"Kapri Marie", "Propho Picasso", "Mike Tyson", "Halle Berry", "Darth Vadar" };
            string message = "What student would you like to get to know? (Enter 1 - 5) \n";
            int number;
            bool ok = true;

            //prompt the user to the program and display
            Console.WriteLine("Welcome to the student information application! \n");

            //use while loop to determine if user would like to gather information about
            //another user

            while (ok)
            {
                //call the display names menu method
                DisplayNamesMenu(studentNames);

                Console.WriteLine();

                //use the ValidateRange method to ensure the user is selecting from the right number range
                number = ValidateRange(message, 1, studentNames.Length + 1);

                Console.WriteLine();

                //pass the number and the student names array list to the student info method 
                //to gather more informations about the student
                StudentInfo(number, studentNames);

                //ask the user if they would like to learn about another user 
                ok = getContinue();
                Console.WriteLine();
            }
            //display exit message
            Console.WriteLine("Thanks!");
        }

        public static void StudentInfo(int number, string[] names)
        {
            string category;

            //create arrays that will store user information
            string[] homeTown = {"Detroit, MI", "Lansing, MI", "Brownsville, NY", "Cleveland, OH", "Tatooine" };
            string[] skill = {"Public Speaking", "Writing", "Boxing", "Acting", "The Force" };

            //initalize bool to track whether or not the user accessed the right category
            bool rightCategory = false;

            //create an index variable to withdrawl the right student from the list
            int index = number - 1;

            //Display the student that the user selected
            Console.WriteLine("Student " + number + " is "
                + names[index] + ". What would you like to know about " + names[index] + "? (enter hometown or skill)" + "\n");

            //use while loop to validate the users input
            while (rightCategory == false)
            {
                category = Console.ReadLine();

                Console.WriteLine();

                //check to see if the category equals Hometown or Skills
                if (category.Equals("hometown", StringComparison.OrdinalIgnoreCase))
                {
                    //display the students name along with their hometown
                    Console.WriteLine(names[index] + " is from " + homeTown[index] + "\n");
                    rightCategory = true;
                }
                else if (category.Equals("skill", StringComparison.OrdinalIgnoreCase))
                {
                    //display the students name along with their hometown
                    Console.WriteLine(names[index] + "'s skill is " + skill[index] + "\n");
                    rightCategory = true;
                }
                else
                {
                    //user entered the wrong entry. Prompt them to try again
                    Console.WriteLine("That data does not exist. Please try again. (enter “hometown” or “skill”) \n");
                    rightCategory = false;
                }

            }

        }

        //The DisplayNamesMenu print out the name of each student
        public static void DisplayNamesMenu(string [] names)
        {
            Console.WriteLine("Student list");
            Console.WriteLine("-------------");

            //use for loop to display the menu
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine((i+1 + ". ") + names[i]);
            }
        }

        public static int ValidateRange(string message, int min, int max)
        {
            int number = ParseString(message);

            if (number >= min && number < max)
            {
                return number;
            }
            else
            {
                //This student does not exist
                Console.WriteLine("This student does not exist.\n");
                return ValidateRange(message, min, max);
            }
        }

        public static int ParseString(string message)
        {
            try
            {
                string input = GetUserInput(message);
                int number = int.Parse(input);
                return number;
            }
            catch (FormatException)
            {
                Console.WriteLine("Bad input. We need a number \n");
                return ParseString(message);
            }
            
        }

        public static string GetUserInput(string message)
        {
            string input;

            Console.WriteLine(message);

            input = Console.ReadLine();

            return input;
        }

        public static bool getContinue()
        {
            //create variables
            String choice;
            bool ok = true;
            bool result = true;

            //create while loop to determine if user wants to continue
            while (ok)
            {
                Console.WriteLine("Would you like to learn about another student? (y/n): \n");

                //retrieve user input
                choice = Console.ReadLine();

                //determine the users input and return corresponding message
                if (choice.Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    //user wants to continue. exit the while loop and return true
                    ok = false;
                    result = true;
                }
                else if (choice.Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    //user does not want to continue
                    ok = false;
                    result = false;
                }
                else
                {
                    //user did not enter y or n
                    Console.WriteLine("Error! Please enter Y or N. Please enter correct input \n");
                }

            }

            return result;
        }

    }
}
