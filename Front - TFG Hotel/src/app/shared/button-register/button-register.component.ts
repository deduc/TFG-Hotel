import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'shared-button-register',
    templateUrl: './button-register.component.html'
})

export class ButtonRegisterComponent  {
    // public RouterLink: string = "auth/register";
    public RouterLink: string = "register";
}