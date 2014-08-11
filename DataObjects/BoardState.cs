using ChessGame.Interfaces;
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

    class BoardState : IBoardState
    {
        #region PrivateMembers
        private Dictionary<int, History> _history;
        private Status _status;
        private IDictionary<Color, HashSet<Piece>> _piecesByColor;
        private Dictionary<Color, CoOrdinate> _kingByColor;
        #endregion

        internal BoardState()
        {
            _history = new Dictionary<int, History>();
            _status = Status.Continue;
            _kingByColor = new Dictionary<Color, CoOrdinate>();
        }

        #region Methods for tracking the state of the board

        public void InitializeState(int currentMoveNumber, Dictionary<CoOrdinate, Piece> initialPiecesByCorOrdinate, Dictionary<Color, HashSet<Piece>> piecesByColor)
        {
            _history[currentMoveNumber] = new History() { LayOut = initialPiecesByCorOrdinate, ColorPlayed = Color.White };
            _piecesByColor = piecesByColor;
        }

        public void SetUpState(Dictionary<CoOrdinate, Piece> currentPiecesByCoOrdinate, Dictionary<CoOrdinate, Piece> initialPiecesByCorOrdinate, HashSet<Piece> piecesByColor)
        {
            foreach (var item in currentPiecesByCoOrdinate)
            {
                initialPiecesByCorOrdinate.Add(item.Key, item.Value);
                piecesByColor.Add(item.Value);
                if (item.Value.Type == PieceType.King)
                    _kingByColor[item.Value.Color] = item.Value.CurrentCoOrdinate;
            }
        }

        public int UpdateState(Piece piece, int currentMoveNumber)
        {
            if (piece.Type == PieceType.King)
                _kingByColor[piece.Color] = piece.CurrentCoOrdinate;

            UpdateStatus(piece, currentMoveNumber);           
            History history = new History() { ColorPlayed = piece.Color };
            history.LayOut = new Dictionary<CoOrdinate, Piece>(_history[currentMoveNumber].LayOut, new CoOrdinateCompare());
            history.LayOut.Remove(piece.FromCoOrdinate);
            history.LayOut[piece.CurrentCoOrdinate] = piece;
            currentMoveNumber++;
            _history.Add(currentMoveNumber, history);
            return currentMoveNumber;
        }

        private void UpdateStatus(Piece piece, int currentMoveNumber)
        {
            History boardState;
            if (!_history.TryGetValue(currentMoveNumber, out boardState))
                throw (new Exception("No state found for this move."));
            
            _status = Status.Continue;           
            CheckWinStatus(piece, boardState);
            if(_status != Status.Win)
                CheckCheckMateStatus(piece,boardState);
        }

        private void CheckWinStatus(Piece piece, History boardState)
        {
            Piece foundPiece;
            if (boardState.LayOut.TryGetValue(piece.CurrentCoOrdinate, out foundPiece))
            {
                if (foundPiece.Type == PieceType.King)
                    _status = Status.Win; //You win if you can replace the King
            }
        }

        /*
         * If a player's move, set's up the board in a manner that his next move can kill the King,
         * It's a checkmate
         */
        private void CheckCheckMateStatus(Piece piece, History boardState)
        {
            var kingPieceCurrentCoOrdinate = piece.Color == Color.White ? _kingByColor[Color.Black] : _kingByColor[Color.White];
            var piecesByColor = boardState.LayOut.Where(x => x.Value.Color == piece.Color); ;
            
            /*
             * If any piece of the current player, can move to the oppponent's King coOrdinate, it's a checkMate
             */
            foreach (var item in piecesByColor)
            {
                if (item.Value.IsValidMove(kingPieceCurrentCoOrdinate, boardState))
                {
                    if (item.Value.Type == PieceType.King)
                        _status = Status.Draw;
                    else
                        _status = Status.CheckMate;
                }
            }
        }

        public History GetStateForMove(int moveNumber)
        {
            History boardState;
            if (!_history.TryGetValue(moveNumber, out boardState))
                throw (new Exception("No state found for this move."));
            return boardState;
        }

        public History GetState(int currentMoveNumber)
        {
            History boardState;
            if (!_history.TryGetValue(currentMoveNumber, out boardState))
                throw (new Exception("No state found for this move."));
            return boardState;
        }

    
        public Status GetStatus(int currentMoveNumber)
        {
            return _status;
        }
        #endregion
    }
}
