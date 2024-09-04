using System;
using System.Text;

namespace Ex01_03
{
    public class Program
    {
        public static void Main()
        {
            PrintTree();
        }

        public static void PrintTree()
        {
            string userInput;
            int i_TotalHeight = 0;

            do
            {
                Console.Write("Please enter the tree height (max 15): ");
                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out i_TotalHeight) == false || i_TotalHeight < 3 || i_TotalHeight > 15)
                {
                    Console.WriteLine("Invalid input, please try again.");
                }

            } while (i_TotalHeight < 3 || i_TotalHeight > 15); 

            if (i_TotalHeight == 3)
            {
                PrintSpecialTreeForHeightThree();
            }
            else
            {
                PrintStandardTree(i_TotalHeight);
            }
        }

        public static void PrintSpecialTreeForHeightThree()
        {
            Console.WriteLine("1     A");
            Console.WriteLine("2    |B|");
            Console.WriteLine("3    |B|");
        }

        public static void PrintStandardTree(int i_TotalHeight)
        {
            int treeHeight = i_TotalHeight - 2;

            StringBuilder treeBuilder = new StringBuilder();
            int middlePosition = treeHeight - 1;

            char currentChar = 'A';
            for (int i_RowIndex = 1; i_RowIndex <= treeHeight; i_RowIndex++)
            {
                treeBuilder.Append(i_RowIndex + "    ");
                treeBuilder.Append(' ', (middlePosition - i_RowIndex + 1) * 2);

                for (int i_CharIndex = 1; i_CharIndex <= (2 * i_RowIndex - 1); i_CharIndex++)
                {
                    treeBuilder.Append(currentChar);
                    treeBuilder.Append(' ');

                    if (currentChar < 'Z')
                    {
                        currentChar++;
                    }
                    else
                    {
                        currentChar = 'A';
                    }
                }

                treeBuilder.AppendLine();
            }

            int trunkStartPosition = (2 * middlePosition) - 1;
            for (int i_TrunkIndex = 0; i_TrunkIndex < 2; i_TrunkIndex++)
            {
                treeBuilder.Append((treeHeight + i_TrunkIndex + 1) + "    ");
                treeBuilder.Append(' ', trunkStartPosition);
                treeBuilder.Append("|");
                treeBuilder.Append(currentChar);
                treeBuilder.Append("|");
                treeBuilder.AppendLine();
            }

            Console.Write(treeBuilder.ToString());
        }
    }
}
