import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { BackendService } from 'src/app/backend/backend.service';
import { DATOS_DE_HABITACIONES_DISPONIBLES } from 'src/app/core/interfaces/datos-de-habitacion-disponible.interface';
import { ReservasService } from '../../reservas/reservas.service';


@Component({
  selector: 'app-habitacion-lujo',
  templateUrl: './habitacion-lujo.component.html',
  styleUrls: ['./habitacion-lujo.component.css']
})
export class HabitacionLujoComponent {
    public datosHabitacion: DATOS_DE_HABITACIONES_DISPONIBLES;

    constructor(
        private httpClient: HttpClient,
        private _backendService: BackendService,
        private _reservasService: ReservasService,
    )
    {
        let apiLink: string = "https://localhost:7149/api/tipos-de-habitaciones/listar-habitacion-por-id?id=5";
        let apiBody = {
            id: 5
        }

        this.httpClient
        .post<DATOS_DE_HABITACIONES_DISPONIBLES>(apiLink, apiBody)
        .subscribe(
            (resp) => {
                if(resp.id_tipo_de_habitacion == 0){
                    let apiLink2: string = "https://localhost:7149/api/tipos-de-habitaciones/listar-habitacion-por-id?id=5";
                    let apiBody2 = {
                        id: 5
                    }
                    this.httpClient
                    .post<DATOS_DE_HABITACIONES_DISPONIBLES>(apiLink2, apiBody2)
                    .subscribe()
                }
                else{
                    this.datosHabitacion = resp;
                }
            }
        );
    }
}
