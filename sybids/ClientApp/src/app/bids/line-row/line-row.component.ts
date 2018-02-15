import { Component, OnInit, Input } from '@angular/core';
import { LineModel } from '../shared/line.model';

@Component({
  selector: 'app-line-row',
  templateUrl: './line-row.component.html',
  styleUrls: ['./line-row.component.css']
})
export class LineRowComponent implements OnInit {
  @Input() line: LineModel;
  @Input() lineIndex: number;

  constructor() { }

  ngOnInit() {
  }

}
