import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { vehiclemake, vehiclemodel, cars } from './add/cars';

@Injectable({
  providedIn: 'root'
})
export class DataService {


  constructor(private http:HttpClient) {}
 
  addCar(cars: cars): Observable<cars> {
    return this.http.post<cars>('/api/make/addcarmake', cars);
  }
  GetMakes(pageSort:string,pageSize: number, pageIndex: number) {
    return this.http.get(`/api/make/vehiclemakes/${pageSort}&${pageIndex}&${pageSize}`);
  }
  updateMake (vehiclemake: vehiclemake): Observable<vehiclemake> {
    return this.http.put<vehiclemake>('/api/make/vehiclemake/update', vehiclemake);
  }
  deleteVehicleMake(make_id: number): Observable<{}> {
    return this.http.delete(`/api/make/vehicleMake/remove/${make_id}`);
  }


  
  GetModels(pageSort:string,pageSize: number, pageIndex: number, filter: number) {
    return this.http.get(`/api/model/vehiclemodels/${pageSort}&${filter}&${pageIndex}&${pageSize}`); 
  }
  updateModel (vehiclemodel: vehiclemodel): Observable<vehiclemodel> {
    return this.http.put<vehiclemodel>('/api/model/vehiclemodel/update', vehiclemodel);
  }
  deleteVehicleModel(model_id: number): Observable<{}> {
    return this.http.delete(`/api/model/vehicleModel/remove/${model_id}`);
  }
 

}
