import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material/material.module';
import { MainComponent } from './components/main/main.component';
import { PointComponent } from './components/main/point/point.component';
import { PointCatalogueComponent } from './components/main/point/point-catalogue/point-catalogue.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { CreatePointComponent } from './components/main/point/create-point/create-point.component';
import { UpdatePointComponent } from './components/main/point/update-point/update-point.component';

@NgModule({
  declarations: [
    AppComponent,
    MainComponent,
    PointComponent,
    PointCatalogueComponent,
    CreatePointComponent,
    UpdatePointComponent,
  ],
  imports: [
    BrowserModule,
    FlexLayoutModule,
    HttpClientModule,
    FormsModule,
    MaterialModule,
    BrowserAnimationsModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
