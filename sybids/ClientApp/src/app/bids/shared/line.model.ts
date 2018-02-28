// {"timestamp":1518802762,"machine":3825207,"pid":1529,"increment":15115763,"creationTime":"2018-02-16T17:39:22Z"}
export interface MongoObjId {
    timestamp: string;
    machine: string;
    pid: string;
    increment: string;
    creationTime: string;
}

export interface PairingModel { 
    // _id: MongoObjId;
    pairingId: string;
    base: string;
    numDays: string;
    block: string;
    credit: string;
    landings: string;
    deadheads: string;
    tafb: string;
    duty: DutyModel[];
}

export interface DutyModel { 
    dutyDay: string;
    legs: string;
    brief: string;
    debrief: string;
    dutyTime: string;
    block: string; 
    credit: string;
    rest: string;
    restType: string;
    leg: LegModel[];
}

export interface LegModel { 
    legNum: string;
    equipment: string;
    fleetCode: string;
    flight: string;
    departure: string;
    arrival: string;
    departureTime: string;
    arrivalTime: string;
    block: string;
    carrier: string;
}

// export interface LineModel {
//     lineid: string;
//     base: string;
//     position: string;
//     numdaysoff: string;
//     tafb: string;
//     blockminutes: string;
//     creditminutes: string;
//     days: DayModel[];
// }

// export interface DayModel {
//     day: string;
//     isoff: string;
//     reporttimeutc: string;
//     releasetimeutc: string;
//     pairings: PairingModel[];
// }

// export interface PairingModel {
//     flight: string;
//     departure: string;
//     destination: string;
//     isdeadhead: string;
// }