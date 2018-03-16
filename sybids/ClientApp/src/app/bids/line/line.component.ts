import { Component, OnInit } from '@angular/core';
import { LineService } from '../shared/line.service';
import { RawDayModel, LineModel, PairingModel, DutyModel, LegModel, DayModel } from '../shared/line.model';
import { LOCALE_DATA } from '@angular/common/src/i18n/locale_data';
import { getMonth } from 'date-fns';

@Component({
  selector: 'app-line',
  templateUrl: './line.component.html',
  styleUrls: ['./line.component.css']
})
export class LineComponent implements OnInit {
  lines: LineModel[] = [];
  pairings: PairingModel[] = [];
  error: any;

  constructor(private lineService: LineService) { }

  csvSelected(evt: any): void {
    let reader = new FileReader();
    reader.readAsText(evt.target.files[0]);
    reader.onload = () => this.csvLoadHandler(reader.result);
  }

  txtSelected(evt: any): void {  
    let reader = new FileReader();
    reader.readAsText(evt.target.files[0]);
    reader.onload = () => this.txtLoadHandler(reader.result);
  }

  saveBidPack(): void {
    //this.lineService.saveBidPack(this.lines, this.pairings);
    for(let i = 0; i < this.lines.length; i++) {
        this.lineService.saveLine(this.lines[i]);
    }
    for(let i = 0; i < this.pairings.length; i++) {
        this.lineService.savePairing(this.pairings[i]);
    }
  }

  getAllLines(): void {
    // this.lineService.getAllLines()
    //                .then(lines => this.lines = lines)
    //                .catch(error => this.error = error);
  }

  ngOnInit(): void {
    //this.getAllLines();
  }
}

// getConvertedTime(minutes:string): string {
//   let hours: string = Math.floor(parseFloat(minutes)/60).toString();
//   let mins: string = ("0" + (parseFloat(minutes)%60)).slice(-2);
//   return hours + ':' + mins;
// }

// saveLine(line: LineModel, event: any): void {
//   event.stopPropagation(); // Prevents the event from bubbling up the DOM tree, preventing any parent handlers from being notified of the event.
//   this.lineService.save(line)
//                   .then(res => this.getAllLines())
//                   .catch(error => this.error = error);
// }

// deleteLine(line: LineModel, event: any): void {
//   event.stopPropagation(); // Prevents the event from bubbling up the DOM tree, preventing any parent handlers from being notified of the event.
//   this.lineService.delete(line)
//                  .then(res => {
//                    this.lines = this.lines.filter(l => l !== line);
//                    this.getAllLines();
//                  })
//                  .catch(error => this.error = error);
// }
