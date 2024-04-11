using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects.Interfaces
{
    public interface IPoint
    {
        int Column { get; }

        int Row { get; }
    }
}
