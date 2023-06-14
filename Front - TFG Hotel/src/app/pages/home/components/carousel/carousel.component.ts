import { Component } from '@angular/core';



@Component({
    selector: 'pages-home-carousel',
    templateUrl: './carousel.component.html',
    styleUrls: ['./carousel.component.css', './carousel-media-queries.component.css']
})

export class MiCarruselComponent  {
    public listaImagenesCarrusel: string[] = [
        '../../../assets/images/pages-carrusel/carrusel-4.webp',
        '../../../assets/images/pages-carrusel/carrusel-5.jpg',
        '../../../assets/images/pages-carrusel/carrusel-6.jpg',
        '../../../assets/images/pages-carrusel/carrusel-1.webp',
    ];
    public indiceListaImagenesCarrusel: number;

    constructor(){
        let randomImageIndex: number = Math.round( Math.random() * ( this.listaImagenesCarrusel.length - 1 ) )
        this.indiceListaImagenesCarrusel = randomImageIndex;
    }


    public avanzarImagen(){
        if(this.indiceListaImagenesCarrusel == this.listaImagenesCarrusel.length - 1){
            this.indiceListaImagenesCarrusel = 0;
        }
        else{
            this.indiceListaImagenesCarrusel++;
        }
    }

    public retrocederImagen(){
        if(this.indiceListaImagenesCarrusel == 0){
            this.indiceListaImagenesCarrusel = this.listaImagenesCarrusel.length - 1;
        }
        else{
            this.indiceListaImagenesCarrusel--;
        }
    }
}