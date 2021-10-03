import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { map } from "rxjs/operators"
import { DrawHistory } from "../models/DrawHistory";

@Injectable()
export class Lottery {
  constructor(private http: HttpClient) { }

  public drawHistory: DrawHistory[];
  public drawNumbers: number[];
  public drawHistoryEndpoint = "/api/draws/GetDrawHistory";
  public newDrawEndpoint = "/api/draws/NewDraw";

  loadDrawHistory() {
    return this.http.get<DrawHistory[]>(this.drawHistoryEndpoint)
      .pipe(map(data => {
        this.drawHistory = data;
        return;
      }));
  }

  GetDrawNumbers() {
    return this.http.get<number[]>(this.newDrawEndpoint)
      .pipe(map(data => {
        this.drawNumbers = data;
        return;
      }));
  }

}
