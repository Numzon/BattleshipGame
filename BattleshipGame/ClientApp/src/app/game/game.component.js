//import { Component, Inject } from '@angular/core';
//import { HttpClient } from '@angular/common/http';
//@Component({
//    selector: 'app-game',
//    templateUrl: './game.component.html'
//})
//export class GameComponent {
//    public historyList: HistoryHitPosition[];
//    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
//        http.get<HistoryHitPosition[]>(baseUrl + 'game').subscribe(result => {
//            this.historyList = result;
//        }, error => console.error(error));
//    }
//}
//interface HistoryHitPosition {
//    x: number;
//    y: number;
//    playerNumber: number;
//    hasBeenHit: boolean;
//    hasBeenSunk: boolean;
//    nameOfSunkShip: string;
//}
//# sourceMappingURL=game.component.js.map