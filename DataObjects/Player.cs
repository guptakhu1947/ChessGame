using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.DataObjects
{
    public class Player
    {
        public PlayerName Name;
        private HashSet<Piece> _myPieces;
        private Color _color;

        public Player(PlayerName name, Color color)
        {
            Name = name;
            _color = color;
        }
        
        public void SetUp(IEnumerable<Piece> pieces)
        {
            _myPieces = pieces.ToHashSet();//For direct lookup to Validate the move
        }

        public void PlayTurn(Piece piece, CoOrdinate to)
        {
            piece.Move(to);
        }

        public bool IsValidMove(Piece piece, CoOrdinate to,History history)
        {
            if (!_myPieces.Contains(piece, new PieceComparer()))
                return false;

            if (piece.IsValidMove(to, history))
                return true;

            return false;
        }
    }
}
