import { Component } from '@angular/core';

// mis servicios
import { ReservasService } from './reservas.service';

// mis interfaces
import { FechaInicioFinInterface } from 'src/app/core/interfaces/fecha-inicio-fin.interface';
import { DatosDeHabitacionesDisponibles } from 'src/app/core/interfaces/datos-de-habitacion-disponible.interface';

// componentes especiales
import { HttpClient } from '@angular/common/http';

// angular material
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { DialogElement } from './components/dialog-element-angular-material/dialog-element-angular-material.component';
import { BackendService } from '../../backend/backend.service';
import { Observable } from 'rxjs';



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

    /** Atributo que sirve para evaluar si el usuario ha buscado en algun momento habitaciones */
    public fechasBuscadas: boolean = false;
    /** Atributo que sirve para evaluar si el usuario ha encontrado habitaciones disponibles */
    public fechasEncontradas: boolean = false;
    /** Indicador boolean de si el usuario tiene la sesión iniciada o no. */
    public isUserLogged: Observable<boolean> | boolean = false;


    public constructor
    (
        /** Servicio reservas que comunica este componente con backend.service */
        private _reservasService:ReservasService,

        /** BackendService */
        private _backendService: BackendService,

        /** Hacedor de llamadas http a urls */
        private httpClient: HttpClient,
        
        // Componente de angular material
        public dialog: MatDialog
    )
    {
        // Inicializo el objeto fechas a fechas del día de hoy
        this.objFechas = {
            fechaInicio: new Date(), 
            fechaFin: new Date()
        };
        
        this.comprobarLogin();
        
        this.suscribirObjFechas();
        // this.obtenerListaHabitaciones();
    }

    private comprobarLogin() {
        this.isUserLogged = this._backendService.comprobarLogin();
    }


    /**
     * Método que comunica this.objFechas con ReservasService.objFechas,
     * el valor de objFechas que emita ReservasService se asignará en
     * this.objFechas
     */
    private suscribirObjFechas(){
        this._reservasService.objFechas.subscribe(serviceObjFechas => this.objFechas = serviceObjFechas);
    }

    public buscarHabitacionesEntreFechas(fechas: FechaInicioFinInterface): void{
        console.log("Objeto fechas emitido y recibido en reservas.component.ts", fechas, "procedo a traer datos de la API.");
        // this.formatearObjFechas();
        
        
        sessionStorage.setItem(
            "obj-fechas", 
            JSON.stringify(this.objFechas)
        );
        
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

    private formatearObjFechas(): void{
        this.objFechas.fechaInicio.setHours(0);
        this.objFechas.fechaInicio.setMinutes(0);
        this.objFechas.fechaInicio.setSeconds(0);
        this.objFechas.fechaInicio.setMilliseconds(0);
        
        this.objFechas.fechaFin.setHours(0);
        this.objFechas.fechaFin.setMinutes(0);
        this.objFechas.fechaFin.setSeconds(0);
        this.objFechas.fechaFin.setMilliseconds(0);
    }

    public lala($event): void {
        console.log($event);
        
    }

    openDialog(): void {
        this.dialog.open(DialogElement);
    }
    

    // fin clase
}

