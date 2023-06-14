import { Component } from '@angular/core';

// mis interfaces
import { CardInterface as HabitacionCardInterface } from '../../core/interfaces/card.interface';

// mis ctes
import { TITULO_HOTEL as tituloHotel } from 'src/app/core/constantes';
import { ActivatedRoute, Router } from '@angular/router';
import { GestionarImagenesService } from '../gestionar-imagenes.service';


@Component({
  selector: 'pages-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
    public tituloHotel: String = tituloHotel;
    public listaHabitacionCards: HabitacionCardInterface[];

    private router: Router;
    private route: ActivatedRoute;
    private gestionarImagenesService: GestionarImagenesService;

    constructor(router: Router, route: ActivatedRoute,
        gestionarImagenesService: GestionarImagenesService)
    {
        this.router = router;
        this.route = route;
        this.gestionarImagenesService = gestionarImagenesService;
        this.listaHabitacionCards = this.gestionarImagenesService.doObtainHabitacionesCardData();
    }
    
    private expandirElementoHTML(elementID: string, transition: string, scale: string, opacity: string): void
    {
        const elementoAExpandir = document.getElementById(elementID);

        elementoAExpandir!.style.transition = transition;
        elementoAExpandir!.style.scale = scale;
        elementoAExpandir!.style.opacity = opacity;
    }
    

    public cambiarDePagina(elementID: string): void
    {
        console.log(elementID);

        let transition: string = "1s";
        let scale: string = "10";
        let opacity: string = "0";
        let delayTimeoutMs: number = 500;
        let rutaHabitaciones: string = "/habitaciones"
        
        this.expandirElementoHTML(elementID, transition, scale, opacity);
    
        setTimeout (() => {
            this.router.navigate ( [rutaHabitaciones], { relativeTo: this.route } );
        }, 
            delayTimeoutMs
        );
    }
}
