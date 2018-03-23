import { Component, OnInit } from '@angular/core';
import { LOCALE_DATA } from '@angular/common/src/i18n/locale_data';
import { LineService } from '../shared/line.service';
import { PairingService } from '../shared/pairing.service';
import { LineHandlerService } from '../shared/line-handler.service';
import { PairingHandlerService } from '../shared/pairing-handler.service';
import { LineModel, PairingModel } from '../shared/line.model';

@Component({
  selector: 'app-line',
  templateUrl: './line.component.html',
  styleUrls: ['./line.component.css']
})
export class LineComponent implements OnInit {
  lines: LineModel[] = [];
  pairings: PairingModel[] = [];
  error: any;

  constructor(private ls: LineService,
    private ps: PairingService,
    private lhs: LineHandlerService,
    private phs: PairingHandlerService) { }

  csvSelected(evt: any): void {
    let reader = new FileReader();
    reader.readAsText(evt.target.files[0]);
    reader.onload = () => this.pairings = this.phs.csvLoadHandler(reader.result);
  }

  txtSelected(evt: any): void {
    let reader = new FileReader();
    reader.readAsText(evt.target.files[0]);
    reader.onload = () => this.lines = this.lhs.txtLoadHandler(reader.result);
  }

  saveBidPack(): void {
    event.stopPropagation(); // Prevents the event from bubbling up the DOM tree, preventing any parent handlers from being notified of the event.
    this.ls.saveLines(this.lines);
    this.ps.savePairings(this.pairings);
  }

  getLines(): void {
     this.ls.getLines()
        .then(lines => this.lines = lines)
        .catch(error => this.error = error);
  }

  deleteLine(line: LineModel, event: any): void {
     event.stopPropagation(); // Prevents the event from bubbling up the DOM tree, preventing any parent handlers from being notified of the event.
     this.ls.delete(line)
        .then(res => {
          this.lines = this.lines.filter(l => l !== line);
          this.getLines();
        })
        .catch(error => this.error = error);
  }

  ngOnInit(): void {
    this.ls.getLines();
  }
}
