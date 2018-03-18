import { Injectable } from '@angular/core';
import { Http, Headers, Response } from '@angular/http';
import { PairingModel } from '../shared/line.model';

@Injectable()
export class PairingService {
  private PAIRING_URL = '/api/pairing/';
  private PAIRINGS_URL = '/api/pairing/pairings/';

  constructor(private http: Http) { }

  save(pairing: PairingModel) {
    const headers = new Headers({ 'Content-Type': 'application/json' });
    return this.http.post(this.PAIRING_URL, JSON.stringify(pairing), {headers: headers})
                    .toPromise()
                    .then(res => res)
                    .catch(this.handleError);
  }

  savePairings(pairings: PairingModel[]) {
    const headers = new Headers({ 'Content-Type': 'application/json' });
    return this.http.post(this.PAIRINGS_URL, JSON.stringify(pairings), { headers: headers })
                    .toPromise()
                    .then(res => res)
                    .catch(this.handleError);
  }

  getPairing(pairingId: string): Promise<PairingModel> {
    return this.http.get(this.PAIRING_URL + pairingId)
                    .toPromise()
                    .then(res => res.json())
                    .catch(this.handleError);
  }

  getPairings(): Promise<Array<PairingModel>> {
    return this.http.get(this.PAIRING_URL)
                    .toPromise()
                    .then(res => res.json())
                    .catch(this.handleError);
  }

  put(pairing: PairingModel): Promise<PairingModel> {
    const headers = new Headers({ 'Content-Type': 'application/json' });
    const url = this.PAIRING_URL + pairing.pairingid;
    return this.http.put(url, JSON.stringify(pairing), { headers: headers})
                    .toPromise()
                    .then(() => pairing)
                    .catch(this.handleError);
  }

  delete(pairing: PairingModel): Promise<Response> {
    const headers = new Headers({ 'Content-Type': 'application/json' });
    const url = this.PAIRING_URL + pairing.pairingid;
    return this.http.delete(url, { headers: headers })
                    .toPromise()
                    .catch(this.handleError);
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occured', error);
    return Promise.reject(error.message || error);
  }
}
