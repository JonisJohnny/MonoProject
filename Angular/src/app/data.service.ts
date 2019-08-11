import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { VehicleMake } from './add/vehicle-make.class';
import { VehicleModel } from './add/vehicle-model.class';
import { Vehicle } from './add/vehicle.class';
import { BehaviorSubject } from 'rxjs';
import { VehicleMakeModel } from './admin/vehicle-make.interface';
import { VehicleModelModel } from './admin/vehicle-model.interface';



@Injectable({
  providedIn: 'root'
})
export class DataService {


  constructor(private http:HttpClient) {}
 

  private filterstart = new BehaviorSubject('-1');
  filterModelTabelFunc = this.filterstart.asObservable();

  changeFilter(filterModelTabelFunc: string) {
    this.filterstart.next(filterModelTabelFunc);
  }
  private searchstart = new BehaviorSubject('null');
  search = this.searchstart.asObservable();

  changeSearch(search: string) {
    this.searchstart.next(search);
  }




  addVehicle(vehicle: Vehicle): Observable<Vehicle> {
    return this.http.post<Vehicle>('/api/vehicle/add',vehicle);
  }



  

  listVehicleMake(pageSort:string,pageSize: number, pageIndex: number, pageSearch: string): Observable<VehicleMake[]> {
    return this.http.get<VehicleMake[]>(`/api/vehiclemake/list/${pageSort}&${pageIndex}&${pageSize}&${pageSearch}`);
  }
  updateVehicleMake (vehicleMake: VehicleMakeModel): Observable<VehicleMakeModel> {
    return this.http.put<VehicleMakeModel>('/api/vehiclemake/update', vehicleMake);
  }
  deleteVehicleMake(makeId: string): Observable<{}> {
    return this.http.delete(`/api/vehiclemake/remove/${makeId}`);
  }




  addVehicleModel(vehicleModel: VehicleModel): Observable<VehicleModel> {
    return this.http.post<VehicleModel>('/api/vehiclemodel/add', vehicleModel);
  }
  listVehicleModel(pageSort:string,pageSize: number, pageIndex: number, filter: string, pageSearch: string): Observable<VehicleModel[]> {
    return this.http.get<VehicleModel[]>(`/api/vehiclemodel/list/${pageSort}&${filter}&${pageIndex}&${pageSize}&${pageSearch}`); 
  }
  updateModel (vehicleModel: VehicleModelModel): Observable<VehicleModelModel> {
    return this.http.put<VehicleModelModel>('/api/vehiclemodel/update', vehicleModel);
  }
  deleteVehicleModel(modelId: string): Observable<{}> {
    return this.http.delete(`/api/vehiclemodel/remove/${modelId}`);
  }
 

}
