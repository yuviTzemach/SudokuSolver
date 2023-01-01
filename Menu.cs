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
            Console.WriteLine("Please choose your input type:");
            Console.WriteLine("1. File Input");
            Console.WriteLine("2. Console Input");
            int input = int.Parse(Console.ReadLine());

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

            //create the Sudoku and prints it
            Sudoku s = new Sudoku(height, width, fill);
            s.printSudoku();

            /*need to do the solve function*/

            //if the sudoku cannot be solved, it throws the SudokuIsNotValidException
            /*if(s.solve() == false)
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
                    string txt = @"TextFile1.txt";
                    string output = s.convertSudokuToString();
                    File.WriteAllText(txt, output);
                }
            }*/
        }
    }
}