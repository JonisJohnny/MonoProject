import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminVehicleMakeComponent } from './admin.vehicle-make.component';

describe('VehicelMakeComponent', () => {
  let component: AdminVehicleMakeComponent;
  let fixture: ComponentFixture<AdminVehicleMakeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminVehicleMakeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminVehicleMakeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
