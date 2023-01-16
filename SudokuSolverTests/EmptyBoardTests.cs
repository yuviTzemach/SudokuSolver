using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinalProject2.SudokuSolver.SudokuSolver.SudokuSolver;

namespace FinalProject2.SudokuSolver.SudokuSolverTests
{
    [TestClass]
    public class EmptyBoardTests
    {
        //empty board of 1x1 sudoku
        [TestMethod]
        public void Solution_1x1_Empty_Board()
        {
            //creating new sudoku
            Sudoku s = new Sudoku(1, 1, "0");
            //assert
            DancingLinksSolver dlx = new DancingLinksSolver(s);
            bool solvedSudoku = dlx.SolveSudoku();
            Assert.IsTrue(solvedSudoku);
        }

        //empty board of 4x4 sudoku
        [TestMethod]
        public void Solution_4x4_Empty_Board()
        {
            //creating new sudoku
            Sudoku s = new Sudoku(2, 2, "0000000000000000");
            //assert
            DancingLinksSolver dlx = new DancingLinksSolver(s);
            bool solvedSudoku = dlx.SolveSudoku();
            Assert.IsTrue(solvedSudoku);
        }

        //empty board of 8x8 sudoku
        [TestMethod]
        public void Solution_8x8_Empty_Board()
        {
            //creating new sudoku
            Sudoku s = new Sudoku(4, 2, "0000000000000000000000000000000000000000000000000000000000000000");
            //assert
            DancingLinksSolver dlx = new DancingLinksSolver(s);
            bool solvedSudoku = dlx.SolveSudoku();
            Assert.IsTrue(solvedSudoku);
        }

        //empty board of 9x9 sudoku
        [TestMethod]
        public void Solution_9x9_Empty_Board()
        {
            //creating new sudoku
            Sudoku s = new Sudoku(3, 3, "000000000000000000000000000000000000000000000000000000000000000000000000000000000");
            //assert
            DancingLinksSolver dlx = new DancingLinksSolver(s);
            bool solvedSudoku = dlx.SolveSudoku();
            Assert.IsTrue(solvedSudoku);
        }

        //empty board of 12x12 sudoku
        [TestMethod]
        public void Solution_12x12_Empty_Board()
        {
            //creating new sudoku
            Sudoku s = new Sudoku(4, 3,
                "000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000");
            //assert
            DancingLinksSolver dlx = new DancingLinksSolver(s);
            bool solvedSudoku = dlx.SolveSudoku();
            Assert.IsTrue(solvedSudoku);
        }

        //empty board of 16x16 sudoku
        [TestMethod]
        public void Solution_16x16_Empty_Board()
        {
            //creating new sudoku
            Sudoku s = new Sudoku(4, 4,
                "0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000");
            //assert
            DancingLinksSolver dlx = new DancingLinksSolver(s);
            bool solvedSudoku = dlx.SolveSudoku();
            Assert.IsTrue(solvedSudoku);
        }

        //empty board of 25x25 sudoku
        [TestMethod]
        public void Solution_25x25_Empty_Board()
        {
            //creating new sudoku
            Sudoku s = new Sudoku(5, 5,
                "0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000");
            //assert
            DancingLinksSolver dlx = new DancingLinksSolver(s);
            bool solvedSudoku = dlx.SolveSudoku();
            Assert.IsTrue(solvedSudoku);
        }
    }
}
