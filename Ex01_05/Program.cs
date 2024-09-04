using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex01_05
{
    class Program
    {
        static void Main()
        {
            runStatistics();
        } 

        private static string handleUserInput()
        {
            string userInput;

            Console.WriteLine("Please enter an integer number with 8 digits:");
            userInput = Console.ReadLine();

            while (userInput.Length != 8 || !int.TryParse(userInput, out int result) || result < 0)
            {
                Console.WriteLine("The input you entered is invalid.\n Please try again...");
                userInput = Console.ReadLine();
            }

            return userInput;
        }

        private static int countDigitSmallerThanUnitNumber(string i_UserInput)
        {
            char unitsNumber = i_UserInput[i_UserInput.Length - 1];
            int counterOfNumberSmallerThanUnitsNumber = 0;

            for (int i = 0; i < i_UserInput.Length - 1; i++)
            {
                if (i_UserInput[i] < unitsNumber)
                {
                    counterOfNumberSmallerThanUnitsNumber++;
                }
            }

            return counterOfNumberSmallerThanUnitsNumber;
        }

        private static int countDigitDividedByThree(string i_UserInput)
        {
            int counterNumberDividedByThree = 0;

            foreach (char digit in i_UserInput)
            {
                if (int.Parse(digit.ToString()) % 3 == 0)
                {
                    counterNumberDividedByThree++;
                }
            }

            return counterNumberDividedByThree;
        }

        private static int differenceBetweenMaxAndMinDigits(string i_UserInput)
        {
            int minNumber = int.MaxValue, maxNumber = int.MinValue;

            for (int i = 0; i < i_UserInput.Length; i++)
            {
                int currentNumber = int.Parse(i_UserInput[i].ToString());

                minNumber = Math.Min(minNumber, currentNumber);
                maxNumber = Math.Max(maxNumber, currentNumber);
            }

            return maxNumber - minNumber;
        }

        private static int countUniqueDigits(string i_UserInput)
        {
            int counterUniqueDigits = 0;
            bool isUnique = true;

            for (int i = 0; i < i_UserInput.Length; i++)
            {
                isUnique = true;
                for (int j = 0; j < i_UserInput.Length; j++)
                {
                    if (i_UserInput[i] == i_UserInput[j] && i != j)
                    {
                        isUnique = false;
                        break;
                    }
                }

                if (isUnique == true)
                {
                    counterUniqueDigits++;
                }
            }

            return counterUniqueDigits;
        }

        private static void runStatistics()
        {
            string userInput;
            int amountOfNumberSmallerThanUnitsNumber, amountOfNumberDividedByThree, differenceBetweenDigits, amountOfUniqueDigits;

            userInput = handleUserInput();
            amountOfNumberSmallerThanUnitsNumber = countDigitSmallerThanUnitNumber(userInput);
            amountOfNumberDividedByThree = countDigitDividedByThree(userInput);
            differenceBetweenDigits = differenceBetweenMaxAndMinDigits(userInput);
            amountOfUniqueDigits = countUniqueDigits(userInput);

            Console.WriteLine(String.Format("The amount of numbers in {0} that are smaller than the unit digit ({1}) are {2}.{3}" +
                              "The amount of numbers in {0} that are divided by three are {4}.{3}" +
                              "The difference between the largest and smallest digits in {0} is {5}.{3}" +
                              "The amount of unique digits in {0} is {6}.",
                              userInput,
                              userInput[userInput.Length - 1],
                              amountOfNumberSmallerThanUnitsNumber,
                              Environment.NewLine,
                              amountOfNumberDividedByThree,
                              differenceBetweenDigits,
                              amountOfUniqueDigits));
        }

    }
}
