import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http'

import { EmployeesModule } from './employees/employees.module';
import { MenuComponent } from './menu/menu.component';
import { TripsModule } from './trips/trips.module';
import { AlgoliaLocationsModule } from './shared/components/algolia-locations/algolia-locations.module';
import { NavbarComponent } from './navbar/navbar.component';
@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    NavbarComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    HttpClientModule,
    EmployeesModule,
    TripsModule,
    AlgoliaLocationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
