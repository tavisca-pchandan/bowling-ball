using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    class GameOverException : Exception
    {
        public String toString()
        {
            return "Game Over Exception";
        }
    }
}
