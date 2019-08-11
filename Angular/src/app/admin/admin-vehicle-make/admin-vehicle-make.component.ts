
import { Component, OnInit, Input } from '@angular/core';
import { DataService } from '../../data.service';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';
import { VehicleMakeModel, VehicleMakeResponse } from '../vehicle-make.interface';


@Component({
  selector: 'app-vehiclemake',
  templateUrl: './admin-vehicle-make.component.html',
  styleUrls: ['../admin-main.component.css']
})
export class AdminVehicleMakeComponent implements OnInit {


vehicleMakeArray: VehicleMakeModel[];
vehicleMake: VehicleMakeModel;
resultsVehicleMakeDelete: any;
filterModelTabel:string;
search:string;

pageSizeOptions: number[] = [5, 10, 25, 100];
pageSortTableVehicleMake:string;

displayedColumnsMake: string[] = ['select', 'name', 'abrv', 'delete'];


@Input() paginationDetailMa = new BehaviorSubject(
  {
   length: 10,
   pageIndex: 0,
   pageSize: 5
  });





  constructor(private DataService:DataService) { }
   
  ngOnInit() {
    this.DataService.filterModelTabelFunc.subscribe(filter => this.filterModelTabel = filter);
    this.DataService.search.subscribe(search => {this.search = search; this.getVehicles();});

  } 




  getVehicles(): void {
    this.DataService.listVehicleMake(this.pageSortTableVehicleMake,this.paginationDetailMa.value.pageSize,this.paginationDetailMa.value.pageIndex,this.search)
      .subscribe(parts => {
        this.vehicleMakeArray = parts.map((response: VehicleMakeResponse) => {
          return <VehicleMakeModel>{
            id: response.id,
            name: response.name,
            abrv: response.abrv
          };
        });

    })
  }
  

  paginationOptionsRefreshVehicleMake(event) {
    this.paginationDetailMa.next(event);
    this.getVehicles();
  }

  sortTableVehicleMake(event){
    
    this.pageSortTableVehicleMake = event.active+"_"+event.direction;
    this.getVehicles();
  }

  setPageSizeOptions(setPageSizeOptionsInput: string) {
    this.pageSizeOptions = setPageSizeOptionsInput.split(',').map(str => +str);
  }

  
  filterVehicleModels(){
    this.DataService.changeFilter(this.filterModelTabel);
  }



  editVehicleMake(vehicleMake: VehicleMakeModel) {
    this.vehicleMake = vehicleMake;
  }
  updateVehicleMake() {
    if (this.vehicleMake) {
      this.DataService
        .updateVehicleMake(this.vehicleMake)
        .subscribe(update => this.vehicleMake = update);

      this.vehicleMake = undefined;
    }
  }


  deleteVehicleMake(id: string) {
    
    this.DataService.deleteVehicleMake(id).subscribe((res) => {
        this.getVehicles();
        this.resultsVehicleMakeDelete = res;
        setTimeout(function() {
          this.resultsVehicleMakeDelete = false;
          }.bind(this), 3000);
      });

  }
  

}
