import { Injectable } from '@angular/core';
import { Http, Headers, Response } from '@angular/http';
import { LineModel } from './line.model';

@Injectable()
export class LineService {
  private LINE_URL = '/api/line/';
  private LINES_URL = '/api/line/lines/';
    
  constructor(private http: Http) { }

  save(line: LineModel) {
    const headers = new Headers({ 'Content-Type': 'application/json' });
    return this.http.post(this.LINE_URL, JSON.stringify(line), {headers: headers})
                    .toPromise()
                    .then(res => res)
                    .catch(this.handleError);
  }

  saveLines(lines: LineModel[]) {
    const headers = new Headers({ 'Content-Type': 'application/json' });
    return this.http.post(this.LINES_URL, JSON.stringify(lines), { headers: headers })
                    .toPromise()
                    .then(res => res)
                    .catch(this.handleError);
  }

  getLine(lineId: string): Promise<LineModel> {
    return this.http.get(this.LINE_URL + lineId)
                    .toPromise()
                    .then(res => res.json())
                    .catch(this.handleError);
  }

  getLines(): Promise<Array<LineModel>> {
    return this.http.get(this.LINE_URL)
                    .toPromise()
                    .then(res => res.json())
                    .catch(this.handleError);
  }

  update(line: LineModel) {
    const headers = new Headers({ 'Content-Type': 'application/json' });
    return this.http.put(this.LINE_URL, JSON.stringify(line), { headers: headers })
      .toPromise()
      .then(res => res)
      .catch(this.handleError);
  }

  delete(line: LineModel): Promise<Response> {
    const headers = new Headers({ 'Content-Type': 'application/json' });
    const url = this.LINE_URL + line.lineid;
    return this.http.delete(url, { headers: headers })
                    .toPromise()
                    .catch(this.handleError);
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occured', error);
    return Promise.reject(error.message || error);
  }
}
