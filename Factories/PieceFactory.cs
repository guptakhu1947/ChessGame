using ChessGame.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class PieceFactory
    {
        public Piece Get(PieceType type)
        {
            switch (type)
            {
                case PieceType.Bishop:
                    return new Bishop();
                case PieceType.King:
                    return new King();
                case PieceType.Knight:
                    return new Knight();
                case PieceType.Pawn:
                    return new Pawn();
                case PieceType.Queen:
                    return new Queen();
                case PieceType.Rook:
                    return new Rook();
                default:
                    throw new ArgumentException("Invalid type", type.GetType().Name);
            }
        }
    }
}
