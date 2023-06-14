import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { BackendService } from 'src/app/backend/backend.service';
import { DATOS_DE_HABITACIONES_DISPONIBLES } from 'src/app/core/interfaces/datos-de-habitacion-disponible.interface';
import { ReservasService } from '../../reservas/reservas.service';

@Component({
  selector: 'app-habitacion-ejecutivos',
  templateUrl: './habitacion-ejecutivos.component.html',
  styleUrls: ['./habitacion-ejecutivos.component.css']
})
export class HabitacionEjecutivosComponent {
    public datosHabitacion: DATOS_DE_HABITACIONES_DISPONIBLES;

    constructor(
        private httpClient: HttpClient,
        private _backendService: BackendService,
        private _reservasService: ReservasService,
    )
    {
        let apiLink: string = "https://localhost:7149/api/tipos-de-habitaciones/listar-habitacion-por-id?id=2";
        let apiBody = {
            id: 2
        }

        this.httpClient
        .post<DATOS_DE_HABITACIONES_DISPONIBLES>(apiLink, apiBody)
        .subscribe(
            (resp) => {
                this.datosHabitacion = resp;
            }
        );
    }

    // fin clase
}