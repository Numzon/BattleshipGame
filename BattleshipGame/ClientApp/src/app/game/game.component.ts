import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-game',
    templateUrl: './game.component.html'
})
export class GameComponent {
    public gameHistory: GameHistory;
    public alphabet: string[];

    constructor(http: HttpClient) {
        http.get<GameHistory>('https://localhost:44382/game').subscribe(result => {
            this.gameHistory = result;
            this.alphabet = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J'];
        }, error => console.error(error));
    }
}

interface HistoryHitPosition {
    x: number;
    y: number;
    playerNumber: number;
    hasBeenHit: boolean;
    hasBeenSunk: boolean;
    nameOfSunkShip: string;
}

interface GameHistory {
    playerOneHistory: HistoryHitPosition[],
    playerTwoHistory: HistoryHitPosition[],
    PlayerWhoWon: number
}