import { Component } from '@angular/core';

import { CardInterface } from 'src/app/core/interfaces/card.interface';
import { TITULO_HOTEL as tituloHotel } from 'src/app/core/constantes';

@Component({
  selector: 'app-actividades',
  templateUrl: './actividades.component.html',
  styleUrls: ['./actividades.component.css', 'actividades-media-queries.component.css']
})
export class ActividadesComponent {
    public listaDatosCard: CardInterface[] = [
        {
            imgSrc: "./../../../assets/images/pages-sobre-nosotros/card-1.jpg",
            cardTitleContent: "Restaurante Salt Bae",
            cardTextContent: "Prueba los nuevos chuletones T-Bonne bañados en oro. Experimenta el menú de degustación con los ingredientes más exóticos de oriente medio."
        },
        {
            imgSrc: "./../../../assets/images/pages-sobre-nosotros/card-2.jpg",
            cardTitleContent: "A la luz de la luna",
            cardTextContent: "Toma un baño relajante en la piscina de uno de nuestros recintos privados, sin distracciones, solo tú y los tuyos."
        },
        {
            imgSrc: "./../../../assets/images/pages-sobre-nosotros/card-4.avif",
            cardTitleContent: "Pasarela de moda",
            cardTextContent: "Lo último en moda arábiga se encuentra con nosotros en una pasarela con público selecto. Únete a la fiesta tras el evento, estás invitado."
        }
    ]

    public datosCardEventoEspecial: CardInterface = {
        imgSrc: "./../../../assets/images/pages-sobre-nosotros/card-3.jpg",
        cardTitleContent: "Tributo a Linkin Park",
        cardTextContent: "Disfruta de un grupo homenaje a Linkin Park en un tributo a modo de promoción del nuevo album de Meteora en su vigésimo aniversario."

    }

    public tituloHotel: String = tituloHotel;

}
