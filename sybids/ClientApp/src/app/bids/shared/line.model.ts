export interface LineModel {
    _id: number;
    dateCreatedUtc: Date;
    lineId: number;
    base: string;
    position: string;
    blockMinutes: number;
    creditMinutes: number;
    days: DayModel[];
}

export interface DayModel {
    reportTimeUtc: Date;
    releaseTimeUtc: Date;
    pairings: PairingModel[];
}

export interface PairingModel {
    flight: number;
    departure: string;
    destination: string;
    isDeadhead: boolean;
}