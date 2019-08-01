import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { vehiclemake } from './add/classvehiclemake';
import { vehiclemodel } from './add/classvehiclemodel';




@Injectable({
  providedIn: 'root'
})
export class DataService {


  constructor(private http:HttpClient) {}
 
  addVehicleMake(vehiclemake: vehiclemake): Observable<vehiclemake> {
    return this.http.post<vehiclemake>('/api/vehiclemake/add', vehiclemake);
  }
  listVehicleMake(pageSort:string,pageSize: number, pageIndex: number): Observable<vehiclemake[]> {
    return this.http.get<vehiclemake[]>(`/api/vehiclemake/list/${pageSort}&${pageIndex}&${pageSize}`);
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
  listVehicleModel(pageSort:string,pageSize: number, pageIndex: number, filter: string): Observable<vehiclemodel[]> {
    return this.http.get<vehiclemodel[]>(`/api/vehiclemodel/list/${pageSort}&${filter}&${pageIndex}&${pageSize}`); 
  }
  updateModel (vehiclemodel: vehiclemodel): Observable<vehiclemodel> {
    return this.http.put<vehiclemodel>('/api/vehiclemodel/update', vehiclemodel);
  }
  deleteVehicleModel(model_id: string): Observable<{}> {
    return this.http.delete(`/api/vehiclemodel/remove/${model_id}`);
  }
 

}
