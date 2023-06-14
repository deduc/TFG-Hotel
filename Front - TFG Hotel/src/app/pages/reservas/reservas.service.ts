import { Injectable } from '@angular/core';
// Esto es para comunicar componentes con los datos del servicio
import { BehaviorSubject } from 'rxjs';

// mis servicios
import { BackendService } from 'src/app/backend/backend.service';

// mis interfaces
import { CardHabitacionInterface } from 'src/app/core/interfaces/card-habitacion.interface';
import { FechaInicioFinInterface } from 'src/app/core/interfaces/fecha-inicio-fin.interface';


@Injectable({providedIn: 'root'})
export class ReservasService {

    public objFechas = new BehaviorSubject<FechaInicioFinInterface>(
        {fechaInicio: new Date, fechaFin: new Date}
    );
    objFechas$ = this.objFechas.asObservable();

    public listaTiposDeHabitaciones: BehaviorSubject<CardHabitacionInterface[]> = new BehaviorSubject<CardHabitacionInterface[]>(
        [   // ! BORRAR mas adelante, ESTO ES UNA PRUEBA, deja solo los corchetes del array!!!
            // * Añado datos de prueba a mi lista de habitaciones y hago que sea un observable
            { categoria: "categoria1", descripcion: "descripcion1", tamaño: 10, imgHabitacionBase64: "imgHabitacionBase64_1", precio: 100, cantidadDeHabitacionesDisponibles: 10 },
            { categoria: "categoria2", descripcion: "descripcion2", tamaño: 15, imgHabitacionBase64: "imgHabitacionBase64_2", precio: 200, cantidadDeHabitacionesDisponibles: 20 },
            { categoria: "categoria3", descripcion: "descripcion3", tamaño: 20, imgHabitacionBase64: "imgHabitacionBase64_3", precio: 300, cantidadDeHabitacionesDisponibles: 30 },
        ]);
    listaTiposDeHabitaciones$ = this.listaTiposDeHabitaciones.asObservable();

    private _backendService: BackendService;


    constructor(backendService: BackendService) { 
        this._backendService = backendService;

        // TODO:    HAZ ESTE METODO EN EL BACK
        // !!   Cuando se cargue el componente, cargar la lista de las habitaciones que están disponibles hoy
        // this.listaTiposDeHabitaciones = this._backendService.obtenerHabitacionesDisponibles();
    }


    /**
     * Método invocado por otro componente. Recibe por parámetros
     * un objeto CardHabitacionInterface, lo asigna al atributo 
     * this.listaTiposDeHabitaciones y lo emite a las otras clases 
     * que estén suscritas a this.listaTiposDeHabitaciones.
     */
    public setListaTiposDeHabitaciones(listaTiposDeHabitaciones: CardHabitacionInterface[]){
        this.listaTiposDeHabitaciones.next(listaTiposDeHabitaciones);
        console.log(this.listaTiposDeHabitaciones);
    }
    
    /**
     * Método invocado por otro componente. Recibe por parámetros
     * un objeto FechaInicioFinInterface, lo asigna al atributo 
     * this.objFechas y lo emite a las otras clases que estén 
     * suscritas a this.objFechas.
     */
    public setObjFechasData(objFechas: FechaInicioFinInterface): void {
        // console.log("El servicio ReservasService ha recibido los datos del formulario: ");
        // console.log(objFechas);
        
        // Envío el objFechas a los atributos de otras clases que estén suscritas a este atributo.
        this.objFechas.next(objFechas);
        console.log(this.objFechas);
        
        // TODO:
        // this.setListaHabitacionesDisponiblesEntreFechas(objFechas);
    }

    public setListaHabitacionesDisponiblesEntreFechas(objFechas: FechaInicioFinInterface){
        // TODO: obtener de la API las habitaciones no reservadas entre fecha inicio y fecha fin
        this._backendService.obtenerListaHabitacionesDisponiblesEntreFechas(objFechas);

    }
}
