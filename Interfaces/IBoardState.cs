using ChessGame.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Interfaces
{
    interface IBoardState
    {
        void InitializeState(int currentMoveNumber, Dictionary<CoOrdinate, Piece> initialPiecesByCorOrdinate, Dictionary<Color, HashSet<Piece>> piecesByColor);
        void SetUpState(Dictionary<CoOrdinate, Piece> currentPiecesByCoOrdinate, Dictionary<CoOrdinate, Piece> initialPiecesByCorOrdinate, HashSet<Piece> piecesByColor);
        int UpdateState(Piece piece, int currentMoveNumber);
        History GetStateForMove(int moveNumber);
        History GetState(int currentMoveNumber);
        Status GetStatus(int currentMoveNumber);
    }
}
