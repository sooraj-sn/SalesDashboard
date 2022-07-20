import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BugCount } from '../models/BugCount';
import { Score } from '../models/Score';
import { map } from 'rxjs/operators';
import { OpenBugs } from '../models/OpenBugs';

@Injectable({
  providedIn: 'root',
})
export class OpenbugsService {
  constructor(private http: HttpClient) {}

  getOpenBugsList(): Observable<OpenBugs[]> {
    var result = this.http.get<OpenBugs[]>(
      'http://localhost:5000/CQData/GetOpenBugs'
    );
    return result;
  }
}
