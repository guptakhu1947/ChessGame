using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.DataObjects
{
    class Queen : Piece
    {
        public Queen()
        {
        }

        public Queen(Color color, CoOrdinate coOrdinate)
            : base(color, coOrdinate, PieceType.Queen)
        {
 
        }

        public override Dictionary<CoOrdinate, Piece> SetUp(Color color)
        {
            Dictionary<CoOrdinate, Piece> pieces = new Dictionary<CoOrdinate, Piece>();
            int xCoOrdinateFirst = 4;
            int yCoOrdinate = GetYCoOrdinate(color);
            CoOrdinate coOrdinate = new CoOrdinate(xCoOrdinateFirst, yCoOrdinate);
            pieces.Add(coOrdinate, new Queen(color, coOrdinate));

            return pieces;
        }

        //Queen move is a combination of Rook and Bishop move          
        public override bool IsValidMove(CoOrdinate to, History history)
        {
            var isValidBisopMove = new Bishop(Color, CurrentCoOrdinate).IsValidMove(to,history);
            var isValidRookMove = new Rook(Color, CurrentCoOrdinate).IsValidMove(to, history);
            return (isValidBisopMove || isValidRookMove);
        }
    }
}
