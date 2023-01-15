using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    internal class Input
    {
        /* The function gets the height and the width of a square in the sudoku
        the function scan the exact number of digits the sudoku should get, unless it gets
        an invalid char- every char thats not between '0' and the
        max char (height * width). if so, it throws InvalidExpressionException, else, return the input*/
        public static string getTheInputFromConsole(int height, int width)
        {
            string input = "";

            //convert from int to char what is the biggest number that the sudoku can get
            int max = (char)(height * width);
            max += '0';
            do
            {
                char c = Console.ReadKey().KeyChar;
                if (c < '0' || c > max)
                {
                    throw new InvalidExpressionException("the char is not valid");
                }
                //insert the char into the string
                input += c;

            } //doing the while the number of cells in the Sudoku, unless it raises the InvalidExpressionException
            while (input.Length < ((height * width) * (height * width)));

            //if the last char is not enter, it throws InvalidExpressionException
            if (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                throw new InvalidExpressionException("the string is longer than what it supposed to be");
            }
            return input;
        }

        /* The function gets the height and the width of a square in the sudoku
        the function gets the input of the sudoku from a file
        it checks if the file is exists, and if so read the chars inside
        it also checks if the the amount of chars it got is bigger, smaller or what it expected
        then, it checks the validation of the chars
        if is invalid, it throws InvalidExpressionException, else, return the input */
        public static string getTheInputFromFile(int height, int width)
        {
            string input = "";
            string txt = @"C:\\Users\\yuval\\source\\repos\\FinalProject2\\SudokuSolver\\TextFile.txt";
            int sizeSudoku = (height * width) * (height * width);
            char[] arr = new char[sizeSudoku];

            //convert from int to char what is the biggest number that the sudoku can get
            char max = (char)(height * width);
            max += '0';
            if (File.Exists(txt))
            {
                using (StreamReader file = new StreamReader(txt))
                {
                    int count = file.ReadBlock(arr, 0, sizeSudoku);
                    //if the amount of the chars is bigger, throws EndOfStreamException
                    if (file.EndOfStream == false)
                    {
                        throw new EndOfStreamException("The number of chars that have been scanned is bigger");
                    }
                    //if the amount of the chars is smaller, throws EndOfStreamException
                    if (count != sizeSudoku)
                    {
                        throw new EndOfStreamException("The number of chars that have been scanned is smaller");
                    }
                    input = new string(arr);
                }
            }
            //if it didn't fount the file, throws FileNotFoundException
            else
            {
                throw new FileNotFoundException("There is no file with the name 'TextFile.txt'");
            }
            //check validation of the input
            for (int i = 0; i < sizeSudoku; i++)
            {
                if (input[i] < '0' || input[i] > max)
                {
                    throw new InvalidExpressionException("the char is not valid");
                }
            }
            return input;
        }

        //the function is getting the filling of the sudoku
        public static string getTheFilling(int input, int height, int width)
        {
            string fill = "";
            //if the input is 1- get the string from file
            if (input == 1)
            {
                fill = getTheInputFromFile(height, width);
            }
            //if the input is 2- get the string from input
            else if (input == 2)
            {
                fill = getTheInputFromConsole(height, width);
            }
            //throw an InvalidExpressionException if it is not 1 or 2
            else
            {
                throw new InvalidExpressionException("the input is not valid");
            }
            return fill;
        }

        //the function is writing the result of the sudoku into new file
        public static void writeSudokuToFile(Sudoku s)
        {
            string txt = @"C:\\Users\\yuval\\source\\repos\\FinalProject2\\SudokuSolver\\TextFile1.txt";
            string output = s.convertSudokuToString();
            File.WriteAllText(txt, output);
        }
    }
}
