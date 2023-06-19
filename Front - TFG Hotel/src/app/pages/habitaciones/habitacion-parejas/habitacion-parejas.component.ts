import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { BackendService } from 'src/app/backend/backend.service';
import { DatosDeHabitacionesDisponibles } from 'src/app/core/interfaces/datos-de-habitacion-disponible.interface';
import { ReservasService } from '../../reservas/reservas.service';

@Component({
  selector: 'app-habitacion-parejas',
  templateUrl: './habitacion-parejas.component.html',
  styleUrls: ['./habitacion-parejas.component.css']
})
export class HabitacionParejasComponent {
        public datosHabitacion: DatosDeHabitacionesDisponibles;

    constructor(
        private httpClient: HttpClient,
        private _backendService: BackendService,
        private _reservasService: ReservasService,
    )
    {
        let apiLink: string = "https://localhost:7149/api/tipos-de-habitaciones/listar-habitacion-por-id?id=3";
        let apiBody = {
            id: 3
        }

        this.httpClient
        .post<DatosDeHabitacionesDisponibles>(apiLink, apiBody)
        .subscribe(
            (resp) => {
                this.datosHabitacion = resp;
            }
        );
    }

}
