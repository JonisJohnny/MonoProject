
import { Component, OnInit, Input } from '@angular/core';
import { DataService } from '../data.service';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';
import { VehicleMakeModel, VehicleMakeResponse } from './vehiclemakeinterface';

@Component({
  selector: 'app-vehiclemake',
  templateUrl: './vehiclemake.component.html',
  styleUrls: ['./admin.component.css']
})
export class VehicleMakeComponent implements OnInit {




VehicleMakeArray: VehicleMakeModel[];
VehicleMake: VehicleMakeModel;
resultsMa: any;

pageSizeOptions: number[] = [5, 10, 25, 100];
pageSortTableVehicleMake:string = "null";

displayedColumnsMake: string[] = ['select','id', 'name', 'abrv', 'delete'];


@Input() paginationDetailMa = new BehaviorSubject(
  {
   length: 10,
   pageIndex: 0,
   pageSize: 5
  });





  constructor(private dataService:DataService) { }
   
  ngOnInit() {
    
    this.getVehicles();
  } 





  getVehicles(): void {
    this.dataService.listVehicleMake(this.pageSortTableVehicleMake,this.paginationDetailMa.value.pageSize,this.paginationDetailMa.value.pageIndex)
      .subscribe(parts => {
        this.VehicleMakeArray = parts.map((response: VehicleMakeResponse) => {
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



  editVehicleMake(vehiclemake: VehicleMakeModel) {
    this.VehicleMake = vehiclemake;
  }
  updateVehicleMake() {
    if (this.VehicleMake) {
      this.dataService
        .updateVehicleMake(this.VehicleMake)
        .subscribe(update => this.VehicleMake = update);

      this.VehicleMake = undefined;
    }
  }


  deleteVehicleMake(id: string) {
    
    this.dataService.deleteVehicleMake(id).subscribe((res) => {
        this.getVehicles();
        this.resultsMa = res;
      });
      setTimeout(function() {
        this.resultsMa = false;
        }.bind(this), 3000);
  }
  

}
