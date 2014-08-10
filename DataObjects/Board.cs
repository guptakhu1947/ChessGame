using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.DataObjects
{
    class Board
    {
        /*
        * Setting up piecesByColor so that the board can be set up even if there are no players
         * It also enables us to assign the pieces to a Player later when the PLayer choses his Color preference
         * 
         * History is set up by CoOrdinates, cz once the game starts, per turn only one CoOrdinate changes
        */
        #region private initializers
        private const int DIMENSION = 8;
        private Dictionary<Color, IEnumerable<Piece>> _piecesByColor;
        private BoardState _boardState;
        #endregion

        public int CurrentMoveNumber { get; private set; }
        
        public IDictionary<Color, IEnumerable<Piece>> PiecesByColor
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
            _piecesByColor = new Dictionary<Color, IEnumerable<Piece>>();
        }
       
        public void SetUp()
        {
            Dictionary<CoOrdinate, Piece> initialPiecesByCorOrdinate = new Dictionary<CoOrdinate, Piece>(new CoOrdinateCompare());
           _piecesByColor[Color.Black] = SetUpPiecesByColor(Color.Black, initialPiecesByCorOrdinate);
           _piecesByColor[Color.White] = SetUpPiecesByColor(Color.White, initialPiecesByCorOrdinate);
           _boardState.InitializeState(CurrentMoveNumber, initialPiecesByCorOrdinate);
        }

        private IEnumerable<Piece> SetUpPiecesByColor(Color color, Dictionary<CoOrdinate, Piece> initialPiecesByCorOrdinate)
        {
            PieceFactory pieceFactory = new PieceFactory();
            List<Piece> piecesByColor = new List<Piece>();
            _boardState.SetUpState(pieceFactory.Get(PieceType.Bishop).SetUp(color), initialPiecesByCorOrdinate, piecesByColor);
            _boardState.SetUpState(pieceFactory.Get(PieceType.King).SetUp(color), initialPiecesByCorOrdinate, piecesByColor);
            _boardState.SetUpState(pieceFactory.Get(PieceType.Knight).SetUp(color), initialPiecesByCorOrdinate, piecesByColor);
            _boardState.SetUpState(pieceFactory.Get(PieceType.Pawn).SetUp(color), initialPiecesByCorOrdinate, piecesByColor);
            _boardState.SetUpState(pieceFactory.Get(PieceType.Queen).SetUp(color), initialPiecesByCorOrdinate, piecesByColor);
            _boardState.SetUpState(pieceFactory.Get(PieceType.Rook).SetUp(color), initialPiecesByCorOrdinate, piecesByColor);
            return piecesByColor;
        }

        internal void UpdateState(Piece piece)
        {
           CurrentMoveNumber = _boardState.UpdateState(piece, CurrentMoveNumber);
           GetStatus();
        }

        /*
         * Dummy Win position
         * If King of any color is in co-ordinate (5,5), you win
         */
        internal Status GetStatus()
        {
            return _boardState.GetStatus(CurrentMoveNumber);
        }

        internal History GetStateForMove(int moveNumber)
        {
            return _boardState.GetStateForMove(moveNumber);
        }

        internal History GetState()
        {
            return _boardState.GetState(CurrentMoveNumber);
        }
    }
}
