import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HabitacionesComponent } from '../habitaciones/habitaciones.component';
import { HabitacionIndividualComponent } from '../habitaciones/habitacion-individual/habitacion-individual.component';
import { HabitacionEjecutivosComponent } from '../habitaciones/habitacion-ejecutivos/habitacion-ejecutivos.component';
import { HabitacionParejasComponent } from '../habitaciones/habitacion-parejas/habitacion-parejas.component';
import { HabitacionParejasAzoteaComponent } from '../habitaciones/habitacion-parejas-azotea/habitacion-parejas-azotea.component';
import { HabitacionLujoComponent } from '../habitaciones/habitacion-lujo/habitacion-lujo.component';


const routes: Routes = [
    {
        path: '', component: HabitacionesComponent
    },
    {
        path: 'habitacion-individual', component: HabitacionIndividualComponent
    },
    {
        path: 'habitacion-ejecutiva', component: HabitacionEjecutivosComponent
    },
    {
        path: 'habitacion-para-parejas', component: HabitacionParejasComponent
    },
    {
        path: 'habitacion-para-parejas-en-azotea', component: HabitacionParejasAzoteaComponent
    },
    {
        path: 'habitacion-de-lujo', component: HabitacionLujoComponent
    },
    {
        path: '**', redirectTo: 'home'
    }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ReservasRoutingModule { }