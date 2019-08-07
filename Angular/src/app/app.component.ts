import { Component } from '@angular/core';
import { DataService } from './data.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Angular';
  search:string;
  constructor(private DataService:DataService){}

  searchVehicles(){
    if(this.search === "" || this.search === undefined){
        this.search = "null";
    }
      this.DataService.changeSearch(this.search);
  }
  submitted = false;
 
  onSubmit() { 
    
    this.submitted = true; 
  }
}
