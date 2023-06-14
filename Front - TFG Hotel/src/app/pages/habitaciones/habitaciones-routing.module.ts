import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HabitacionesComponent } from './habitaciones.component';
import { HabitacionIndividualComponent } from './habitacion-individual/habitacion-individual.component';
import { HabitacionEjecutivosComponent } from './habitacion-ejecutivos/habitacion-ejecutivos.component';
import { HabitacionParejasComponent } from './habitacion-parejas/habitacion-parejas.component';
import { HabitacionLujoComponent } from './habitacion-lujo/habitacion-lujo.component';
import { HabitacionParejasAzoteaComponent } from './habitacion-parejas-azotea/habitacion-parejas-azotea.component';

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
    // ! Esto es para obtener una habitacion por ID
    // TODO:    Una buena opción sería matar todos estos componentes y hacer uno llamado /habitaciones/:cadena-habitacion
    // {
    //     path: 'habitacion-para-parejas-en-azotea/:idHabitacion', component: HabitacionParejasAzoteaComponent
    // },
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
export class HabitacionesRoutingModule { }
