import { Component } from '@angular/core';
import { ReservasService } from './reservas.service';
import { FechaInicioFinInterface } from 'src/app/core/interfaces/fecha-inicio-fin.interface';
import { HttpClient } from '@angular/common/http';
import { DatosDeHabitacionesDisponibles } from 'src/app/core/interfaces/datos-de-habitacion-disponible.interface';


@Component({
    selector: 'pages-reservas',
    templateUrl: './reservas.component.html',
    styles: ["@media (min-width: 993px) {.card-imagen{height: 40vh;}}"]
})
export class ReservasComponent {
    /** Objeto que almacena las fecha de inicio y fin del formulario */
    public objFechas: FechaInicioFinInterface;
    
    /** Lista de las habitaciones disponibles. Es variable. */
    public listaTiposDeHabitaciones: DatosDeHabitacionesDisponibles[] = [];


    public constructor
    (
        /** Servicio reservas que comunica este componente con backend.service */
        private _reservasService:ReservasService,

        /** Hacedor de llamadas http a urls */
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
    private async obtenerListaHabitaciones(): Promise<void> {
        const apiUrl: string = "https://localhost:7149/api/tipos-de-habitaciones/listar-tipos-de-habitaciones";
        
        this.httpClient
        .get<DatosDeHabitacionesDisponibles[]>(apiUrl)
        .subscribe(
            async resp => {
                this.listaTiposDeHabitaciones = [];
                this.listaTiposDeHabitaciones = await resp;
                
                await console.log("Lista de habitaciones:", this.listaTiposDeHabitaciones);
            }
        );
    }
    
      

    public buscarHabitacionesEntreFechas(fechas: FechaInicioFinInterface): void{
        console.log("Objeto fechas emitido y recibido en reservas.component.ts", fechas, "procedo a traer datos de la API.");
        
        const url: string = "https://localhost:7149/api/habitaciones-disponibles/obtener-habitaciones-disponibles-entre-fechas";
        const body: FechaInicioFinInterface = this.objFechas;

        this.httpClient
        .post<DatosDeHabitacionesDisponibles[]>(url, body)
        .subscribe(
            async resp => {
                this.listaTiposDeHabitaciones = [];
                this.listaTiposDeHabitaciones = await resp;
                
                await console.log("Lista de habitaciones disponibles entre fechas:", this.listaTiposDeHabitaciones);
            }
        );
        
        // fin metodo
    }
    // fin clase
}