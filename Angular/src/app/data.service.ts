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
    var returning = this.http.post<vehiclemake>('/api/vehiclemake/add', vehiclemake);
    alert(JSON.stringify(returning)+" "+JSON.stringify(vehiclemake));
    return returning;
  }
  listVehicleMake(pageSort:string,pageSize: number, pageIndex: number): Observable<vehiclemake[]> {
    var returning = this.http.get<vehiclemake[]>(`/api/vehiclemake/list/${pageSort}&${pageIndex}&${pageSize}`);
    alert(JSON.stringify(returning)+" "+JSON.stringify(vehiclemake));
    return returning;
  }
  updateVehicleMake (vehiclemake: vehiclemake): Observable<vehiclemake> {
    var returning = this.http.put<vehiclemake>('/api/vehiclemake/update', vehiclemake);
    alert(JSON.stringify(returning)+" "+JSON.stringify(vehiclemake));
    return returning;
  }
  deleteVehicleMake(make_id: string): Observable<{}> {
    var returning = this.http.delete(`/api/vehiclemake/remove/${make_id}`);
    alert(JSON.stringify(returning)+" "+JSON.stringify(vehiclemake));
    return returning;
  }




  addVehicleModel(vehiclemodel: vehiclemodel): Observable<vehiclemodel> {
    var returning = this.http.post<vehiclemodel>('/api/vehiclemake/add', vehiclemodel);
    alert(JSON.stringify(returning)+" "+JSON.stringify(vehiclemodel));
    return returning;
  }
  listVehicleModel(pageSort:string,pageSize: number, pageIndex: number, filter: string): Observable<vehiclemodel[]> {
    var returning = this.http.get<vehiclemodel[]>(`/api/vehiclemodel/list/${pageSort}&${filter}&${pageIndex}&${pageSize}`); 
   alert(JSON.stringify(returning)+" "+JSON.stringify(vehiclemodel));
    return returning;
  }
  updateModel (vehiclemodel: vehiclemodel): Observable<vehiclemodel> {
    var returning = this.http.put<vehiclemodel>('/api/vehiclemodel/update', vehiclemodel);
    alert(JSON.stringify(returning)+" "+JSON.stringify(vehiclemodel));
     return returning;
  }
  deleteVehicleModel(model_id: string): Observable<{}> {
    var returning = this.http.delete(`/api/vehiclemodel/remove/${model_id}`);
    alert(JSON.stringify(returning)+" "+JSON.stringify(vehiclemodel));
     return returning;
  }
 

}
