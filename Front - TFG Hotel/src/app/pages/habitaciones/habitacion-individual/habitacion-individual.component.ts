import { Component, OnInit } from '@angular/core';
import { CardHabitacionInterface } from '../../../core/interfaces/card-habitacion.interface';
import { HabitacionesService } from '../habitaciones.service';
import { DatosDeHabitacionesDisponibles } from 'src/app/core/interfaces/datos-de-habitacion-disponible.interface';
import { BackendService } from '../../../backend/backend.service';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { API_GET_HABITACIONES_BY_ID, API_GET_TIPOS_DE_HABITACIONES, API_LINK, API_LINK_TIPOS_DE_HABITACIONES } from 'src/app/core/constantes';
import { ReservasService } from '../../reservas/reservas.service';


@Component({
    selector: 'app-habitacion-individual',
    templateUrl: './habitacion-individual.component.html',
    styleUrls: ['./habitacion-individual.component.css']
})
export class HabitacionIndividualComponent{
    public datosHabitacion: DatosDeHabitacionesDisponibles;

    constructor(
        private httpClient: HttpClient,
        private _backendService: BackendService,
        private _reservasService: ReservasService,
    )
    {
        let apiLink: string = "https://localhost:7149/api/tipos-de-habitaciones/listar-habitacion-por-id?id=1";
        let apiBody = {
            id: 1
        }

        this.httpClient
        .post<DatosDeHabitacionesDisponibles>(apiLink, apiBody)
        .subscribe(
            (resp) => {
                console.log(resp);
                this.datosHabitacion = resp;
            }
        );
    }

    // fin constructor
}
