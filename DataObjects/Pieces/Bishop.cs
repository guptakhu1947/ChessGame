using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.DataObjects
{
    class Bishop : Piece
    {
        #region Constructors
        public Bishop()
        {
        }

        public Bishop(Color color, CoOrdinate coOrdinate)
            : base(color, coOrdinate, PieceType.Bishop)
        {
           
        }
        #endregion

        public override Dictionary<CoOrdinate, Piece> SetUp(Color color)
        {
            int xCoOrdinateFirst = 2;
            int xCoOrdinateSecond = 5;
            int yCoOrdinate = GetYCoOrdinate(color);
            Dictionary<CoOrdinate, Piece> pieces = new Dictionary<CoOrdinate, Piece>();
            CoOrdinate coOrdinate = new CoOrdinate(xCoOrdinateFirst, yCoOrdinate);
            var piece = new Bishop(color, coOrdinate);
            pieces.Add(piece.FromCoOrdinate, piece);
            coOrdinate = new CoOrdinate(xCoOrdinateSecond, yCoOrdinate);
            piece = new Bishop(color, coOrdinate);
            pieces.Add(piece.FromCoOrdinate, piece);
            return pieces;
        }

        //Bishop can only move only diagonally 
        public override bool IsValidMove(CoOrdinate to, History history)
        { 
            if (to.XCoOrdinate == CurrentCoOrdinate.XCoOrdinate || to.YCoOrdinate == CurrentCoOrdinate.YCoOrdinate)
                return false;

             CoOrdinate finalCheckCoOrdinate;

            //For Bishop to move all cells should be empty in diagonal direction
            if (to.XCoOrdinate > CurrentCoOrdinate.XCoOrdinate)
            {
                //Try to move diagonally to the right of current position
                finalCheckCoOrdinate = AreCellsEmpty(CurrentCoOrdinate.XCoOrdinate, CurrentCoOrdinate.YCoOrdinate, to.YCoOrdinate, history, true);
            }
            else
            {
                //Try to move diagonally to the left of current position
                finalCheckCoOrdinate = AreCellsEmpty(CurrentCoOrdinate.XCoOrdinate, CurrentCoOrdinate.YCoOrdinate, to.YCoOrdinate, history, false);
            }

            return to.Equals(finalCheckCoOrdinate);
        }

        private CoOrdinate AreCellsEmpty(int staticIndex, int startIndex, int finalIndex, History history, bool isRightHalf)
        {
            Piece foundPiece;
            if (startIndex < finalIndex)
            {
                for (int i = startIndex+1; i <= finalIndex; i++)
                {
                    if (isRightHalf)
                        staticIndex++;
                    else
                        staticIndex--;

                    var checkCoOrdinate = new CoOrdinate(staticIndex, i);
                    if (history.LayOut.TryGetValue(checkCoOrdinate, out foundPiece))
                    {
                        if (!CanPieceBeMoved(finalIndex, foundPiece, i))
                            return checkCoOrdinate;
                    }                   
                }
            }
            else
            {
                for (int i = startIndex - 1; i >= finalIndex; i--)
                {
                    if (isRightHalf)
                        staticIndex++;
                    else
                        staticIndex--;

                    var checkCoOrdinate = new CoOrdinate(staticIndex, i) ;
                    if (history.LayOut.TryGetValue(checkCoOrdinate, out foundPiece))
                    {
                        if (!CanPieceBeMoved(finalIndex, foundPiece, i))
                            return checkCoOrdinate;
                    }
                }
            }
           return new CoOrdinate(staticIndex, finalIndex);
        }
    }
}
