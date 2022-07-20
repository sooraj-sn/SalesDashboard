import { Routes } from '@angular/router';
import { SummaryComponent } from './app/summary/summary.component';
import { ImportcqdataComponent } from './app/importcqdata/importcqdata.component';
import { OpenBugsComponent } from './app/open-bugs/open-bugs.component';
import { ResourcewiseComponent } from './app/resourcewise/resourcewise.component';

export const appRoutes: Routes = [
  { path: 'summary', component: SummaryComponent },
  { path: 'import', component: ImportcqdataComponent },
  { path: 'openbugs', component: OpenBugsComponent },
  { path: 'resourcewise', component: ResourcewiseComponent },
  { path: '', redirectTo: '/summary', pathMatch: 'full' },
];
