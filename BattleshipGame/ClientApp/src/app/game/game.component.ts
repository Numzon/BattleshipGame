import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-game',
    templateUrl: './game.component.html'
})
export class GameComponent {
    public gameHistory: GameHistory;
    public alphabet: string[];
    public numbers: number[];
    private http: HttpClient;

    constructor(http: HttpClient) {
        this.alphabet = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J'];
        this.numbers = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];
        this.http = http;
        this.getGameHistoryData();
    }

    public getGameHistoryData() {
        this.http.get<GameHistory>('https://localhost:44382/game').subscribe(result => {
            this.gameHistory = result;
        }, error => console.error(error));
    }
}

interface GameHistory {
    playersHistory: PlayerBoardHistory[],
    playerWhoWon: number
}

interface PlayerBoardHistory {
    playerNumber: number,
    boardHistory: HistoryHitPosition[][]
}

interface HistoryHitPosition {
    x: number;
    y: number;
    hasBeenHit: boolean;
    hasBeenSunk: boolean;
    shipInitial: string;
}

