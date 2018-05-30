//import { Component } from '@angular/core';

export interface IForecastFormViewModel {
  LumpSumInvestment: number;
  MonthlyInvestment: number;
  TargetValue: number;
  InvestmentTermInYears: number;
  RiskLevel: string;

}

//added this purely so tests can recognise the class
//@Component({
//  selector: 'viewmodel',
//  template: ''
//})
export class ForecastFormViewModel implements IForecastFormViewModel {
  LumpSumInvestment: number;
  MonthlyInvestment: number;
  TargetValue: number;
  InvestmentTermInYears: number;
  RiskLevel: string;
  isValid: boolean = true;

  LumpSumInvestmentError: Array<string> = [];
  MonthlyInvestmentError: Array<string> = [];
  TargetValueError: Array<string> = [];
  InvestmentTermInYearsError: Array<string> = [];
  RiskLevelError: Array<string> = [];


  constructor(lumpSumInvestment: number, monthlyInvestment: number, targetValue: number, investmentTermInYears: number, riskLevel: string) {
    this.LumpSumInvestment = lumpSumInvestment;
    this.MonthlyInvestment = monthlyInvestment;
    this.TargetValue = targetValue;
    this.InvestmentTermInYears = investmentTermInYears;
    this.RiskLevel = riskLevel;
  }

  clearErrors() {
    this.LumpSumInvestmentError = [];
    this.MonthlyInvestmentError = [];
    this.TargetValueError = [];
    this.InvestmentTermInYearsError = [];
    this.RiskLevelError = [];
  }

  validate(): boolean {
    this.clearErrors();
    let isValid = true;

    if (this.LumpSumInvestment <= 0 || this.LumpSumInvestment > 100000000) {
      this.LumpSumInvestmentError.push("Lump sum must be between 1 and 100,000,000");
      isValid = false;
    }
    if (this.MonthlyInvestment <= 0 || this.MonthlyInvestment > 10000000) {
      this.MonthlyInvestmentError.push("Monthly investment must be between 1 and 10,000,000");
      isValid = false;
    }
    if (this.InvestmentTermInYears <= 0 || this.InvestmentTermInYears > 100) {
      this.InvestmentTermInYearsError.push("Investment term must be between 1 and 100");
      isValid = false;
    }

    if (this.TargetValue <= 0 || this.TargetValue > 10000000) {
      this.TargetValueError.push("Target value term must be between 1 and 10,000,000");
      isValid = false;
    }

    switch (this.RiskLevel) {
      case 'low':
      case 'medium':
      case 'high':
        break;
      default:
        this.RiskLevelError.push("Risk level acceptable values (low, medium, high)");
        isValid = false;
    }

    this.isValid = isValid;

    return isValid;
  }



}
