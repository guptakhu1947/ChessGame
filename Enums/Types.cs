using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public enum Color
    {
        Black,
        White
    }

    public enum PieceType
    {
        Bishop,
        King,
        Knight,
        Pawn,
        Queen,
        Rook
    }

    public enum Status
    {
        Continue,
        Win,
        Lose,
        Draw,
        CheckMate
    }

    public enum PlayerName
    {
        PlayerOne,
        PlayerTwo
    }

    public enum CoOrdinateType
    {
        X,
        Y
    }
}
