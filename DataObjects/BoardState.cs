using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.DataObjects
{
    public class History
    {
        public IDictionary<CoOrdinate, Piece> LayOut;
        public Color ColorPlayed;      
    }

    class BoardState
    {
        #region PrivateMembers
        private Dictionary<int, History> _history;
        private Status _status;
        private static CoOrdinate winningCoOrdinate = new CoOrdinate(3,3);
        private static CoOrdinate checkMateKingCoOrdinate = new CoOrdinate(3,4);
        private static CoOrdinate checkMateBishopCoOrdinate = new CoOrdinate(4, 3);
        #endregion

        internal BoardState()
        {
            _history = new Dictionary<int, History>();
            _status = Status.Continue;
        }

        #region Methods for tracking the state of the board

        public void SetUpState(Dictionary<CoOrdinate, Piece> currentPiecesByCoOrdinate, Dictionary<CoOrdinate, Piece> initialPiecesByCorOrdinate, List<Piece> piecesByColor)
        {
            foreach (var item in currentPiecesByCoOrdinate)
            {
                initialPiecesByCorOrdinate.Add(item.Key, item.Value);
                piecesByColor.Add(item.Value);
            }
        }

        internal int UpdateState(Piece piece, int currentMoveNumber)
        {
            History history = new History() { ColorPlayed = piece.Color };
            history.LayOut = new Dictionary<CoOrdinate, Piece>(_history[currentMoveNumber].LayOut, new CoOrdinateCompare());
            history.LayOut.Remove(piece.FromCoOrdinate);
            history.LayOut[piece.CurrentCoOrdinate] = piece;
            currentMoveNumber++;
            _history.Add(currentMoveNumber, history);
            UpdateStatus(piece, currentMoveNumber);
            return currentMoveNumber;
        }

        private void UpdateStatus(Piece piece, int currentMoveNumber)
        {
            History boardState;
            if (!_history.TryGetValue(currentMoveNumber, out boardState))
                throw (new Exception("No state found for this move."));

            Piece foundPiece;
            if (boardState.LayOut.TryGetValue(piece.FromCoOrdinate, out foundPiece))
            {
                if (foundPiece.Type == PieceType.King)
                    _status = Status.Win; //You win if you can replace the King
            }
        }

        internal History GetStateForMove(int moveNumber)
        {
            History boardState;
            if (!_history.TryGetValue(moveNumber, out boardState))
                throw (new Exception("No state found for this move."));
            return boardState;
        }

        internal History GetState(int currentMoveNumber)
        {
            History boardState;
            if (!_history.TryGetValue(currentMoveNumber, out boardState))
                throw (new Exception("No state found for this move."));
            return boardState;
        }

    
        internal Status GetStatus(int currentMoveNumber)
        {
            return _status;
        }
        #endregion

        internal void InitializeState(int currentMoveNumber, Dictionary<CoOrdinate, Piece> initialPiecesByCorOrdinate)
        {
            _history[currentMoveNumber] = new History() { LayOut = initialPiecesByCorOrdinate, ColorPlayed = Color.White };
        }
    }
}
