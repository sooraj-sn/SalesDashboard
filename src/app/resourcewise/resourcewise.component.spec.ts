import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResourcewiseComponent } from './resourcewise.component';

describe('ResourcewiseComponent', () => {
  let component: ResourcewiseComponent;
  let fixture: ComponentFixture<ResourcewiseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ResourcewiseComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ResourcewiseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
