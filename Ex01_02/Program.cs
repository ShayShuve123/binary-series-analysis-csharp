using System;
using System.Text; 

namespace Ex01_02
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GenerateLetterTree();
        }

        public static void GenerateLetterTree()
        {
            char currentChar = 'A';
            int numOfLines = 5;

            StringBuilder treeBuilder = new StringBuilder(); 

            for (int i = 1; i <= numOfLines; i++)
            {
                treeBuilder.Append(i + " "); 
                treeBuilder.Append(new string(' ', (numOfLines - i) * 2));

                int numOfCharsInRow = 2 * i - 1;
                for (int j = 0; j < numOfCharsInRow; j++)
                {
                    if (currentChar <= 'Z')
                    {
                        treeBuilder.Append(currentChar + " "); 
                        currentChar++;
                    }
                }

                treeBuilder.AppendLine();
            }

            for (int i = 6; i <= 7; i++)
            {
                treeBuilder.AppendLine(i + " " + new string(' ', 7) + "|Z|"); 
            }

            Console.Write(treeBuilder.ToString()); 
        }
    }
}
