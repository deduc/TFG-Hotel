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
export class AppComponent{
    public tituloHotel: string = "TFG Hotel Iván";

    constructor(private httpClient: HttpClient) { }
}
