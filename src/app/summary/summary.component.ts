import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { BugCount } from '../models/BugCount';
import { Score } from '../models/Score';
import { SummaryService } from '../services/summary.service';
import { NgChartsModule } from 'ng2-charts';

const SAMPLE_BARCHART_DATA: any[] = [
  { data: [65, 59, 80, 81, 56, 54, 30], label: 'Q3 Sales' },
  { data: [25, 39, 60, 91, 36, 54, 50], label: 'Q4 Sales' },
];

const SAMPLE_BARCHART_LABELS: string[] = [
  'W1',
  'W2',
  'W3',
  'W4',
  'W5',
  'W6',
  'W7',
];

@Component({
  selector: 'app-summary',
  templateUrl: './summary.component.html',
  styleUrls: ['./summary.component.css'],
})
export class SummaryComponent implements OnInit {
  apiBugCount: BugCount;
  apiScoreTable: Score;
  featureTotalBugs: any;
  arrayFeatureTotalBugs: any = [];
  featureOpenBugs: any;
  arrayFeatureOpenBugs: any = [];

  constructor(private summaryService: SummaryService) {}
  public barChartData: any[] = SAMPLE_BARCHART_DATA;
  public barChartLabels: string[] = SAMPLE_BARCHART_LABELS;
  public barChartType: 'bar';
  public barChartLegend = false;
  public barChartOptions: any = {
    scaleShowVerticalLines: false,
    responsive: true,
  };

  ngOnInit(): void {
    //debugger;

    this.summaryService
      .getBugCount()
      .subscribe((data) => (this.apiBugCount = data));

    this.summaryService
      .getScoreTable()
      .subscribe((data) => (this.apiScoreTable = data));

    this.summaryService.getFeatureWiseTotalBugs().subscribe((data: any) => {
      this.featureTotalBugs = data;
      console.log(this.featureTotalBugs);
      var keysArray = Object.keys(this.featureTotalBugs);
      var valuesArray = Object.values(this.featureTotalBugs);
      for (var i = 0; i < keysArray.length; i++) {
        this.arrayFeatureTotalBugs.push({
          key: keysArray[i],
          value: valuesArray[i],
        });
      }
      console.log(this.arrayFeatureTotalBugs);
    });

    this.summaryService.getFeatureWiseOpenBugs().subscribe((data: any) => {
      this.featureOpenBugs = data;
      console.log('Feature Open Bugs ', this.featureOpenBugs);
      var keysArray = Object.keys(this.featureOpenBugs);
      var valuesArray = Object.values(this.featureOpenBugs);
      for (var i = 0; i < keysArray.length; i++) {
        this.arrayFeatureOpenBugs.push({
          key: keysArray[i],
          value: valuesArray[i],
        });
      }
      console.log(this.arrayFeatureOpenBugs);
    });
  }
}
