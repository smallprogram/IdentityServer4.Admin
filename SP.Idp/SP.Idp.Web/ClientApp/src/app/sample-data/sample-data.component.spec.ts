import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SampleDataComponent } from './sample-data.component';

describe('SampleDataComponent', () => {
  let component: SampleDataComponent;
  let fixture: ComponentFixture<SampleDataComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SampleDataComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SampleDataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
