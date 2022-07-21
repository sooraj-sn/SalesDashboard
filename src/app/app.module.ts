import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { SummaryComponent } from './summary/summary.component';
import { OpenBugsComponent } from './open-bugs/open-bugs.component';
import { ResourcewiseComponent } from './resourcewise/resourcewise.component';
import { ImportcqdataComponent } from './importcqdata/importcqdata.component';
import { appRoutes } from 'src/routes';
import { HttpClientModule } from '@angular/common/http';
import { NgChartsModule } from 'ng2-charts';
import Chart from 'chart.js/auto';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    SidebarComponent,
    SummaryComponent,
    OpenBugsComponent,
    ResourcewiseComponent,
    ImportcqdataComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    RouterModule.forRoot(appRoutes),
    NgChartsModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
