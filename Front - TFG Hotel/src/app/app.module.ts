import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';

// mis modulos
import { PagesModule } from './pages/pages.module';
import { SharedModule } from './shared/shared.module';
// modulo de routing
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';



@NgModule({
    declarations: [
        // * componentes
        AppComponent,
    ],
    imports: [
        // * modulos
        // modulo de routing
        AppRoutingModule,
        BrowserModule,
        // * mis modulos
        PagesModule,
        SharedModule,
        HttpClientModule,
    ],
    providers: [],
    bootstrap: [
        AppComponent
    ]
})
export class AppModule { }
