import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { VehicleMake } from './add/class.vehicle-make';
import { VehicleModel } from './add/class.vehicle-model';
import { Vehicle } from './add/class.vehicle';
import { BehaviorSubject } from 'rxjs';



@Injectable({
  providedIn: 'root'
})
export class DataService {


  constructor(private http:HttpClient) {}
 

  private filterstart = new BehaviorSubject('00000000-0000-0000-0000-000000000000');
  filter = this.filterstart.asObservable();

  changeFilter(filter: string) {
    this.filterstart.next(filter);
  }
  private searchstart = new BehaviorSubject('null');
  search = this.searchstart.asObservable();

  changeSearch(search: string) {
    this.searchstart.next(search);
  }




  addVehicle(Vehicle: Vehicle): Observable<Vehicle> {
    return this.http.post<Vehicle>('/api/vehicle/add',Vehicle);
  }



  

  listVehicleMake(pageSort:string,pageSize: number, pageIndex: number, pageSearch: string): Observable<VehicleMake[]> {
    return this.http.get<VehicleMake[]>(`/api/vehiclemake/list/${pageSort}&${pageIndex}&${pageSize}&${pageSearch}`);
  }
  updateVehicleMake (VehicleMake: VehicleMake): Observable<VehicleMake> {
    return this.http.put<VehicleMake>('/api/vehiclemake/update', VehicleMake);
  }
  deleteVehicleMake(MakeId: string): Observable<{}> {
    return this.http.delete(`/api/vehiclemake/remove/${MakeId}`);
  }




  addVehicleModel(vehiclemodel: VehicleModel): Observable<VehicleModel> {
    return this.http.post<VehicleModel>('/api/vehiclemodel/add', vehiclemodel);
  }
  listVehicleModel(pageSort:string,pageSize: number, pageIndex: number, filter: string, pageSearch: string): Observable<VehicleModel[]> {
    return this.http.get<VehicleModel[]>(`/api/vehiclemodel/list/${pageSort}&${filter}&${pageIndex}&${pageSize}&${pageSearch}`); 
  }
  updateModel (vehiclemodel: VehicleModel): Observable<VehicleModel> {
    return this.http.put<VehicleModel>('/api/vehiclemodel/update', vehiclemodel);
  }
  deleteVehicleModel(ModelId: string): Observable<{}> {
    return this.http.delete(`/api/vehiclemodel/remove/${ModelId}`);
  }
 

}
