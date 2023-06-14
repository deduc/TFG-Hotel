import { NgModule } from '@angular/core';

// mis modulos
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../shared/shared.module';

// mis componentes
import { HomeComponent } from './home.component';
import { MiCarruselComponent } from './components/carousel/carousel.component';
import { PagesRoutingModule } from '../pages-routing.module';


@NgModule({
    declarations: [
        HomeComponent,
        MiCarruselComponent,
    ],
    imports: [
        SharedModule,
        CommonModule,
        PagesRoutingModule,
    ]
})
export class HomeModule { }
