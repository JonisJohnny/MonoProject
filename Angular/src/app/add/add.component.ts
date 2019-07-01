import { Component, OnInit } from '@angular/core';
import { cars } from './cars';
import { DataService } from '../data.service';
import { Router,ActivatedRoute } from '@angular/router';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {
cars = cars;
brandc: Object;
results;
br;

 
constructor(private dataService: DataService,private route: ActivatedRoute,private router: Router) { }

ngOnInit() {
  this.brandc = this.dataService.GetMakes(null,10,0).subscribe((brandc) => {this.brandc = brandc;});
  

}


 public show:boolean = true;
  toggle() {
   
    if(this.car.make_id == -1){
      this.show = true;
    }else{
      this.show = false;
    }
  }




  car = new cars(-1,'What brand is it?', 'What is thier slogan?',0,0,'What model?','What color does the car have?');
 
  submitted = false;
 
  onSubmit() { 
    
    this.submitted = true; 
  }
 
  newCar() {  
 
    this.dataService.addCar(this.car).subscribe((results) => {
      this.results = results;
      this.router.navigate(['/fetch/'],{ relativeTo: this.route });
      
    });
  }
  


} 
