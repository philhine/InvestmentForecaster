import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ForecastFormComponent } from './InvestmentForecast/forecast.form.component';
import { AppComponent } from './app.component';

import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { InvestmentForecastService } from './api/forecast.service';
import { LineChartComponent } from './chart/line.chart.component'


@NgModule({
  declarations: [
    AppComponent,
    ForecastFormComponent,
    LineChartComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [InvestmentForecastService],
  bootstrap: [AppComponent]
})
export class AppModule { }
