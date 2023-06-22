import {Component, Input} from '@angular/core';
import {MatDialogModule, MatDialogRef} from '@angular/material/dialog';
import {MatButtonModule} from '@angular/material/button';
import { UserLoggedInterface } from 'src/app/core/interfaces/user-logged.interface';
import { CommonModule } from '@angular/common';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Inject } from '@angular/core';



@Component({
    selector: 'dialog-elements-change-user-password',
    templateUrl: 'dialog-element-angular-material.component.html',
    standalone: true,
    // Imports como si fuera un modulo
    imports: [
        MatDialogModule, 
        MatButtonModule, 
        CommonModule
    ]
})
export class DialogElement {
    public userData = { oldPassword: "", newPassword: "" };

    
    constructor(
        public dialogRef: MatDialogRef<DialogElement>,
        @Inject(MAT_DIALOG_DATA) public errorLogin: any
    ) 
    {}

    public cerrarCajaError(): void {
        this.errorLogin = 0;
        this.closeDialog();
    }

    closeDialog(): void {
        this.dialogRef.close();
    }
}
