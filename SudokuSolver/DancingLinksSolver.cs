using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject2
{
    public class DancingLinksSolver
    {
        /* The constraints are:
        1. Each cell can only contain one integer between 1 and 'max size'.
        2-4. Each row/column/box can only contain 'max size' unique integers in the range of 1 to 'max size'.
        */
        private static int CONSTRAINTS = 4;

        //This bool matrix represents the constrains
        private bool[,] coverBoard;
        private int headerBase;

        private Sudoku sudoku;

        public DancingLinksSolver(Sudoku sudoku)
        {
            this.sudoku = sudoku;
            this.coverBoard = new bool[sudoku.max * sudoku.max * sudoku.max, sudoku.max * sudoku.max * CONSTRAINTS];
            this.headerBase = 0;
        }

        //This function creates the cover board and runs the Dancing Links algorithm to solve the sudoku
        //returns wether the sudoku has a solution or not
        public bool SolveSudoku()
        {
            this.CreateExactCoverBoard();

            DancingLinks dancingLinks = new DancingLinks(this.coverBoard, this.sudoku.mat);
            dancingLinks.DLX();
            return dancingLinks.isSolved;
        }

        //This function converts sudoku's row, column and value to their corresponding index in the cover board 
        private int getIndex(int row, int column, int value)
        {
            return (row - 1) * this.sudoku.max * this.sudoku.max + (column - 1) * this.sudoku.max + (value - 1);
        }

        //Set all possible constrains that match the basic rules of the sudoku game,
        //regardless of the given sudoku board (it will be handled later in AdjustConstraintsAccordingToBoard())
        private void InitBasicExactCoverBoard()
        {
            this.SetCellConstraint();
            this.SetRowConstraint();
            this.SetColumnConstraint();
            this.SetSubGridConstraint();
        }

        //for every sub-grid constraint - set the constraint as true
        private void SetSubGridConstraint()
        {
            for (int row = 1; row <= this.sudoku.max; row += this.sudoku.height)
            {
                for (int column = 1; column <= this.sudoku.max; column += this.sudoku.width)
                {
                    for (int value = 1; value <= this.sudoku.max; value++, this.headerBase++)
                    {
                        for (int rowDelta = 0; rowDelta < this.sudoku.height; rowDelta++)
                        {
                            for (int columnDelta = 0; columnDelta < this.sudoku.width; columnDelta++)
                            {
                                this.coverBoard[getIndex(row + rowDelta, column + columnDelta, value), this.headerBase] = true;
                            }
                        }
                    }
                }
            }
        }

        //for every column constraint - set the constraint as true
        private void SetColumnConstraint()
        {
            for (int column = 1; column <= this.sudoku.max; column++)
            {
                for (int value = 1; value <= this.sudoku.max; value++, this.headerBase++)
                {
                    for (int row = 1; row <= this.sudoku.max; row++)
                    {
                        this.coverBoard[getIndex(row, column, value), this.headerBase] = true;
                    }
                }
            }
        }

        // or every row constraint - set the constraint as true
        private void SetRowConstraint()
        {
            for (int row = 1; row <= this.sudoku.max; row++)
            {
                for (int value = 1; value <= this.sudoku.max; value++, this.headerBase++)
                {
                    for (int column = 1; column <= this.sudoku.max; column++)
                    {
                        this.coverBoard[getIndex(row, column, value), this.headerBase] = true;
                    }
                }
            }
        }

        //for every cell constraint - set the constraint as true
        private void SetCellConstraint()
        {
            for (int row = 1; row <= this.sudoku.max; row++)
            {
                for (int column = 1; column <= this.sudoku.max; column++, this.headerBase++)
                {
                    for (int value = 1; value <= this.sudoku.max; value++)
                    {
                        this.coverBoard[getIndex(row, column, value), this.headerBase] = true;
                    }
                }
            }
        }

        /*This function adjusts (unset) the illegal constraints that the general initialization
        in InitBasicExactCoverBoard() did
        It's doing that by canceling the (row, column, number) constraints
        when board[row, column] = value and value != 0 and value != number  */
        private void AdjustConstraintsAccordingToBoard()
        {
            for (int row = 1; row <= this.sudoku.max; row++)
            {
                for (int column = 1; column <= this.sudoku.max; column++)
                {
                    int value = this.sudoku.mat[row - 1, column - 1];
                    //for every not-empty cell (!= 0)
                    if (value != 0)
                    {
                        for (int num = 1; num <= this.sudoku.max; num++)
                        {
                            //for those row and column, set all constraints to false -
                            //except the constraint that refers to the real value in this cell - (row, column, value)
                            //all other constraints set to false, because those combinations are illegal
                            if (num != value)
                            {
                                int idx = getIndex(row, column, num);
                                for (int i = 0; i < this.coverBoard.GetLength(1); i++)
                                {
                                    this.coverBoard[idx, i] = false;
                                }
                            }
                        }
                    }
                }
            }
        }

        //This function create the matching Exact Cover Board for the given sudoku
        private void CreateExactCoverBoard()
        {
            //set all possible constrains that match the basic rules of the sudoku game
            this.InitBasicExactCoverBoard();

            //after we set the constraints for all the rules (regardless of the given sudoku board),
            //now it is time to unset the constraints that don't match this specific board values (its not-empty cells)
            this.AdjustConstraintsAccordingToBoard();
        }
    }
}