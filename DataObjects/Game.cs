using ChessGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.DataObjects
{
    public class Game :IGame
    {
        public const int MAXPLAYERS = 2;

        private IBoard _board;
        private IPlayer _player;
        private IBoardState _boardState;
        private Dictionary<PlayerName, IPlayer> _playerDetailsByType;
        private Dictionary<Color, PlayerName> _playersByColor;
        private List<IPlayer> _players;
        private Status _status;
       
        public Game()
        {
            _players = new List<IPlayer>(MAXPLAYERS);
            _playerDetailsByType = new Dictionary<PlayerName, IPlayer>();
            _playersByColor = new Dictionary<Color, PlayerName>();
            _board = new Board();
            _player = new Player();
        }

        public void SetUp()
        {
           _boardState = _board.SetUp();
        }

        public void AddPlayer(PlayerName playerType, Color color)
        {
            IPlayer player = _player.GetPlayer(playerType, color);
            _players.Add(player);
            player.SetUp(_board.PiecesByColor[color]);
            _playerDetailsByType[playerType] = player;
            _playersByColor[color] = playerType;
        }

        public PlayerName GetPlayerByColor(Color color)
        {
            PlayerName playerName;
            if (!_playersByColor.TryGetValue(color, out playerName))
                throw (new Exception("No player found for this color"));

            return playerName;
        }

        public bool PlayTurn(PlayerName playerType, Piece piece, CoOrdinate to)
        {
            var player = _playerDetailsByType[playerType];
            History history = _boardState.GetState(_board.CurrentMoveNumber);
            if (player.IsValidMove(piece, to, history))
            {
                player.PlayTurn(piece, to);
                _board.UpdateState(piece);
                _status = _boardState.GetStatus(_board.CurrentMoveNumber);
                return true;
            }
            return false;
        }

        public History GetStateForMove(int moveNumber)
        {
            return _boardState.GetStateForMove(moveNumber);
        }

        public History GetState()
        {
            return _boardState.GetState(_board.CurrentMoveNumber);
        }

        public int GetCurrentMoveNumber()
        {
            return _board.CurrentMoveNumber;
        }

        public bool IsGameOver()
        {
            if (_status == Status.Win)
                return true;
            return false;
        }

        public bool IsGameDraw()
        {
            if (_status == Status.Draw)
                return true;
            return false;
        }

        public bool IsCheck()
        {
            if (_status == Status.CheckMate)
                return true;
            return false;
        }
    }
}
