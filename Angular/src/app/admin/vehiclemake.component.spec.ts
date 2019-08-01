import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicleMakeComponent } from './vehiclemakeadmin.component';

describe('VehicelMakeComponent', () => {
  let component: VehicleMakeComponent;
  let fixture: ComponentFixture<VehicleMakeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VehicleMakeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VehicleMakeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
