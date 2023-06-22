import { Component } from '@angular/core';

import { CardInterface } from 'src/app/core/interfaces/card.interface';
import { TITULO_HOTEL as tituloHotel } from 'src/app/core/constantes';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { ReservasDeServicios_DTO } from 'src/app/core/interfaces/ReservasDeServicios_DTO.interface';
import { Observable } from 'rxjs';
import { BackendService } from '../../backend/backend.service';
import { SESSION_STORAGE_USER_LOGGED } from '../../core/constantes';
import { USUARIOS } from 'src/app/core/interfaces/USUARIOS.interface';
import { MatDialog } from '@angular/material/dialog';
import { DialogElement } from './components/dialog-element-angular-material/dialog-element-angular-material.component';


@Component({
  selector: 'app-reservas-de-servicios',
  templateUrl: './reservas-de-servicios.component.html',
  styleUrls: ['./reservas-de-servicios.component.css', 'reservas-de-servicios-media-queries.component.css']
})
export class ReservasDeServiciosComponent {
    public listaDatosCard: CardInterface[] = [
        {
            id_servicio: 1,
            imgSrc: "./../../../assets/images/pages-sobre-nosotros/card-1.jpg",
            cardTitleContent: "Restaurante Salt Bae",
            cardTextContent: "Prueba los nuevos chuletones T-Bonne bañados en oro. Experimenta el menú de degustación con los ingredientes más exóticos de oriente medio."
        },
        {
            id_servicio: 2,
            imgSrc: "./../../../assets/images/pages-sobre-nosotros/card-2.jpg",
            cardTitleContent: "A la luz de la luna",
            cardTextContent: "Toma un baño relajante en la piscina de uno de nuestros recintos privados, sin distracciones, solo tú y los tuyos."
        },
        {
            id_servicio: 3,
            imgSrc: "./../../../assets/images/pages-sobre-nosotros/card-4.jpg",
            cardTitleContent: "Pasarela de moda",
            cardTextContent: "Lo último en moda arábiga se encuentra con nosotros en una pasarela con público selecto. Únete a la fiesta tras el evento, estás invitado."
        }
    ]

    public datosCardEventoEspecial: CardInterface = {
        id_servicio: 4,
        imgSrc: "./../../../assets/images/pages-sobre-nosotros/card-3.jpg",
        cardTitleContent: "Tributo a Linkin Park",
        cardTextContent: "Disfruta de un grupo homenaje a Linkin Park en un tributo a modo de promoción del nuevo album de Meteora en su vigésimo aniversario."

    }

    public tituloHotel: String = tituloHotel;
    /** Indicador boolean de si el usuario tiene la sesión iniciada o no. */
    public isUserLogged: Observable<boolean> | boolean = false;
    public username: string = "";


    constructor(
        private httpClient: HttpClient,
        private _backendService: BackendService,
        public dialog: MatDialog,
    )
    {
        this.comprobarLogin();
        this.obtenerUsernameConEmail();
    }

    public reservarServicio($event: number){
        const apiUrl: string = "https://localhost:7149/api/reservas-de-servicios/add-reserva-de-servicio-with-username";
        const body: ReservasDeServicios_DTO = {
            Username: this.username,
            Id_Servicio: $event
        };

        console.log(body);
        

        this.httpClient
        .post<HttpErrorResponse>(apiUrl, body)        
        .subscribe(
            async res => {
                if(await res.status >= 200 && await res.status < 400){
                    console.log("Reserva de servicio añadida.");
                    
                }
                else{
                    console.log("ERROR: Error inesperado");
                    
                }
                
            }
        )

        this.openDialog();
    }

    public openDialog(): void {
        this.dialog.open(DialogElement);
    }


    private obtenerUsernameConEmail(){
        /**
         * obtener del sessionstorage el objeto user_logged
         * peticion a la api para obtener usename a partir del email
         */
        let userEmail: string = JSON.parse(sessionStorage.getItem(SESSION_STORAGE_USER_LOGGED)).Email;
        // console.log(userEmail);

        const apiUrl = "https://localhost:7149/api/usuarios/obtener-datos-de-usuario-by-email";
        const body = { email: userEmail };

        this.httpClient
        .post<USUARIOS>(apiUrl, body)
        .subscribe(
          res => {
            // console.log(res.USERNAME);
            this.username = res.USERNAME;
          }
        );
  
        
    }

    private comprobarLogin() {
        this.isUserLogged = this._backendService.comprobarLogin();
    }
}
