import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HabitacionIndividualComponent } from './habitacion-individual/habitacion-individual.component';
import { HabitacionEjecutivosComponent } from './habitacion-ejecutivos/habitacion-ejecutivos.component';
import { HabitacionParejasComponent } from './habitacion-parejas/habitacion-parejas.component';
import { HabitacionLujoComponent } from './habitacion-lujo/habitacion-lujo.component';

import { HabitacionesRoutingModule } from './habitaciones-routing.module';
import { HabitacionParejasAzoteaComponent } from './habitacion-parejas-azotea/habitacion-parejas-azotea.component';

// mis servicios
import { HabitacionesService } from './habitaciones.service';


@NgModule({
  declarations: [
    HabitacionIndividualComponent,
    HabitacionEjecutivosComponent,
    HabitacionParejasComponent,
    HabitacionLujoComponent,
    HabitacionParejasAzoteaComponent
  ],
  imports: [
    CommonModule,
    HabitacionesRoutingModule,
  ],
  providers: [
      HabitacionesService
  ]
})
export class HabitacionesModule { }
