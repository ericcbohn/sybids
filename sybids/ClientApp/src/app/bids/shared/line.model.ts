export interface LineModel {
    _id: string;
    datecreatedutc: string;
    lineid: string;
    base: string;
    position: string;
    blockminutes: string;
    creditminutes: string;
    days: DayModel[];
}

export interface DayModel {
    reporttimeutc: string;
    releasetimeutc: string;
    pairings: PairingModel[];
}

export interface PairingModel {
    flight: string;
    departure: string;
    destination: string;
    isdeadhead: string;
}