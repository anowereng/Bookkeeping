import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ReconciliationPageComponent } from './reconciliation-page/reconciliation-page.component';

const routes: Routes = [
  { path: '', component: ReconciliationPageComponent },
  { path: 'recouncilition', component: ReconciliationPageComponent },
  { path: '**', component: ReconciliationPageComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
