import { Component } from "@angular/core";

import { UserLoggedInterface } from 'src/app/core/interfaces/user-logged.interface';
import { HttpClient } from '@angular/common/http';
import { UsuariosDTO } from 'src/app/core/interfaces/UsuariosDTO.interface';
import { UserEmailObjectDTO } from 'src/app/core/interfaces/UserEmailObjectDTO.interface';
import { BackendService } from "src/app/backend/backend.service";
import { CommonModule } from '@angular/common';
import { DoChangeUserPasswordDTO } from "src/app/core/interfaces/DoChangeUserPasswordDTO.interface";
import { MatDialog } from "@angular/material/dialog";
import { DialogElement } from "./components/dialog-element-angular-material/dialog-element-angular-material.component";


@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.css'],
//   standalone: true,
//   imports: [ CommonModule ]
})
export class UserPageComponent {
    public userLogged: UserLoggedInterface;
    public datosUsuarioObj: UsuariosDTO;
    
    private userLoggedSessionStorageKey: string = "user_logged";

    constructor(
        private _backendService: BackendService,
        private httpClient: HttpClient,
        public dialog: MatDialog,
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
        this.obtenerDatosUsuarioObj();
        this.obtenerReservasDeHabitaciones();
        this.obtenerReservasDeServicios();
    }

    private obtenerDatosUsuarioObj(){
        const apiUrl: string = "https://localhost:7149/api/usuarios/obtener-datos-de-usuario-by-email";
        const userEmail: UserEmailObjectDTO = { Email: this.userLogged.Email};
        this.httpClient
        .post<UsuariosDTO>(apiUrl, userEmail)
        .subscribe(
            async res => {
                await console.log(res);
                this.datosUsuarioObj = await res;
            }
        )
    }

    public obtenerReservasDeHabitaciones(){
        // TODO: HACER ESTO UNA VEZ EL USUARIO PUEDA HACER RESERVAS
        // const apiUrl: string = "";
        // const body: { USERNAME: string = this.datosUsuarioObj.USERNAME}
        
        // this.httpClient
        // .get<>(apiUrl)
        // .subscribe();
    }

    public obtenerReservasDeServicios(){
        // TODO: HACER ESTO UNA VEZ EL USUARIO PUEDA HACER RESERVAS
        // const apiUrl: string = "";
        // const body: { USERNAME: string = this.datosUsuarioObj.USERNAME}
        
        // this.httpClient
        // .get<>(apiUrl)
        // .subscribe();
    }

    public cambiarPassword(oldPassword: string, newPassword: string){
        const apiUrl: string = "https://localhost:7149/api/usuarios/cambiar-contrasena";

        let username = this.datosUsuarioObj.USERNAME;
        const body: DoChangeUserPasswordDTO = {
            Username: username,
            OldPassword: oldPassword,
            NewPassword: newPassword,
        }

        this.httpClient
        .post<string>(apiUrl, body)
        .subscribe(
            res => {
                
            }
        );
    }

    public mostrarDialogCambiarPassword(){
        this.dialog.open(DialogElement);
    }

    // fin clase
}
