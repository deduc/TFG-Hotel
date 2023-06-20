import { Component } from '@angular/core';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styles: [ 'router-outlet{position:relative; }']
})
export class AppComponent{
    public tituloHotel: string = "TFG Hotel Iván";
}
