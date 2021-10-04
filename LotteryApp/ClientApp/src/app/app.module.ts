import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { DrawHistoryComponent } from './draw-history/draw-history.component';
import { Lottery } from './services/lottery.service';
import { DrawComponent } from './lets-play/lets-play.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    DrawHistoryComponent,
    DrawComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'lets-play', component: DrawComponent },
      { path: 'draw-history', component: DrawHistoryComponent },
    ])
  ],
  providers: [Lottery],
  bootstrap: [AppComponent]
})
export class AppModule { }
