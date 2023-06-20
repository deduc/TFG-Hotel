import { NgModule } from '@angular/core';

// * mis modulos
import { AngularMaterialModule } from '../shared/material/material.module';
import { CommonModule } from '@angular/common';
// * modulo para manipular formularios
import { FormsModule } from "@angular/forms";
import { HomeModule } from './home/home.module';
import { PagesRoutingModule } from './pages-routing.module';
import { SharedModule } from '../shared/shared.module';
import { ReservasModule } from './reservas/reservas.module';

// * mis componentes
import { ActividadesComponent } from './actividades/actividades.component';
import { PagesComponent } from './pages.component';
import { HabitacionesComponent } from './habitaciones/habitaciones.component';
import { UserLoginComponent } from './user-login/user-login.component';
import { UserRegisterComponent } from './user-register/user-register.component';
import { BackendService } from '../backend/backend.service';
import { UserPanelModule } from './user-panel/user-panel.module';



@NgModule({
    declarations: [
        // componentes
        ActividadesComponent,
        HabitacionesComponent,
        PagesComponent,
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
        ReservasModule,
        UserPanelModule,
    ],
    exports: [
        // componentes globales para la app
    ],
    providers: [
        BackendService,
    ]
})
export class PagesModule { }
