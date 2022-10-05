using System.Drawing;
using System.Runtime.Intrinsics.X86;
using System;

namespace Dice_Roller_Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool goAgain = true;
            //Don't worry about negative numbers for this lab
            Console.WriteLine("Welcome to the Totally Legit Casino!");
            
            while (goAgain == true)
            {
                Console.WriteLine("How many sides should each die have?");
                int input = 0;
                //Exception handling if the user inputs anything other than a number
                try
                {
                    string diceSides = Console.ReadLine();
                    input = int.Parse(diceSides);
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Input must be a numerical value.");
                    continue;
                }

                int roll = RandomRoller(input);
                int roll2 = RandomRoller(input);

                Console.WriteLine(roll);
                Console.WriteLine(roll2);
                int total = roll + roll2;

                Console.WriteLine("You rolled: " + roll + " " + roll2 + " Total: " + total);
                Console.WriteLine(SixSideCombo(roll, roll2, total));

                goAgain = AskToContinue();
            }
        }
        //Method to randomly roll
        public static int RandomRoller(int diceSides)
        {            
            Random rand = new Random();
            int r = rand.Next(1, diceSides + 1);
            return r;            
        }

        //Method to ask the user if they want to keep using the application
        public static bool AskToContinue()
        {
            Console.WriteLine("Would you like to roll again? Y/N");
            string input = Console.ReadLine().ToLower();

            if (input == "y")
            {
                return true;
            }
            else if (input == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Input invalid. Please try again.");
                return AskToContinue();
            }
        }
        //Method that gives out a phrase when rolls generate a specific combination/total
        public static string SixSideCombo(int roll, int roll2, int total)
        {            
            if (roll == 1 && roll2 == 1)
            {
                Console.WriteLine("Snake Eyes");
            }
            else if (roll == 1 && roll2 == 2 || roll == 2 && roll2 == 1)
            {
                Console.WriteLine("Ace Deuce");
            }
            else if (roll == 6 && roll2 == 6)
            {
                Console.WriteLine("Box Cars");
            }

            if (total == 7 || total == 11)
            {
                Console.WriteLine("Win!");
            }
            else if(total == 2 || total == 3 || total == 12)
            {
                Console.WriteLine("Craps!");
            }
            return"";
        }
    }
}

//What will the application do?
//The application asks the user to enter the number of sides for a pair of dice. 
//If you have learned about exception handling, make sure the user can only enter numbers

//The application prompts the user to roll the dice.

//The application “rolls” two n-sided dice, displaying the results of each along with a total

//For 6-sided dice, the application recognizes the following dice combinations and displays a message for each. It should not output this for any other size of dice.
//Snake Eyes: Two 1s
//Ace Deuce: A 1 and 2
//Box Cars: Two 6s
//Win: A total of 7 or 11
//Craps: A total of 2, 3, or 12 (will also generate another message!)

//The application asks the user if he/she wants to roll the dice again.

//Build Specifications:
//Create a static method to generate the random numbers.
//Proper method header: 2 points
//Program generates random numbers validly within the user-specified range: 1 point
//Method returns meaningful value of proper type: 1 point

//Create a static method for six - sided dice that takes two dice values as parameters, and returns a string for one of the valid combinations(e.g.Snake Eyes, etc.) or an empty string if the dice don’t match one of the combinations.

//Create a static method to implement output for different dice combinations
//Proper method header: 2 points
//Method recognizes all specified cases correctly: 1 point
//Method displays properly to Console: 1 point

//Application takes all user input correctly: 1 point

//Application loops properly: 1 point

//Hints:
//Use the Random class to generate a random number.

//Extra Challenges:
//Come up with a set of winning combinations for other dice sizes besides 6.
