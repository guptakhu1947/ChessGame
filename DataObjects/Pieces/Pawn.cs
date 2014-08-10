using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.DataObjects
{
    class Pawn : Piece
    {
        private const int NUMBEROFPAWNS = 8;
       
        public Pawn()
        {
        }
        public Pawn(Color color, CoOrdinate coOrdinate)
            : base(color, coOrdinate, PieceType.Pawn)
        {
 
        }

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

        //Pawn can only move straight ahead           
        public override bool IsValidMove(CoOrdinate to, History history)
        {
            Piece foundPiece;

            if (to.XCoOrdinate == CurrentCoOrdinate.XCoOrdinate)
            {
                //The next cell should be empty if moving forward
                if (!history.LayOut.TryGetValue(to, out foundPiece))
                {
                    //TPwan cannot move backwards
                    if (Color == Color.White)
                        return (to.YCoOrdinate - CurrentCoOrdinate.YCoOrdinate) == 1;
                    else
                        return (CurrentCoOrdinate.YCoOrdinate - to.YCoOrdinate) == 1;
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
