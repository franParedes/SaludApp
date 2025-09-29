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

DROP FUNCTION IF EXISTS f_buscar_medico_por_id;
DELIMITER //
CREATE FUNCTION f_buscar_medico_por_id(iNIdMedico INT)
RETURNS INT
READS SQL DATA
BEGIN
	DECLARE _idMedico INT DEFAULT 0;
    
    SELECT Id_medico INTO _idMedico FROM tb_medicos WHERE Id_medico = iNIdMedico;
    
    RETURN _idMedico;
END //
DELIMITER ;

DROP FUNCTION IF EXISTS f_asignar_medico;
DELIMITER //
CREATE FUNCTION f_asignar_medico(iNEspecialidad INT)
RETURNS INT
READS SQL DATA
BEGIN
	DECLARE _medicoId INT;
	DECLARE _total_citas INT;
    
	SELECT Medico_id, COUNT(*) as total_citas INTO _medicoId, _total_citas
	FROM tb_citas_medicas
	WHERE especialidad = 1
	GROUP BY Medico_id
	ORDER BY total_citas ASC
	LIMIT 1;
    
    IF _medicoId IS NULL THEN 
		SELECT Id_medico INTO _medicoId FROM tb_medicos WHERE especialidad = iNEspecialidad LIMIT 1;
    END IF;

	RETURN _medicoId;
END //
DELIMITER ;

DROP FUNCTION IF EXISTS fn_obtener_has_password;
DELIMITER //
CREATE FUNCTION fn_obtener_has_password(iNCorreo VARCHAR(50))
RETURNS TEXT
READS SQL DATA
BEGIN
	DECLARE _hash TEXT;
    DECLARE _idUsuario INT;
    
    SELECT Id_usuario INTO _idUsuario FROM tb_usuarios WHERE Correo = iNCorreo;
    IF _idUsuario IS NOT NULL THEN
		SELECT hash_passwd INTO _hash FROM tb_passwd WHERE Id_usuario = _idUsuario;
    END IF;
    
    RETURN _hash;
END //
DELIMITER ;