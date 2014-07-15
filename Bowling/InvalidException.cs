using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    class InvalidException :Exception
    {
        public String ToString()
        {
            return "Invalid Score Exception...!";
        }
    }
}
