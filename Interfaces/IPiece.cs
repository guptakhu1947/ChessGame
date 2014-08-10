
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    interface IPiece
    {
        bool IsValidMove();
        bool UpDatePoistion();
    }
}
