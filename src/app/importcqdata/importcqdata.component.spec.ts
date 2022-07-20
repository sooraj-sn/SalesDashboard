import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ImportcqdataComponent } from './importcqdata.component';

describe('ImportcqdataComponent', () => {
  let component: ImportcqdataComponent;
  let fixture: ComponentFixture<ImportcqdataComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ImportcqdataComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ImportcqdataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
