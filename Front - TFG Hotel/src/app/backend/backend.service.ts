import { Injectable } from '@angular/core';

// mis interfaces
import { UserRegisterFormInterface } from '../core/interfaces/user-register-form.interface';

// mis modulos
import { API_LINK, API_LINK_USUARIOS, API_POST_USUARIOS, API_LINK_HABITACIONES, API_GET_HABITACIONES_DISPONIBLES, API_LOGIN_USUARIOS, SESSION_STORAGE_USER_LOGGED, API_COMPROBAR_SI_LOGIN_CORRECTO, API_GET_TIPOS_DE_HABITACIONES, API_LINK_TIPOS_DE_HABITACIONES, API_GET_HABITACIONES_BY_ID } from '../core/constantes';
import { HttpClient, HttpResponse } from '@angular/common/http';
// Usado, por ahora, en reservasService para un atributo observable
import { BehaviorSubject, Observable } from 'rxjs';

// Mis interfaces
import { CardHabitacionInterface } from '../core/interfaces/card-habitacion.interface';
import { FechaInicioFinInterface } from '../core/interfaces/fecha-inicio-fin.interface';
import { UserLoggedInterface } from '../core/interfaces/user-logged.interface';
import { DATOS_DE_HABITACIONES_DISPONIBLES } from '../core/interfaces/datos-de-habitacion-disponible.interface';


@Injectable({ providedIn: 'root' })
export class BackendService {

    constructor
    (
        private httpClient: HttpClient
    ) { }

    /**
     * método asíncrono que envía una petición en modo POST a la API
     * para registrar un usuario en la base de datos
     */
    public async registrarUsuario(user: UserRegisterFormInterface): Promise<any> {
        let url: string = `${API_LINK}/${API_LINK_USUARIOS}/${API_POST_USUARIOS}`;

        /**
         * ! { observe: 'response' } es para obtener una respuesta completa de la peticion http. 
         * ! Lo uso para conseguir el status code de la peticion http y verificar si los datos son correctos
         */
        this.httpClient
        .post(url, user, { observe: 'response' })
        .subscribe(
            (response: HttpResponse<any>) => {
                console.log(response);
                
                // Se consigue registrar un usuario 
                if (response.status >= 200 && response.status < 400 && response.body.length == 0) {
                    console.log("Usuario registrado con éxito, codigo de status = " + response.status);

                    let algo = {
                        usuarioRegistrado: 1,
                    };

                    sessionStorage.setItem("tmp", JSON.stringify(algo));
                    console.log(1111111);
                    
                    return true;
                }
                // No se consigue registrar un usuario 
                else {
                    console.log(22222);
                    let listaErrores: string[] = response.body;
                    let cadenaFormateada: string = "Se ha obtenido una respuesta del servidor:\n\n";    
                    
                    listaErrores.forEach(element => {
                        cadenaFormateada += element + "\n";
                    });

                    alert(cadenaFormateada);

                    return false;
                }

                // fin subscribe
            }

            // fin llamada http
        );

        // fin metodo
    }


    /**
     * Método asíncrono que hace una petición en modo POST a la API.
     * 
     * Obtiene una lista de las habitaciones disponibles (no reservadas),
     * entre las fechas indicadas en el objeto recibido por parámetro
     */
    public async obtenerListaHabitacionesDisponiblesEntreFechas(objFechas: FechaInicioFinInterface) {
        let url: string = `${API_LINK}/${API_LINK_HABITACIONES}/${API_GET_HABITACIONES_DISPONIBLES}`;

        this.httpClient
        .post(url, objFechas, { observe: 'response' })
        .subscribe(
            (response: HttpResponse<any>) => {
                if (response.status >= 200 && response.status < 400) {
                    console.log("Has obtenido respuestas, lol. BackendService");

                } else {
                    console.error(response.status);
                }
            }
        );

    }

    public async loginUsuariooo(datosLoginUsuario: UserLoggedInterface): Promise<any> {
        let url: string = `${API_LINK}/${API_LINK_USUARIOS}/${API_LOGIN_USUARIOS}`;

        /**
         * ! { observe: 'response' } es para obtener una respuesta completa de la peticion http. 
         * ! Lo uso para conseguir el status code de la peticion http y verificar si los datos son correctos
         */
        this.httpClient
        .post(url, datosLoginUsuario)
        .subscribe(
            async (response: HttpResponse<any>) => {
                if (response.status >= 200 && response.status < 400) {
                    console.log("BackendService", response);

                    return await response.body;

                } else {
                    console.log("MAL");
                    console.error('uno' + response);
                    return false;
                }
            }
        );
        return false;
    }

