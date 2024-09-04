using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex01_04
{
    class Program
    {
        static void Main()
        {
            analyzeString();
        }

        private static void analyzeString()
        {
            string userInput;
            StringBuilder resultMessage = new StringBuilder();
            bool isPalindromeResult, isDividedByThreeResult, isAlphabeticResult;
            int numberOfUpperCaseResult;

            userInput = handleUserInput();
            resultMessage.AppendLine(userInput);

            isPalindromeResult = isPalindrome(userInput);
            resultMessage.AppendLine($"{userInput} is " + (isPalindromeResult ? "a palindrome" : "not a palindrome"));

            if (IsAllDigits(userInput) == true)
            {
                isDividedByThreeResult = isDividedByThree(userInput);
                resultMessage.AppendLine($"{userInput} is " + (isDividedByThreeResult ? "divided by 3" : "not divided by 3"));
            }
            else
            {
                numberOfUpperCaseResult = numberOfUpperCase(userInput);
                resultMessage.AppendLine($"Number of uppercase letters in {userInput}: {numberOfUpperCaseResult}");

                isAlphabeticResult = isAlphabetic(userInput);
                resultMessage.AppendLine($"{userInput} is " + (isAlphabeticResult ? "in alphabetical order" : "not in alphabetical order"));
            }

            Console.WriteLine(resultMessage.ToString());
        }

        private static string handleUserInput()
        {
            string userInput;

            Console.WriteLine("Please enter a string with 8 characters that contain only letters or digits: ");
            userInput = Console.ReadLine();

            while ((!IsAllDigits(userInput) && !IsAllLetters(userInput)) || userInput.Length != 8)
            {
                Console.WriteLine("The input you entered is invalid." + Environment.NewLine + " Please try again...");
                userInput = Console.ReadLine();
            }

            return userInput;
        }

        private static bool IsAllLetters(string i_UserInput)
        {
            bool IsContainOnlyLetters = true;

            foreach (char c in i_UserInput)
            {
                if (char.IsLetter(c) == false)
                {
                    IsContainOnlyLetters = false;
                    break;
                }
            }

            return IsContainOnlyLetters;
        }

        private static bool IsAllDigits(string i_UserInput)
        {
            bool IsContainOnlyDigits = true;

            foreach (char c in i_UserInput)
            {
                if (char.IsDigit(c) == false)
                {
                    IsContainOnlyDigits = false;
                    break;
                }
            }

            return IsContainOnlyDigits;
        }

        private static bool isPalindrome(string i_UserInput)
        {
            bool isValidPalindrome = true;
            int inputLength = i_UserInput.Length;
            string substring;

            if (inputLength > 1)
            {
                if (i_UserInput[0] == i_UserInput[inputLength - 1])
                {
                    substring = i_UserInput.Substring(1, inputLength - 2);
                    isValidPalindrome = isPalindrome(substring);
                }
                else
                {
                    isValidPalindrome = false;
                }
            }

            return isValidPalindrome;
        }

        private static bool isDividedByThree(string i_UserInput)
        {
            return int.Parse(i_UserInput) % 3 == 0;
        }

        private static int numberOfUpperCase(string i_UserInput)
        {
            int counterUpperCase = 0;

            foreach (char c in i_UserInput)
            {
                if (char.IsUpper(c) == false)
                {
                    counterUpperCase++;
                }
            }

            return counterUpperCase;
        }

        private static bool isAlphabetic(string i_UserInput)
        {
            bool isValidAlphabetic = true;

            for (int i = 0; i < i_UserInput.Length - 1; i++)
            {
                if (i_UserInput[i] > i_UserInput[i + 1])
                {
                    isValidAlphabetic = false;
                    break;
                }
            }

            return isValidAlphabetic;
        }
    }
}
