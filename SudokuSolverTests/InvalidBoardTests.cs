using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinalProject2.SudokuSolver.SudokuSolver.SudokuSolver;
using System.Data;

namespace FinalProject2.SudokuSolver.SudokuSolverTests
{
    [TestClass]
    public class InvalidBoardTests
    {
        //can't get a number that is higher than the limits
        public void Solution_1x1_Invalid_Board()
        {
            //creating new sudoku
            Sudoku s = new Sudoku(1, 1, "2");
            //assert
            DancingLinksSolver dlx = new DancingLinksSolver(s);
            Assert.ThrowsException<InvalidExpressionException>(() => dlx.SolveSudoku());
        }

        //there are less chars than what it required- return this error when it is only from console
        [TestMethod]
        public void Solution_4x4_Invalid_Board()
        {
            //creating new sudoku
            Sudoku s = new Sudoku(2, 2, "102301423410000");
            //assert
            DancingLinksSolver dlx = new DancingLinksSolver(s);
            Assert.ThrowsException<InvalidExpressionException>(() => dlx.SolveSudoku());
        }

        //there are too much chars than what it required- can only happend when it's came from file
        [TestMethod]
        public void Solution_9x9_Invalid_Board()
        {
            //creating new sudoku
            Sudoku s = new Sudoku(3, 3,
                       "8300096747968442620442637189159783046483296715627140038365471892074058361018362547");
            //assert
            DancingLinksSolver dlx = new DancingLinksSolver(s);
            Assert.ThrowsException<EndOfStreamException>(() => dlx.SolveSudoku());
        }

        //there are less chars than what it required- return this error when it is only from file
        [TestMethod]
        public void Solution_16x16_Invalid_Board()
        {
            //creating new sudoku
            Sudoku s = new Sudoku(4, 4,
                       "830?2@009?67<;47968442<6204426@3718915978;304648329@671562714003>83654718?9207405836101836==2547");
            //assert
            DancingLinksSolver dlx = new DancingLinksSolver(s);
            Assert.ThrowsException<EndOfStreamException>(() => dlx.SolveSudoku());
        }

        //the sudoku can't be solved- it returns false
        [TestMethod]
        public void Solution_25x25_Invalid_Board()
        {
            //creating new sudoku
            Sudoku s = new Sudoku(5, 5,
                       "0E0?0000012FI009>04G200:A0A0B@0001?57086H00=0409>00C000005D0?000150006=0HF00I=009>00GB00000<0000007;0080000I=000>04B@:A0E10<350;0600F0=4000C2B00000000<000007;060HF00G90000000:0:02B0<300600000H0I000G0>9>040B@00000<00050;0I=000HF000G90002B@0010030;0607G9>C4000:A01?<3800700I0DH0HF0=0000C02000E10<000800650080DH00C0G00A0B@0<3E00?03E065708=D00000900002B0B00000?0000607;=00FI004091?03E80000I=D0000G00@:02B20@:000003006570=00F0004G000>CA000:001?<;86070F000=000IC0G000A0B@3000<50;0086070I0DHF000G0002000030100003;8000000D0>0409B0002000@:3E0?07;000FI00009>C000G00:00B000E1?000000000=0=0H0>C0090:00B<300?05700;0007F00DH000400:A0010030");
            //assert
            DancingLinksSolver dlx = new DancingLinksSolver(s);
            bool solvedSudoku = dlx.SolveSudoku();
            Assert.IsFalse(solvedSudoku);
        }
    }
}
