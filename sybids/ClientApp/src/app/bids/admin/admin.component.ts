import { Component, OnInit } from '@angular/core';
import { LineService } from '../shared/line.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  constructor(private lineService: LineService) { }

  ngOnInit() { }

}
