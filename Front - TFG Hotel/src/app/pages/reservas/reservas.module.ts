import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

// mis componentes
import { CajaReservarMedianteFechasComponent } from './components/caja-reservar-mediante-fechas/caja-reservar-mediante-fechas.component';
import { ReservasComponent } from './reservas.component';

// mis servicios
import { ReservasService } from './reservas.service';

// mis modulos
import { SharedModule } from 'src/app/shared/shared.module';
import { FormsModule } from '@angular/forms';


@NgModule({
    declarations: [
        ReservasComponent,
        CajaReservarMedianteFechasComponent,
    ],
    imports: [
        CommonModule,
        FormsModule,
        SharedModule,
    ],
    exports: [],
    providers: [
        ReservasService
    ],
})
export class ReservasModule { }
