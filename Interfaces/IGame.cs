using ChessGame.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Interfaces
{
    interface IGame
    {
        void SetUp();
        void AddPlayer(PlayerName playerType, Color color);
        PlayerName GetPlayerByColor(Color color);
        bool PlayTurn(PlayerName playerType, Piece piece, CoOrdinate to);
        History GetStateForMove(int moveNumber);
        History GetState();
        int GetCurrentMoveNumber();
        bool IsGameOver();
        bool IsGameDraw();
        bool IsCheck();
    }
}
