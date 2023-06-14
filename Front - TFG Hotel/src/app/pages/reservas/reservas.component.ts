import { Component } from '@angular/core';
import { ReservasService } from './reservas.service';
import { FechaInicioFinInterface } from 'src/app/core/interfaces/fecha-inicio-fin.interface';
import { CardHabitacionInterface } from 'src/app/core/interfaces/card-habitacion.interface';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';



@Component({
    selector: 'pages-reservas',
    templateUrl: './reservas.component.html',
    styles: ["@media (min-width: 993px) {.card-imagen{height: 40vh;}}"]
})
export class ReservasComponent {
    /** Objeto que almacena las fecha de inicio y fin del formulario */
    public objFechas: FechaInicioFinInterface;
    /** Lista de las habitaciones disponibles. Es variable. */
    public listaTiposDeHabitaciones: CardHabitacionInterface[] | any;


    public constructor
    (
        /** Servicio reservas que comunica este componente con backend.service */
        private _reservasService:ReservasService,
        private httpClient: HttpClient,
    )
    {
        // Inicializo el objeto fechas a fechas del día de hoy
        this.objFechas = {
            fechaInicio: new Date(), 
            fechaFin: new Date()
        };
        
        this.suscribirObjFechas();
        this.obtenerListaHabitaciones();
        
        console.log(this.listaTiposDeHabitaciones);
        // this.listaHabitacionesDisponibles = null;
    }

    /**
     * Método que comunica this.objFechas con ReservasService.objFechas,
     * el valor de objFechas que emita ReservasService se asignará en
     * this.objFechas
     */
    private suscribirObjFechas(){
        this._reservasService.objFechas.subscribe(serviceObjFechas => this.objFechas = serviceObjFechas);
    }

    /**
     * Método que comunica this.objFechas con ReservasService.objFechas,
     * el valor de objFechas que emita ReservasService se asignará en
     * this.objFechas
     */
    private obtenerListaHabitaciones(){
        this._reservasService.listaTiposDeHabitaciones
        .subscribe(lista => this.listaTiposDeHabitaciones = lista);

        const apiUrl: string = "https://localhost:7149/api/tipos-de-habitaciones/listar-tipos-de-habitaciones";
        this.httpClient
        .get(apiUrl)
        .subscribe(
            (resp) => {
                console.log(resp);
                this.listaTiposDeHabitaciones = resp;
            }
        );
    }


    // fin clase
}