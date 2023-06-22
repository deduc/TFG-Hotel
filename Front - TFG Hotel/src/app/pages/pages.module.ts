import { NgModule } from '@angular/core';

// * mis modulos
import { AngularMaterialModule } from '../shared/material/material.module';
// * modulo para manipular formularios
import { FormsModule } from "@angular/forms";
import { HomeModule } from './home/home.module';
import { PagesRoutingModule } from './pages-routing.module';
import { SharedModule } from '../shared/shared.module';

// * mis componentes
import { PagesComponent } from './pages.component';
import { HabitacionesComponent } from './habitaciones/habitaciones.component';
import { UserLoginComponent } from './user-login/user-login.component';
import { UserRegisterComponent } from './user-register/user-register.component';
import { BackendService } from '../backend/backend.service';
import { ReservasDeHabitacionesModule } from './reservas-de-habitaciones/reservas-de-habitaciones.module';
import { ReservasDeServiciosComponent } from './reservas-de-servicios/reservas-de-servicios.component';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { UserPageModule } from './user-page/user-page.module';



@NgModule({
    declarations: [
        // componentes
        HabitacionesComponent,
        PagesComponent,
        ReservasDeServiciosComponent,
        UserLoginComponent,
        UserRegisterComponent,
    ],
    imports: [
        AngularMaterialModule,
        CommonModule,
        FormsModule,
        HomeModule,
        PagesRoutingModule,
        SharedModule,
        ReservasDeHabitacionesModule,
        UserPageModule,
        RouterModule,
    ],
    exports: [
        // componentes globales para la app
    ],
    providers: [
        BackendService,
    ]
})
export class PagesModule { }
