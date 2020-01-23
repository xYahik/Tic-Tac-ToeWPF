## Table of contents
* [Tic-Tac-Toe](#Tic-Tac-Toe)
* [Game rules and end od the game](#game-rules)
* [Code Architecture](#code-architecture)

##  Tic Tac Toe
Tic-tac-toe (American English), noughts and crosses (British English), or Xs and Os is a paper-and-pencil game for two players, X and O, who take turns marking the spaces in a 3×3 grid.But in our application you play on a 4x4 board and you can choose a computer as your opponent


##  Game rules and End of the game

the game starts with the player with the O sign choosing one of 16 boxes, then the player moves with the X sign. The game ends when one player arranges four of their characters horizontally, vertically, diagonally or arranges a square from them, the game ends in a draw if  none of them will complete this task and the fields will be over

##  Code Architecture
### Technology
* Windows Presentation Foundation
* .Net Framework 4.6.1


### Game logic
  Initialization of game is provide by ZaczynamyRozgrywke method, which clear board to new game. Czy_Ruch_Gracza_Pierwszego it is a property that identifies which of player has a move. Method Button_Cl is a function which is executed every player move, display a player char in board and after it, board is checked to define if one of player won by Wygrana method. Wygrana method can change property Czy_Gra_Zakończona, which identifies if game is finished and if yes adds point to a player who win and enable a revange button. Button "PC" execute a ButtonPC_Click method, which change value of boolean property _computerPlaying. This property decide that second player is a computer or person.


### Graphic representation
The game view is implemented with XAML. Player points are displayed by ContentControl and updated by UpdateWynik function. In the MainWindow class constructor, we divided the board into rows and columns and drew grid. 16 of grids are a fields which can be choose by player to set a his mark X or O. Extra 3 buttons. One of them is to reset score, second to revange a player, and third to switch between option playing vs Player or vs PC.
