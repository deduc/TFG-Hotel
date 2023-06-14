import { NgModule } from '@angular/core';

// mis componentes
import { NavbarComponent } from './navbar/navbar.component';
import { FooterComponent } from './footer/footer.component';

// mis modulos
import { RouterModule } from '@angular/router';
import { ButtonLoginComponent } from './button-login/button-login.component';
import { ButtonRegisterComponent } from './button-register/button-register.component';
import { AngularMaterialModule } from './material/material.module';
import { ButtonGoHomeComponent } from './button-go-home/button-go-home.component';
import { CommonModule } from '@angular/common';
import { CajaReservarMedianteFechasComponent } from './caja-reservar-mediante-fechas/caja-reservar-mediante-fechas.component';


@NgModule({
    imports: [
        // * Importa este módulo en caso de utilizar routing
        RouterModule,
        AngularMaterialModule,
        CommonModule
    ],
    declarations: [
        // declaro qué componentes importa este módulo
        NavbarComponent,
        FooterComponent,
        ButtonLoginComponent,
        ButtonRegisterComponent,
        ButtonGoHomeComponent,
        CajaReservarMedianteFechasComponent,
    ],
    exports: [
        // componentes que se usará en otros puntos del código
        NavbarComponent,
        FooterComponent,
        ButtonLoginComponent,
        ButtonRegisterComponent,
        ButtonGoHomeComponent,
        CajaReservarMedianteFechasComponent,
    ],
})
export class SharedModule { }
