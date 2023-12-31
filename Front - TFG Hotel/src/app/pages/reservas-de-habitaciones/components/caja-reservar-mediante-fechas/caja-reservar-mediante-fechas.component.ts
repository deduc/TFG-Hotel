import { Component, EventEmitter, Output } from '@angular/core';
import { FechaInicioFinInterface } from '../../../../core/interfaces/fecha-inicio-fin.interface';
import { ReservasDeHabitacionesService } from '../../reservas-de-habitaciones.service';

@Component({
  selector: 'pages-reservas-caja-reservar-mediante-fechas',
  templateUrl: './caja-reservar-mediante-fechas.component.html',
  styleUrls: ['./caja-reservar-mediante-fechas.component.css']
})
export class CajaReservarMedianteFechasComponent {
    @Output() fechas = new EventEmitter();
    public reservasService:ReservasDeHabitacionesService;
    public errorFormulario: number = 0;
    public fechaHoy: Date = new Date();

    public objFechas: FechaInicioFinInterface = {
        fechaInicio: null,
        fechaFin: null
    }
    
    public constructor(
        reservasService:ReservasDeHabitacionesService
    )
    {
        this.reservasService = reservasService;
        
        this.fechaHoy.setHours(0);
        this.fechaHoy.setMinutes(0);
        this.fechaHoy.setSeconds(0);
        this.fechaHoy.setMilliseconds(0);
    }

    public enviarFormulario(): void{
        if( (this.objFechas.fechaInicio != null) && (this.objFechas.fechaFin != null) ){
            let fechaInicio: Date = new Date(this.objFechas.fechaInicio);
                fechaInicio.setHours(0);
                fechaInicio.setMinutes(0);
                fechaInicio.setSeconds(0);
                fechaInicio.setMilliseconds(0);

            let fechaFin: Date = new Date(this.objFechas.fechaFin);
                fechaFin.setHours(0);
                fechaFin.setMinutes(0);
                fechaFin.setSeconds(0);
                fechaFin.setMilliseconds(0);

            /**
             * comprobar estados. Cuando this.errorFormulario sea 1, 
             * invoco al metodo setObjFechasData(obj) de mi objeto reservasService
             * y en el html muestro un mensaje de éxito.
             * 
             * En caso contrario, mostraré en el html 1 de los 2 posibles mensajes de error.
             */
            if(fechaInicio >= this.fechaHoy){
                if(fechaInicio <= fechaFin){
                    this.errorFormulario = 1;
                    
                    this.emitirObjFechas(this.objFechas);
                    
                    // Envío al servicio las fechas del formulario que ha rellenado el usuario
                    this.reservasService.setObjFechasData(this.objFechas);
                }
                else{ this.errorFormulario = 3; }
            }
            else{ this.errorFormulario = 2; }
        }
        else{ this.errorFormulario = 4; }

        // fin metodo
    }

    public emitirObjFechas ( fechas: FechaInicioFinInterface){
        this.fechas.emit(fechas);
    }

    public cerrarCaja(){
        this.errorFormulario = 0;
    }

    // fin clase
}
