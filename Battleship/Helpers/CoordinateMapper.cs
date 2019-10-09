using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public static class CoordinateMapper
    {
        public static int Map(char coordinateChar)
        {
            var result = ((int)coordinateChar) - 64;
            return result;
        }

    }
}