    public loginTest(userLoggedObject: UserLoggedInterface): Observable<any>{
        const url = `${API_LINK}/${API_LINK_USUARIOS}/${API_LOGIN_USUARIOS}`

        const body = {
            Email: userLoggedObject.Email,
            Password: userLoggedObject.Password
        }

        return this.httpClient.post<UserLoggedInterface>(url, body);
    }

    /**
     * 
     * metodo que comprueba si hay un objeto en concreto en sessionstorage, obtiene sus valores
     * y los convierte a objeto. Manda una peticiçon a la API para validarlos y retorna true o false
     * si son correctos
     */
    public comprobarLogin(): Observable<boolean> | boolean {
        // console.log("compruebo loggin kekw");
        if (sessionStorage.getItem(SESSION_STORAGE_USER_LOGGED)) {
            // convierto a objeto los valores obtenidos en sessionStorage
            let userLoggedObject: UserLoggedInterface = JSON.parse(
                sessionStorage.getItem(SESSION_STORAGE_USER_LOGGED)
            );
            
            const url = `${API_LINK}/${API_LINK_USUARIOS}/${API_COMPROBAR_SI_LOGIN_CORRECTO}`

            /**
             * * Asigno a una variable: Observable el valor boolean que retorna invocar a this.httpClient.post
             * El método .post devuelve un Observable sí o sí, y en la API, en este caso, un boolean,
             * retornando así un Observable<boolean>
             */
            let observableBooleanValue: Observable<boolean> = this.httpClient.post<boolean>(url, userLoggedObject);
            return observableBooleanValue;
        }
        else{
            console.log("no estas loggeado");
            return false;
        }

        // fin metodo
    }

    private comprobarLoginCorrecto(userLoggedObject): boolean{
        const url = `${API_LINK}/${API_LINK_USUARIOS}/${API_COMPROBAR_SI_LOGIN_CORRECTO}`

        const body = {
            Email: userLoggedObject.Email,
            Password: userLoggedObject.Password
        }

        // let a:any = this.httpClient.post<boolean>(url, body);
        // console.log("------------------");
        // console.log(a);
        // console.log("------------------");
        
        return false;
    }

    // ! Hecho con chatGTP, procedo a explicar qué coño hace:
    /**
     * Método que crea una variable listaHabitaciones
     * hace una consulta get a la API para obtener un array de habitaciones
     * y
     */
    public obtenerHabitacionesDisponibles(): BehaviorSubject<CardHabitacionInterface[]> {
        const baseApiUrl = `${API_LINK}/${API_LINK_TIPOS_DE_HABITACIONES}`;
        const tiposHabitacionesUrl = `${baseApiUrl}/${API_GET_TIPOS_DE_HABITACIONES}`;
      
        let listaHabitaciones = new BehaviorSubject<CardHabitacionInterface[]>([]);
      
        this.httpClient
        .get<CardHabitacionInterface[]>(tiposHabitacionesUrl)
        .subscribe(
            habitaciones => 
            {
                console.log(1111);
                console.log(habitaciones);
                
                listaHabitaciones.next(habitaciones);
                listaHabitaciones.complete();

                console.log(2222);
                console.log(listaHabitaciones);
            }
        );

        return listaHabitaciones;
    }

    public obtenerTiposDeHabitaciones(): DATOS_DE_HABITACIONES_DISPONIBLES[] | void {
        const baseApiUrl = `${API_LINK}/${API_LINK_TIPOS_DE_HABITACIONES}`;
        const tiposHabitacionesUrl = `${baseApiUrl}/${API_GET_TIPOS_DE_HABITACIONES}`;
      
        this.httpClient
        .get<CardHabitacionInterface[]>(tiposHabitacionesUrl)
        .subscribe(
            habitaciones => 
            {
                console.log(1111);
                console.log(habitaciones);

                return habitaciones;
            }
        );
    }
    

    public obtenerHabitacionById(idHabitacion: number): DATOS_DE_HABITACIONES_DISPONIBLES | any {
        const baseApiUrl = `${API_LINK}/${API_LINK_TIPOS_DE_HABITACIONES}`;
        const habitacionFiltradaURL = `${baseApiUrl}/${API_GET_HABITACIONES_BY_ID}/${idHabitacion}`;

        const apiBody = {
            id: idHabitacion
        }

        this.httpClient
            .post<DATOS_DE_HABITACIONES_DISPONIBLES>(habitacionFiltradaURL, apiBody)
            .subscribe(
                (resp) => {
                    return resp;
                }
            )
        ;
    }

    // fin clase
}
