using System.Drawing;
namespace ChessGame
{
    partial class GameController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameController));
            this.ChessBoard = new System.Windows.Forms.TableLayoutPanel();
            this.PlayerOne = new System.Windows.Forms.PictureBox();
            this.PlayerTwo = new System.Windows.Forms.PictureBox();
            this.PlayerOneLabel = new System.Windows.Forms.Label();
            this.PlayerTwoLabel = new System.Windows.Forms.Label();
            this.StartGame = new System.Windows.Forms.Button();
            this.Quit = new System.Windows.Forms.Button();
            this.WhiteBox = new System.Windows.Forms.PictureBox();
            this.BlackBox = new System.Windows.Forms.PictureBox();
            this.Message = new System.Windows.Forms.Label();
            this.TurnTimer = new System.Windows.Forms.Timer(this.components);
            this.BoardStateHistory = new System.Windows.Forms.TableLayoutPanel();
            this.BoardStatePanel = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.BoardStateHistoryHeader = new System.Windows.Forms.TableLayoutPanel();
            this.MoveNumber = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CheckMateLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerOne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerTwo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WhiteBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlackBox)).BeginInit();
            this.BoardStatePanel.SuspendLayout();
            this.BoardStateHistoryHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChessBoard
            // 
            this.ChessBoard.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ChessBoard.ColumnCount = 8;
            this.ChessBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ChessBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ChessBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ChessBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ChessBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ChessBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ChessBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ChessBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ChessBoard.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.ChessBoard.Location = new System.Drawing.Point(12, 12);
            this.ChessBoard.Margin = new System.Windows.Forms.Padding(0);
            this.ChessBoard.Name = "ChessBoard";
            this.ChessBoard.RowCount = 8;
            this.ChessBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ChessBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ChessBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ChessBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ChessBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ChessBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ChessBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ChessBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ChessBoard.Size = new System.Drawing.Size(240, 240);
            this.ChessBoard.TabIndex = 0;
            // 
            // PlayerOne
            // 
            this.PlayerOne.Image = ((System.Drawing.Image)(resources.GetObject("PlayerOne.Image")));
            this.PlayerOne.InitialImage = ((System.Drawing.Image)(resources.GetObject("PlayerOne.InitialImage")));
            this.PlayerOne.Location = new System.Drawing.Point(291, 41);
            this.PlayerOne.Name = "PlayerOne";
            this.PlayerOne.Size = new System.Drawing.Size(69, 79);
            this.PlayerOne.TabIndex = 1;
            this.PlayerOne.TabStop = false;
            // 
            // PlayerTwo
            // 
            this.PlayerTwo.Image = ((System.Drawing.Image)(resources.GetObject("PlayerTwo.Image")));
            this.PlayerTwo.Location = new System.Drawing.Point(291, 173);
            this.PlayerTwo.Name = "PlayerTwo";
            this.PlayerTwo.Size = new System.Drawing.Size(69, 79);
            this.PlayerTwo.TabIndex = 2;
            this.PlayerTwo.TabStop = false;
            // 
            // PlayerOneLabel
            // 
            this.PlayerOneLabel.AutoSize = true;
            this.PlayerOneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerOneLabel.ForeColor = System.Drawing.Color.Green;
            this.PlayerOneLabel.Location = new System.Drawing.Point(288, 21);
            this.PlayerOneLabel.Name = "PlayerOneLabel";
            this.PlayerOneLabel.Size = new System.Drawing.Size(79, 17);
            this.PlayerOneLabel.TabIndex = 3;
            this.PlayerOneLabel.Text = "Player One";
            // 
            // PlayerTwoLabel
            // 
            this.PlayerTwoLabel.AutoSize = true;
            this.PlayerTwoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerTwoLabel.ForeColor = System.Drawing.Color.Green;
            this.PlayerTwoLabel.Location = new System.Drawing.Point(288, 153);
            this.PlayerTwoLabel.Name = "PlayerTwoLabel";
            this.PlayerTwoLabel.Size = new System.Drawing.Size(78, 17);
            this.PlayerTwoLabel.TabIndex = 4;
            this.PlayerTwoLabel.Text = "Player Two";
            // 
            // StartGame
            // 
            this.StartGame.BackColor = System.Drawing.Color.LightGreen;
            this.StartGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartGame.Location = new System.Drawing.Point(416, 286);
            this.StartGame.Name = "StartGame";
            this.StartGame.Size = new System.Drawing.Size(95, 26);
            this.StartGame.TabIndex = 5;
            this.StartGame.Text = "Start Game";
            this.StartGame.UseVisualStyleBackColor = false;
            this.StartGame.Click += new System.EventHandler(this.StartGame_Click);
            // 
            // Quit
            // 
            this.Quit.BackColor = System.Drawing.Color.LightGreen;
            this.Quit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Quit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quit.Location = new System.Drawing.Point(416, 318);
            this.Quit.Name = "Quit";
            this.Quit.Size = new System.Drawing.Size(95, 26);
            this.Quit.TabIndex = 6;
            this.Quit.Text = "Quit";
            this.Quit.UseVisualStyleBackColor = false;
            this.Quit.Click += new System.EventHandler(this.Quit_Click);
            // 
            // WhiteBox
            // 
            this.WhiteBox.Image = ((System.Drawing.Image)(resources.GetObject("WhiteBox.Image")));
            this.WhiteBox.Location = new System.Drawing.Point(416, 173);
            this.WhiteBox.Name = "WhiteBox";
            this.WhiteBox.Size = new System.Drawing.Size(46, 48);
            this.WhiteBox.TabIndex = 7;
            this.WhiteBox.TabStop = false;
            this.WhiteBox.Visible = false;
            this.WhiteBox.Click += new System.EventHandler(this.WhiteBox_Click);
            // 
            // BlackBox
            // 
            this.BlackBox.Image = ((System.Drawing.Image)(resources.GetObject("BlackBox.Image")));
            this.BlackBox.Location = new System.Drawing.Point(482, 173);
            this.BlackBox.Name = "BlackBox";
            this.BlackBox.Size = new System.Drawing.Size(46, 48);
            this.BlackBox.TabIndex = 8;
            this.BlackBox.TabStop = false;
            this.BlackBox.Visible = false;
            this.BlackBox.Click += new System.EventHandler(this.BlackBox_Click);
            // 
            // Message
            // 
            this.Message.AutoSize = true;
            this.Message.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Message.ForeColor = System.Drawing.Color.IndianRed;
            this.Message.Location = new System.Drawing.Point(413, 119);
            this.Message.MaximumSize = new System.Drawing.Size(150, 0);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(133, 34);
            this.Message.TabIndex = 9;
            this.Message.Text = "Player One, please choose your color.";
            this.Message.Visible = false;
            // 
            // TurnTimer
            // 
            this.TurnTimer.Interval = 1000;
            this.TurnTimer.Tick += new System.EventHandler(this.turnTimer_Tick);
            // 
            // BoardStateHistory
            // 
            this.BoardStateHistory.AutoSize = true;
            this.BoardStateHistory.BackColor = System.Drawing.Color.PowderBlue;
            this.BoardStateHistory.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.BoardStateHistory.ColumnCount = 2;
            this.BoardStateHistory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.BoardStateHistory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BoardStateHistory.ForeColor = System.Drawing.Color.Black;
            this.BoardStateHistory.Location = new System.Drawing.Point(3, 0);
            this.BoardStateHistory.Name = "BoardStateHistory";
            this.BoardStateHistory.RowCount = 1;
            this.BoardStateHistory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.31915F));
            this.BoardStateHistory.Size = new System.Drawing.Size(220, 36);
            this.BoardStateHistory.TabIndex = 10;
            // 
            // BoardStatePanel
            // 
            this.BoardStatePanel.AutoScroll = true;
            this.BoardStatePanel.AutoScrollMinSize = new System.Drawing.Size(0, 227);
            this.BoardStatePanel.Controls.Add(this.BoardStateHistory);
            this.BoardStatePanel.Location = new System.Drawing.Point(631, 74);
            this.BoardStatePanel.Name = "BoardStatePanel";
            this.BoardStatePanel.Size = new System.Drawing.Size(245, 227);
            this.BoardStatePanel.TabIndex = 11;
            // 
            // BoardStateHistoryHeader
            // 
            this.BoardStateHistoryHeader.BackColor = System.Drawing.Color.Silver;
            this.BoardStateHistoryHeader.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.BoardStateHistoryHeader.ColumnCount = 2;
            this.BoardStateHistoryHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.BoardStateHistoryHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BoardStateHistoryHeader.Controls.Add(this.MoveNumber, 0, 0);
            this.BoardStateHistoryHeader.Controls.Add(this.label1, 1, 0);
            this.BoardStateHistoryHeader.ForeColor = System.Drawing.Color.Black;
            this.BoardStateHistoryHeader.Location = new System.Drawing.Point(634, 41);
            this.BoardStateHistoryHeader.Name = "BoardStateHistoryHeader";
            this.BoardStateHistoryHeader.RowCount = 1;
            this.BoardStateHistoryHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.31915F));
            this.BoardStateHistoryHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.BoardStateHistoryHeader.Size = new System.Drawing.Size(220, 36);
            this.BoardStateHistoryHeader.TabIndex = 12;
            // 
            // MoveNumber
            // 
            this.MoveNumber.AutoSize = true;
            this.MoveNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveNumber.Location = new System.Drawing.Point(4, 1);
            this.MoveNumber.Name = "MoveNumber";
            this.MoveNumber.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.MoveNumber.Size = new System.Drawing.Size(44, 31);
            this.MoveNumber.TabIndex = 0;
            this.MoveNumber.Text = "Move Number";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(55, 1);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(50, 20, 0, 0);
            this.label1.Size = new System.Drawing.Size(89, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Details";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CheckMateLabel
            // 
            this.CheckMateLabel.AutoSize = true;
            this.CheckMateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckMateLabel.ForeColor = System.Drawing.Color.IndianRed;
            this.CheckMateLabel.Location = new System.Drawing.Point(413, 4);
            this.CheckMateLabel.MaximumSize = new System.Drawing.Size(150, 0);
            this.CheckMateLabel.Name = "CheckMateLabel";
            this.CheckMateLabel.Size = new System.Drawing.Size(0, 17);
            this.CheckMateLabel.TabIndex = 10;
            this.CheckMateLabel.Visible = false;
            // 
            // GameController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(932, 356);
            this.Controls.Add(this.CheckMateLabel);
            this.Controls.Add(this.BoardStateHistoryHeader);
            this.Controls.Add(this.BoardStatePanel);
            this.Controls.Add(this.Message);
            this.Controls.Add(this.BlackBox);
            this.Controls.Add(this.WhiteBox);
            this.Controls.Add(this.Quit);
            this.Controls.Add(this.StartGame);
            this.Controls.Add(this.PlayerTwoLabel);
            this.Controls.Add(this.PlayerOneLabel);
            this.Controls.Add(this.PlayerTwo);
            this.Controls.Add(this.PlayerOne);
            this.Controls.Add(this.ChessBoard);
            this.ForeColor = System.Drawing.Color.Green;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameController";
            this.Text = "Welcome to the game of Chess!";
            ((System.ComponentModel.ISupportInitialize)(this.PlayerOne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerTwo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WhiteBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlackBox)).EndInit();
            this.BoardStatePanel.ResumeLayout(false);
            this.BoardStatePanel.PerformLayout();
            this.BoardStateHistoryHeader.ResumeLayout(false);
            this.BoardStateHistoryHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel ChessBoard;
        private System.Windows.Forms.PictureBox PlayerOne;
        private System.Windows.Forms.PictureBox PlayerTwo;
        private System.Windows.Forms.Label PlayerOneLabel;
        private System.Windows.Forms.Label PlayerTwoLabel;
        private System.Windows.Forms.Button StartGame;
        private System.Windows.Forms.Button Quit;
        private System.Windows.Forms.PictureBox WhiteBox;
        private System.Windows.Forms.PictureBox BlackBox;
        private System.Windows.Forms.Label Message;
        private System.Windows.Forms.Timer TurnTimer;
        private System.Windows.Forms.TableLayoutPanel BoardStateHistory;
        private System.Windows.Forms.Panel BoardStatePanel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TableLayoutPanel BoardStateHistoryHeader;
        private System.Windows.Forms.Label MoveNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label CheckMateLabel;

    }
}

