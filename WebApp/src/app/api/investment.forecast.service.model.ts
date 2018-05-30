import { IForecastFormViewModel } from '../InvestmentForecast/forecast.form.viewmodel';

export interface IForecastServiceModel {
  LumpSumInvestment: number;
  MonthlyInvestment: number;
  TargetValue: number;
  InvestmentTermInYears: number;
  RiskLevel: string;

}

export class ForecastServiceModel implements IForecastServiceModel {
  LumpSumInvestment: number;
  MonthlyInvestment: number;
  TargetValue: number;
  InvestmentTermInYears: number;
  RiskLevel: string;

  constructor(model: IForecastFormViewModel) {
    this.LumpSumInvestment = model.LumpSumInvestment;
    this.MonthlyInvestment = model.MonthlyInvestment;
    this.TargetValue = model.TargetValue;
    this.InvestmentTermInYears = model.InvestmentTermInYears;
    this.RiskLevel = model.RiskLevel;
  }
}
