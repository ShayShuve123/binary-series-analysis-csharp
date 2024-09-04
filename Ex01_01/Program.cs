using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex01_01
{
    // $G$ RUL-999 (-10) The name format of the main folder, is not as required.
    // $G$ THE-001 (-3) The explanation for the file being an assembly is lacking. The file is an assembly because it can be analysed by ILDASM.
    // $G$ THE-999 (0) Good Job!, Keep up with the clean code.
    class Program
    {
        static string[] binaryNumbers = new string[3];
        static int[] decimalNumbers = new int[3];
        static void Main()
        {
            binarySeries();
        }
        // $G$ CSS-027 (-2) Unnecessary blank lines.
        private static void binarySeries()
        {
            handleUserInput();

            printAscendingArrayOfDecimal(decimalNumbers);

            average(decimalNumbers);

            longestBitSequence(binaryNumbers);

            numberOfPalindromes(binaryNumbers);

            highestOnesLowestZeros(binaryNumbers);
        }
        // $G$ CSS-006 (-3) Missing blank line, after "if / else" block.
        private static bool inputIsValidNumber(string i_Input)
        {
            bool isValidNumber = true;

            if (i_Input.Length != 7)
            {
                isValidNumber = false;
            }
            foreach (char c in i_Input)
            {
                if (c != '0' && c != '1')
                {
                    isValidNumber = false;
                }
            }
            return isValidNumber;
        }

        private static int convertToDecimal(string i_BinaryString)
        {
            int decimalValue = 0;

            for (int i = 0; i < i_BinaryString.Length; i++)
            {
                decimalValue += int.Parse(i_BinaryString[i_BinaryString.Length - 1 - i].ToString()) * (int)Math.Pow(2, i);
            }

            return decimalValue;
        }
        // $G$ NTT-999 (-10) You should have used Environment.NewLine instead of "\n".
        private static void handleUserInput()
        {
            int numberOfValidNumbers = 0;
            string userInput;
            Console.WriteLine("Please enter 3 numbers with 7 digits each:");
            while (numberOfValidNumbers != 3)
            {
                userInput = Console.ReadLine();
                if (inputIsValidNumber(userInput) == false)
                {
                    Console.WriteLine("The input you entered is invalid.\n Please try again...");
                }
                else
                {
                    binaryNumbers[numberOfValidNumbers] = userInput;
                    decimalNumbers[numberOfValidNumbers] = convertToDecimal(userInput);
                    numberOfValidNumbers++;
                }
            }
        }

        private static void printAscendingArrayOfDecimal(int[] i_ArrayOfDecimalNumber)
        {
            Array.Sort(i_ArrayOfDecimalNumber);
            Array.Reverse(i_ArrayOfDecimalNumber);
            Console.Write("The Ascending Order Is: ");

            for (int i = 0; i < i_ArrayOfDecimalNumber.Length; i++)
            {
                Console.Write(String.Format("{0}", i_ArrayOfDecimalNumber[i]));

                if (i < i_ArrayOfDecimalNumber.Length - 1)
                {
                    Console.Write(", ");
                }
            }

            Console.WriteLine();
        }

        private static void average(int[] i_DecimalArr)
        {
            float sum = i_DecimalArr.Sum();
            float avg = sum / i_DecimalArr.Length;

            StringBuilder sb = new StringBuilder();

            if (avg % 1 == 0)
            {
                sb.AppendFormat("Decimal numbers average: {0}", (int)avg);
            }
            else
            {
                sb.AppendFormat("Decimal numbers average: {0:F2}", avg);
            }

            Console.WriteLine(sb.ToString());
        }

        private static void longestBitSequence(string[] i_BinaryArr)
        {
            int maxLengthTotal = 0, maxIndex = -1;

            for (int i = 0; i < i_BinaryArr.Length; i++)
            {
                int currentLength = 1, maxLength = 1;
                char currentChar = i_BinaryArr[i][0];

                for (int j = 1; j < i_BinaryArr[i].Length; j++)
                {
                    if (currentChar == i_BinaryArr[i][j])
                    {
                        currentLength++;
                    }
                    else
                    {
                        if (maxLength < currentLength)
                        {
                            maxLength = currentLength;
                        }
                        currentChar = i_BinaryArr[i][j];
                        currentLength = 1;
                    }
                }

                if (maxLength < currentLength)
                {
                    maxLength = currentLength;
                }

                if (maxLengthTotal < maxLength)
                {
                    maxLengthTotal = maxLength;
                    maxIndex = i;
                }
            }

            Console.WriteLine($"Longest sequence:{maxLengthTotal} ({i_BinaryArr[maxIndex]})");
        }

        private static void numberOfPalindromes(string[] i_BinaryArr)
        {
            int PalindromesCount = 0;
            int start, end;
            int flagNotPalindromes = 0;
            List<string> palindromesList = new List<string>();
            StringBuilder sb = new StringBuilder();


            for (int i = 0; i < i_BinaryArr.Length; i++)
            {
                flagNotPalindromes = 0;
                start = 0;
                end = i_BinaryArr[i].Length - 1;

                while (start < end)
                {
                    if (!((i_BinaryArr[i][start].Equals(i_BinaryArr[i][end]))))
                    {
                        flagNotPalindromes = 1;
                        break;
                    }

                    start++;
                    end--;
                }

                if (flagNotPalindromes == 0)
                {
                    palindromesList.Add(i_BinaryArr[i]);
                    PalindromesCount++;
                }
            }

            sb.Append("Number of palindromes: ");
            if (PalindromesCount == 0)
            {
                sb.Append("None of the numbers are palindromes");
            }
            else if (PalindromesCount == 3)
            {
                sb.Append("All the numbers are polindroms");
            }
            else
            {
                sb.Append($"{PalindromesCount} (");
                sb.Append(string.Join(", ", palindromesList));
                sb.Append(")");
            }

            Console.WriteLine(sb.ToString());
        }
        // $G$ CSS-007 (-3) Missing blank line, after "for" block.
        private static void highestOnesLowestZeros(string[] i_BinaryArr)
        {
            int maxOnes = int.MinValue, minZeros = int.MaxValue, maxIndex = -1;

            for (int i = 0; i < i_BinaryArr.Length; i++)
            {
                int onesCount = 0;
                int zerosCount = 0;

                foreach (char digit in i_BinaryArr[i])
                {
                    if (digit == '1')
                    {
                        onesCount++;
                    }
                    else if (digit == '0')
                    {
                        zerosCount++;
                    }
                }

                if (onesCount > maxOnes || (onesCount == maxOnes && zerosCount < minZeros))
                {
                    maxOnes = onesCount;
                    minZeros = zerosCount;
                    maxIndex = i;
                }
            }
            int decimalValue = convertToDecimal(i_BinaryArr[maxIndex]);
            Console.WriteLine($"highest Ones Lowest Zeros: {decimalValue} (binary : {i_BinaryArr[maxIndex]})");
        }
    }
}