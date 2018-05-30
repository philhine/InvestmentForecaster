export interface IForecastChartRequest {
  XAxisLabels: Array<string>;
  Data: Array<ChartDataSet>;
}

export class ChartDataSet {
  lowerBound: Array<number>;
  backgroundColor: string;
  higherBound: Array<number>;
  label: string

  constructor(lowerBound: Array<number>, backgroundColor: string, higherBound: Array<number>, label: string) {
    this.lowerBound = lowerBound;
    this.backgroundColor = backgroundColor;
    this.label = label;
    if (higherBound && higherBound.length > 0) {
      this.higherBound = higherBound;
    }
  }

}

export class ForecastChartRequest implements IForecastChartRequest {
  XAxisLabels: Array<string>;
  Data: Array<ChartDataSet>;

  constructor(XAxisLabels: Array<string>, Data: Array<ChartDataSet>) {
    this.XAxisLabels = XAxisLabels;
    this.Data = Data;
  }
}
