
import { Component, OnInit, Input } from '@angular/core';
import { DataService } from '../data.service';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';

 
export interface vehiclemake {
  id: number;
  name: string;
  abrv: string;
}
export interface vehiclemodel {
  makeid:number;
  id: number;
  name: string;
  abrv: string;
}

@Component({
  selector: 'app-fetch',
  templateUrl: './fetch.component.html',
  styleUrls: ['./fetch.component.css']
})
export class FetchComponent implements OnInit {


makesdata: Object;
modelsdata: Object;
resultsMa: Object;
resultsMo: Object;
resultUMa: Object;
resultUMo: Object;
vehiclemake: vehiclemake[];
vehiclemodel: vehiclemodel[];
editCarMa: vehiclemake;
editCarMo: vehiclemodel;
filter=0;
pageSizeOptions: number[] = [5, 10, 25, 100];
pageSortMa:string = "null";
pageSortMo:string = "null";


displayedColumnsMake: string[] = ['select','id', 'name', 'abrv', 'delete'];
displayedColumnsModel: string[] = ['id', 'name', 'abrv','makeid', 'delete'];




@Input() paginationDetailMa = new BehaviorSubject(
  {
    
   length: 10,
   pageIndex: 0,
   pageSize: 5
  });
  @Input() paginationDetailMo = new BehaviorSubject(
    {
     length: 10,
     pageIndex: 0,
     pageSize: 10,
     
    });

   
    
  constructor(private dataService:DataService) { }
   
  ngOnInit() {
    
    this.makesdata = this.dataService.GetMakes(this.pageSortMa,this.paginationDetailMa.value.pageSize,this.paginationDetailMa.value.pageIndex).subscribe(makesdata => this.makesdata = makesdata);
    this.modelsdata = this.dataService.GetModels(this.pageSortMo,this.paginationDetailMo.value.pageSize,this.paginationDetailMo.value.pageIndex,this.filter).subscribe(modelsdata => this.modelsdata = modelsdata);
    
  } 
  
 


  getUpdateMa(event) {
    this.paginationDetailMa.next(event);
    this.refreshMakes();
  }
  getUpdateMo(event) {
    this.paginationDetailMo.next(event); 
    this.refreshModels();
    }

  refreshMakes(){
    this.makesdata = this.dataService.GetMakes(this.pageSortMa,this.paginationDetailMa.value.pageSize,this.paginationDetailMa.value.pageIndex).subscribe(makesdata => this.makesdata = makesdata);
  }
  refreshModels(){
    this.modelsdata = this.dataService.GetModels(this.pageSortMo,this.paginationDetailMo.value.pageSize,this.paginationDetailMo.value.pageIndex,this.filter).subscribe(modelsdata => this.modelsdata = modelsdata);
    
  }


  filterModels(){
    this.modelsdata = this.dataService.GetModels(this.pageSortMo,this.paginationDetailMo.value.pageSize,this.paginationDetailMo.value.pageIndex,this.filter).subscribe(modelsdata => this.modelsdata = modelsdata);
   
  }

  pageEvent(value) {
    console.log('page event', value);
  }

  sortDataMa(event){
    this.pageSortMa = event.active+"_"+event.direction;
    
    this.makesdata = this.dataService.GetMakes(this.pageSortMa,this.paginationDetailMa.value.pageSize,this.paginationDetailMa.value.pageIndex).subscribe(makesdata => this.makesdata = makesdata);

  }
  sortDataMo(event){
    this.pageSortMo = event.active+"_"+event.direction;
    
   this.modelsdata = this.dataService.GetModels(this.pageSortMo,this.paginationDetailMo.value.pageSize,this.paginationDetailMo.value.pageIndex,this.filter).subscribe(modelsdata => this.modelsdata = modelsdata);
    
  }




  setPageSizeOptions(setPageSizeOptionsInput: string) {
    this.pageSizeOptions = setPageSizeOptionsInput.split(',').map(str => +str);
  }

  clearradiobtn(){
    this.filter=0;
  }


  editMa(vehiclemake: vehiclemake) {
    this.editCarMa = vehiclemake;
  }
  editMo(vehiclemodel: vehiclemodel) {
    this.editCarMo = vehiclemodel;
  }
  updateMake() {
    if (this.editCarMa) {
      this.dataService
        .updateMake(this.editCarMa)
        .subscribe(car => this.resultUMa = car);

      this.editCarMa = undefined;
    }
  }
  updateModel() {
    if (this.editCarMo) {
      this.dataService
      .updateModel(this.editCarMo)
      .subscribe(car => this.resultUMo = car);
      this.editCarMo = undefined;
    }
  }


  
  
  deleteMake(id: number) {
    
    this.dataService.deleteVehicleMake(id).subscribe((res) => {
        this.refreshMakes();
        this.resultsMa = res;
      });
      setTimeout(function() {
        this.resultsMa = false;
        }.bind(this), 3000);
  }
  deleteModel(id: number) {
    this.dataService.deleteVehicleModel(id).subscribe((res) => {
    this.refreshModels();
      this.resultsMo = res;
    });
    setTimeout(function() {
      this.resultsMo = false;
      }.bind(this), 3000);
    
  }
  

}
