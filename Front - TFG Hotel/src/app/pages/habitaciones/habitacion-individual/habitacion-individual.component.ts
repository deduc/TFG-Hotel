import { Component, OnInit } from '@angular/core';
import { DatosDeHabitacionDisponibleDTO } from '../../../core/interfaces/DatosDeHabitacionesDisponiblesDTO.interface';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-habitacion-individual',
  templateUrl: './habitacion-individual.component.html',
  styleUrls: ['./habitacion-individual.component.css']
})
export class HabitacionIndividualComponent implements OnInit {
    public datosHabitacion: DatosDeHabitacionDisponibleDTO = {
        idtipodehabitacion: 0,
        habitacionesdisponibles: 0,
        categoria: "",
        descripcion: "",
        imghabitacionbase64: "",
        precio: 0,
        tamano: 0
    };
    private idHabitacion = 1;
    
    private urlApi: string = "https://localhost:7149/api/tipos-de-habitaciones/listar-habitacion-por-id";
    private body = {IdHabitacion: this.idHabitacion};

    
    constructor(
        private httpClient: HttpClient
    ){
        
    }

    ngOnInit(): void {
        this.httpClient
        .post<DatosDeHabitacionDisponibleDTO>(this.urlApi, this.body)
        .subscribe(
            (response) => {
                this.datosHabitacion = response;
                console.log(this.datosHabitacion);
            }
        );
    }
}
