using System;

namespace Ex01_02
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GenerateLetterTree();
        }
        // $G$ NTT-006 (-10) You should have used StringBuilder here.
        public static void GenerateLetterTree()
        {
            char currentChar = 'A';
            int numOfLines = 5;

            for (int i = 1; i <= numOfLines; i++)
            {
                Console.Write(i + " ");
                Console.Write(new string(' ', (numOfLines - i) * 2));

                int numOfCharsInRow = 2 * i - 1;
                for (int j = 0; j < numOfCharsInRow; j++)
                {
                    if (currentChar <= 'Z')
                    {
                        Console.Write(currentChar + " ");
                        currentChar++;
                    }
                }

                Console.WriteLine();
            }

            for (int i = 6; i <= 7; i++)
            {
                Console.WriteLine(i + " " + new string(' ', 7) + "|Z|");
            }
        }
    }
}
