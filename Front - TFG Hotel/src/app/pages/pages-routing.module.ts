import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';


import { AuthGuard } from '../core/guards/auth.guard';
// mis componentes
import { PagesComponent } from './pages.component';
import { HomeComponent } from './home/home.component';

import { NuestroForoComponent } from './TODO-nuestro-foro/nuestro-foro.component';
import { UserPageComponent } from './user-page/user-page.component';
import { ReservasDeHabitacionesComponent } from './reservas-de-habitaciones/reservas-de-habitaciones.component';
import { ReservasDeServiciosComponent } from './reservas-de-servicios/reservas-de-servicios.component';


//  localhost:4200/heroes/''
const routes: Routes = [
    {
        path: '',
        component: PagesComponent,
        // rutas hijas relacionadas con el modulo heroes
        children: [
            /**
             * ! *IMPORTANTE* 
             * *    El orden del routing es importante. El modulo va a recorrer todas las rutas 
             * *    desde la primera hasta la última en orden y, la primera que coincida, será
             * *    la ruta que elegirá.
             * 
             * *    Es por eso que es recomendable poner las rutas variables al final.
             */
            {
                path: 'home', component: HomeComponent
            },
            {
                path: 'reservas', component: ReservasDeHabitacionesComponent
            },
            {
                path: 'habitaciones',
                loadChildren: () => import('./habitaciones/habitaciones.module')
                .then(modulo => modulo.HabitacionesModule)
            },
            {
                path: 'servicios', component: ReservasDeServiciosComponent,
                canActivate: [AuthGuard],
                canMatch: [AuthGuard]
            },
            {
                path: 'foro', component: NuestroForoComponent,
                canActivate: [AuthGuard],
                canMatch: [AuthGuard]
            },
            {
                path: 'mi-perfil', component: UserPageComponent,
                canActivate: [AuthGuard],
                canMatch: [AuthGuard]
            },
            {
                path: '**', redirectTo: 'home'
            }
        ]

    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class PagesRoutingModule { }
