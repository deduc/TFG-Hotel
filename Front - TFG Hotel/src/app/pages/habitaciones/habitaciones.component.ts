import { Component, OnInit } from '@angular/core';

// mis interfaces
import { CardHabitacionInterface } from 'src/app/core/interfaces/card-habitacion.interface';

// mis componentes
import { ActivatedRoute, Router } from '@angular/router';

// mis servicios
import { GestionarImagenesService } from '../gestionar-imagenes.service';
import { HabitacionesService } from './habitaciones.service';
import { BackendService } from 'src/app/backend/backend.service';
import { Observable } from 'rxjs';



@Component({
    selector: 'pages-habitaciones',
    templateUrl: './habitaciones.component.html',
    styleUrls: ['./habitaciones.component.css']
})
export class HabitacionesComponent implements OnInit{
    public listaHabitacionCards: CardHabitacionInterface[] = [];
    public listaHabitacionCardsTotales: CardHabitacionInterface[];
    public listaHabitacionCardsIndividual: CardHabitacionInterface[];
    public listaHabitacionCardsParejas: CardHabitacionInterface[];
    public listaHabitacionCardsLujo: CardHabitacionInterface[];

    public opcionFiltrarHabitacion: string = "";

    // mis servicios
    private gestionarImagenesService: GestionarImagenesService;
    private habitacionesService: HabitacionesService;
    private _backendService: BackendService;

    public usuarioLoggeado: Observable<boolean> | boolean = false;


    
    constructor(
        private router: Router, 
        private route: ActivatedRoute, 
        gestionarImagenesService: GestionarImagenesService,
        habitacionesService: HabitacionesService,
        backendService: BackendService
    )
    {
        // La barra de scroll del eje Y estará en la posición 0, arriba del todo
        document.body.scrollTop = 0;

        this.gestionarImagenesService = gestionarImagenesService;
        this.habitacionesService = habitacionesService;
        this._backendService = backendService;

        this.listaHabitacionCardsTotales = this.habitacionesService.getListaHabitacionesCard();
        this.listaHabitacionCards = this.listaHabitacionCardsTotales;
        this.listaHabitacionCardsIndividual = this.listaHabitacionCardsTotales.filter(x => x.categoria == "individual");
        this.listaHabitacionCardsParejas = this.listaHabitacionCardsTotales.filter(x => x.categoria == "parejas");
        this.listaHabitacionCardsLujo = this.listaHabitacionCardsTotales.filter(x => x.categoria == "lujo");
    }

    ngOnInit(): void {
        this.usuarioLoggeado = this._backendService.comprobarLogin();
    }

    public onSelected(value:string): void {
        switch(value){
            case "individual":
                this.listaHabitacionCards = this.listaHabitacionCardsIndividual;
            break;
            case "parejas":
                this.listaHabitacionCards = this.listaHabitacionCardsParejas;
            break;
            case "lujo":
                this.listaHabitacionCards = this.listaHabitacionCardsLujo;
            break;
        }

		this.opcionFiltrarHabitacion = value;
	}


    public reiniciarFiltro(){
        this.opcionFiltrarHabitacion = "";
        this.listaHabitacionCards = this.listaHabitacionCardsTotales;

        // reinicio la opcion seleccionada del formulario
        let select = document.getElementById('select') as HTMLSelectElement;
        select.selectedIndex = 0;

    }

    public reservarHabitacion(){}


    // fin clase
}
