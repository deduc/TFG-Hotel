DECLARE @F_I DATE = '2023-07-16';
DECLARE @F_F DATE = '2023-07-20';

select
	ID_TIPO_DE_HABITACION, count(ID_TIPO_DE_HABITACION) as "cantidad disponible"
from
	HABITACIONES
where
	ID_HABITACION in 
	(
		SELECT ID_HABITACION FROM RESERVAS_DE_HABITACIONES
		WHERE
				@F_F < FECHA_INICIO
			OR	@F_I > FECHA_FIN
			AND	@F_I < FECHA_INICIO
	)
group by 
	ID_TIPO_DE_HABITACION
;

SELECT 
	T.ID_TIPO_DE_HABITACION, 
	COUNT(H.ID_TIPO_DE_HABITACION) AS "CANTIDAD DISPONIBLE",
	T.CATEGORIA,
	T.PRECIO,
	T.DESCRIPCION,
	T.IMG_HABITACION_BASE_64,
	T.TAMA�O,
	T.ENLACE_URL
FROM 
	HABITACIONES H 
	LEFT JOIN TIPOS_DE_HABITACIONES T 
	ON H.ID_TIPO_DE_HABITACION = T.ID_TIPO_DE_HABITACION
WHERE
	ID_HABITACION in 
	(
		SELECT ID_HABITACION FROM RESERVAS_DE_HABITACIONES
		WHERE
				@F_F < FECHA_INICIO
			OR	@F_I > FECHA_FIN
			AND	@F_I < FECHA_INICIO
	)
GROUP BY
	T.ID_TIPO_DE_HABITACION, 
	T.CATEGORIA,
	T.PRECIO,
	T.DESCRIPCION,
	T.IMG_HABITACION_BASE_64,
	T.TAMA�O,
	T.ENLACE_URL
;
