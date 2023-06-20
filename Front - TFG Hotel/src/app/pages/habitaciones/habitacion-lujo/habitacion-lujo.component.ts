import { Component, OnInit } from '@angular/core';
import { DatosDeHabitacionDisponibleDTO } from '../../../core/interfaces/DatosDeHabitacionesDisponiblesDTO.interface';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-habitacion-lujo',
  templateUrl: './habitacion-lujo.component.html',
  styleUrls: ['./habitacion-lujo.component.css']
})
export class HabitacionLujoComponent implements OnInit {
    public datosHabitacion: DatosDeHabitacionDisponibleDTO = {
        idtipodehabitacion: 0,
        habitacionesdisponibles: 0,
        categoria: "",
        descripcion: "",
        imghabitacionbase64: "",
        precio: 0,
        tamano: 0
    };
    private IdHabitacion = 5;
    
    private urlApi: string = "https://localhost:7149/api/tipos-de-habitaciones/listar-habitacion-por-id";
    private body = {IdHabitacion: this.IdHabitacion};

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
