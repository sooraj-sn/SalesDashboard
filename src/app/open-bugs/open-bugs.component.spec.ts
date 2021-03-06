import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OpenBugsComponent } from './open-bugs.component';

describe('OpenBugsComponent', () => {
  let component: OpenBugsComponent;
  let fixture: ComponentFixture<OpenBugsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OpenBugsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OpenBugsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
