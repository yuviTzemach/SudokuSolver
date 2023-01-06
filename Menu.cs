using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject2
{
    internal class Menu
    {
        public static void menu()
        {
            //getting the size of the Sudoko from the input
            Console.WriteLine("Please enter the height of one square in the sudoku:");
            int height = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the width of one square in the sudoku:");
            int width = int.Parse(Console.ReadLine());

            string fill = "";

            //input of the menu
            int input = inputMenu();

            //get the text that fills the sudoku
            fill = getTheFilling(input, height, width);

            //create the Sudoku and prints it
            Sudoku s = new Sudoku(height, width, fill);
            s.printSudoku();

            //trying to solve the sudoku, if it can, return true, else, return false
            //also, print the time that takesthe sudoku to be solved
            bool solvedSudoku = solveSudoku(s);

            //if the sudoku cannot be solved, it throws the SudokuIsNotValidException
            if (solvedSudoku == false)
            {
                throw new SudokuIsNotValidException("The sudoku can not be solved");
            }
            //else, print the new sudoku
            else
            {
                s.printSudoku();
                //if the input is 1 (means it came from file), insert the result to new file
                if (input == 1)
                {
                    writeSudokuToFile(s);
                }
            }
        }

        //the function returns the input of the menu
        public static int inputMenu()
        {
            Console.WriteLine("Please choose your input type:");
            Console.WriteLine("1. File Input");
            Console.WriteLine("2. Console Input");
            int input = int.Parse(Console.ReadLine());
            return input;
        }

        //the function is getting the filling of the sudoku
        public static string getTheFilling(int input, int height, int width)
        {
            string fill;
            //if the input is 1- get the string from file
            if (input == 1)
            {
                fill = Sudoku.getTheInputFromFile(height, width);
            }
            //if the input is 2- get the string from input
            else if (input == 2)
            {
                fill = Sudoku.getTheInputFromConsole(height, width);
            }
            //throw an InvalidExpressionException if it is not 1 or 2
            else
            {
                throw new InvalidExpressionException("the input is not valid");
            }
            return fill;
        }

        //the function is returns true if the sudoku can be solved, and false otherwise, and print the time that
        //took the function to solve the sudoku
        public static bool solveSudoku(Sudoku s)
        {
            var time = new System.Diagnostics.Stopwatch();
            time.Start();
            bool solvedSudoku = s.solve(0, 0);
            time.Stop();
            Console.WriteLine("\n");
            Console.WriteLine($"Time: {time.Elapsed.TotalMilliseconds} ms");
            return solvedSudoku;
        }

        //the function is writing the result of the sudoku into new file
        public static void writeSudokuToFile(Sudoku s)
        {
            string txt = Path.Combine(Directory.GetCurrentDirectory(), "\\TextFile1.txt");
            string output = s.convertSudokuToString();
            File.WriteAllText(txt, output);
        }
    }
}