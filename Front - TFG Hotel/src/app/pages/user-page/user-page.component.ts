import { Component, EventEmitter, Output } from '@angular/core';

import { UserLoggedInterface } from 'src/app/core/interfaces/user-logged.interface';
import { HttpClient } from '@angular/common/http';
import { UsuariosDTO } from 'src/app/core/interfaces/UsuariosDTO.interface';
import { UserEmailObjectDTO } from 'src/app/core/interfaces/UserEmailObjectDTO.interface';
import { BackendService } from "src/app/backend/backend.service";
import { CommonModule } from '@angular/common';
import { DoChangeUserPasswordDTO } from "src/app/core/interfaces/DoChangeUserPasswordDTO.interface";
import { MatDialog } from "@angular/material/dialog";
import { DialogElement } from "./components/dialog-cambiar-password/dialog-element-angular-material.component";
import { DialogCambiarFotoPerfil } from "./components/dialog-cambiar-img-perfil/dialog-element-angular-material.component";


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
    public imagenPerfil: string;
    
    private userLoggedSessionStorageKey: string = "user_logged";

    constructor(
        private httpClient: HttpClient,
        public dialogCambiarPassword: MatDialog,
        public dialogCambiarFotoPerfil: MatDialog,
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
    }

    private obtenerDatosUsuarioObj(){
        const apiUrl: string = "https://localhost:7149/api/usuarios/obtener-datos-de-usuario-by-email";
        const userEmail: UserEmailObjectDTO = { Email: this.userLogged.Email};
        this.httpClient
        .post<UsuariosDTO>(apiUrl, userEmail)
        .subscribe(
            async res => {
                // await console.log(res);
                this.datosUsuarioObj = await res;
                this.imagenPerfil = await this.datosUsuarioObj.FOTO_DE_PERFIL_BASE_64;
            }
        )
    }

    public mostrarDialogCambiarPassword(){
        this.dialogCambiarPassword.open(DialogElement, { data: this.datosUsuarioObj });
    }

    public mostrarDialogCambiarFotoPerfil(){
        this.dialogCambiarFotoPerfil.open(DialogCambiarFotoPerfil, { data: this.datosUsuarioObj });
    }

    // fin clase
}
