import {Component, Inject} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogModule, MatDialogRef} from '@angular/material/dialog';
import {MatButtonModule} from '@angular/material/button';
import {CommonModule} from '@angular/common';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { UsernameFotoPerfilBase64DTO } from 'src/app/core/interfaces/UsernameFotoPerfilBase64DTO.interface';
import { UsuariosDTO } from 'src/app/core/interfaces/UsuariosDTO.interface';
import { UserPageComponent } from '../../user-page.component';
import { DialogElement } from '../dialog-cambiar-password/dialog-element-angular-material.component';
import { Route, Router } from '@angular/router';
import { UserEmailObjectDTO } from 'src/app/core/interfaces/UserEmailObjectDTO.interface';


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
export class DialogCambiarFotoPerfil {
    public selectedImage: File;
    public imagePreview: string;
    private imgBase64: string;

    constructor(
        public dialogRef: MatDialogRef<DialogElement>,
        private httpClient: HttpClient,
        @Inject(MAT_DIALOG_DATA) public datosUsuarioObj: UsuariosDTO,
        private route:Router,
    ) 
    { }

    ngOnInit() {}

    public onImageSelected(event: any) {
        const file: File = event.target.files[0];

        this.selectedImage = file;

        let reader = new FileReader();
        reader.onload = () => {
            this.imagePreview = reader.result as string;
            this.imgBase64 = reader.result as string;
        };
        reader.readAsDataURL(file);
    }

    public enviarImagen() {
        const apiUrl = "https://localhost:7149/api/usuarios/cambiar-foto-perfil";
        const apiBody: UsernameFotoPerfilBase64DTO = {
            Username: this.datosUsuarioObj.USERNAME,
            FotoPerfilBase64: this.imgBase64
        };
        
        this.httpClient
        .post(apiUrl, apiBody)
        .subscribe(
            async res => {
                console.log(res);
                this.closeDialog();
            }
        );
    }

    
    public closeDialog(): void {
        this.dialogRef.close();
        
        this.route.navigate(["/home"]);
        setTimeout(() => {
            this.route.navigate(["/mi-perfil"]);
        }, 1);
        
        
        // const apiUrl: string = "https://localhost:7149/api/usuarios/obtener-datos-de-usuario-by-email";
        // const userEmail: UserEmailObjectDTO = { Email: this.datosUsuarioObj.EMAIL};
        // this.httpClient
        // .post<UsuariosDTO>(apiUrl, userEmail)
        // .subscribe(
        //     async res => {
        //         await console.log(res);
        //         this.datosUsuarioObj = await res;
        //     }
        // )
    }
      
      
      


    // fin clase
}
