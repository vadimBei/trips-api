import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SearchLocationComponent } from './search-location/search-location.component';

@NgModule({
  declarations: [
    SearchLocationComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  exports: [
    SearchLocationComponent
  ]
})
export class AlgoliaLocationsModule { }