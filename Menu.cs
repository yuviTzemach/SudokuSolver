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
            while (true)
            {
                Console.WriteLine("Please choose the option you want:");
                Console.WriteLine("1. Solve a sudoku");
                Console.WriteLine("2. Exit");
                int option;
                //checking if parsed is int, else, it requires the user to try again
                bool parsed = int.TryParse(Console.ReadLine(), out option);
                if (!parsed)
                {
                    Console.WriteLine("Invalid expression, please try again");
                    continue;
                }
                if (option == 1)
                {
                    // getting the size of the Sudoko from the input
                    Console.WriteLine("Please enter the height of one square in the sudoku:");
                    int height, width;
                    //checking if parsed is int, else, it requires the user to try again
                    parsed = int.TryParse(Console.ReadLine(), out height);
                    if (!parsed)
                    {
                        Console.WriteLine("Invalid expression, please try again");
                        continue;
                    }
                    Console.WriteLine("Please enter the width of one square in the sudoku:");
                    //checking if parsed is int, else, it requires the user to try again
                    parsed = int.TryParse(Console.ReadLine(), out width);
                    if (!parsed)
                    {
                        Console.WriteLine("Invalid expression, please try again");
                        continue;
                    }

                    string fill = "";

                    //input of the menu
                    int input = inputMenu();
                    //the input is not valid, and it's start the menu from the beggining
                    if (input == -1)
                    {
                        continue;
                    }

                    Console.WriteLine("Please enter your sudoku string:");

                    //get the text that fills the sudoku
                    try
                    {
                        fill = Input.getTheFilling(input, height, width);
                    }
                    catch (InvalidExpressionException iee)
                    {
                        Console.WriteLine(iee.Message);
                        continue;
                    }
                    catch (EndOfStreamException eose)
                    {
                        Console.WriteLine(eose.Message);
                        continue;
                    }
                    catch (FileNotFoundException fnfe)
                    {
                        Console.WriteLine(fnfe.Message);
                        continue;
                    }

                    //create the Sudoku and prints it
                    Sudoku s = new Sudoku(height, width, fill);
                    s.printSudoku();

                    //trying to solve the sudoku, if it can, return true, else, return false
                    //also, print the time that takesthe sudoku to be solved
                    bool solvedSudoku = solveSudoku(s);

                    //if the sudoku cannot be solved, it throws the SudokuIsNotValidException
                    if (solvedSudoku == false)
                    {
                        Console.WriteLine("The sudoku can not be solved");
                        continue;
                    }
                    //else, print the new sudoku
                    else
                    {
                        s.printSudoku();
                        //if the input is 1 (means it came from file), insert the result to new file
                        if (input == 1)
                        {
                            Input.writeSudokuToFile(s);
                        }
                    }
                }
                //if the input is 2- the user want to exit the menu
                else if (option == 2)
                {
                    Console.WriteLine("Goodbye :)");
                    return;
                }
                //if it is not 1 or 2- it's print that the input is not valid, and it requires the user to try again 
                else
                {
                    Console.WriteLine("the input is not valid, please try again");
                }
            }
        }

        //the function returns the input of the menu
        public static int inputMenu()
        {
            Console.WriteLine("Please choose your input type:");
            Console.WriteLine("1. File Input");
            Console.WriteLine("2. Console Input");
            int input;
            //checking if parsed is int, else, it requires the user to try again
            bool parsed = int.TryParse(Console.ReadLine(), out input);
            if (!parsed)
            {
                Console.WriteLine("Invalid expression, please try again");
                return -1;
            }
            return input;
        }

        //the function is returns true if the sudoku can be solved, and false otherwise, and print the time that
        //took the function to solve the sudoku
        public static bool solveSudoku(Sudoku s)
        {
            var time = new System.Diagnostics.Stopwatch();
            time.Start();
            DancingLinksSolver dlx = new DancingLinksSolver(s);
            bool solvedSudoku = dlx.SolveSudoku();
            time.Stop();
            Console.WriteLine("\n");
            Console.WriteLine($"The time that took the algorithem to solve the sudoku is {time.Elapsed.TotalMilliseconds} ms");
            return solvedSudoku;
        }
    }
}