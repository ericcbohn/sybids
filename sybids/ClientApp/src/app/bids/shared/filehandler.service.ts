import { Injectable } from '@angular/core';

@Injectable()
export class FilehandlerService {

  constructor() { }

  //  getDayIndexes(rawDays: string) {
  //   let startIndex = 23;
  //   let monthIndexes = [];
  //   let dayIndexInterval = 6;
  //   // O(n)
  //   for (let i = 1; startIndex < rawDays.length; i++) {
  //     monthIndexes.push(startIndex);
  //     if(i%5 === 0) { startIndex = startIndex + (dayIndexInterval-1); }
  //     else { startIndex = startIndex + dayIndexInterval; }
  //   }
  //   return monthIndexes;
  // }

  // getLineIndexes(rawLines: string[]) {
  //   let lineIndexes = [];
  //   let lineIndexInterval = 5;
  //   for (let i = 0; i < rawLines.length;) { 
  //     lineIndexes.push(i); 
  //     i = i + lineIndexInterval;
  //   }
  //   return lineIndexes;
  // }

  // getDays(rawDays: string): RawDayModel[] {
  //   let days: RawDayModel[] = [];
  //   let dayIndexes = this.getDayIndexes(rawDays);

  //   // O(n)
  //   for (let i = 0; i < dayIndexes.length; i++) {
  //     let dayModel = {
  //       month: '',
  //       day: '',
  //       dayIndex: dayIndexes[i]
  //     };
  //     let day: string = '';
  //     for (let x = 0; x < 5; x++) { day = day + rawDays[dayIndexes[i]+x]; }
  //     let monthStr = day.match(/^\D+/);
  //     let dayNum = day.match(/\d+$/);
  //     dayModel.month = monthStr.length > 0 ? monthStr[0] : '0';
  //     dayModel.day = dayNum.length > 0 ? dayNum[0] : '0';
  //     days.push(dayModel);
  //   }
  //   return days;
  // }

  // getDetail(rawStr, startIndex, length): string {
  //   let detail: string = '';
  //   for (let i = startIndex; i < startIndex+length; i++) {
  //     detail = detail + rawStr[i];
  //   }
  //   return detail;
  // }

  // parseLines(rawLines: string[], days: RawDayModel[]): LineModel[] {
  //   let lineIndexes = this.getLineIndexes(rawLines);
  //   let lines: LineModel[] = [];
  //   let lineDetailProperty = {
  //     base: {
  //       row: 0,
  //       start: 0,
  //       length: 3
  //     },
  //     equipment: {
  //       row: 0,
  //       start: 5,
  //       length: 3
  //     },
  //     position: {
  //       row: 0,
  //       start: 10,
  //       length: 2
  //     },
  //     lineId: {
  //       row: 1,
  //       start: 0,
  //       length: 4
  //     },
  //     block: {
  //       row: 2,
  //       start: 16,
  //       length: 5
  //     },
  //     credit: {
  //       row: 3,
  //       start: 8,
  //       length: 5
  //     }
  //   };
  //   for (let i = 0; i < lineIndexes.length; i++) {
  //     let line: LineModel = {
  //       lineid: this.getDetail(rawLines[lineIndexes[i]+lineDetailProperty.lineId.row], lineDetailProperty.lineId.start, lineDetailProperty.lineId.length),
  //       base: this.getDetail(rawLines[lineIndexes[i]+lineDetailProperty.base.row], lineDetailProperty.base.start, lineDetailProperty.base.length),
  //       equipment: this.getDetail(rawLines[lineIndexes[i]+lineDetailProperty.equipment.row], lineDetailProperty.equipment.start, lineDetailProperty.equipment.length), 
  //       position: this.getDetail(rawLines[lineIndexes[i]+lineDetailProperty.position.row], lineDetailProperty.position.start, lineDetailProperty.position.length),
  //       blockminutes: this.getDetail(rawLines[lineIndexes[i]+lineDetailProperty.block.row], lineDetailProperty.block.start, lineDetailProperty.block.length),
  //       creditminutes: this.getDetail(rawLines[lineIndexes[i]+lineDetailProperty.credit.row], lineDetailProperty.credit.start, lineDetailProperty.credit.length),
  //       days: []
  //     };

  //     // parse days
  //     for (let x = 0; x < days.length; x++) { // for each day
  //       let day: DayModel = { 
  //         month: days[x].month,
  //         day: days[x].day,
  //         pairingid: []
  //       };
  //       for (let z = 0; z < 2; z++) { // for each row in day
  //         let pairingRow = rawLines[lineIndexes[i]+z];
  //         let detail: string = '';
  //         for (let q = days[x].dayIndex; q < days[x].dayIndex+5; q++) { // for each character 
  //           if(pairingRow[q] === undefined) { break; }
  //           detail = detail + pairingRow[q];
  //         }
  //         detail = detail.trim();

  //         if(detail.startsWith('RES') || detail === 'OFFG' || (day.pairingid.length === 0 && detail === '')) { 
  //           day.pairingid.push(detail); 
  //           break; 
  //         }
  //         else if(detail === '') { break; }
  //         day.pairingid.push(detail);
  //       }
  //       line.days.push(day);
  //     }
  //     lines.push(line);
  //   }
  //   return lines;
  // }

  // txtLoadHandler(result: string): void {
  //   const headerRows = 4;
  //   let allTextLines = result.split(/\r\n|\n/); // \r = carriage return character; \n = new line character
  //   let rawLines: string[] = [];
  //   let days: string = allTextLines[3].trim();
  //   for (let i = headerRows; i < allTextLines.length; i++) {
  //     let temp = allTextLines[i].trim();
  //     if(temp.startsWith('MSP')) {
  //       for (let x = i; x < i+5; x++) { rawLines.push(allTextLines[x].trim()); }
  //       i = i+4;
  //     }
  //   }
  //   this.lines = this.parseLines(rawLines, this.getDays(days));
  // }

}
