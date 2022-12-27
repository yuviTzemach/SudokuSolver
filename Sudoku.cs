using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject2
{
    class Sudoku
    {
        protected char [,] mat;
        protected int height;
        protected int width;

        //constructor of the Sudoku class
        public Sudoku(int height, int width, string fill)
        {
            this.height = height;
            this.width = width;
            int index = 0;
            //creating a matrix that has 
            mat = new char[height * width, height * width];

            //filling the matrix with what the input was
            for (int i = 0; i< (height * width); i++)
            {
                for(int j= 0;j < (height * width); j++)
                {
                    mat[i, j] = fill[index];
                    index++;
                }
            }
        }

        //the function is printing the Sudoku
        public void printSudoku()
        {
            Console.Write("\n");
            for (int i = 0; i < this.height * this.width; i++)
            {
                Console.Write("----");
            }
            for (int i=0; i< this.height * this.width; i++)
            {
                Console.Write("\n");
                Console.Write("|");
                for (int j=0; j< this.height * this.width; j++)
                {
                    Console.Write(" " + mat[i, j] + " |");
                }
                Console.Write("\n");
                for (int k = 0; k < this.height * this.width; k++)
                {
                    Console.Write("----");
                }
            }
        }

        //the function gets the height and the width of
        public static string getTheFillingToTheSudoku(int height, int width)
        {
            string input = "";

            //convert from int to char what is the biggest number that the sudoku can get
            char max = (char)(height * width);
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

            return input;
        }

        public static void Main(String[] args)
        {
            //getting the size of the Sudoko from the input
            Console.WriteLine("Please enter the height of one square in the sudoku:");
            int height = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the width of one square in the sudoku:");
            int width = int.Parse(Console.ReadLine());

            //getting the string that suppose to be in the Sudoku
            string fill = getTheFillingToTheSudoku(height, width);

            //create the Sudoku and prints it
            Sudoku s = new Sudoku(height, width, fill);
            s.printSudoku();
        }

    }
}
