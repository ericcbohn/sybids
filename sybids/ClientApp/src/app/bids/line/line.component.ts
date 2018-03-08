import { Component, OnInit } from '@angular/core';
import { LineService } from '../shared/line.service';
import { LineModel, PairingModel, DutyModel, LegModel, DayModel } from '../shared/line.model';
import { LOCALE_DATA } from '@angular/common/src/i18n/locale_data';
import { getMonth } from 'date-fns';

@Component({
  selector: 'app-line',
  templateUrl: './line.component.html',
  styleUrls: ['./line.component.css']
})
export class LineComponent implements OnInit {
  lines: LineModel[];
  error: any;

  constructor(private lineService: LineService) { }

  csvLoadHandler(result: string): void {
    let allTextLines = result.split(/\r\n|\n/);
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
  }

  csvSelected(evt: any): void {
    let reader = new FileReader();
    reader.readAsText(evt.target.files[0]);
    reader.onload = () => this.csvLoadHandler(reader.result);
  }

  rotateArray(matrix) {
    let result = [];
    for(let i = 0; i < matrix[0].length; i++) {
        let row = matrix.map(e => e[i]).reverse();
        result.push(row);
    }
    return result;
  }

  getDayIndexes(rawDays: string) {
    let startIndex = 23;
    let monthIndexes = [];
    let dayIndexInterval = 6;
    // O(n)
    for (let i = 1; startIndex < rawDays.length; i++) {
      monthIndexes.push(startIndex);
      if(i%5 === 0) { startIndex = startIndex + (dayIndexInterval-1); }
      else { startIndex = startIndex + dayIndexInterval; }
    }
    return monthIndexes;
  }

  getLineIndexes(rawLines: string[]) {
    let lineIndexes = [];
    let lineIndexInterval = 5;
    for (let i = 0; i < rawLines.length;) { 
      lineIndexes.push(i); 
      i = i + lineIndexInterval;
    }
    return lineIndexes;
  }

  getDays(rawDays: string): RawDayModel[] {
    let days: RawDayModel[] = [];
    let dayIndexes = this.getDayIndexes(rawDays);

    // O(n)
    for (let i = 0; i < dayIndexes.length; i++) {
      let dayModel = {
        day: '',
        dayIndex: dayIndexes[i]
      };
      let day: string = '';
      for (let x = 0; x < 5; x++) { day = day + rawDays[dayIndexes[i]+x]; }
      dayModel.day = day;
      days.push(dayModel);
    }
    return days;
  }

  getDetail(rawStr, startIndex, length): string {
    let detail: string = '';
    for (let i = startIndex; i < startIndex+length; i++) {
      detail = detail + rawStr[i];
    }
    return detail;
  }

  parseLines(rawLines: string[], days: RawDayModel[]): LineModel[] {
    let lineIndexes = this.getLineIndexes(rawLines);
    let lines: LineModel[] = [];
    let lineDetailProperty = {
      base: {
        row: 0,
        start: 0,
        length: 3
      },
      equipment: {
        row: 0,
        start: 5,
        length: 3
      },
      position: {
        row: 0,
        start: 10,
        length: 2
      },
      lineId: {
        row: 1,
        start: 0,
        length: 4
      },
      block: {
        row: 2,
        start: 16,
        length: 5
      },
      credit: {
        row: 3,
        start: 8,
        length: 5
      }
    };
    for (let i = 0; i < lineIndexes.length; i++) {
      let line: LineModel = {
        lineid: this.getDetail(rawLines[lineIndexes[i]+lineDetailProperty.lineId.row], lineDetailProperty.lineId.start, lineDetailProperty.lineId.length),
        base: this.getDetail(rawLines[lineIndexes[i]+lineDetailProperty.base.row], lineDetailProperty.base.start, lineDetailProperty.base.length),
        equipment: this.getDetail(rawLines[lineIndexes[i]+lineDetailProperty.equipment.row], lineDetailProperty.equipment.start, lineDetailProperty.equipment.length), 
        position: this.getDetail(rawLines[lineIndexes[i]+lineDetailProperty.position.row], lineDetailProperty.position.start, lineDetailProperty.position.length),
        blockminutes: this.getDetail(rawLines[lineIndexes[i]+lineDetailProperty.block.row], lineDetailProperty.block.start, lineDetailProperty.block.length),
        creditminutes: this.getDetail(rawLines[lineIndexes[i]+lineDetailProperty.credit.row], lineDetailProperty.credit.start, lineDetailProperty.credit.length),
        days: []
      };

      // parse days
      for (let x = 0; x < days.length; x++) { // for each day
        let day: DayModel = { 
          day: days[x].day,
          pairingid: []
        };
        for (let z = 0; z < 2; z++) { // for each row in day
          let pairingRow = rawLines[lineIndexes[i]+z];
          let detail: string = '';
          for (let q = days[x].dayIndex; q < days[x].dayIndex+5; q++) { // for each character 
            if(pairingRow[q] === undefined) { break; }
            detail = detail + pairingRow[q];
          }
          detail = detail.trim();

          if(detail.startsWith('RES') || detail === 'OFFG' || (day.pairingid.length === 0 && detail === '')) { 
            day.pairingid.push(detail); 
            break; 
          }
          else if(detail === '') { break; }
          day.pairingid.push(detail);
        }
        line.days.push(day);
      }
      lines.push(line);
    }
    return lines;
  }

  txtLoadHandler(result: string): void {
    const headerRows = 4;
    let allTextLines = result.split(/\r\n|\n/); // \r = carriage return character; \n = new line character
    let rawLines: string[] = [];
    let days: string = allTextLines[3].trim();
    for (let i = headerRows; i < allTextLines.length; i++) {
      let temp = allTextLines[i].trim();
      if(temp.startsWith('MSP')) {
        for (let x = i; x < i+5; x++) { rawLines.push(allTextLines[x].trim()); }
        i = i+4;
      }
    }
    let lines: LineModel[] = this.parseLines(rawLines, this.getDays(days));
  }

  txtSelected(evt: any): void {  
    let reader = new FileReader();
    reader.readAsText(evt.target.files[0]);
    reader.onload = () => this.txtLoadHandler(reader.result);
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

interface RawDayModel {
  day: string,
  dayIndex: number
};

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
