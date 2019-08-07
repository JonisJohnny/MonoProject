import { Component, OnInit } from '@angular/core';
import { VehicleMake } from './class.vehicle-make';
import { VehicleModel } from './class.vehicle-model';
import { Vehicle } from './class.vehicle';
import { DataService } from '../data.service';
import { Router,ActivatedRoute } from '@angular/router';
import { VehicleMakeModel, VehicleMakeResponse } from '../admin/interface.vehicle-make';


@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {

VehicleMakeArray: VehicleMakeModel[];

VehicleMake = new VehicleMake("00000000-0000-0000-0000-000000000000",'What brand is it?', 'What is thier slogan?');
VehicleModel = new VehicleModel("00000000-0000-0000-0000-000000000000","00000000-0000-0000-0000-000000000000",'What model?','What color does the car have?');
Vehicle = new Vehicle(this.VehicleMake,this.VehicleModel);
results;
public show:boolean = true;
 
constructor(private DataService: DataService,private route: ActivatedRoute,private router: Router) { }

ngOnInit() {
 this.getVehicles();
}

getVehicles(): void {
  this.DataService.listVehicleMake(null,50,0,null)
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

 
  toggle() {
    if(this.Vehicle.VehicleMake.id === "00000000-0000-0000-0000-000000000000"){
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
    if(this.Vehicle.VehicleMake.id === "00000000-0000-0000-0000-000000000000"){
        this.DataService.addVehicle(this.Vehicle).subscribe((results) => {
          this.results = results;
          this.router.navigate(['/admin/'],{ relativeTo: this.route });
        });   
    }else{
        this.VehicleModel.makeid = this.Vehicle.VehicleMake.id;
        this.DataService.addVehicleModel(this.VehicleModel).subscribe((results) => {
          this.results = results;
          this.router.navigate(['/admin/'],{ relativeTo: this.route });
        });  
    }
 

  }
  


} 