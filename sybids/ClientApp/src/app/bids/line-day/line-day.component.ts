import { LineModel, DayModel, PairingModel } from '../shared/line.model';
import { Component, Input, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { LineService } from '../shared/line.service';

const colors: any = {
  red: {
    primary: '#ad2121',
    secondary: '#FAE3E3'
  },
  blue: {
    primary: '#1e90ff',
    secondary: '#D1E8FF'
  },
  yellow: {
    primary: '#e3bc08',
    secondary: '#FDF1BA'
  }
};

@Component({
  selector: 'app-line-day',
  templateUrl: './line-day.component.html',
styleUrls: ['./line-day.component.css']
})
export class LineDayComponent {
  @Input() lineId: string;
  line: LineModel;
  error: any;

  constructor(private lineService: LineService) { }

  getLine(lineId): void {
    this.lineService.getLine(lineId)
                    .then(line => this.line = line)
                    .catch(error => this.error = error);
  }

  ngOnInit(): void {
    this.getLine(this.lineId);
  }
}

  // getBlankDays(): DayModel[] {
  //   var pairings: PairingModel[] = [{ 
  //     flight: '',
  //     departure: '',
  //     destination: '',
  //     isdeadhead: ''
  //   }];
  //   var days: DayModel[] = [{
  //     reporttimeutc: '',
  //     releasetimeutc: '',
  //     pairings: pairings
  //   }];
  //   return days;
  // }