
import { Component, OnInit, Input } from '@angular/core';
import { DataService } from '../data.service';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';
import { VehicleModelModel, VehicleModelResponse } from './interface.vehicle-model';


 

@Component({
  selector: 'app-vehiclemodel',
  templateUrl: './admin.vehicle-model.component.html',
  styleUrls: ['./admin.main.component.css']
})
export class AdminVehicleModelComponent implements OnInit {


VehicleModelArray: VehicleModelModel[];
VehicleModel: VehicleModelModel;
resultsMo: any;

filter:string;
search="null";
pageSizeOptions: number[] = [5, 10, 25, 100];
pageSortTableVehicleModel:string = "null";

displayedColumnsModel: string[] = ['id', 'name', 'abrv','makeid', 'delete'];


  @Input() paginationDetailMo = new BehaviorSubject(
    {
     length: 10,
     pageIndex: 0,
     pageSize: 10,
    });





  constructor(private DataService:DataService) { }
   
  ngOnInit() {
        this.DataService.filter.subscribe( filter => {this.filter = filter; this.getVehicles();});
        this.DataService.search.subscribe(search => {this.search = search; this.getVehicles();});
  } 


  

  getVehicles(): void {
    this.DataService.listVehicleModel(this.pageSortTableVehicleModel,this.paginationDetailMo.value.pageSize,this.paginationDetailMo.value.pageIndex,this.filter,this.search)
      .subscribe(parts => {
        this.VehicleModelArray = parts.map((response: VehicleModelResponse) => {
          return <VehicleModelModel>{
            id: response.id,
            name: response.name,
            abrv: response.abrv,
            makeid: response.makeid
          };
        });

    })
  }


  paginationOptionsRefreshVehicleModel(event) {
    this.paginationDetailMo.next(event); 
    this.getVehicles();
  }

  sortTableVehicleModel(event){
    this.pageSortTableVehicleModel = event.active+"_"+event.direction;
    
    this.getVehicles();
  }

  setPageSizeOptions(setPageSizeOptionsInput: string) {
    this.pageSizeOptions = setPageSizeOptionsInput.split(',').map(str => +str);
  }



  editVehicleModel(vehiclemodel: VehicleModelModel) {
    this.VehicleModel = vehiclemodel;
  }
  updateVehicleModel() {
    if (this.VehicleModel) {
      this.DataService
      .updateModel(this.VehicleModel)
      .subscribe(update => this.VehicleModel = update);
      this.VehicleModel = undefined;
    }
  }


  
  
  deleteVehicleModel(Id:string) {
    this.DataService.deleteVehicleModel(Id).subscribe((res) => {
    this.getVehicles();
      this.resultsMo = res;
    });
    setTimeout(function() {
      this.resultsMo = false;
      }.bind(this), 3000);
    
  }
  

}
