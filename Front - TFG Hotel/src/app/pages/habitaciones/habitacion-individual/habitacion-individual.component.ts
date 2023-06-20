import { Component, OnInit } from '@angular/core';
import { DatosDeHabitacionDisponibleDTO } from '../../../core/interfaces/DatosDeHabitacionesDisponiblesDTO.interface';
import { HttpClient } from '@angular/common/http';
import { FechaInicioFinInterface } from 'src/app/core/interfaces/fecha-inicio-fin.interface';
import { MezclaDeObjetoFechasYObjetoIdTipoHabitacion } from 'src/app/core/interfaces/MezclaDeObjetoFechasYObjetoIdTipoHabitacion.interface';
import { FechaInicioFinDTO } from 'src/app/core/interfaces/FechaInicioFinDTO.interface';
import { IdTipoHabitacionDTO } from 'src/app/core/interfaces/IdTipoHabitacionDTO.interface';
import { DatosYCantidadDeHabitacionesDisponiblesEntreFechasDTO } from 'src/app/core/interfaces/DatosYCantidadDeHabitacionesDisponiblesEntreFechasDTO.interface';

@Component({
  selector: 'app-habitacion-individual',
  templateUrl: './habitacion-individual.component.html',
  styleUrls: ['./habitacion-individual.component.css']
})
export class HabitacionIndividualComponent implements OnInit {
    public datosHabitacion: DatosYCantidadDeHabitacionesDisponiblesEntreFechasDTO = {
        id_tipo_de_habitacion: 0,
        habitaciones_disponibles: 0,
        categoria: "",
        descripcion: "",
        img_habitacion_base_64: "",
        precio: 0,
        tamaño: 0,
        enlace_url: ""
    };
    private idHabitacion: number = 1;
    private objFechas: FechaInicioFinInterface;
    private objFechasKey: string = "obj-fechas";

    // private urlApi: string = "https://localhost:7149/api/tipos-de-habitaciones/listar-habitacion-por-id";
    private urlApi: string = "https://localhost:7149/api/habitaciones-disponibles/obtener-datos-de-habitacion-disponible-entre-fechas";


    constructor(
        private httpClient: HttpClient
    ){
        if(sessionStorage.getItem(this.objFechasKey)){
            console.log("Hay objeto fechas, procedo a buscar las habitaciones disponibles entre la fecha de inicio y fin.");
            this.objFechas = JSON.parse(
                sessionStorage.getItem(this.objFechasKey)
            );
        }
    }

    ngOnInit(): void {
        const body: MezclaDeObjetoFechasYObjetoIdTipoHabitacion = this.crearBodyLlamadaHttp();

        this.httpClient
        .post<DatosYCantidadDeHabitacionesDisponiblesEntreFechasDTO>(this.urlApi, body)
        .subscribe(
            (response) => {
                console.log(response);
                console.log("azaaaaaaaaaaaaaaa");
                
                
                this.datosHabitacion = response;
                console.log(this.datosHabitacion);
                
            }
        );
    }

    private crearBodyLlamadaHttp(): MezclaDeObjetoFechasYObjetoIdTipoHabitacion {
        // Creo objeto que almacena fechas y equivale a un objetoDTO de la API
        const objFechas: FechaInicioFinDTO = {
            FechaInicio: this.objFechas.fechaInicio,
            FechaFin: this.objFechas.fechaFin
        }
        
        // Creo un objeto que almacena un ID y equivale a un objetoDTO de la API
        const objIdTipoHabitacionDTO: IdTipoHabitacionDTO = {
            idTipoHabitacion: this.idHabitacion
        }
        
        /**
         * Creo un objeto que contiene los 2 objetos anteriores y equivale a un objetoDTO de la API,
         * y será el cuerpo|body de la peticion http
         */
        const body: MezclaDeObjetoFechasYObjetoIdTipoHabitacion = {
            objFechasDto: objFechas,
            idTipoHabitacion: objIdTipoHabitacionDTO
        }

        return body;
    }
}
