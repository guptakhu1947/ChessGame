using ChessGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.DataObjects
{
    public class Player :IPlayer
    {
        public PlayerName Name;
        private HashSet<Piece> _myPieces;
        private Color _color;

        public Player()
        {
        }

        Player(PlayerName name, Color color)
        {
            Name = name;
            _color = color;
        }

        public IPlayer GetPlayer(PlayerName name, Color color)
        {
            return new Player(name, color);
        }

        public void SetUp(ICollection<Piece> pieces)
        {
            _myPieces = pieces.ToHashSet();
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
