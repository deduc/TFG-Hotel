import { NgModule } from '@angular/core';
import { UserPageComponent } from './user-page.component';
import { CommonModule } from '@angular/common';
import { ReservasHabitacionesComponent } from './components/reservas-habitaciones/reservas-habitaciones.component';
import { ReservasServiciosComponent } from './components/reservas-servicios/reservas-servicios.component';
import { FormsModule } from '@angular/forms';


@NgModule({
    declarations: [
        UserPageComponent,
        ReservasHabitacionesComponent,
        ReservasServiciosComponent,
    ],
    imports: [
        CommonModule,
        FormsModule,
    ],
})
export class UserPageModule { }
