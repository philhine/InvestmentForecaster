import { TestBed, async } from '@angular/core/testing';
import { AppComponent } from './app.component';
import { ForecastFormComponent } from './InvestmentForecast/forecast.form.component';
 
describe('AppComponent', () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        AppComponent,
        ForecastFormComponent
      ],
    }).compileComponents();
  }));
  //it('should create the app', async(() => {
  //  const fixture = TestBed.createComponent(AppComponent);
  //  const app = fixture.debugElement.componentInstance;
  //  expect(app).toBeTruthy();
  //}));
  //it(`should have as title 'app'`, async(() => {
  //  const fixture = TestBed.createComponent(AppComponent);
  //  const app = fixture.debugElement.componentInstance;
  //  expect(app.title).toEqual('app');
  //}));
});
