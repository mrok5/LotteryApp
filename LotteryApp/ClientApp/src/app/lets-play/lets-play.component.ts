import { Component, Inject, OnInit } from '@angular/core';
import { Lottery } from '../services/lottery.service';

@Component({
  selector: 'app-lets-play',
  templateUrl: './lets-play.component.html'
})
export class DrawComponent{

  constructor(public lottery: Lottery) {
  }

  public drawNumbers: number[];
  public label = "Draw";

  public draw() {
    this.lottery.GetDrawNumbers()
      .subscribe();

    this.label = "Draw again";
  }


}
