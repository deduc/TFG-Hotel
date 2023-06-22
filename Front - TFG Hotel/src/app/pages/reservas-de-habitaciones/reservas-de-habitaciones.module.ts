import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

// mis componentes
import { CajaReservarMedianteFechasComponent } from './components/caja-reservar-mediante-fechas/caja-reservar-mediante-fechas.component';

// mis servicios

// mis modulos
import { SharedModule } from 'src/app/shared/shared.module';
import { FormsModule } from '@angular/forms';

// Angular material
import { MatDialogModule } from '@angular/material/dialog';
import { ReservasDeHabitacionesService } from './reservas-de-habitaciones.service';
import { ReservasDeHabitacionesComponent } from './reservas-de-habitaciones.component';



@NgModule({
    declarations: [
        ReservasDeHabitacionesComponent,
        CajaReservarMedianteFechasComponent,
    ],
    imports: [
        CommonModule,
        FormsModule,
        SharedModule,
        MatDialogModule,
    ],
    exports: [],
    providers: [
        ReservasDeHabitacionesService
    ],
})
export class ReservasDeHabitacionesModule { }
