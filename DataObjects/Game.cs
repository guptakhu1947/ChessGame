using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.DataObjects
{
    public class Game
    {
        public const int MAXPLAYERS = 2;
        public List<Player> Players;
        private Status _status;
        private Board _board;
        private Dictionary<PlayerName, Player> _playerDetailsByType;
        private Dictionary<Color, PlayerName> _playersByColor;

        public Game()
        {
            Players = new List<Player>(MAXPLAYERS);
            _playerDetailsByType = new Dictionary<PlayerName, Player>();
            _playersByColor = new Dictionary<Color, PlayerName>();
            _board = new Board();           
        }

        public void SetUp()
        {
            _board.SetUp();
        }

        public void AddPlayer(PlayerName playerType, Color color)
        {
            Player player = new Player(playerType, color);
            Players.Add(player);
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
            History history = _board.GetState();

            if (player.IsValidMove(piece, to, history))
            {
                player.PlayTurn(piece, to);
                _board.UpdateState(piece);
                return true;
            }
            return false;
        }

        public History GetStateForMove(int moveNumber)
        {
            return _board.GetStateForMove(moveNumber);
        }

        public History GetState()
        {
            return _board.GetState();
        }

        public int GetCurrentMoveNumber()
        {
            return _board.CurrentMoveNumber;
        }

        public bool IsGameOver()
        {
            _status = _board.GetStatus();
            if (_status == Status.Win || _status == Status.Lose || _status == Status.Draw)
                return true;
            return false;
        }
    }
}
