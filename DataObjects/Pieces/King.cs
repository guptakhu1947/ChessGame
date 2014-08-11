using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.DataObjects
{
    class King : Piece
    {
        #region Constructors
        public King()
        {
        }

        public King(Color color, CoOrdinate coOrdinate)
            : base(color, coOrdinate, PieceType.King)
        {
 
        }
        #endregion

        public override Dictionary<CoOrdinate, Piece> SetUp(Color color)
        {
            Dictionary<CoOrdinate, Piece> pieces = new Dictionary<CoOrdinate, Piece>();
            int xCoOrdinateFirst = 3;
            int yCoOrdinate = GetYCoOrdinate(color);
            CoOrdinate coOrdinate = new CoOrdinate(xCoOrdinateFirst, yCoOrdinate);
            pieces.Add(coOrdinate, new King(color, coOrdinate));

            return pieces;
        }

        //King can move in any direction, only if there is piece of another color in that position          
        public override bool IsValidMove(CoOrdinate to, History history)
        {
            Piece foundPiece;

            if (history.LayOut.TryGetValue(to, out foundPiece) && Color == foundPiece.Color)
                return false;

            if (to.XCoOrdinate == CurrentCoOrdinate.XCoOrdinate)
            {
               return Math.Abs(to.YCoOrdinate - CurrentCoOrdinate.YCoOrdinate) ==1;
            }

            if (to.YCoOrdinate == CurrentCoOrdinate.YCoOrdinate)
            {
                return Math.Abs(to.XCoOrdinate - CurrentCoOrdinate.XCoOrdinate) == 1;
            }

            var diagonalYCoOrdinate = Color == Color.White ? CurrentCoOrdinate.YCoOrdinate + 1 : CurrentCoOrdinate.YCoOrdinate - 1;
            var diagonalBackwardYCoOrdinate = Color == Color.White ? CurrentCoOrdinate.YCoOrdinate - 1 : CurrentCoOrdinate.YCoOrdinate + 1;
            
            var leftDiagonalCoOrdinate = new CoOrdinate(CurrentCoOrdinate.XCoOrdinate - 1, diagonalYCoOrdinate);
            var leftBackwardDiagonalCoOrdinate = new CoOrdinate(CurrentCoOrdinate.XCoOrdinate - 1, diagonalBackwardYCoOrdinate);
           
            var rightDiagonalCoOrdinate = new CoOrdinate(CurrentCoOrdinate.XCoOrdinate + 1, diagonalYCoOrdinate);
            var rightBackwardDiagonalCoOrdinate = new CoOrdinate(CurrentCoOrdinate.XCoOrdinate + 1, diagonalBackwardYCoOrdinate);


            if (history.LayOut.TryGetValue(leftDiagonalCoOrdinate, out foundPiece))
            {
                if (foundPiece.Color == Color)
                    foundPiece = null;
                else
                    return to.Equals(leftDiagonalCoOrdinate);
            }

            if (history.LayOut.TryGetValue(leftBackwardDiagonalCoOrdinate, out foundPiece))
            {
                if (foundPiece.Color == Color)
                    foundPiece = null;
                else
                    return to.Equals(leftBackwardDiagonalCoOrdinate);
            }

            if (history.LayOut.TryGetValue(rightDiagonalCoOrdinate, out foundPiece))
            {
                if (foundPiece.Color == Color)
                    foundPiece = null;
                else
                    return to.Equals(rightDiagonalCoOrdinate);
            }

            if (history.LayOut.TryGetValue(rightBackwardDiagonalCoOrdinate, out foundPiece))
            {
                if (foundPiece.Color == Color)
                    foundPiece = null;
                else
                    return to.Equals(rightBackwardDiagonalCoOrdinate);
            }

            if (foundPiece == null)
            {
                return (to.Equals(leftDiagonalCoOrdinate) || to.Equals(leftBackwardDiagonalCoOrdinate) || to.Equals(rightDiagonalCoOrdinate) || to.Equals(rightBackwardDiagonalCoOrdinate));
            }

            return false;
        }
    }
}
