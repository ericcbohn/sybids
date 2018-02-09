import { Component, OnInit } from '@angular/core';
import { HttpClient } from 'selenium-webdriver/http';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  constructor(private http: HttpClient) { }

  ngOnInit() { }

}
