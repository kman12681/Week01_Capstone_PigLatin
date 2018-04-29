using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week01_PigLatin
{
    class Program
    {
        static void Main(string[] args)
        {
            GetWelcome();
            bool again = true;
            while (again)
            {
                RunTranslation();
                again = GetContinue();
            }
            GetGoodbye();
        }

        static void RunTranslation() // method call for user input

        {
            Console.Write("Enter a sentence: ");
            string sentence = Console.ReadLine(); 
            string vowels = "aeiouAEIOU";

            Console.WriteLine();
            Console.WriteLine("---Translated to Pig Latin is---\n");

            TranslatePigLatin(sentence, vowels); // method call to do the translation

        }

        static void TranslatePigLatin(string pork, string beef)

        {
            string[] words = pork.Split(' '); // splits user input at each " " into a string array of words             

            foreach (string part in words) // and then runs the following series of steps on each word in the array
            {

                if (HasSpecialCharOrNum(part)) // method to check if each word has a special character in it
                {
                    Console.Write($"{part} "); // if yes, the word is printed and skips translation
                }
                else if (!HasNoVowels(part))
                {
                    Console.Write($"{part} ");
                }

                else if (!HasSpecialCharOrNum(part))                   

                    for (int i = 0; i < part.Length; i++)

                    // checks for the number of letters (indexes) in each word
                    {
                        for (int j = 0; j < beef.Length; j++) // compares each letter of the word against each letter in our "word" of vowels
                        {
                            if (part[i] == beef[j]) // at the first indexed occurrence that matches any vowel, continue on
                            {
                                if (i == 0) // if the first occurrence is at the beginning of the word, write the word with "way" appended.

                                {
                                    Console.Write($"{part}way ");
                                    i = part.Length;
                                    j = beef.Length;
                                }
                                else // if the first occurrence is not at the beginning of the word, make this spot the new beginning of the word,
                                     // and move the letters before the vowel to the end, and append "ay"
                                {
                                    string vowelForward = part.Substring(i, part.Length - i);

                                    string wordBegin = part.Substring(0, i);

                                    Console.Write($"{vowelForward}{wordBegin}ay ");

                                    i = part.Length;
                                    j = beef.Length;
                                }
                            }

                        }
                    }

            }
            return;
        }

        public static bool HasSpecialCharOrNum(string input)
        {
            string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,0123456789""";
            foreach (var item in specialChar)
            {
                if (input.Contains(item)) return true;
            }

            return false;
        }

        public static bool HasNoVowels(string input)
        {
            string specialChar = "aeiouAEIOU";
            foreach (var item in specialChar)
            {
                if (input.Contains(item)) return true;
            }

            return false;
        }

        static void GetWelcome()

        {
            Console.WriteLine("\t=======================");
            Console.WriteLine("\t|     Amazing         |\n\t|       Pig           |\n\t|         Latin       |\n\t|          Translator |");
            Console.WriteLine("\t=======================\n");
        }

        static bool GetContinue()

        {
            while (true)
            {
                //ask user if they want to continue
                Console.WriteLine();
                Console.Write("\nDo you want to translate another sentence (y/n)? ");
                //get string input
                string input = Console.ReadLine();
                Console.WriteLine();

                //if it's yes, return true
                if (input == "y" || input == "Y")
                {
                    return true;
                }
                //if it's no, return false
                else if (input == "n" || input == "N")
                {
                    return false;
                }
                //anything else, ask again
                Console.WriteLine("Not a valid entry\n");
            }
        }

        static void GetGoodbye()

        {
            Console.WriteLine("hanktay ouyay orfay layingpay!");
            Console.ReadLine();
        }
    }
}






