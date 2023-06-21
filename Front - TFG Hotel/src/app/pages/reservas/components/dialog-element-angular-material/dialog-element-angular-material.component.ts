import {Component} from '@angular/core';
import {MatDialogModule, MatDialogRef} from '@angular/material/dialog';
import {MatButtonModule} from '@angular/material/button';


@Component({
    selector: 'dialog-elements-reservar-habitacion',
    templateUrl: 'dialog-element-angular-material.component.html',
    styles: ['.posicion-fixed{position:fixed}'],
    standalone: true,
    imports: [MatDialogModule, MatButtonModule]
})
export class DialogElement {
    constructor(public dialogRef: MatDialogRef<DialogElement>) { }

    closeDialog(): void {
        this.dialogRef.close();
    }

}
