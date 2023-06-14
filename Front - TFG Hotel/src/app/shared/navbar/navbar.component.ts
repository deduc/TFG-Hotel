import { Component } from '@angular/core';
import { TITULO_HOTEL as tituloHotel } from 'src/app/core/constantes';
import { NavbarLinksInterface } from 'src/app/core/interfaces/navbarLinks.interface';
import { BackendService } from '../../backend/backend.service';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';


@Component({
  selector: 'shared-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {
    public tituloHotel: string = tituloHotel;
    public navBarDesplegada: boolean = false;
    public listaLinks: NavbarLinksInterface[] = [
        {
            LinkName: "Reservas",
            RouterLink: "/reservas",
        },
        {
            LinkName: "Habitaciones",
            RouterLink: "/habitaciones",
        },
        {
            LinkName: "Actividades",
            RouterLink: "/actividades",
        },
    ];

    public isUserLogged: Observable<boolean> | boolean = false;

    constructor(
        private BackendService : BackendService,
        private route: Router
    ){
        this.comprobarSiUsuarioLogged();
    }

    private comprobarSiUsuarioLogged() {
        this.isUserLogged = this.BackendService.comprobarLogin();
    }


    public doChangeNavBarDesplegada(){
        if(this.navBarDesplegada){
            this.navBarDesplegada = false;
        }
        else{
            this.navBarDesplegada = true;
        }
    }

    public cerrarSesion(){
        sessionStorage.clear();
        window.location.reload();
        this.route.navigate(['./home']);
    }
}
