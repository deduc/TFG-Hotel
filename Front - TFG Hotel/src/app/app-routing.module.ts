import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';


// mis componentes
import { UserLoginComponent } from './pages/user-login/user-login.component';
import { UserRegisterComponent } from './pages/user-register/user-register.component';
// import { PanelAdministradorComponent } from './pages/panel-administrador/panel-administrador.component';


const myRoutes: Routes = [
    {
        path: 'login',
        component: UserLoginComponent
    },
    {
        path: 'register',
        component: UserRegisterComponent
    },
    // {
    //     path: 'panel-administrador',
    //     component: PanelAdministradorComponent
    // },
    {
        path: '',
        loadChildren: () => import('./pages/pages.module')
            .then( modulo => modulo.PagesModule )
    },
    {
        path: '**', redirectTo: ''
    }
];

// configures NgModule imports and exports
@NgModule({
  imports: [
      RouterModule.forRoot(myRoutes)
    ],
  exports: [
      RouterModule
    ]
})
export class AppRoutingModule { }