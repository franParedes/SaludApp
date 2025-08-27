
-- tabla para saber si es: paciente, médico
INSERT INTO tb_tipo_usuarios(Tipo_usuario) VALUES('Paciente'),('Médico'), ('Persona de contacto');

-- Generos
INSERT INTO tb_generos(Genero) VALUES('Maculino'),('Femenino'), ('Otro');

-- usuarios generales de la app
INSERT INTO tb_usuarios(Username, Cedula, Primer_nombre, Segundo_nombre, Primer_apellido, Segundo_apellido, Correo, Genero, Fecha_nacimiento, 
						Tipo_usuario, Fecha_creacion, Fecha_actualizacion, activo)
			VALUES('@fparedes', '086-145223-1222S', 'Francisco', '', 'Paredes', 'Av', 'fparedes.dev@outlook.com', 1, '2004-05-28', 1, CURRENT_DATE(),
            CURRENT_DATE(), true);

DROP FUNCTION IF EXISTS F_VALIDAR_USUARIO_EXISTE;
DELIMITER //            
CREATE FUNCTION F_VALIDAR_USUARIO_EXISTE(iNcorreo VARCHAR(50)) 
RETURNS BOOLEAN
READS SQL DATA -- indica que la función solo lee datos de la base de datos, como con una consulta SELECT
-- DETERMINISTIC -- indica que la función siempre produce el mismo resultado con los mismos parámetros
BEGIN
	DECLARE _userExist INT DEFAULT 0;
    
    SELECT COUNT(1) INTO _userExist FROM tb_usuarios WHERE Correo = iNcorreo;
    
    RETURN _userExist > 0;
END; 
//
DELIMITER ;

SELECT COUNT(1) FROM tb_usuarios WHERE Correo = "fpredes.dev@outlok.com";
SELECT F_VALIDAR_USUARIO_EXISTE("fparedes.dev@outlook.com");