import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import {MatButton} from "@angular/material/button";
import {KanbanBoardComponent} from "./components/kanban-board/kanban-board.component";
import {TaskService} from "./services/task.service";
import {HttpClientModule} from "@angular/common/http";

@NgModule({
  declarations: [
    AppComponent,
  ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        MatButton,
        KanbanBoardComponent,
        HttpClientModule
    ],
  providers: [
      provideAnimationsAsync(),
      TaskService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
