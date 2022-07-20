import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-importcqdata',
  templateUrl: './importcqdata.component.html',
  styleUrls: ['./importcqdata.component.css'],
})
export class ImportcqdataComponent implements OnInit {
  fileToUpload: File | null = null;
  constructor() {}

  ngOnInit(): void {}

  handleFileInput() {}
}
