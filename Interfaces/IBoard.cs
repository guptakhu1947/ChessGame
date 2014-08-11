using ChessGame.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Interfaces
{
    interface IBoard
    {
        int CurrentMoveNumber { get; set; }
        IDictionary<Color, HashSet<Piece>> PiecesByColor { get; }
        IBoardState SetUp();
        HashSet<Piece> SetUpPiecesByColor(Color color, Dictionary<CoOrdinate, Piece> initialPiecesByCorOrdinate);
        void UpdateState(Piece piece);
    }
}
