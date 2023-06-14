import { Injectable } from '@angular/core';

// mis interfaces
import { CardInterface } from 'src/app/core/interfaces/card.interface';

// mis constantes
import { API_KEY, API_LINK } from '../core/constantes';

@Injectable({providedIn: 'root'})
export class GestionarImagenesService {
    public doObtainHabitacionesCardData(API_KEY?: string): CardInterface[]{
        // TODO:    peticion a la API
        
        // ! provisional
        let listaHabitacionesCards: CardInterface[] = [
            {
                cardTitleContent: "Habitación individual",
                cardTextContent: "Habitación para los amantes de la soledad. Selección perfecta para desconectar de las personas. Disfruta de las vistas a la ciudad mientras tomas tu bebida favorita.",
                imgSrc: "assets/images/habitaciones/habitacion-1.jpg",
                imgID: "assets/images/habitaciones/habitacion-1.jpg",
                enlace: "/habitacion/{{imgID}}",
            },
            {
                cardTitleContent: "Habitación para ejecutivos",
                cardTextContent: "Habitación individual. Selección perfecta para hospedarte en un lugar que permita el descanso y el trabajo al mismo tiempo.",
                imgSrc: "assets/images/habitaciones/habitacion-2.jpeg",
                imgID: "assets/images/habitaciones/habitacion-2.jpeg",
                enlace: "/habitacion/{{imgID}}",
            },
            {
                cardTitleContent: "Habitación para parejas",
                cardTextContent: "Habitación para parejas. Disfrute de las vistas al mar y a la playa desde lo alto del hotel. Su disfrute está insonorizado para no tener ni un ápice de ruido del exterior.",
                imgSrc: "assets/images/habitaciones/habitacion-3.jfif",
                imgID: "assets/images/habitaciones/habitacion-3.jfif",
                enlace: "/habitacion/{{imgID}}",
            },
            {
                cardTitleContent: "Habitación para parejas",
                cardTextContent: "Habitación para parejas. Disfrute de las vistas a la ciudad y al mar desde lo alto del edificio en una terraza perfectamente iluminada con luz natural.",
                imgSrc: "assets/images/habitaciones/habitacion-4.jfif",
                imgID: "assets/images/habitaciones/habitacion-4.jfif",
                enlace: "/habitacion/{{imgID}}",
            },
            {
                cardTitleContent: "Habitación de lujo",
                cardTextContent: "Habitación para las parejas más exigentes. Disfrute de las vistas al mar desde lo más bajo del edificio en un espacio habilitado debajo del agua.",
                imgSrc: "assets/images/habitaciones/habitacion-lujo-1.jfif",
                imgID: "assets/images/habitaciones/habitacion-lujo-1.jfif",
                enlace: "/habitacion/{{imgID}}",
            }
        ];
        // ! fin provisional

        return listaHabitacionesCards;
    }





    // fin de clase GestionarUsuariosService
}
