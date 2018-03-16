import { Injectable } from '@angular/core';
import { PairingModel, DutyModel, LegModel } from '../shared/line.model';


@Injectable()
export class PairingHandlerService {

  constructor() { }

  csvLoadHandler(result: string): PairingModel[] {
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

    return pairings;
  }
}
