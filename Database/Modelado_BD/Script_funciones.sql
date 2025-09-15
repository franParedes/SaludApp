DROP FUNCTION IF EXISTS f_buscar_usuario_por_correo;
DELIMITER //
CREATE FUNCTION f_buscar_usuario_por_correo(iNCorreo VARCHAR(50))
RETURNS INT
READS SQL DATA
BEGIN
	DECLARE _idUsuario INT DEFAULT 0;
    
    SELECT Id_usuario INTO _idUsuario FROM tb_usuarios WHERE correo = iNCorreo;
    
    RETURN _idUsuario;
END //
DELIMITER ;

DROP FUNCTION IF EXISTS f_buscar_paciente_por_id;
DELIMITER //
CREATE FUNCTION f_buscar_paciente_por_id(iNIdPaciente INT)
RETURNS INT
READS SQL DATA
BEGIN
	DECLARE _idPaciente INT DEFAULT 0;
    
    SELECT Id_paciente INTO _idPaciente FROM tb_pacientes WHERE Id_paciente = iNIdPaciente;
    
    RETURN _idPaciente;
END //
DELIMITER ;
