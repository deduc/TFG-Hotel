import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CLIENTES } from 'src/app/core/interfaces/CLIENTES.interface';
import { DATOS_HABITACIONES_TIPOS_FECHAS } from 'src/app/core/interfaces/DATOS_HABITACIONES_TIPOS_FECHAS.interface';
import { UsernameObjectDTO } from 'src/app/core/interfaces/UsernameObjectDTO.interface';
import { UsuariosDTO } from 'src/app/core/interfaces/UsuariosDTO.interface';

@Component({
  selector: 'app-reservas-habitaciones',
  templateUrl: './reservas-habitaciones.component.html',
  styleUrls: ['./reservas-habitaciones.component.css']
})
export class ReservasHabitacionesComponent implements OnInit{
    @Input() public datosUsuarioObj: UsuariosDTO;
    public datosCliente: CLIENTES;
    public misReservas: DATOS_HABITACIONES_TIPOS_FECHAS[];
    
    constructor(
        private http: HttpClient,
        private route: Router,
    )
    {}

    ngOnInit(): void {
        console.log(this.datosUsuarioObj);
        this.obtenerDatosClienteWithUsername();
    }

    public obtenerDatosClienteWithUsername(){
        const apiUrl: string = "https://localhost:7149/api/clientes/obtener-datos-cliente-by-username";
        const body: UsernameObjectDTO = {
            Username: this.datosUsuarioObj.USERNAME
        };

        this.http
        .post<CLIENTES>(apiUrl, body)
        .subscribe(
            res => {
                this.datosCliente = res;
                this.obtenerReservasDeHabitaciones();
            }
        );
    }

    public obtenerReservasDeHabitaciones(){
        const apiUrl = "https://localhost:7149/api/reservas-de-habitaciones/get-reservas-de-habitaciones-by-id-cliente?idCliente=" + this.datosCliente.ID_CLIENTE;
        
        this.http
        .get<DATOS_HABITACIONES_TIPOS_FECHAS[]>(apiUrl)
        .subscribe(
            async res => {
                this.misReservas = await res;
            }
        )
    }

    public cancelarReserva($idHabitacion){
        const apiUrl = "https://localhost:7149/api/reservas-de-habitaciones/cancelar-reserva-de-habitacion?idHabitacion="+$idHabitacion;

        console.log(apiUrl);
        
        this.http
        .get(apiUrl)
        .subscribe(
            res => {
                console.log(res);
                
            }
        );

        this.route.navigate(["/home"]);
        setTimeout(() => {
            this.route.navigate(["/mi-perfil"]);
        }, 1);
    }


    // fin clase
}
