using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject2
{
    internal class SudokuIsNotValidException : Exception
    {
        public SudokuIsNotValidException() { }

        public SudokuIsNotValidException(string message) : base(message) { }

        public SudokuIsNotValidException(string message, Exception inner) : base(message, inner) { }
    }
}