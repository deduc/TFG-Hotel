import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'shared-button-login',
    templateUrl: './button-login.component.html'
})

export class ButtonLoginComponent  {
    // public RouterLink: string = "auth/login";
    public RouterLink: string = "login";
}