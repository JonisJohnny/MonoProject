import { Component, OnInit } from '@angular/core';
import { VehicleMake } from './vehicle-make.class';
import { VehicleModel } from './vehicle-model.class';
import { Vehicle } from './vehicle.class';
import { DataService } from '../data.service';
import { Router,ActivatedRoute } from '@angular/router';
import { VehicleMakeModel, VehicleMakeResponse } from '../admin/vehicle-make.interface';


@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {

vehicleMakeArray: VehicleMakeModel[];
vehicleMake = new VehicleMake('-1','','');
vehicleModel = new VehicleModel('','','');
vehicle = new Vehicle(this.vehicleMake,this.vehicleModel);
public show:boolean = true;

constructor(private DataService: DataService,private route: ActivatedRoute,private router: Router) { }

ngOnInit() {
 this.getVehicles();
}

getVehicles(): void {
  this.DataService.listVehicleMake(null,50,0,null)
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

 
  toggle() {
    if(this.vehicle.VehicleMake.id === "-1"){
      this.show = true;
    }else{
      this.show = false;
    }
  }





  submitted = false;
 
  onSubmit() { 
    
    this.submitted = true; 
  }
 
  newCar() {  
    if(this.vehicle.VehicleMake.id === "-1"){
        delete this.vehicle.VehicleMake.id;
        delete this.vehicle.VehicleModel.makeid;
        this.DataService.addVehicle(this.vehicle).subscribe(results => {
          this.router.navigate(['/admin/'],{ relativeTo: this.route });
        });
    }else{
        this.vehicleModel.makeid = this.vehicle.VehicleMake.id;
        this.DataService.addVehicleModel(this.vehicleModel).subscribe(results => {
          this.router.navigate(['/admin/'],{ relativeTo: this.route });
        });
    }
 

  }
  


} 