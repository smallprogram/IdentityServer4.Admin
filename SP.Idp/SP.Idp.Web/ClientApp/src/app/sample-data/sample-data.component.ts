import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-sample-data',
  templateUrl: './sample-data.component.html',
  styleUrls: ['./sample-data.component.scss']
})
export class SampleDataComponent implements OnInit {

  public forecasts: WeatherForecast[];


  constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    httpClient.get<WeatherForecast[]>(baseUrl + 'api/SampleData/WeatherForecasts').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }
  ngOnInit() {
  }

}

interface WeatherForecast {
  dateFormatted: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
