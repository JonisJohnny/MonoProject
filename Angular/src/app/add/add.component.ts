import { Component, OnInit } from '@angular/core';
import { vehiclemake } from './classvehiclemake';
import { vehiclemodel } from './classvehiclemodel';
import { DataService } from '../data.service';
import { Router,ActivatedRoute } from '@angular/router';
import { VehicleMakeModel, VehicleMakeResponse } from '../admin/vehiclemakeinterface';


@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {
vehiclemake = vehiclemake;
VehicleMakeArray: VehicleMakeModel[];
results;

 
constructor(private dataService: DataService,private route: ActivatedRoute,private router: Router) { }

ngOnInit() {
 this.getVehicles();
}

getVehicles(): void {
  this.dataService.listVehicleMake(null,50,0,null)
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

 public show:boolean = true;
  toggle() {
    if(this.VehicleMake.id == "00000000-0000-0000-0000-000000000000"){
      this.show = true;
    }else{
      this.show = false;
    }
  }




  VehicleMake = new vehiclemake("00000000-0000-0000-0000-000000000000",'What brand is it?', 'What is thier slogan?');
  VehicleModel = new vehiclemodel("00000000-0000-0000-0000-000000000000","00000000-0000-0000-0000-000000000000",'What model?','What color does the car have?');
 
  submitted = false;
 
  onSubmit() { 
    
    this.submitted = true; 
  }
 
  newCar() {  
    
    if(this.VehicleMake.id != "00000000-0000-0000-0000-000000000000"){
      this.VehicleModel.makeid = this.VehicleMake.id;
    }
    //alert(JSON.stringify(this.VehicleMake)+" "+JSON.stringify(this.VehicleModel));
 
    this.dataService.addVehicleMake(this.VehicleMake).subscribe((results) => {
      this.results = results;
      
    });    
    this.dataService.addVehicleModel(this.VehicleModel).subscribe((results) => {
      this.results = results;
      this.router.navigate(['/admin/'],{ relativeTo: this.route });
      
    });
  }
  


} 