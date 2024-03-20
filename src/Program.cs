using System;
using System.ComponentModel;
using Microsoft.VisualBasic;
using System.Text;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks.Dataflow;

namespace FunctionChallenges
{
    class Program
    {
        static void Main(string[] args)
        {
            // Challenge 1: String and Number Processor
            Console.WriteLine();
            Console.WriteLine("Challenge 1: String and Number Processor");

            StringBuilder StringNumberProcessor(params object[] arr)
            {
                List<int> numList = new List<int>();
                StringBuilder str = new StringBuilder();
                for (var i = 0; i < arr.Length; i++)
                {
                    if (arr[i].GetType() == typeof(int))
                    {
                        numList.Add(Convert.ToInt32(arr[i]));
                    }
                    else
                    {
                        str.Append($"{arr[i]} ");
                    }
                }
                str.Append($"; {numList.Sum()}");
                return str;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nHello, 100, 200, World, 500, welcome, 5, to SDA");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{StringNumberProcessor("Hello", 100, 200, "World,", 500, "welcome", 5, "to SDA")}"); // Expected outcome: "Hello World; 300"





            /////////////////////////////////////////////////////////////////////////////////////////////////////
            // Challenge 2: Object Swapper
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n════════════════════════════════════════════════════\n");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Challenge 2: Object Swapper");

            string SwapObjects<T>(ref T obj1, ref T obj2)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                if (obj1 is null || obj2 is null)
                {
                    return "Please provide values";
                }

                if (obj1.GetType() == typeof(string) && obj2.GetType() == typeof(string))
                {
                    if (obj1.ToString()?.Length <= 5 || obj2.ToString()?.Length <= 5)
                    {
                        return "Error: Length must be more than 5";
                    }
                }
                else if (obj1.GetType() == typeof(int) && obj2.GetType() == typeof(int))
                {
                    if (Convert.ToInt32(obj1) <= 18 || Convert.ToInt32(obj2) <= 18)
                    {
                        return "Error: Value must be more than 18";
                    }
                }
                else
                {
                    return "Please provide objects of the same type";
                }

                (obj2, obj1) = (obj1, obj2);
                Console.ForegroundColor = ConsoleColor.Green;
                return "Objects successfully swapped";

            }

            int num1 = 25, num2 = 30;
            int num3 = 10, num4 = 30;
            string str1 = "HelloWorld", str2 = "Programming";
            string str3 = "Hi", str4 = "Programming";

            Console.WriteLine();

            Console.WriteLine($"Before: obj1 = {num1} | obj2 = {num2}");
            Console.WriteLine(SwapObjects(ref num1, ref num2)); ; // Values after swap: 30, 25
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"After: obj1 = {num1} | obj2 = {num2}");

            Console.WriteLine();


            Console.WriteLine($"Before: obj1 = {str1} | obj2 = {str2}");
            Console.WriteLine(SwapObjects(ref str1, ref str2)); // Values after swap: "Programming", "HelloWorld"
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"After: obj1 = {str1} | obj2 = {str2}");

            Console.WriteLine();

            Console.WriteLine($"Before: obj1 = {str3} | obj2 = {str4}");
            Console.WriteLine(SwapObjects(ref str3, ref str4)); // Error: Length must be more than 5
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"After: obj1 = {str3} | obj2 = {str4}");

            Console.WriteLine();

            Console.WriteLine($"Before: obj1 = {num3} | obj2 = {num4}");
            Console.WriteLine(SwapObjects(ref num3, ref num4)); // Error: Value must be more than 18
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"After: obj1 = {num3} | obj2 = {num4}");

            //SwapObjects(ref num1, ref str1); // Error: Objects must be of same types
            //SwapObjects(ref true, ref false); // Error: Unsuported type





            /////////////////////////////////////////////////////////////////////////////////////////////////////
            // Challenge 3: Guessing Game
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n════════════════════════════════════════════════════\n");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nChallenge 3: Guessing Game\n");

            void GuessingGame()
            {
                Random rnd = new Random();
                int random = rnd.Next(rnd.Next(0, 101));
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Guess a number between 1 and 100, enter (q) to quit");
                while (true)
                {
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        string? input = Console.ReadLine();
                        if (input is null || input == "")
                        {
                            Console.WriteLine($"Please enter a value");
                            continue;
                        }
                        if (input.ToLower() == "q")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"You lost the game 😈🤣");
                            break;
                        }

                        int number = int.Parse(input);
                        if (number == random)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"you have guessed the number correctly 😖😫");
                            Console.WriteLine();

                            break;
                        }
                        else if (number < random)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"Wrong, try higher");
                            continue;
                        }
                        else if (number > random)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"Wrong, try lower");
                            continue;
                        }
                    }
                    catch (Exception)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"invalid input try again");
                    }
                }
            }
            GuessingGame(); // Expected outcome: User input until the correct number is guessed or user inputs `Quit`





            /////////////////////////////////////////////////////////////////////////////////////////////////////
            // Challenge 4: Simple Word Reversal
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n════════════════════════════════════════════════════\n");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Challenge 4: Simple Word Reversal\n");

            string ReverseWords(string str)
            {
                string[] strList = str.Split(" ");
                StringBuilder reversedWordList = new StringBuilder();
                foreach (string item in strList)
                {
                    char[] stringArray = item.ToCharArray();
                    Array.Reverse(stringArray);
                    string reversedWord = new string(stringArray);
                    reversedWordList.Append($"{reversedWord} ");
                }
                return reversedWordList.ToString();
            }

            string sentence = "This is the original sentence!";
            string reversed = ReverseWords(sentence);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{sentence}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" => ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{reversed}"); // Expected outcome: "sihT si eht lanigiro !ecnetnes"
            Console.WriteLine();
            Console.WriteLine();

        }
    }
}
