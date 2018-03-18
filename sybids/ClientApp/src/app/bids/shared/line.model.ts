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
    pairingid: string;
    base: string;
    numdays: string;
    block: string;
    credit: string;
    landings: string;
    deadheads: string;
    tafb: string;
    duty: DutyModel[];
}

export interface DutyModel { 
    dutyday: string;
    legs: string;
    brief: string;
    debrief: string;
    dutytime: string;
    block: string; 
    credit: string;
    rest: string;
    resttype: string;
    leg: LegModel[];
}

export interface LegModel { 
    legNum: string;
    equipment: string;
    fleetcode: string;
    flight: string;
    departure: string;
    arrival: string;
    departuretime: string;
    arrivaltime: string;
    block: string;
    carrier: string;
}

export interface LineModel {
    // _id: MongoObjId;
    lineid: string;
    base: string;
    equipment: string;
    position: string;
    blockminutes: string;
    creditminutes: string;
    day: DayModel[];
}

export interface DayModel {
    month: string;
    day: string;
    pairingid: string[];
}

export interface RawDayModel {
    month: string;
    day: string;
    dayIndex: number;
}
