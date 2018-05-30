import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import "rxjs/add/operator/map";
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { IForecastServiceModel } from './investment.forecast.service.model'

@Injectable({
  providedIn: 'root'
})
export class InvestmentForecastService {
  private _urlDomain = "https://localhost:44352/api/";
  constructor(private _http: HttpClient) { }

  annualForecast(requestModel: IForecastServiceModel) {
    let fullUrl = this._urlDomain + "InvestmentForecast";

    return this._http.post(fullUrl, requestModel);
  }

  test() {
    let fullUrl = this._urlDomain + "Connectivity";

    return this._http.get(fullUrl)
      .map(result => result);
  }
}
