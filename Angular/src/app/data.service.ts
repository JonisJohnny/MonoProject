import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { cars } from './add/cars';

@Injectable({
  providedIn: 'root'
})
export class DataService {


  constructor(private http:HttpClient) {}

  GetMakes(pageSort:string,pageSize: number, pageIndex: number) {
    return this.http.get(`/api/values/vehiclemakes/${pageSort}&${pageIndex}&${pageSize}`);
  }
  GetModels(pageSort:string,pageSize: number, pageIndex: number, filter: number) {
    return this.http.get(`/api/values/vehiclemodels/${pageSort}&${filter}&${pageIndex}&${pageSize}`); 
  }
  deleteVehicleMake(make_id: number): Observable<{}> {
    return this.http.delete(`/api/values/vehicleMake/remove/${make_id}`);
  }
  deleteVehicleModel(model_id: number): Observable<{}> {
    return this.http.delete(`/api/values/vehicleModel/remove/${model_id}`);
  }
  addCar (cars: cars): Observable<cars> {
    return this.http.post<cars>('/api/values/addcarmodel', cars);
  }
  updateMake (cars: cars): Observable<cars> {
    return this.http.put<cars>('/api/values/vehiclemake/update', cars);
  }
  updateModel (cars: cars): Observable<cars> {
    return this.http.put<cars>('/api/values/vehiclemodel/update', cars);
  }
}
