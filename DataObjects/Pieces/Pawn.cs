using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.DataObjects
{
    class Pawn : Piece
    {
        #region Constructors
        public Pawn()
        {
        }
        public Pawn(Color color, CoOrdinate coOrdinate)
            : base(color, coOrdinate, PieceType.Pawn)
        {
 
        }
        #endregion

        private const int NUMBEROFPAWNS = 8;

        public override Dictionary<CoOrdinate, Piece> SetUp(Color color)
        {
            int yCoOrdinate = color == Color.White ? 1 : 6;       
            Dictionary<CoOrdinate, Piece> pieces = new Dictionary<CoOrdinate, Piece>();
            for (int x = 0; x < NUMBEROFPAWNS; x++)
            {
                CoOrdinate coOrdinate = new CoOrdinate(x, yCoOrdinate);
                pieces.Add(coOrdinate, new Pawn(color, coOrdinate));
            }

            return pieces;
        }

       /*
        * A pawn moves straight forward one square, if that square is vacant. If it has not yet moved, 
        * a pawn also has the option of moving two squares straight forward, provided both squares are vacant. 
        * Pawns cannot move backwards.
        * Pawns are the only pieces that capture differently from how they move. A pawn can capture an enemy piece on either of the two squares diagonally in front of the pawn (but cannot move to those squares if they are vacant).
        */
        public override bool IsValidMove(CoOrdinate to, History history)
        {
            Piece foundPiece;

            if (to.XCoOrdinate == CurrentCoOrdinate.XCoOrdinate)
            {
                //The next cell should be empty if moving forward
                if (!history.LayOut.TryGetValue(to, out foundPiece))
                {
                    int maxMoveMagnitude = CurrentCoOrdinate == FromCoOrdinate ? 2 : 1;
                            
                    if (maxMoveMagnitude == 2 && Math.Abs(to.YCoOrdinate - CurrentCoOrdinate.YCoOrdinate) == 2)
                    {
                        if (Color == Color.White)
                        {
                            var diffInCoOrdinate = to.YCoOrdinate - CurrentCoOrdinate.YCoOrdinate;
                            if (diffInCoOrdinate > 0 && diffInCoOrdinate <= maxMoveMagnitude)
                            {
                                return AreCellsEmpty(CurrentCoOrdinate.XCoOrdinate, CurrentCoOrdinate.YCoOrdinate, to.YCoOrdinate-1, history, CoOrdinateType.X);           
                            }
                        }
                        else
                        {
                            var diffInCoOrdinate = CurrentCoOrdinate.YCoOrdinate - to.YCoOrdinate;
                            if (diffInCoOrdinate > 0 && diffInCoOrdinate <= maxMoveMagnitude)
                            {
                                return AreCellsEmpty(CurrentCoOrdinate.XCoOrdinate, to.YCoOrdinate, CurrentCoOrdinate.YCoOrdinate-1, history, CoOrdinateType.X);                                       
                            }
                        }
                        
                    }
                    else
                    {
                        //Pwan cannot move backwards
                        if (Color == Color.White)
                            return (to.YCoOrdinate - CurrentCoOrdinate.YCoOrdinate) == 1;
                        else
                            return (CurrentCoOrdinate.YCoOrdinate - to.YCoOrdinate) == 1;
                    }
                }
            }

            //Pawn can move diagonally only of there is piece of another color in that position
            var diagonalYCoOrdinate = Color == Color.White ? CurrentCoOrdinate.YCoOrdinate + 1 : CurrentCoOrdinate.YCoOrdinate - 1;
            var leftDiagonalCoOrdinate = new CoOrdinate(CurrentCoOrdinate.XCoOrdinate - 1, diagonalYCoOrdinate);
            var rightDiagonalCoOrdinate = new CoOrdinate(CurrentCoOrdinate.XCoOrdinate + 1, diagonalYCoOrdinate);
          
            if (history.LayOut.TryGetValue(leftDiagonalCoOrdinate, out foundPiece) && foundPiece.Color != Color)
            {
                return to.Equals(leftDiagonalCoOrdinate);
            }
            if (history.LayOut.TryGetValue(rightDiagonalCoOrdinate, out foundPiece) && foundPiece.Color != Color)
            {
                return to.Equals(rightDiagonalCoOrdinate);
            }

            return false;
        }

    }
}
