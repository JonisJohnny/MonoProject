import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FetchComponent } from './fetch/fetch.component';
import { AddComponent } from './add/add.component';

const routes: Routes = [
  {
    path: 'fetch',
    component: FetchComponent,
    pathMatch: 'full'
  },  {
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
