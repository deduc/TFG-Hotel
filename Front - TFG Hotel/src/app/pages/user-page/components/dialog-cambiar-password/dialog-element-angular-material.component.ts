import {Component, Input} from '@angular/core';
import {MatDialogModule, MatDialogRef} from '@angular/material/dialog';
import {MatButtonModule} from '@angular/material/button';
import { UserLoggedInterface } from 'src/app/core/interfaces/user-logged.interface';
import { CommonModule } from '@angular/common';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Inject } from '@angular/core';
import { DoChangeUserPasswordDTO } from 'src/app/core/interfaces/DoChangeUserPasswordDTO.interface';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { UsuariosDTO } from 'src/app/core/interfaces/UsuariosDTO.interface';
import { UserEmailObjectDTO } from 'src/app/core/interfaces/UserEmailObjectDTO.interface';
import { USUARIOS } from 'src/app/core/interfaces/USUARIOS.interface';
import { SESSION_STORAGE_USER_LOGGED } from 'src/app/core/constantes';



@Component({
    selector: 'dialog-elements-change-user-password',
    templateUrl: 'dialog-element-angular-material.component.html',
    styleUrls: ['dialog-element-angular-material.component.css'],
    standalone: true,
    // Imports como si fuera un modulo
    imports: [
        MatDialogModule, 
        MatButtonModule, 
        CommonModule
    ]
})
export class DialogElement {
    private userLoggedSessionStorageKey: string = "user_logged";
    public userLogged: UserLoggedInterface;
    public oldpassword: string;
    public newpassword: string;

    constructor
    (
        public dialogRef: MatDialogRef<DialogElement>,
        @Inject(MAT_DIALOG_DATA) public datosUsuarioObj: UsuariosDTO,
        private httpClient: HttpClient,
    ) 
    {
        // console.log(datosUsuarioObj);
    }

    public cerrarCajaError(): void {
        this.closeDialog();
    }

    public closeDialog(): void {
        this.dialogRef.close();
    }

    public submitFormulario(){
        this.oldpassword = (<HTMLInputElement>document.getElementById("oldpassword")).value;
        this.newpassword = (<HTMLInputElement>document.getElementById("newpassword")).value;

        let oldpassword = this.oldpassword;
        let newpassword = this.newpassword;


        if(oldpassword.length > 8 && newpassword.length > 8){
            // this.cambiarPassword(oldpassword, newpassword)

            const apiUrl: string = "https://localhost:7149/api/usuarios/cambiar-contrasena";

            let username = this.datosUsuarioObj.USERNAME;
            const body: DoChangeUserPasswordDTO = {
                Username: username,
                OldPassword: oldpassword,
                NewPassword: newpassword,
            }
    
            this.httpClient
            .post<string>(apiUrl, body)
            .subscribe(
                res => {
                    if(res){
                        alert("Contraseña cambiada con éxito.");
                        this.dialogRef.close();
                        this.modificarSesion();
                        // this.recargarPagina();
                    }
                    else{
                        alert("ERROR: No se ha podido cambiar la contraseña.");
                        this.dialogRef.close();
                    }
                    // fin respuesta
                }
            );
        }
        else{
            alert("ERROR: Las contraseñas no pueden tener 8 o menos caracteres.");
        }
    }

    private modificarSesion(){
        // sessionStorage.removeItem(SESSION_STORAGE_USER_LOGGED);
        let aaa: any = sessionStorage.getItem(SESSION_STORAGE_USER_LOGGED);
        console.log(aaa);

        let bbb: UserLoggedInterface = JSON.parse(aaa);
        bbb.Password = this.newpassword;

        sessionStorage.setItem(
            SESSION_STORAGE_USER_LOGGED,
            JSON.stringify(bbb)
        );

        console.log(aaa);
        console.log(bbb);
        
        
        
        // console.log("Session borrada.");
    }
    private recargarPagina(){
        // window.location.reload();
    }

    // fin clase
}
