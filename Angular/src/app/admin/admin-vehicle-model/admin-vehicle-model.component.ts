
import { Component, OnInit, Input } from '@angular/core';
import { DataService } from '../../data.service';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';
import { VehicleModelModel } from '../vehicle-model.interface';


 

@Component({
  selector: 'app-vehiclemodel',
  templateUrl: './admin-vehicle-model.component.html',
  styleUrls: ['../admin-main.component.css']
})
export class AdminVehicleModelComponent implements OnInit {


vehicleModelArray: VehicleModelModel[];
vehicleModel: VehicleModelModel;
totalRecords:number;
resultsVehicleModelDelete: any;

filterModelTabel:string;
search="null";
pageSizeOptions: number[] = [5, 10, 25, 100];
pageSortTableVehicleModel:string;

displayedColumnsModel: string[] = ['name', 'abrv', 'delete'];


  @Input() paginationDetailMo = new BehaviorSubject(
    {
     length: 10,
     pageIndex: 0,
     pageSize: 10,
    });





  constructor(private DataService:DataService) { }
   
  ngOnInit() {
        this.DataService.filterModelTabelFunc.subscribe( filter => {this.filterModelTabel = filter; this.getVehicles();});
        this.DataService.search.subscribe(search => {this.search = search; this.getVehicles();});
  } 


  

  getVehicles() {
    this.DataService.listVehicleModel(this.pageSortTableVehicleModel,this.paginationDetailMo.value.pageSize,this.paginationDetailMo.value.pageIndex,this.filterModelTabel,this.search)
      .subscribe(model => {
        this.vehicleModelArray = model['items'];
        this.totalRecords = model['totalRecords'];
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



  editVehicleModel(vehicleModel: VehicleModelModel) {
    this.vehicleModel = vehicleModel;
  }
  updateVehicleModel() {
    if (this.vehicleModel) {
      this.DataService
      .updateModel(this.vehicleModel)
      .subscribe(update => this.vehicleModel = update);
      this.vehicleModel = undefined;
    }
  }


  
  
  deleteVehicleModel(Id:string) {
    this.DataService.deleteVehicleModel(Id).subscribe((res) => {
    this.getVehicles();
      this.resultsVehicleModelDelete = res;
      setTimeout(function() {
        this.resultsVehicleModelDelete = false;
        }.bind(this), 3000);
    });

    
  }
  

}
