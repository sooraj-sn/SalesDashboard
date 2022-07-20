import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BugCount } from '../models/BugCount';
import { Score } from '../models/Score';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class SummaryService {
  constructor(private http: HttpClient) {}

  getBugCount(): Observable<BugCount> {
    var result = this.http.get<BugCount>(
      'http://localhost:5000/CQData/GetBugCount'
    );
    return result;
  }

  getScoreTable(): Observable<Score> {
    var result = this.http.get<Score>('http://localhost:5000/CQData/GetScore');
    return result;
  }

  getFeatureWiseTotalBugs(): any {
    var result = this.http.get<any>(
      'http://localhost:5000/CQData/GetFeaturesTotalBugs'
    );

    return result;
  }

  getFeatureWiseOpenBugs(): any {
    var result = this.http.get<any>(
      'http://localhost:5000/CQData/GetFeaturesOpenBugs'
    );

    return result;
  }
}
