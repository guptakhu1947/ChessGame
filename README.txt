
Sources:
------------------------------------
http://en.wikipedia.org/wiki/Rules_of_chess
Images: Google

Description
------------------------------------
 1) Designed the classes for implementing a chess game
 2) Implemented moves for every piece except their special situation moves like Castling, en passant and promotion
 3) Implemented a Win, Check and Draw status
 4) Added functionality to store move history and provide an ability to restore the state 
	of the board to the 'nth' move in the game, including both players' moves
 5) Interactive UI. The player with active turn, is indicated to play his turn by a flashing message against his name
 6) Has the ability to Restart or Quit the game
 7) Displays a History/State tracker for every move.

 Draw/Win/Check Rules
 ------------------------------------
 1) If the King of the other player, gets replaced by any player's move, that player wins the game
 2) If a King is against King, its a Draw
 3) If the current player's move, changes the state of the board in such a way, that his next move could be a win, it's a Check.

 Assumptions
------------------------------------
 1) Not all Draw scenarios are implemented
 2) The game is not played under any time contraints
 3) Checkmate condition not implemented

 Notes
 ------------------------------------
 1) One you get an error for a wrong move, you need to restart by selecting the piece again
 2) The code avoids useless comments, as per best coding practices




