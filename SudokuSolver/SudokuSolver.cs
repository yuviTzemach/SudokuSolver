using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject2.Sudoku;

namespace FinalProject2
{
    internal class SudokuSolver
    {
        public static void Main(String[] args)
        {
            //adding ui
            Console.WriteLine(@"
 __        _______ _     ____ ___  __  __ _____   _____ ___   __   ___   ___     ___    _     _ ____   
 \ \      / / ____| |   / ___/ _ \|  \/  | ____| |_   _/ _ \  \ \ / / | | \ \   / / \  | |   ( ) ___|  
  \ \ /\ / /|  _| | |  | |  | | | | |\/| |  _|     | || | | |  \ V /| | | |\ \ / / _ \ | |   |/\___ \  
   \ V  V / | |___| |__| |__| |_| | |  | | |___    | || |_| |   | | | |_| | \ V / ___ \| |___   ___) | 
    \_/\_/  |_____|_____\____\___/|_|  |_|_____|_  |_|_\___/__  |_|_ \___/___\_/_/___\_\_____| |____/  
              / ___|| | | |  _ \ / _ \| |/ / | | | / ___| / _ \| |\ \   / / ____|  _ \                 
              \___ \| | | | | | | | | | ' /| | | | \___ \| | | | | \ \ / /|  _| | |_) |                
               ___) | |_| | |_| | |_| | . \| |_| |  ___) | |_| | |__\ V / | |___|  _ <                 
              |____/ \___/|____/ \___/|_|\_\\___/  |____/ \___/|_____\_/  |_____|_| \_\                
                                                                                                
            ");

            //calling the menu
            Menu.menu();
        }
    }
}