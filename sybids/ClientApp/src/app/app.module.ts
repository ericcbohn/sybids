// modules
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { NgbModule, NgbModalModule } from '@ng-bootstrap/ng-bootstrap';

// project components
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { LineComponent } from './bids/line/line.component';

// services
import { LineService } from './bids/shared/line.service';
import { PairingService } from './bids/shared/pairing.service';
import { LineHandlerService } from './bids/shared/line-handler.service';
import { PairingHandlerService } from './bids/shared/pairing-handler.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    FetchDataComponent,
    LineComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    NgbModule.forRoot(),
    NgbModalModule.forRoot(),
    CommonModule,
    HttpModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: LineComponent, pathMatch: 'full' },
      { path: 'fetch-data', component: FetchDataComponent },
    ])
  ],
  providers: [LineService, PairingService, LineHandlerService, PairingHandlerService ],
  bootstrap: [AppComponent]
})
export class AppModule { }
