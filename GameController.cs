using ChessGame.Controls;
using ChessGame.DataObjects;
using ChessGame.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGame
{

    public partial class GameController : Form
    {
        #region PrivateMembers
        private IGame _game;
        private PieceButton _currentSelectedPiece;
        private PlayerName _currentPlayerTurn;
        private string _currentPlayerName;
        private bool _isFirstClick;
        private Timer _messageFlashTimer = new Timer();
        private int _boardStateHistoryRowNumber = 1;

        private static string choosePieceColorByPlayer = "Player One, please choose your color.";
        private static string pieceSelectionText = ",click on the piece you want to play.";
        private static string pieceNextPositionText = ",click on the destination square to put the piece.";
        private static string errorWrongMove = "Wrong move! Please choose again.";
        private static string noPieceFound = "No piece at this position!";
        private static string moveDetail = "{0} moved {1}";
        private static string restoreMoveDetail = "{0} restored the board to move number = {1}";
        private static string restoreText = "You can restore the board to this move by clicking this button";
        private static string checkMateText = ",its a CheckMate for you!";
        private static string drawMessage = "It's a Draw!";
        private static string winMessage = ", you win!!!";
        private static string playerOne = "Player One";
        private static string playerTwo = "Player Two";
        #endregion

        public GameController()
        {
            _messageFlashTimer.Interval = 500;
            _messageFlashTimer.Tick += new EventHandler(timer_Tick);
            InitializeComponent();
            InitializeController();
        }

        private void InitializeController()
        {
            _boardStateHistoryRowNumber = 1;
            _isFirstClick = true;
            _messageFlashTimer.Enabled = false;
            _currentPlayerTurn = PlayerName.PlayerOne;
            _currentPlayerName = playerOne;
            Message.Text = choosePieceColorByPlayer;
            WhiteBox.Location = new Point(416, 173);
            BlackBox.Location = new Point(482, 173);
            Message.Location = new Point(413, 119);
            BlackBox.Enabled = true;
            WhiteBox.Enabled = true;
            BoardStatePanel.Enabled = true;
            BoardStatePanel.Visible = false;
            BoardStateHistoryHeader.Visible = false;
            CheckMateLabel.Visible = false;
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            _game = new Game();
            _game.SetUp();
            var boardState = _game.GetState();
            DrawChessBoard(boardState);
            ChessBoard.Enabled = false;
        }

        private void DrawChessBoard(History boardState)
        {
            ChessBoard.Controls.Clear();
            for (int row = 0; row < this.ChessBoard.ColumnCount; row++)
            {
                for (int column = 0; column < this.ChessBoard.RowCount; column++)
                {
                    CoOrdinate key = new CoOrdinate(row, column);
                    PieceButton cellButton = CreateButton(row, column);
                    Piece piece;
                    if (boardState.LayOut.TryGetValue(key, out piece))
                    {
                        cellButton.Image = piece.Image;
                    }
                    cellButton.Piece = piece;
                    this.ChessBoard.Controls.Add(cellButton, row, column);
                }
            }
        }

        private PieceButton CreateButton(int row, int column)
        {
            PieceButton cellButton = new PieceButton();
            cellButton.Height = 200;
            cellButton.Width = 200;
            cellButton.Padding = new Padding(0);
            cellButton.Margin = new Padding(0);
            cellButton.Image = null;
            cellButton.Name = row + "_" + column;

            if ((column + row) % 2 == 0)
                cellButton.BackColor = System.Drawing.Color.Orange;
            cellButton.Click += new EventHandler(Cellbutton_Click);
            return cellButton;
        }

        private void RefreshChessBoard()
        {
            var pieceBeingMoved = _currentSelectedPiece.Piece;

            var fromControl = ChessBoard.GetControlFromPosition(pieceBeingMoved.FromCoOrdinate.XCoOrdinate, pieceBeingMoved.FromCoOrdinate.YCoOrdinate);
            var toControl = ChessBoard.GetControlFromPosition(pieceBeingMoved.CurrentCoOrdinate.XCoOrdinate, pieceBeingMoved.CurrentCoOrdinate.YCoOrdinate);

            var toControlNew = CreateButton(pieceBeingMoved.FromCoOrdinate.XCoOrdinate, pieceBeingMoved.FromCoOrdinate.YCoOrdinate);
            var fromControlNew = CreateButton(pieceBeingMoved.CurrentCoOrdinate.XCoOrdinate, pieceBeingMoved.CurrentCoOrdinate.YCoOrdinate);
            fromControlNew.Name = toControl.Name;

            var boardState = _game.GetState();

            Piece piece;
            if (boardState.LayOut.TryGetValue(pieceBeingMoved.CurrentCoOrdinate, out piece))
            {
                fromControlNew.Image = piece.Image;
            }
            fromControlNew.Piece = piece;

            ChessBoard.Controls.Remove(fromControl);
            ChessBoard.Controls.Remove(toControl);
            toControl.Dispose();
            fromControl.Dispose();
            ChessBoard.Controls.Add(fromControlNew, pieceBeingMoved.CurrentCoOrdinate.XCoOrdinate, pieceBeingMoved.CurrentCoOrdinate.YCoOrdinate);
            ChessBoard.Controls.Add(toControlNew, pieceBeingMoved.FromCoOrdinate.XCoOrdinate, pieceBeingMoved.FromCoOrdinate.YCoOrdinate);
        }

        private void DrawBoardStateHistory()
        {
            BoardStateHistory.MaximumSize = new Size(220, 0);
            ColumnStyle cStyle = new ColumnStyle(SizeType.Absolute);

            RowStyle rStyle = new RowStyle(SizeType.AutoSize);
            rStyle.Height = 30;
            BoardStateHistory.ColumnStyles.Add(cStyle);
            BoardStateHistory.RowStyles.Add(rStyle);
            BoardStateHistory.AutoScroll = false;
        }

        private void PopulateBoardStateHistoryEnteries(Control firstColumn, Control secondColumn)
        {
            BoardStateHistory.Controls.Add(firstColumn, 0, _boardStateHistoryRowNumber);
            BoardStateHistory.Controls.Add(secondColumn, 1, _boardStateHistoryRowNumber);
            _boardStateHistoryRowNumber++;
        }

        private void UpdateStateHistory(bool wasBoardRestored = false, string moveRestored = null)
        {
            Button moveNumber = new Button();
            string currentMoveNumber = _game.GetCurrentMoveNumber().ToString();
            moveNumber.Text = _boardStateHistoryRowNumber.ToString();
            moveNumber.Name = currentMoveNumber;
            moveNumber.Anchor = AnchorStyles.None;
            moveNumber.Font = new System.Drawing.Font(moveNumber.Font.FontFamily.Name, 8);
            new ToolTip().SetToolTip(moveNumber, restoreText);
            moveNumber.Click += new EventHandler(SetBoardStateByMove_Click);

            Label details = new Label();
            details.AutoSize = true;
            details.TextAlign = ContentAlignment.BottomLeft;
            details.Anchor = AnchorStyles.None;
            details.Dock = DockStyle.Left;
            details.MaximumSize = new Size(200, 0);
            details.Font = new System.Drawing.Font(moveNumber.Font.FontFamily.Name, 8);

            if (!wasBoardRestored)
                details.Text = string.Format(moveDetail, _currentPlayerName, _currentSelectedPiece.Piece.Type);
            else
                details.Text = string.Format(restoreMoveDetail, _currentPlayerName, moveRestored);

            PopulateBoardStateHistoryEnteries(moveNumber, details);
        }

        private void SetBoardStateByMove_Click(object sender, EventArgs e)
        {
            TurnTimer.Enabled = false;
            Button moveNumber = (Button)sender;
            UpdateStateHistory(true, moveNumber.Text);
            var history = _game.GetStateForMove(Int32.Parse(moveNumber.Name));

            /*
             * If PlayerOne was the player who played the nth move, then when the board is restored to nth state,
             * it is the next player's turn
            */
            _currentPlayerTurn = _game.GetPlayerByColor(history.ColorPlayed) == PlayerName.PlayerOne ? PlayerName.PlayerTwo : PlayerName.PlayerOne;
            _currentPlayerName = _currentPlayerTurn == PlayerName.PlayerOne ? playerOne : playerTwo;
            DrawChessBoard(history);
            TurnTimer.Enabled = true;
        }


        private void Cellbutton_Click(object sender, EventArgs e)
        {
            PieceButton pieceButton = (PieceButton)sender;
            if (_isFirstClick)
            {
                _isFirstClick = OnFirstClick(pieceButton);
            }
            else
            {
                OnSecondClick(pieceButton);
                _isFirstClick = true;
            }
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StartGame_Click(object sender, EventArgs e)
        {
            WhiteBox.Visible = true;
            BlackBox.Visible = true;
            Message.Visible = true;
            StartGame.Text = "Restart Game";
            StartGame.Click -= StartGame_Click;
            StartGame.Click += Restart_Click;
        }

        private void Restart_Click(object sender, EventArgs e)
        {
            BoardStateHistory.Controls.Clear();
            BoardStateHistory.RowStyles.Clear();
            TurnTimer.Enabled = false;
            InitializeController();
        }

        private void WhiteBox_Click(object sender, EventArgs e)
        {
            WhiteBox.Location = new Point(391, 69);
            BlackBox.Location = new Point(391, 204);
            _game.AddPlayer(PlayerName.PlayerOne, Color.White);
            _game.AddPlayer(PlayerName.PlayerTwo, Color.Black);
            PrepareToStartGame();
        }

        private void BlackBox_Click(object sender, EventArgs e)
        {
            BlackBox.Location = new Point(391, 69);
            WhiteBox.Location = new Point(391, 204);
            _game.AddPlayer(PlayerName.PlayerOne, Color.Black);
            _game.AddPlayer(PlayerName.PlayerTwo, Color.White);
            PrepareToStartGame();
        }

        private void PrepareToStartGame()
        {
            Message.Visible = false;
            WhiteBox.Enabled = false;
            BlackBox.Enabled = false;
            TurnTimer.Enabled = true;
            BoardStatePanel.Visible = true;
            BoardStateHistoryHeader.Visible = true;
            ChessBoard.Enabled = true;
            DrawBoardStateHistory();
        }

        private void PlayGame()
        {
            Message.Visible = true;
            _messageFlashTimer.Enabled = true;
            if (_currentPlayerTurn == PlayerName.PlayerOne)
            {
                Message.Location = new Point(450, 69);
                TakeTurn(PlayerName.PlayerOne);
            }
            else
            {
                Message.Location = new Point(450, 204);
                TakeTurn(PlayerName.PlayerTwo);
            }
        }

        private void TakeTurn(PlayerName player)
        {
            Message.Text = _currentPlayerName + pieceSelectionText;
        }

        private bool OnFirstClick(PieceButton currentPosition)
        {
            Message.Text = _currentPlayerName + pieceNextPositionText;
            _currentSelectedPiece = currentPosition;
            if (_currentSelectedPiece.Piece == null)
            {
                MessageBox.Show(this, noPieceFound);
                _messageFlashTimer.Enabled = false;
                return true;
            }
            return false;
        }

        private void OnSecondClick(PieceButton currentPosition)
        {
            CoOrdinate toCoOrdinate = CoOrdinate.GetCoOrdinate(currentPosition.Name);

            //If the location to be moved is not empty or is not a valid move
            if (!_game.PlayTurn(_currentPlayerTurn, _currentSelectedPiece.Piece, toCoOrdinate))
            {
                _messageFlashTimer.Enabled = false;
                MessageBox.Show(this, errorWrongMove);
            }
            else
            {
                RefreshChessBoard();
                UpdateStateHistory();
                CheckGameStatus();
            }
        }

        private void CheckGameStatus()
        {
            CheckMateLabel.Visible = false;
            if (_game.IsGameOver() || _game.IsGameDraw())
            {
                TurnTimer.Stop();
                ChessBoard.Enabled = false;
                BoardStateHistory.Enabled = false;
                Message.Location = new Point(413, 150);
                if (_game.IsGameDraw())
                    Message.Text = drawMessage;
                else
                    Message.Text = _currentPlayerName + winMessage;
            }
            else
            {
                _currentPlayerTurn = _currentPlayerTurn == PlayerName.PlayerOne ? PlayerName.PlayerTwo : PlayerName.PlayerOne;
                _currentPlayerName = _currentPlayerTurn == PlayerName.PlayerOne ? playerOne : playerTwo;
                if (_game.IsCheck())
                {
                    CheckMateLabel.Text = _currentPlayerName + checkMateText;
                    CheckMateLabel.Visible = true;
                }
            }
        }

        #region Timers
        private void turnTimer_Tick(object sender, EventArgs e)
        {
            PlayGame();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (_isFirstClick)
            {
                if (Message.ForeColor == System.Drawing.Color.Green)
                    Message.ForeColor = System.Drawing.Color.Coral;
                else
                    Message.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                if (Message.ForeColor == System.Drawing.Color.Blue)
                    Message.ForeColor = System.Drawing.Color.Coral;
                else
                    Message.ForeColor = System.Drawing.Color.Blue;
            }
        }
        #endregion
    }
}
