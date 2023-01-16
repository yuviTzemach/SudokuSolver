using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinalProject2.SudokuSolver.SudokuSolver.SudokuSolver;
using System.Data;

namespace FinalProject2.SudokuSolver.SudokuSolverTests
{
    [TestClass]
    public class ValidBoardTests
    {
        //board of 4x4 sudoku
        [TestMethod]
        public void Solution_4x4_Board()
        {
            //creating new sudoku
            Sudoku s = new Sudoku(2, 2, "1200341021400320");
            //assert
            DancingLinksSolver dlx = new DancingLinksSolver(s);
            bool solvedSudoku = dlx.SolveSudoku();
            Assert.IsTrue(solvedSudoku);
        }

        //board of 6x6 sudoku
        [TestMethod]
        public void Solution_6x6_Board()
        {
            //creating new sudoku
            Sudoku s = new Sudoku(3, 2, "023456400023510034304512241000635201");
            //assert
            DancingLinksSolver dlx = new DancingLinksSolver(s);
            bool solvedSudoku = dlx.SolveSudoku();
            Assert.IsTrue(solvedSudoku);
        }

        //board of 9x9 sudoku
        [TestMethod]
        public void Solution_9x9_Board()
        {
            //creating new sudoku
            Sudoku s = new Sudoku(3, 3, "010080003436100500005000090920000000643000000080406010000003900000805400000020070");
            //assert
            DancingLinksSolver dlx = new DancingLinksSolver(s);
            bool solvedSudoku = dlx.SolveSudoku();
            Assert.IsTrue(solvedSudoku);
        }

        //board of 16x16 sudoku
        [TestMethod]
        public void Solution_16x16_Board()
        {
            //creating new sudoku
            Sudoku s = new Sudoku(4, 4, "0@0=0021006000<9000;0030000?@00:004>09?50=0020079000=0001000040630000000;:@00072?0090@80>0000<00@8;:001000000=9021>0004009?080:04000?0007@0;062100:0@0000200<000000001>600400:000>6004000?50;700>0300<0005=0008000?000:020;7031>0:000;7231>000400028006000<90000");
            //assert
            DancingLinksSolver dlx = new DancingLinksSolver(s);
            bool solvedSudoku = dlx.SolveSudoku();
            Assert.IsTrue(solvedSudoku);
        }

        //board of 25x25 sudoku
        [TestMethod]
        public void Solution_25x25_Board()
        {
            //creating new sudoku
            Sudoku s = new Sudoku(5, 5, "0E0?0000050FI009>04G200:A0A0B@0001?57086H00=0409>00C00000020?000150006=0HF00I=009>00GB00000<0000007;0080000I=000>04B@:A0E10<350;0600F0=4000C2B00000000<000007;060HF00G90000000:0:02B0<300600000H0I000G0>9>040B@00000<00050;0I=000HF000G90002B@0010030;0607G9>C4000:A01?<3800700I0DH0HF0=0000C02000E10<000800650080DH00C0G00A0B@0<3E00?03E065708=D00000900002B0B00000?0000607;=00FI004091?03E80000I=D0000G00@:02B20@:000003006570=00F0004G000>CA000:001?<;86070F000=000IC0G000A0B@3000<50;0086070I0DHF000G0002000030100003;8000000D0>0409B0002000@:3E0?07;000FI00009>C000G00:00B000E1?000000000=0=0H0>C0090:00B<300?05700;0007F00DH000400:A0010030");
            //assert
            DancingLinksSolver dlx = new DancingLinksSolver(s);
            bool solvedSudoku = dlx.SolveSudoku();
            Assert.IsTrue(solvedSudoku);
        }
    }
}