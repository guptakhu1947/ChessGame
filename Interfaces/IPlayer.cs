using ChessGame.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Interfaces
{
    public interface IPlayer
    {
        IPlayer GetPlayer(PlayerName name, Color color);
        void SetUp(ICollection<Piece> pieces);
        void PlayTurn(Piece piece, CoOrdinate to);
        bool IsValidMove(Piece piece, CoOrdinate to, History history);

    }
}
