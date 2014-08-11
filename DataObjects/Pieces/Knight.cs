using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.DataObjects
{
    class Knight : Piece
    {
        #region Constructors
        public Knight()
        {
        }

        public Knight(Color color, CoOrdinate coOrdinate)
            : base(color, coOrdinate, PieceType.Knight)
        {

        }
        #endregion

        public override Dictionary<CoOrdinate, Piece> SetUp(Color color)
        {
            Dictionary<CoOrdinate, Piece> pieces = new Dictionary<CoOrdinate, Piece>();
            int xCoOrdinateFirst = 1;
            int xCoOrdinateSecond = 6;
            int yCoOrdinate = GetYCoOrdinate(color);
            CoOrdinate coOrdinate = new CoOrdinate(xCoOrdinateFirst, yCoOrdinate);
            pieces.Add(coOrdinate, new Knight(color, coOrdinate));
            coOrdinate = new CoOrdinate(xCoOrdinateSecond, yCoOrdinate);
            pieces.Add(coOrdinate, new Knight(color, coOrdinate));

            return pieces;
        }

        /*
         * Knight can move two squares horizontally then one square vertically, 
        * or moving one square horizontally then two squares vertically
        */
        public override bool IsValidMove(CoOrdinate to, History history)
        {
            if (to.XCoOrdinate == CurrentCoOrdinate.XCoOrdinate || to.YCoOrdinate == CurrentCoOrdinate.YCoOrdinate)
                return false;

            //Cannot kill its own piece
            Piece foundPiece;
            if (history.LayOut.TryGetValue(to, out foundPiece) && Color == foundPiece.Color)
                return false;

            if (Math.Abs(to.XCoOrdinate - CurrentCoOrdinate.XCoOrdinate) == 2)
            {
                return Math.Abs(to.YCoOrdinate - CurrentCoOrdinate.YCoOrdinate) == 1;
            }
            else if (Math.Abs(to.YCoOrdinate - CurrentCoOrdinate.YCoOrdinate) == 2)
            {
                return Math.Abs(to.XCoOrdinate - CurrentCoOrdinate.XCoOrdinate) == 1;
            }
            return false;
        }
    }
}
