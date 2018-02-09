import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable()
export class BidService {
  http: HttpClient;
  baseUrl: string;
    
  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrlStr: string) {
    this.http = httpClient;
    this.baseUrl = baseUrlStr;
  }

  getBid(): void {
  }
}

interface WeatherForecast {
  dateFormatted: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
