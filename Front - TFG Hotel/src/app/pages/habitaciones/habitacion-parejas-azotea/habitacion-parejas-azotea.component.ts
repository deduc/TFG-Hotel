import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { BackendService } from 'src/app/backend/backend.service';
import { DATOS_DE_HABITACIONES_DISPONIBLES } from 'src/app/core/interfaces/datos-de-habitacion-disponible.interface';
import { ReservasService } from '../../reservas/reservas.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-habitacion-parejas-azotea',
  templateUrl: './habitacion-parejas-azotea.component.html',
  styleUrls: ['./habitacion-parejas-azotea.component.css']
})
export class HabitacionParejasAzoteaComponent {
    public datosHabitacion: DATOS_DE_HABITACIONES_DISPONIBLES;

    constructor(
        private httpClient: HttpClient,
        private _backendService: BackendService,
        private _reservasService: ReservasService,
        public _route: ActivatedRoute
    )
    {
        let apiLink: string = "https://localhost:7149/api/tipos-de-habitaciones/listar-habitacion-por-id?id=4";
        let apiBody = {
            id: 4
        }
        this._route.params.subscribe(params => {
            let idHab =params['idHabitacion'];
            debugger
         });
        this.httpClient
        .post<DATOS_DE_HABITACIONES_DISPONIBLES>(apiLink, apiBody)
        .subscribe(
            (resp) => {
                this.datosHabitacion = resp;
            }
        );
    }
}
