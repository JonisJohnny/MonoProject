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




  addVehicle(vehicle: vehicle): Observable<vehicle> {
    return this.http.post<vehicle>('/api/vehicle/add',vehicle);
  }



  

  listVehicleMake(pageSort:string,pageSize: number, pageIndex: number, pageSearch: string): Observable<vehiclemake[]> {
    return this.http.get<vehiclemake[]>(`/api/vehiclemake/list/${pageSort}&${pageIndex}&${pageSize}&${pageSearch}`);
  }
  updateVehicleMake (vehiclemake: vehiclemake): Observable<vehiclemake> {
    return this.http.put<vehiclemake>('/api/vehiclemake/update', vehiclemake);
  }
  deleteVehicleMake(make_id: string): Observable<{}> {
    return this.http.delete(`/api/vehiclemake/remove/${make_id}`);
  }




  addVehicleModel(vehiclemodel: vehiclemodel): Observable<vehiclemodel> {
    return this.http.post<vehiclemodel>('/api/vehiclemodel/add', vehiclemodel);
  }
  listVehicleModel(pageSort:string,pageSize: number, pageIndex: number, filter: string, pageSearch: string): Observable<vehiclemodel[]> {
    return this.http.get<vehiclemodel[]>(`/api/vehiclemodel/list/${pageSort}&${filter}&${pageIndex}&${pageSize}&${pageSearch}`); 
  }
  updateModel (vehiclemodel: vehiclemodel): Observable<vehiclemodel> {
    return this.http.put<vehiclemodel>('/api/vehiclemodel/update', vehiclemodel);
  }
  deleteVehicleModel(model_id: string): Observable<{}> {
    return this.http.delete(`/api/vehiclemodel/remove/${model_id}`);
  }
 

}
