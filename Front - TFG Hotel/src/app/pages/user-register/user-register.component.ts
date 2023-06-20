import { HttpClient, HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BackendService } from 'src/app/backend/backend.service';
import { API_LINK, API_LINK_USUARIOS, API_POST_USUARIOS } from 'src/app/core/constantes';
import { UserRegisterDTOInterface } from 'src/app/core/interfaces/UserRegisterDTO.interface';
import { UserRegisterFormInterface } from 'src/app/core/interfaces/user-register-form.interface';


@Component({
  selector: 'app-user-register',
  templateUrl: './user-register.component.html',
  styleUrls: ['./user-register.component.css']
})
export class UserRegisterComponent implements OnInit{
    public datosRegistroUsuario: UserRegisterFormInterface = {
        nombre: "ivan",
        apellidos: "gomez",
        username: "deduc",
        dni: "12312312A",
        email: "deduc@deduc.es",
        password: "deduc@deduc.esdeduc@deduc.es",
        repeatedPassword: "deduc@deduc.esdeduc@deduc.es"
    }
;
    public listaErrores: string[] = [];
    public formularioRegistroCompletado: boolean = false;

    constructor(
        private backendService: BackendService,
        private httpClient: HttpClient,
        private router: Router,

    ){}

    ngOnInit(): void {
        if (sessionStorage.getItem('user_logged')) {
            this.router.navigate(['./home'])
        }
    }

    public validarFormulario(): void {
        if(this.bloqueComprobaciones()){
            console.log("Datos insertados correctamente.", "La petición de registrar tu usuario ha sido enviada al servidor.");
            this.registrarUsuario();
        }
        else{
            console.error("Datos insertados erróneamente, tienes " + this.listaErrores.length + " errores:", );
            this.listaErrores.forEach(error => console.error(error));
            this.mostrarErrores(this.listaErrores);
        }
        // fin metodo validarFormulario
    }

    private registrarUsuario(): void{
        let url: string = `${API_LINK}/${API_LINK_USUARIOS}/${API_POST_USUARIOS}`;
        
        let user: UserRegisterDTOInterface = this.crearUsuarioRegisterDTO();
        
        console.log(user);

        this.httpClient
        .post(url, user)
        .subscribe(
            // * mi api, en este caso, devuelve un array de strings
            (response: string[]) => {
                // Se consigue registrar un usuario 
                if (response.length == 0) {
                    this.completarRegistro(this.datosRegistroUsuario);
                }
                // No se consigue registrar un usuario y muestro los errores
                else {
                    this.mostrarErrores(response);
                }

                // fin subscribe
            }

            // fin llamada http
        );


        // fin metodo
    }

    private crearUsuarioRegisterDTO(){
        return {
            ID_USUARIO: 0,
            USERNAME: this.datosRegistroUsuario.username,
            EMAIL: this.datosRegistroUsuario.email,
            DNI: this.datosRegistroUsuario.dni,
            PASSWORD: this.datosRegistroUsuario.password,
            NOMBRE: this.datosRegistroUsuario.nombre,
            APELLIDOS: this.datosRegistroUsuario.apellidos,
            FOTO_DE_PERFIL_BASE_64: ""
        }
    }

    private bloqueComprobaciones(): boolean {
        var valorRetorno = false;
        var patronEmail: RegExp = new RegExp("[a-zA-Z\.-_]{1,}@[a-z]{1,}\.[a-z]{1,}$");
        var patronDNI: RegExp = new RegExp("^[0-9]{8}[A-Z]{1}$")

        this.listaErrores = [];

        if(! (this.datosRegistroUsuario.nombre.length > 0) ){
            this.listaErrores.push("ERROR: El campo nombre no puede estar vacío.");
        }

        if(! (this.datosRegistroUsuario.apellidos.length > 0) ){
            this.listaErrores.push("ERROR: El campo apellido no puede estar vacío.");
        }

        if(! (this.datosRegistroUsuario.username.length > 0) ){
            this.listaErrores.push("ERROR: El campo nombre de usuario no puede estar vacío.");
        }

        if(! (this.datosRegistroUsuario.dni.length > 0) ){
            this.listaErrores.push("ERROR: El campo dni no puede estar vacío.");
        }
        else if(! (patronDNI.test(this.datosRegistroUsuario.dni)) ){
            this.listaErrores.push("ERROR: El campo dni no es válido. Ha de ser una serie de 8 números y una letra en mayúsculas.");
        }

        if(! (this.datosRegistroUsuario.email.length > 0) ){
            this.listaErrores.push("ERROR: El campo email no puede estar vacío.");
        }
        else if(! (patronEmail.test( this.datosRegistroUsuario.email )) ){
            this.listaErrores.push("ERROR: El campo email no es válido. Ha de cumplir el siguiete patrón: [a-zA-Z\.-_]{1,}@[a-z]{1,}\.[a-z]{1,}.");
        }

        if(! (this.datosRegistroUsuario.password.length > 0) ){
            this.listaErrores.push("ERROR: El campo contraseña no puede estar vacío.");
        }
        else if(!(this.datosRegistroUsuario.password.length >= 8)){
            this.listaErrores.push("ERROR: La contraseña debe tener mínimo 8 caracteres.");
        }

        if(! (this.datosRegistroUsuario.repeatedPassword.length > 0) ){
            this.listaErrores.push("ERROR: El campo contraseña verificada no puede estar vacío.");
        }
        
        if(! (this.datosRegistroUsuario.password === this.datosRegistroUsuario.repeatedPassword) ){
            this.listaErrores.push("ERROR: Los campos contraseña y repetir contraseña no coinciden.");
        }

        if(this.listaErrores.length == 0){
            valorRetorno = true;
        }

        return valorRetorno;

        // fin metodo bloqueComprobaciones
    }

    public completarRegistro(user: UserRegisterFormInterface){
        this.formularioRegistroCompletado = true;
        this.guardarEmailPasswordEnSessionStorage(user.email, user.password);
        this.vaciarFormularioRegistro();
        sessionStorage.removeItem("tmp");
    }

    private mostrarErrores(listaErrores: string[]): void{
        let listaErroresFormateada: string = "";

        listaErrores.forEach(error => {
            listaErroresFormateada += error + "\n";
        });
        
        alert(listaErroresFormateada);

        // fin metodo mostrarErrores
    }

    private vaciarFormularioRegistro(): void{
        this.datosRegistroUsuario =
        {
            nombre: "",
            apellidos: "",
            username: "",
            dni: "",
            email: "",
            password: "",
            repeatedPassword: ""
        }
    }

    private guardarEmailPasswordEnSessionStorage(email:string, password:string){
        let objTemp = {
            email: email,
            password: password
        };

        sessionStorage.setItem("user_registered", JSON.stringify(objTemp));
    }

    public iniciarSesion(){
        this.router.navigate(["/login"])
    }

    // fin clase UserRegisterComponent
}