import { Component, OnInit } from '@angular/core';
import { LineService } from '../shared/line.service';
import { LineModel } from '../shared/line.model';

@Component({
  selector: 'app-line',
  templateUrl: './line.component.html',
  styleUrls: ['./line.component.css']
})
export class LineComponent implements OnInit {
  lines: LineModel[];
  selectedLine: LineModel;
  addingLine = false;
  error: any;
  showNgFor = false;

  constructor(private lineService: LineService) { }

  getAllLines(): void {
    this.lineService.getAllLines()
                   .then(lines => { 
                     this.lines = lines;
                   })
                   .catch(error => this.error = error);
  }

  addLine(): void {
    this.addingLine = true;
    this.selectedLine = null;
  }

  close(savedLine: LineModel): void {
    this.addingLine = false;
    if(savedLine) { this.getAllLines(); }
  }

  deleteLine(line: LineModel, event: any): void {
    event.stopPropagation();
    this.lineService.delete(line)
                   .then(res => {
                     this.lines = this.lines.filter(l => l !== line);
                     if(this.selectedLine === line) { this.selectedLine = null; }
                   })
                   .catch(error => this.error = error);
  }

  ngOnInit(): void {
    this.getAllLines();
  }

  onSelect(line: LineModel): void {
    this.selectedLine = line;
    this.addingLine = false;
  }

  // gotoDetail(): void {
  //   this.router.navigate(['/detail', this.selectedLine.lineid]);
  // }
}
