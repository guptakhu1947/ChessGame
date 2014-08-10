using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.DataObjects
{
    class Rook : Piece
    {     
        public Rook()
        {
        }

        public Rook(Color color, CoOrdinate coOrdinate)
            : base(color, coOrdinate, PieceType.Rook)
        {
 
        }

        public override Dictionary<CoOrdinate, Piece> SetUp(Color color)
        {
            int xCoOrdinateFirst = 0;
            int xCoOrdinateSecond = 7;
            int yCoOrdinate = GetYCoOrdinate(color);
            Dictionary<CoOrdinate, Piece> pieces = new Dictionary<CoOrdinate, Piece>();

            CoOrdinate coOrdinate = new CoOrdinate(xCoOrdinateFirst, yCoOrdinate);
            pieces.Add(coOrdinate, new Rook(color, coOrdinate));
            coOrdinate = new CoOrdinate(xCoOrdinateSecond, yCoOrdinate);
            pieces.Add(coOrdinate, new Rook(color, coOrdinate));

            return pieces;
        }

        //For rook to move all cells should be empty in straight direction
        public override bool IsValidMove(CoOrdinate to, History history)
        {
            if (to.XCoOrdinate == CurrentCoOrdinate.XCoOrdinate && Math.Abs(to.YCoOrdinate - CurrentCoOrdinate.YCoOrdinate) > 0)
            {
                return AreCellsEmpty(CurrentCoOrdinate.XCoOrdinate,CurrentCoOrdinate.YCoOrdinate,to.YCoOrdinate,history,CoOrdinateType.X);
            }
            if (to.YCoOrdinate == CurrentCoOrdinate.YCoOrdinate && Math.Abs(to.XCoOrdinate - CurrentCoOrdinate.YCoOrdinate) > 0)
            {
                return AreCellsEmpty(CurrentCoOrdinate.YCoOrdinate, CurrentCoOrdinate.XCoOrdinate, to.XCoOrdinate, history, CoOrdinateType.Y);
            }

            return false;
        }

        private bool AreCellsEmpty(int staticIndex, int startIndex, int finalIndex, History history,CoOrdinateType coOrdinateType)
        {
            Piece foundPiece;
            if (startIndex < finalIndex)
            {
                for (int i = startIndex + 1; i <= finalIndex; i++)
                {
                    var checkCoOrdinate = coOrdinateType == CoOrdinateType.X ? new CoOrdinate(staticIndex, i) : new CoOrdinate(i, staticIndex);
                    if (history.LayOut.TryGetValue(checkCoOrdinate, out foundPiece))
                    {
                        if (!CanPieceBeMoved(finalIndex, foundPiece, i))
                            return false;
                    }
                }
            }
            else
            {
                for (int i = startIndex - 1; i >= finalIndex; i--)
                {
                    var checkCoOrdinate = coOrdinateType == CoOrdinateType.X ? new CoOrdinate(staticIndex, i) : new CoOrdinate(i, staticIndex);
                    if (history.LayOut.TryGetValue(checkCoOrdinate, out foundPiece))
                    {
                        if (!CanPieceBeMoved(finalIndex, foundPiece, i))
                            return false;
                    }
                }
            }
            return true;
        }

        private bool CanPieceBeMoved(int finalIndex, Piece foundPiece, int i)
        {
            if (i == finalIndex)
            {
                //If the destination index color is same as my color, wrong move. 
                //You cannot kill your own piece.
                if (foundPiece.Color == Color)
                    return false;
                else
                    return true;
            }
            else
                return false;
        }
    }
}
