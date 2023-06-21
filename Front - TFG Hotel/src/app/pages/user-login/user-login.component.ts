import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { BackendService } from 'src/app/backend/backend.service';
import { Router } from '@angular/router';
import { SESSION_STORAGE_USER_LOGGED, SESSION_STORAGE_USER_REGISTERED } from 'src/app/core/constantes';
import { UserLoggedInterface } from 'src/app/core/interfaces/user-logged.interface';
import { DialogElement } from './components/dialog-element-angular-material/dialog-element-angular-material.component';
import { MatDialog } from '@angular/material/dialog';


@Component({
    selector: 'app-user-login',
    templateUrl: './user-login.component.html',
    styleUrls: ['./user-login.component.css']
})
export class UserLoginComponent implements OnInit {
    
    public listaImagenes: String[] = [
        'assets/images/pages-user-login/login-image-1.jpg',
        'assets/images/pages-user-login/login-image-2.jfif',
        'assets/images/pages-user-login/login-image-3.webp',
        'assets/images/pages-user-login/login-image-4.webp',
    ];
    
    public SRCimagenAMostrar: String = "";
    
    public errorLogin: number = 0;
    public userData: UserLoggedInterface = { Email: "", Password: "" };
    public patronEmail: RegExp = new RegExp("[a-zA-Z\.-_]{1,}@[a-z]{1,}\.[a-z]{1,}");
    public disabledBotonIniciarSesion = false;

    constructor(
        private _backendService: BackendService,
        private route : Router,
        public dialog: MatDialog
    ) {
        let randomImageIndex: number = Math.round(Math.random() * (this.listaImagenes.length - 1))
        this.SRCimagenAMostrar = this.listaImagenes[randomImageIndex];
    }
    
    ngOnInit(): void {
        /**
         * si el usuario está loggeado en la sesion actual, 
         * compruebo que los datos sean correctos
         * y le mando a la página /home
         */
        if (sessionStorage.getItem(SESSION_STORAGE_USER_LOGGED)) {
            this.route.navigate(['./home'])
        }


        // si el usuario está registrado en la sesion actual, relleno el formulario de login por él
        if (sessionStorage.getItem(SESSION_STORAGE_USER_REGISTERED)){
            let objTemp: UserLoggedInterface = JSON.parse(sessionStorage.getItem(SESSION_STORAGE_USER_REGISTERED));
            
            this.userData.Email = objTemp.Email;
            this.userData.Password = objTemp.Password;

            sessionStorage.removeItem(SESSION_STORAGE_USER_REGISTERED);
        }
    }

    /**
     * metodo que se ejecuta en user-login.component.html cuando el usuario rellena
     * el formulario de login e intenta iniciar sesion
     */
    public tryLoginUser(): void {
        if ((this.userData.Password.length >= 8) && (this.userData.Email.match(this.patronEmail))) {
            this._backendService.loginTest(this.userData).subscribe(response => {
                if(response.email.length > 0 && response.password.length > 0)
                {
                    sessionStorage.setItem(SESSION_STORAGE_USER_LOGGED, JSON.stringify(this.userData))
                    
                    this.errorLogin = 1;
                    this.openDialog(this.errorLogin);
                    
                    this.disabledBotonIniciarSesion = true;

                    console.log("Front: Ahora sí estás loggeado.");
                    
                    
                    setTimeout( () => {
                        this.closeDialog();
                        this.route.navigate(['./home'])
                    }, 2000)
                }
                else{
                    this.errorLogin = 3;
                    this.openDialog(this.errorLogin);
                }
            })
        }
        else {
            this.errorLogin = 2;
            this.openDialog(this.errorLogin);
        }

    }

    public cerrarCajaError(): void {
        this.errorLogin = 0;
    }

    public recuperarContrasenia(): void{
        let email: string = prompt("Inserta tu email para que te enviemos un enlace para recuperar tu contraseña.");
        if(email.match(this.patronEmail)){
            alert("Correo de recuperación de cuenta enviado a la dirección '" + email + "'");
        }
        else{
            alert("Correo no válido.")
        }
    }

    public openDialog(errorLogin: number): void {
        this.dialog.open(DialogElement, { data: errorLogin });
    }

    private closeDialog(): void {
        this.dialog.closeAll();
    }

    // fin clase
}
