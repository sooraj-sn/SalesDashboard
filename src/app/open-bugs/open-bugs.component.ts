import { Component, OnInit } from '@angular/core';
import { OpenBugs } from '../models/OpenBugs';
import { OpenbugsService } from '../services/openbugs.service';

@Component({
  selector: 'app-open-bugs',
  templateUrl: './open-bugs.component.html',
  styleUrls: ['./open-bugs.component.css'],
})
export class OpenBugsComponent implements OnInit {
  openBugsList: OpenBugs[];
  constructor(private openbugsService: OpenbugsService) {}

  ngOnInit(): void {
    this.openbugsService
      .getOpenBugsList()
      .subscribe((data) => (this.openBugsList = data));
  }
}
