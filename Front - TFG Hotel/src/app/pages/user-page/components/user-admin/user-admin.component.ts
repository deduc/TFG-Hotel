import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SESSION_STORAGE_USER_LOGGED } from 'src/app/core/constantes';
import { DATOS_HABITACIONES_TIPOS_FECHAS } from 'src/app/core/interfaces/DATOS_HABITACIONES_TIPOS_FECHAS.interface';
import { DATOS_RESERVAS_DE_SERVICIOS_Y_CLIENTES } from 'src/app/core/interfaces/DATOS_RESERVAS_DE_SERVICIOS_Y_CLIENTES.interface';
import { RESERVAS_DE_SERVICIOS } from 'src/app/core/interfaces/RESERVAS_DE_SERVICIOS.interface';
import { ReservasDeHabitacionesDTO } from 'src/app/core/interfaces/ReservasDeHabitacionesDTO.interface';
import { UserEmailObjectDTO } from 'src/app/core/interfaces/UserEmailObjectDTO.interface';
import { UsuariosDTO } from 'src/app/core/interfaces/UsuariosDTO.interface';
import { UserLoggedInterface } from 'src/app/core/interfaces/user-logged.interface';

@Component({
    selector: 'app-user-admin',
    templateUrl: 'user-admin.component.html',
    styles: [
        ".mi-contenedor{ display:flex; flex-direction: row; gap: 150px;}"
    ]
})

export class UserAdminComponent implements OnInit {
    @Input() public datosUsuarioObj: UsuariosDTO;
    public isUserAdmin: boolean = false;
    public misReservasHabitaciones: ReservasDeHabitacionesDTO[];
    public misReservasServicios: RESERVAS_DE_SERVICIOS[];

    constructor(
        private http: HttpClient,
        private route: Router,
    ) { }

    ngOnInit(): void {
        console.log(this.datosUsuarioObj);
        this.obtenerReservasDeHabitaciones();
        this.obtenerReservasDeServicios();
        this.comprobarSiUsuarioEsAdmin();
    }

    public comprobarSiUsuarioEsAdmin(){
        let body: UserEmailObjectDTO;

        let objUsuario: UserLoggedInterface = JSON.parse(
            sessionStorage.getItem(SESSION_STORAGE_USER_LOGGED)
        );

        body = {
            Email: objUsuario.Email
        };

        const url = "https://localhost:7149/api/usuarios/comprobar-si-usuario-administrador";
        
        this.http
        .post(url, body)
        .subscribe(
            async res => {
                console.log(await res);
                
                if(await res == true){
                    this.isUserAdmin = await true;
                }
            }
        )
    }

    public obtenerReservasDeHabitaciones(){
        const apiUrl = "https://localhost:7149/api/reservas-de-habitaciones/listar-reservas";
        
        this.http
        .get<ReservasDeHabitacionesDTO[]>(apiUrl)
        .subscribe(
            async res => {
                console.log(res);
                
                this.misReservasHabitaciones = await res;
            }
        )
    }

    public cancelarReservaHabitacion($idHabitacion){
        const apiUrl = "https://localhost:7149/api/reservas-de-habitaciones/cancelar-reserva-de-habitacion?idHabitacion="+$idHabitacion;

        console.log(apiUrl);
        
        this.http
        .get<ReservasDeHabitacionesDTO[]>(apiUrl)
        .subscribe(
            async res => {
                console.log(res);
                this.misReservasHabitaciones = await res;
            }
        );

        this.route.navigate(["/home"]);
        setTimeout(() => {
            this.route.navigate(["/mi-perfil"]);
        }, 1);
    }



    public obtenerReservasDeServicios(){
        const apiUrl = "https://localhost:7149/api/reservas-de-servicios/listar-reservas-de-servicios";
        
        this.http
        .get<RESERVAS_DE_SERVICIOS[]>(apiUrl)
        .subscribe(
            async res => {
                console.log(res);
                this.misReservasServicios = await res;                
            }
        )
    }

    public cancelarReservaServicio($idReservaServicio){
        console.log($idReservaServicio);
        const apiUrl = "https://localhost:7149/api/reservas-de-servicios/cancelar-reserva-de-servicio?idReservaServicio=" + $idReservaServicio;

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