using ChessGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.DataObjects
{
    class Board : IBoard
    {
        /*
        * Setting up piecesByColor so that the board can be set up even if there are no players
         * It also enables us to assign the pieces to a Player later when the PLayer choses his Color preference
         * 
         * History is set up by CoOrdinates, cz once the game starts, per turn only one CoOrdinate changes
        */
        #region private initializers
        private const int DIMENSION = 8;
        private Dictionary<Color, HashSet<Piece>> _piecesByColor;
        private IBoardState _boardState;
        #endregion

        public int CurrentMoveNumber { get; set; }
        
        public IDictionary<Color, HashSet<Piece>> PiecesByColor
        {
            get
            {
                return _piecesByColor;
            }
        }

        public Board()
        {
            CurrentMoveNumber = 0;
            _boardState = new BoardState();
            _piecesByColor = new Dictionary<Color, HashSet<Piece>>();
        }

        public IBoardState SetUp()
        {
            Dictionary<CoOrdinate, Piece> initialPiecesByCorOrdinate = new Dictionary<CoOrdinate, Piece>(new CoOrdinateCompare());
           _piecesByColor[Color.Black] = SetUpPiecesByColor(Color.Black, initialPiecesByCorOrdinate);
           _piecesByColor[Color.White] = SetUpPiecesByColor(Color.White, initialPiecesByCorOrdinate);
           _boardState.InitializeState(CurrentMoveNumber, initialPiecesByCorOrdinate, _piecesByColor);
           return _boardState;
        }

        public HashSet<Piece> SetUpPiecesByColor(Color color, Dictionary<CoOrdinate, Piece> initialPiecesByCorOrdinate)
        {
            PieceFactory pieceFactory = new PieceFactory();
            HashSet<Piece> piecesByColor = new HashSet<Piece>();
            _boardState.SetUpState(pieceFactory.Get(PieceType.Bishop).SetUp(color), initialPiecesByCorOrdinate, piecesByColor);
            _boardState.SetUpState(pieceFactory.Get(PieceType.King).SetUp(color), initialPiecesByCorOrdinate, piecesByColor);
            _boardState.SetUpState(pieceFactory.Get(PieceType.Knight).SetUp(color), initialPiecesByCorOrdinate, piecesByColor);
            _boardState.SetUpState(pieceFactory.Get(PieceType.Pawn).SetUp(color), initialPiecesByCorOrdinate, piecesByColor);
            _boardState.SetUpState(pieceFactory.Get(PieceType.Queen).SetUp(color), initialPiecesByCorOrdinate, piecesByColor);
            _boardState.SetUpState(pieceFactory.Get(PieceType.Rook).SetUp(color), initialPiecesByCorOrdinate, piecesByColor);
            return piecesByColor;
        }

        public void UpdateState(Piece piece)
        {
           CurrentMoveNumber = _boardState.UpdateState(piece, CurrentMoveNumber);
        }
    }
}
