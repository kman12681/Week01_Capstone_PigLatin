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

                GetPigLatin();

                again = GetContinue();
            }

            GetGoodbye();
        }

        static void GetPigLatin()

        {
            Console.Write("Enter a word: ");
            string word = Console.ReadLine().ToLower();

            string vowels = "aeiou";

            Console.WriteLine();
            Console.WriteLine("---Translated to Pig Latin is---\n");
            for (int i = 0; i < word.Length; i++)
            {
                for (int j = 0; j < vowels.Length; j++)
                {
                    if (word[i] == vowels[j])
                    {
                        if (i == 0)
                        {
                            Console.WriteLine($"{word}way\n");
                            i = word.Length;
                            j = vowels.Length;
                        }
                        else
                        {
                            string newWord = word.Substring(i, word.Length - i);

                            string start = word.Substring(0, i);

                            Console.WriteLine($"{newWord}{start}ay\n");
                            i = word.Length;
                            j = vowels.Length;
                        }
                    }
                }
            }
            
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
                Console.Write("Do you want to translate another word (y/n)? ");
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
