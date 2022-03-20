# BattleshipGame

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 6.0.0.

To start the battleship game just run the project. 

Colors legend:
	- Black: Ship has been hit and sunk
	- Pink: Ship has been hit but hasn't been sunk
	- White with initial letter: Ship position that hasn't been hit

Game simulates match between two players. If you want to simulate match again, you have to click "Play again" button.
Every player have five ships:
	- Carrier (5 fields on board)
	- Battleship (4 fields on board)
	- Destroyer (3 fields on board)
	- Submarine (3 fields on board)
	- Patrol boat (2 fields on board)

Ships can be placed horizontaly or verticaly. Their position is chosen randomly. Ships can't overlap.
In game always is on winner and one looser. 

Ships are stored in list. Every type of ship is a different class but all of them inherite from abstract class Ship.
If every position that ship take has been hit that means that ship has been sunk.
Players are allowed to play untill all ships of one of then would be sink.
Player who is allowed to start first is chosen randomly.
Every time when match starts position of the ships of both players is generated randomly.
Firing positions are chosen randomly.
After the end of the match, state of ships of both players are copied to game history and then send to view. 
