
import { Component, OnInit, Input } from '@angular/core';
import { DataService } from '../data.service';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';
import { VehicleModelModel, VehicleModelResponse } from './vehiclemodelinterface';
 

@Component({
  selector: 'app-vehiclemodel',
  templateUrl: './vehiclemodel.component.html',
  styleUrls: ['./admin.component.css']
})
export class VehicleModelComponent implements OnInit {


VehicleModelArray: VehicleModelModel[];
VehicleModel: VehicleModelModel;
resultsMo: any;

filter="00000000-0000-0000-0000-000000000000";
pageSizeOptions: number[] = [5, 10, 25, 100];
pageSortTableVehicleModel:string = "null";

displayedColumnsModel: string[] = ['id', 'name', 'abrv','makeid', 'delete'];


  @Input() paginationDetailMo = new BehaviorSubject(
    {
     length: 10,
     pageIndex: 0,
     pageSize: 10,
    });





  constructor(private dataService:DataService) { }
   
  ngOnInit() {
        this.getVehicles();
  } 

  getVehicles(): void {
    this.dataService.listVehicleModel(this.pageSortTableVehicleModel,this.paginationDetailMo.value.pageSize,this.paginationDetailMo.value.pageIndex,this.filter)
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

  clearradiobtn(){
    this.filter="00000000-0000-0000-0000-000000000000";
  }


  editVehicleModel(vehiclemodel: VehicleModelModel) {
    this.VehicleModel = vehiclemodel;
  }
  updateVehicleModel() {
    if (this.VehicleModel) {
      this.dataService
      .updateModel(this.VehicleModel)
      .subscribe(update => this.VehicleModel = update);
      this.VehicleModel = undefined;
    }
  }


  
  
  deleteVehicleModel(id:string) {
    this.dataService.deleteVehicleModel(id).subscribe((res) => {
    this.getVehicles();
      this.resultsMo = res;
    });
    setTimeout(function() {
      this.resultsMo = false;
      }.bind(this), 3000);
    
  }
  

}
