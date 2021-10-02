import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { map } from "rxjs/operators"
import { DrawHistory } from "../models/DrawHistory";

@Injectable()
export class Lottery {
  constructor(private http: HttpClient) { }

  public drawHistory: DrawHistory[];
  public endpoint = "/api/draws/GetDrawHistory";

  loadDrawHistory() {
    return this.http.get<DrawHistory[]>(this.endpoint)
      .pipe(map(data => {
        this.drawHistory = data;
        return;
      }));
  }

}
