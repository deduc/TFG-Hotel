/*
	###########################################################
	BLOQUE CREACION DE VISTAS
	###########################################################

*/
CREATE VIEW DATOS_DE_HABITACIONES_DISPONIBLES AS
SELECT 
    T.ID_TIPO_DE_HABITACION,
    COUNT(H.ID_HABITACION) AS HABITACIONES_DISPONIBLES,
    T.CATEGORIA,
    T.PRECIO,
    T.DESCRIPCION,
    T.IMG_HABITACION_BASE_64,
    T.TAMAÑO
FROM 
    TIPOS_DE_HABITACIONES T
	LEFT JOIN 
		HABITACIONES H ON T.ID_TIPO_DE_HABITACION = H.ID_TIPO_DE_HABITACION
WHERE
	H.DISPONIBLE = 1
	
GROUP BY 
    T.ID_TIPO_DE_HABITACION,
    T.CATEGORIA,
    T.PRECIO,
    T.DESCRIPCION,
    T.IMG_HABITACION_BASE_64,
    T.TAMAÑO
;
/*
	###########################################################
	FIN BLOQUE CREACION DE VISTAS
	###########################################################
*/
