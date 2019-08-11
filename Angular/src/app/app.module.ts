import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AdminMainComponent } from './admin/admin-main.component';
import { AdminVehicleMakeComponent } from './admin/admin-vehicle-make/admin-vehicle-make.component';
import { AdminVehicleModelComponent } from './admin/admin-vehicle-model/admin-vehicle-model.component';
import { AddComponent } from './add/add.component';
import { FormsModule }   from '@angular/forms';
import { MatInputModule, MatPaginatorModule, MatProgressSpinnerModule, MatSortModule, MatTableModule } from "@angular/material";
import { MatRadioModule } from '@angular/material/radio';





@NgModule({
  declarations: [
    AppComponent,
    AdminMainComponent,
    AdminVehicleMakeComponent,
    AdminVehicleModelComponent,
    AddComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    MatTableModule,
    MatInputModule,
    MatPaginatorModule,
    MatSortModule,
    MatProgressSpinnerModule,
    MatRadioModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { 

}
