using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public enum eShotResult
    {
        Miss = 1,
        Hit = 2,
        Sink = 3,
        Win = 4,
        WrongCoordinates = 5
    }
}
