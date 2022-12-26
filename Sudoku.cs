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
    }
}
