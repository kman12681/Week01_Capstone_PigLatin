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

        static void RunTranslation()

        {
            string sentence = "";
            string vowels = "aeiouAEIOU";

            do
            {
                Console.Write("Enter a word or sentence: ");
                sentence = Console.ReadLine();

            } while (EmptyTest(sentence));


            GetThinking();                                                 // method to display thinking header           


            TranslatePigLatin(sentence, vowels);                           // method call to do the translation        

        }

        static void TranslatePigLatin(string pork, string beef)

        {
            string[] words = pork.Split(' ');                              // splits user input at each space into a string array of words 
            Console.WriteLine($"\"{pork}\"");
            Console.WriteLine();
            Console.WriteLine("becomes:\n");

            foreach (string part in words)                                 // and then runs the following series of steps on each word in the array
            {
                if (HasSpecialCharOrNum(part))                             // method to check if each word has a special character in it
                {
                    Console.Write($"{part} ");                             // if yes, the word is printed and skips translation
                }
                else if (!HasNoVowels(part))                               // method to check is word has no vowels at all, if so prints word and skips translation
                {
                    Console.Write($"{part} ");
                }

                else if (!HasSpecialCharOrNum(part))

                    for (int i = 0; i < part.Length; i++)                  // checks for the number of letters (indexes) in each word
                    {
                        for (int j = 0; j < beef.Length; j++)              // compares each letter of the word against each letter in our "word" of vowels
                        {

                            if (part[i] == beef[j])                        // at the first indexed occurrence that matches any vowel, continue on

                                if (i == 0)                                // if the first occurrence is at the beginning of the word, write the word with "way" appended.


                                    if (CheckAllUpperCase(part, part.Length - 1))

                                    {
                                        Console.Write($"{part}WAY ");
                                        i = part.Length;
                                        j = beef.Length;
                                        continue;
                                    }
                                    else if (!CheckTitleCase(part, 0))          // method to check if first letter of word is not uppercase.
                                    {
                                        Console.Write($"{part}way ");
                                        i = part.Length;
                                        j = beef.Length;
                                    }
                                    else
                                    {
                                        Console.Write($"{part.Substring(0, 1).ToUpper()}{part.Substring(1)}way ");  //  If uppercase, translation maintains uppercase in first index.
                                        i = part.Length;
                                        j = beef.Length;
                                    }


                                else

                                {
                                    if (CheckAllUpperCase(part, part.Length - 1))

                                    {
                                        string vowelForward = part.Substring(i, part.Length - i).ToUpper();
                                        string wordBegin = part.Substring(0, i).ToUpper();
                                        Console.Write($"{vowelForward}{wordBegin}AY ");
                                        i = part.Length;
                                        j = beef.Length;
                                        continue;
                                    }

                                    else if (!CheckTitleCase(part, 0))
                                    {
                                        string vowelForward = part.Substring(i, part.Length - i);

                                        string wordBegin = part.Substring(0, i);

                                        Console.Write($"{vowelForward}{wordBegin}ay ");
                                    }
                                    else
                                    {

                                        string vowelForward = part.Substring(i, part.Length - i).ToLower();
                                        string start = part.Substring(0, 1).ToUpper();

                                        string wordBegin = part.Substring(0, i).ToLower();

                                        Console.Write($"{start}{vowelForward}{wordBegin}ay ");
                                    }
                                    i = part.Length;
                                    j = beef.Length;
                                }
                        }
                    }

            }
            return;
        }
        public static bool EmptyTest(string chicken)                    // method to verify that text was entered - checks for spaces and tabs
        {
            string turkey = chicken.TrimStart(' ');

            if (String.IsNullOrEmpty(turkey))
                return true;
            else if (chicken.Contains('\t'))
                return true;
            else
                return false;
        }

        public static bool HasSpecialCharOrNum(string input)
        {
            string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;<>_,0123456789""";
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

        public static bool CheckAllUpperCase(string sheep, int lamb)
        {
            {
                if (Char.IsUpper(sheep, lamb))
                    return true;
            }
            return false;
        }

        public static bool CheckTitleCase(string cow, int goat)
        {
            {
                if (Char.IsUpper(cow, goat))
                    return true;
            }
            return false;
        }



        static void GetWelcome()

        {
            Console.WriteLine("\t=======================");
            Console.WriteLine("\t|     Amazing         |\n\t|       Pig           |\n\t|         Latin       |\n\t|          Translator |");
            Console.WriteLine("\t=======================\n");
        }

        static void GetThinking()
        {
            Console.WriteLine();
            Console.WriteLine("___________________");
            Console.WriteLine();
            Console.WriteLine("    thinking.....");
            Console.WriteLine("___________________");
            Console.WriteLine();
            Console.WriteLine();
        }

        static bool GetContinue()

        {
            while (true)
            {
                //ask user if they want to continue
                Console.WriteLine();
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

            Console.WriteLine("______________________________");
            Console.WriteLine();
            Console.WriteLine("hanktay ouyay orfay layingpay!");
            Console.WriteLine("______________________________");
            Console.WriteLine();
            Console.WriteLine();
            Console.ReadLine();
        }
    }




}







