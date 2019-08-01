import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddComponent } from './add/add.component';
import { adminComponent } from './admin/admin.component';

const routes: Routes = [
  {
    path: 'admin',
    component: adminComponent,
    pathMatch: 'full'
  }, {
    path: 'add',
    component: AddComponent,
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
