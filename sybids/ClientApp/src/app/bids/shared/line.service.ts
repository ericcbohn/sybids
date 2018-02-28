import { Injectable } from '@angular/core';
import { Http, Headers, Response } from '@angular/http';
import 'rxjs/add/operator/toPromise';
import { LineModel } from './line.model';

@Injectable()
export class LineService {
  private BID_URL = '/api/bid/';
    
  constructor(private http: Http) { }

  getAllLines(): Promise<Array<LineModel>> {
    return this.http.get(this.BID_URL)
                    .toPromise()
                    .then(res => res.json())
                    .catch(this.handleError);
  }

  getLine(lineId: string): Promise<LineModel> {
    return this.getAllLines().then(lines => lines.find(line => line.lineid === lineId));
  }

  save(line: LineModel): Promise<LineModel> {
    // if(line._id !== null) {
    //   console.log("put " + line._id);
    //   return this.put(line);
    // }
    console.log("post");
    return this.post(line);
  }

  delete(line: LineModel): Promise<Response> {
    const headers = new Headers({ 'Content-Type': 'application/json' });
    const url = this.BID_URL + line.lineid;
    return this.http.delete(url, { headers: headers })
                    .toPromise()
                    .catch(this.handleError);
  }

  private put(line: LineModel): Promise<LineModel> {
    const headers = new Headers({ 'Content-Type': 'application/json' });
    const url = this.BID_URL + line.lineid;

    return this.http.put(url, JSON.stringify(line), { headers: headers})
                    .toPromise()
                    .then(() => line)
                    .catch(this.handleError);
  }

  private post(line: LineModel): Promise<LineModel> {
    const headers = new Headers({ 'Content-Type': 'application/json' });

    return this.http.post(this.BID_URL, JSON.stringify(line), {headers: headers})
                    .toPromise()
                    .then(res => res)
                    .catch(this.handleError);
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occured', error);
    return Promise.reject(error.message || error);
  }
}
