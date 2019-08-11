import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { AdminVehicleModelComponent } from './admin-vehicle-model.component';

describe('VehicelModelComponent', () => {
  let component: AdminVehicleModelComponent;
  let fixture: ComponentFixture<AdminVehicleModelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminVehicleModelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminVehicleModelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
