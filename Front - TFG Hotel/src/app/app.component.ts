import { Component } from '@angular/core';
import { SESSION_STORAGE_USER_LOGGED } from './core/constantes';
import { USUARIOS } from './core/interfaces/USUARIOS.interface';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styles: [ 'router-outlet{position:relative; }']
})
export class AppComponent{
    public tituloHotel: string = "TFG Hotel Iván";

    constructor(
        private httpClient: HttpClient
    ){
        // let sessionStorageObject: any = JSON.parse(
        //     sessionStorage.getItem(SESSION_STORAGE_USER_LOGGED)
        // );
        // let email = sessionStorageObject.Email;

        // const apiUrl = "https://localhost:7149/api/usuarios/obtener-datos-de-usuario-by-email";
        // const body = { email: email };
        

        // if(email.length > 0){
        //     this.httpClient
        //     .post<USUARIOS>(apiUrl, body)
        //     .subscribe(
        //         resp => {
        //             if(resp.USERNAME.length > 0){
        //                 console.log(resp.USERNAME);
                        
        //             }
                    
        //         }
        //     );
        // }

    }
}
