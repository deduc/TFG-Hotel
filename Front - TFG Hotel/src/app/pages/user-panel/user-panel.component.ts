import { Component, OnInit } from "@angular/core";

@Component({
    selector: 'app-user-panel',
    templateUrl: 'user-panel.component.html',
})
export class UserPanelComponent implements OnInit {
    constructor() { }

    ngOnInit() { }
}

/*
import { Component, OnInit } from '@angular/core';
import { UserLoggedInterface } from 'src/app/core/interfaces/user-logged.interface';
import { BackendService } from '../../../../backend/backend.service';
import { HttpClient } from '@angular/common/http';
import { UsuariosDTO } from 'src/app/core/interfaces/UsuariosDTO.interface';
import { UserEmailObjectDTO } from 'src/app/core/interfaces/UserEmailObjectDTO.interface';

@Component({
    selector: 'user-profile',
    templateUrl: 'user-profile.component.html',
    styleUrls: ['user-profile.component.css']
})

export class UserProfileComponent implements OnInit {
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
}
*/