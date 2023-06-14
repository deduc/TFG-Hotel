import { Injectable } from '@angular/core';

import { CardHabitacionInterface } from 'src/app/core/interfaces/card-habitacion.interface';


@Injectable({providedIn: 'root'})
export class HabitacionesService {
    public listaHabitacionCard: CardHabitacionInterface[] = [
        {
            titulo: "Habitación individual",
            descripcion: "Habitación para los amantes de la soledad. Selección perfecta para desconectar de las personas. Disfruta de las vistas a la ciudad mientras tomas tu bebida favorita.",
            categoria: "individual",
            imgSrc: "assets/images/habitaciones/habitacion-1.jpg",
            imgID: 1,
            enlace: "habitacion-individual",
        },
        {
            titulo: "Habitación para ejecutivos",
            descripcion: "Habitación para ejecutivos. Selección perfecta para hospedarte en un lugar que permita el descanso y el trabajo al mismo tiempo.",
            categoria: "individual",
            imgSrc: "assets/images/habitaciones/habitacion-2.jpeg",
            imgID: 2,
            enlace: "habitacion-ejecutiva",
        },
        {
            titulo: "Habitación para parejas",
            descripcion: "Habitación para parejas. Disfrute de las vistas al mar y a la playa desde lo alto del hotel. Su disfrute está insonorizado para no tener ni un ápice de ruido del exterior.",
            categoria: "parejas",
            imgSrc: "assets/images/habitaciones/habitacion-3.jfif",
            imgID: 3,
            enlace: "habitacion-para-parejas",
        },
        {
            titulo: "Habitación para parejas en azotea",
            descripcion: "Habitación para parejas. Disfrute de las vistas a la ciudad y al mar desde lo alto del edificio en una terraza perfectamente iluminada con luz natural.",
            categoria: "parejas",
            imgSrc: "assets/images/habitaciones/habitacion-4.jfif",
            imgID: 4,
            enlace: "habitacion-para-parejas-en-azotea",
        },
        {
            titulo: "Habitación de lujo",
            descripcion: "Habitación para los clientes más exigentes. Disfrute de las vistas al mar desde lo más bajo del edificio en un espacio habilitado debajo del agua.",
            categoria: "lujo",
            imgSrc: "assets/images/habitaciones/habitacion-lujo-1.jfif",
            imgID: 5,
            enlace: "habitacion-de-lujo",
        }
    ];

    public getListaHabitacionesCard(): CardHabitacionInterface[] {
        return this.listaHabitacionCard;
    }

    public getHabitacionCard(idHabitacion: number){
        // obtengo un array que contiene 1 objeto habitación y luego saco el primer elemento del array
        let habitacionCard = this.listaHabitacionCard.filter(x=> x.imgID == idHabitacion)[0];
        return habitacionCard;
        
    }
}