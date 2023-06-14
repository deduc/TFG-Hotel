import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { API_GET_USUARIOS, API_LINK, API_LINK_USUARIOS } from './core/constantes';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styles: [ 
      'router-outlet{position:relative; }',
    ]
})
export class AppComponent implements OnInit{
    public tituloHotel: string = "TFG Hotel Iván";

    constructor(private httpClient: HttpClient) { }

    async ngOnInit(): Promise<void> {
        let url: string = `${API_LINK}/${API_LINK_USUARIOS}/${API_GET_USUARIOS}`;
        
        await this.httpClient
        .get(url)
        .subscribe(respuestaHttp => {
            let mensaje: string = "Petición http a la url";
            let mensaje2: string = "Fin de la llamada http. Datos obtenidos desde app.component.ts";
            
            // console.log(mensaje, url);
            // console.table(respuestaHttp);
            // console.log(mensaje2);
        });
    }
}
