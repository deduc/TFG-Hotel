import { Component, OnInit } from "@angular/core";

import { UserLoggedInterface } from 'src/app/core/interfaces/user-logged.interface';
import { HttpClient } from '@angular/common/http';
import { UsuariosDTO } from 'src/app/core/interfaces/UsuariosDTO.interface';
import { UserEmailObjectDTO } from 'src/app/core/interfaces/UserEmailObjectDTO.interface';
import { BackendService } from "src/app/backend/backend.service";


@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.css']
})
export class UserPageComponent {
    public userLogged: UserLoggedInterface;
    public datosUsuario: UsuariosDTO;
    
    private userLoggedSessionStorageKey: string = "user_logged";

    constructor(
        private _backendService: BackendService,
        private httpClient: HttpClient,
    ) 
    { 
        if(sessionStorage.getItem(this.userLoggedSessionStorageKey)){
            this.userLogged = JSON.parse(
                sessionStorage.getItem(this.userLoggedSessionStorageKey)
            );

            // this._backendService.comprobarSiLoginCorrecto(this.userLogged);
        }
    }

    ngOnInit() { 
        this.obtenerDatosUsuario();
        this.obtenerReservasDeHabitaciones();
        this.obtenerReservasDeServicios();
    }

    private obtenerDatosUsuario(){
        const apiUrl: string = "https://localhost:7149/api/usuarios/obtener-datos-de-usuario";
        const userEmail: UserEmailObjectDTO = { Email: this.userLogged.Email};
        this.httpClient
        .post<UsuariosDTO>(apiUrl, userEmail)
        .subscribe(
            async res => {
                // TODO: sin hacer todavia
                await console.log(res);
                this.datosUsuario = await res;
            }
        )
    }

    public obtenerReservasDeHabitaciones(){
        // TODO: HACER ESTO UNA VEZ EL USUARIO PUEDA HACER RESERVAS
        // const apiUrl: string = "";
        // const body: { USERNAME: string = this.datosUsuario.USERNAME}
        
        // this.httpClient
        // .get<>(apiUrl)
        // .subscribe();
    }

    public obtenerReservasDeServicios(){
        // TODO: HACER ESTO UNA VEZ EL USUARIO PUEDA HACER RESERVAS
        // const apiUrl: string = "";
        // const body: { USERNAME: string = this.datosUsuario.USERNAME}
        
        // this.httpClient
        // .get<>(apiUrl)
        // .subscribe();
    }


}
