CREATE VIEW DATOS_HABITACIONES_TIPOS_FECHAS
AS
SELECT 
	H.ID_HABITACION,
	R.ID_CLIENTE,
	T.ID_TIPO_DE_HABITACION,
	T.CATEGORIA,
	R.FECHA_INICIO,
	R.FECHA_FIN

FROM
	HABITACIONES H,
	RESERVAS_DE_HABITACIONES R,
	TIPOS_DE_HABITACIONES T

WHERE
		H.ID_TIPO_DE_HABITACION = T.ID_TIPO_DE_HABITACION
	AND	H.ID_HABITACION = R.ID_HABITACION
;
