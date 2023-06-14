import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, CanMatch, Route, RouterStateSnapshot, UrlSegment, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { BackendService } from 'src/app/backend/backend.service';
import { UserLoggedInterface } from '../interfaces/user-logged.interface';
import { SESSION_STORAGE_USER_LOGGED } from '../constantes';

@Injectable({
    providedIn: 'root'
})
export class AuthGuard implements CanActivate, CanMatch {

    constructor(
        private backService: BackendService
    ) {
        
    }

    private comprobarEstadoAuth() : Observable<boolean> | boolean {
        // let userLoggedObject: UserLoggedInterface = JSON.parse(
        //     sessionStorage.getItem(SESSION_STORAGE_USER_LOGGED)
        // );
        // console.log(userLoggedObject);
        

        return this.backService.comprobarLogin();
    }


    canMatch(route: Route): boolean | Observable<boolean> {
        return this.comprobarEstadoAuth();
    }
    canActivate(route: ActivatedRouteSnapshot): boolean | Observable<boolean> {
        return this.comprobarEstadoAuth();
    }

}
