import { Component, OnInit } from '@angular/core';
import { LineService } from '../shared/line.service';
import { PairingModel, DutyModel, LegModel } from '../shared/line.model';

@Component({
  selector: 'app-line',
  templateUrl: './line.component.html',
  styleUrls: ['./line.component.css']
})
export class LineComponent implements OnInit {
  //lines: LineModel[];
  error: any;

  constructor(private lineService: LineService) { }

  csvSelected(evt: any): void {
    let reader = new FileReader();
    reader.readAsText(evt.target.files[0]);
    reader.onload = this.csvLoadHandler;
  }

  csvLoadHandler(fre: FileReaderEvent) {
    let csv = fre.target.result;
    let allTextLines = csv.split(/\r\n|\n/);
    let pairings: PairingModel[] = []
    let pairing: PairingModel;
    let duty: DutyModel;
    let leg: LegModel;
    let dutyIndex = -1;
    let pairingIndex = -1;

    // pairing info starts at row 4, the rest is header info
    for (let i = 4; i < allTextLines.length; i++) {
      let data = allTextLines[i].split(',');

      switch(data[0]) {
        case 'PRG':
          pairingIndex++;
          pairing = {
            pairingId: data[1],
            base: data[5],
            numDays: data[6],
            block: data[9],
            credit: data[10],
            landings: data[11],
            deadheads: data[12],
            tafb: data[13],
            duty: []
          };
          pairings.push(pairing);
          dutyIndex = -1;
          break;
        case 'DTY':
          dutyIndex++;
          duty = { 
            dutyDay: data[1],
            legs: data[2],
            brief: data[3],
            debrief: data[4],
            dutyTime: data[5],
            block: data[6],
            credit: data[8],
            rest: data[9],
            restType: data[10],
            leg: []
          }
          pairings[pairingIndex].duty.push(duty);
          break;
        case 'LEG':
          leg = {
            legNum: data[1],
            equipment: data[3],
            fleetCode: data[4],
            flight: data[5],
            departure: data[6],
            arrival: data[8],
            departureTime: data[7],
            arrivalTime: data[9],
            block: data[10],
            carrier: data[13]
          }
          pairings[pairingIndex].duty[dutyIndex].leg.push(leg);
          break;
        default: // end of file
          break;
      }
    }
    console.log(pairings);
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

interface FileReaderEventTarget extends EventTarget {
  result: string;
}

interface FileReaderEvent extends Event {
  target: FileReaderEventTarget;
  getMessage(): string;
}

// PRGLABEL,Pg#,Eff,Thru,Frq,Base,Days,Duties,C/J,Block,Credit,Lndgs,Dhds,TAFB,NumCA,NumFO,NumFA
// DTYLABEL,Duty#,Legs,Brief,Debrief,TOD,Block,DhdPay,Credit,Rest,RestType,FDPDutyTime,FDPDutyLimit,FDPLegTally,StartTaxiDur,EndTaxiDur,StartCustoms,EndCustoms,NoMinGuar
// LEGLABEL,Leg#,Day,Eqp,Fleetcode,Flt#,DStn,DepT,AStn,ArvT,Block,NextFlt,IntlCode,Carrier
//
// PRG,M0001,03022018,03102018,56,MSP,1,1,J,800,800,2,0,1020
// DTY,1,2,100,30,1020,800,0,800,1200,21,950,1200,2,0,0,0,0,0
// LEG,1,1,738,738,527,MSP,600,CZM,1055,355,528,Q,SY
// LEG,2,1,738,738,528,CZM,1145,MSP,1450,405,0,Q,SY

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
