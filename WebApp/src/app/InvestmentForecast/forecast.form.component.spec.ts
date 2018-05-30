import { TestBed, async } from '@angular/core/testing';
import { ForecastFormComponent } from './forecast.form.component';
import { InvestmentForecastService } from '../api/forecast.service';
import { ForecastFormViewModel } from './forecast.form.viewmodel';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { LineChartComponent } from '../chart/line.chart.component'
import { HttpClientModule } from '@angular/common/http';
import { IForecastChartRequest } from '../chart/chart.request.model'
import { ChartDataSet } from '../chart/chart.request.model';

describe('ForecastFormComponent', () => {
  let formComponent: ForecastFormComponent
  let fakeServiceResponse = {
    narrowLowerValue: [2000, 5000, 6000, 7000, 8000],
    narrowUpperValue: [3000, 4000, 8000, 2300, 2400],
    wideLowerValue: [7000, 8000, 9000, 1000, 1100],
    wideUpperValue: [1000, 2000, 3000, 4000, 5000]
  }

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        ForecastFormComponent,
        ForecastFormViewModel,
        LineChartComponent
      ],
      imports: [FormsModule, HttpClientModule, BrowserModule],
      providers: [InvestmentForecastService]
    }).compileComponents();
  }));

  it(`it should have created a view model with expected values`, async(() => {
    //Arrange
    let expectedModel = new ForecastFormViewModel(100000, 2000, 150000, 5, 'low');

    //Act
    const fixture = TestBed.createComponent(ForecastFormComponent);

    //Assert
    const app = fixture.debugElement.componentInstance;
    expect(app._model).toEqual(expectedModel);
  }));
  it('it should assemble chart request with correct Axis Labels', async(() => {
    //Arrange
    let expectedXAxisLabels: Array<string> = ['0', '1', '2', '3', '4', '5', '6'];

    const fixture = TestBed.createComponent(ForecastFormComponent);
    const app = fixture.debugElement.componentInstance;
    app._model.InvestmentTermInYears = 6;

    //Act
    app.assembleChartRequest(fakeServiceResponse);

    //Assert
    let request: IForecastChartRequest = app.chartRequest;
    expect(request.XAxisLabels).toEqual(expectedXAxisLabels);
  }));
  it('it should assemble chart request with correct narrow lower bound values', async(() => {
    //Arrange
    let expectedNarrowLowerValue: Array<number> = [2000, 5000, 6000, 7000, 8000];
    let expectedNarrowWideValue: Array<number> = [3000, 4000, 8000, 2300, 2400];

    let fakeServiceRes = {
      narrowLowerValue: expectedNarrowLowerValue,
      narrowUpperValue: expectedNarrowWideValue,
      wideLowerValue: [7000, 8000, 9000, 1000, 1100],
      wideUpperValue: [1000, 2000, 3000, 4000, 5000]
    }


    const fixture = TestBed.createComponent(ForecastFormComponent);
    const app = fixture.debugElement.componentInstance;
    app._model.InvestmentTermInYears = 6;

    //Act
    app.assembleChartRequest(fakeServiceRes);

    //Assert
    let data: ChartDataSet = app.chartRequest.Data;
    expect(data[0].lowerBound).toEqual(expectedNarrowLowerValue);
  }));
  it('it should assemble chart request with correct narrow upper bound values', async(() => {
    //Arrange
    let expectedNarrowLowerValue: Array<number> = [2000, 5000, 6000, 7000, 8000];
    let expectedNarrowUpperValue: Array<number> = [3000, 4000, 8000, 2300, 2400];

    let fakeServiceRes = {
      narrowLowerValue: expectedNarrowLowerValue,
      narrowUpperValue: expectedNarrowUpperValue,
      wideLowerValue: [7000, 8000, 9000, 1000, 1100],
      wideUpperValue: [1000, 2000, 3000, 4000, 5000]
    }


    const fixture = TestBed.createComponent(ForecastFormComponent);
    const app = fixture.debugElement.componentInstance;
    app._model.InvestmentTermInYears = 6;

    //Act
    app.assembleChartRequest(fakeServiceRes);

    //Assert
    let data: ChartDataSet = app.chartRequest.Data;
    expect(data[0].higherBound).toEqual(expectedNarrowUpperValue);
  }));


  it('it should assemble chart request with correct wide lower bound values', async(() => {
    //Arrange
    let expectedWideLowerValue: Array<number> = [2000, 5000, 6000, 7000, 8000];

    let fakeServiceRes = {
      narrowLowerValue: [2000, 5000, 6000, 7000, 8000],
      narrowUpperValue: [3000, 4000, 8000, 2300, 2400],
      wideLowerValue: expectedWideLowerValue,
      wideUpperValue: [1000, 2000, 3000, 4000, 5000]
    }


    const fixture = TestBed.createComponent(ForecastFormComponent);
    const app = fixture.debugElement.componentInstance;
    app._model.InvestmentTermInYears = 6;

    //Act
    app.assembleChartRequest(fakeServiceRes);

    //Assert
    let data: ChartDataSet = app.chartRequest.Data;
    expect(data[2].lowerBound).toEqual(expectedWideLowerValue);
  }));
  it('it should assemble chart request with correct wide upper bound values', async(() => {
    //Arrange
    let expectedWideUpperValue: Array<number> = [1000, 2000, 3000, 4000, 5000];

    let fakeServiceRes = {
      narrowLowerValue: [2000, 5000, 6000, 7000, 8000],
      narrowUpperValue: [3000, 4000, 8000, 2300, 2400],
      wideLowerValue: [7000, 8000, 9000, 1000, 1100],
      wideUpperValue: expectedWideUpperValue
    }


    const fixture = TestBed.createComponent(ForecastFormComponent);
    const app = fixture.debugElement.componentInstance;
    app._model.InvestmentTermInYears = 6;

    //Act
    app.assembleChartRequest(fakeServiceRes);

    //Assert
    let data: ChartDataSet = app.chartRequest.Data;
    expect(data[2].higherBound).toEqual(expectedWideUpperValue);
  }));

  it('it should assemble chart request with correct target values', async(() => {
    //Arrange
    let targetValue = 2000;
    let expectedTargetValues: Array<number> = [targetValue, targetValue, targetValue];

    
    const fixture = TestBed.createComponent(ForecastFormComponent);
    const app = fixture.debugElement.componentInstance;
    app._model.InvestmentTermInYears = 2;
    app._model.TargetValue = targetValue;

    //Act
    app.assembleChartRequest(fakeServiceResponse);

    //Assert
    let data: ChartDataSet = app.chartRequest.Data;
    expect(data[1].lowerBound).toEqual(expectedTargetValues);
  }));

  //it('should render title in a h1 tag', async(() => {
  //  const fixture = TestBed.createComponent(AppComponent);
  //  fixture.detectChanges();
  //  const compiled = fixture.debugElement.nativeElement;
  //  expect(compiled.querySelector('h1').textContent).toContain('Welcome to WebApp!');
  //}));
});
