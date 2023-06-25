import { HttpClient } from '@angular/common/http';
import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { CLIENTES } from 'src/app/core/interfaces/CLIENTES.interface';
import { DATOS_RESERVAS_DE_SERVICIOS_Y_CLIENTES } from 'src/app/core/interfaces/DATOS_RESERVAS_DE_SERVICIOS_Y_CLIENTES.interface';
import { UsernameObjectDTO } from 'src/app/core/interfaces/UsernameObjectDTO.interface';
import { UsuariosDTO } from 'src/app/core/interfaces/UsuariosDTO.interface';

@Component({
  selector: 'app-reservas-servicios',
  templateUrl: './reservas-servicios.component.html',
  styleUrls: ['./reservas-servicios.component.css']
})
export class ReservasServiciosComponent {
    @Input() public datosUsuarioObj: UsuariosDTO;
    public datosCliente: CLIENTES;
    public misReservas: DATOS_RESERVAS_DE_SERVICIOS_Y_CLIENTES[];
    
    constructor(
        private http: HttpClient,
        private route: Router,
    )
    {}

    ngOnInit(): void {
        console.log(this.datosUsuarioObj);
        this.obtenerDatosClienteWithUsername();
    }

    public obtenerDatosClienteWithUsername(){
        const apiUrl: string = "https://localhost:7149/api/clientes/obtener-datos-cliente-by-username";
        const body: UsernameObjectDTO = {
            Username: this.datosUsuarioObj.USERNAME
        };

        this.http
        .post<CLIENTES>(apiUrl, body)
        .subscribe(
            res => {
                this.datosCliente = res;
                this.obtenerReservasDeServicios();
            }
        );
    }

    public obtenerReservasDeServicios(){
        const apiUrl = "https://localhost:7149/api/reservas-de-servicios/get-reservas-de-servicios-by-id-cliente?idCliente=" + this.datosCliente.ID_CLIENTE;
        
        this.http
        .get<DATOS_RESERVAS_DE_SERVICIOS_Y_CLIENTES[]>(apiUrl)
        .subscribe(
            async res => {
                this.misReservas = await res;
            }
        )
    }

    public cancelarReserva($idReservaServicio){
        console.log($idReservaServicio);
        const apiUrl = "https://localhost:7149/api/reservas-de-servicios/cancelar-reserva-de-servicio?idReservaServicio=" + $idReservaServicio;

        console.log(apiUrl);
        
        this.http
        .get(apiUrl)
        .subscribe(
            res => {
                console.log(res);
                
            }
        );

        this.route.navigate(["/home"]);
        setTimeout(() => {
            this.route.navigate(["/mi-perfil"]);
        }, 1);
    }


    // fin clase
}
