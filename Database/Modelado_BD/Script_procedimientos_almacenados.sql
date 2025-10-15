DROP PROCEDURE IF EXISTS sp_devolver_municipios_por_departamento;
DELIMITER //
CREATE PROCEDURE sp_devolver_municipios_por_departamento(iNId_departamento INT)
BEGIN
	SELECT mun.Id_municipio AS IdMunicipio, mun.Municipio, mun.Departamento_al_que_pertenece AS 'DepartamentoAlQuePertenece'
    FROM tb_municipios AS mun
    WHERE Departamento_al_que_pertenece = iNId_departamento;
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS sp_devolver_barrios_por_municipio;
DELIMITER //
CREATE PROCEDURE sp_devolver_barrios_por_municipio(iNId_municipio INT)
BEGIN
	SELECT barr.Id_barrio AS IdBarrio, barr.Barrio, barr.Municipio_al_que_pertenece AS 'MunicipioAlQuePertenece'
    FROM tb_barrios as barr
    WHERE Municipio_al_que_pertenece = iNId_municipio;
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS sp_citas_pendientes_aprobacion;
DELIMITER //
CREATE PROCEDURE sp_citas_pendientes_aprobacion()
BEGIN
	DECLARE _estadoPendiente INT;
    DECLARE _tipoEstado INT;
    
    SELECT Id_tipo INTO _tipoEstado 
    FROM tb_tipo_estado
    WHERE Tipo = 'Cita';
    
    SELECT Id_estado INTO _estadoPendiente
    FROM tb_stados 
    WHERE Estado = 'PENDIENTE'
	  AND Tipo_estado = _tipoEstado;
    
	SELECT cita.Id_cita AS 'IdCita',
		cita.Paciente_id AS 'IdPaciente', 
        centro.Centro AS 'CentroMedico',
        tipo.Tipo AS 'TipoDeCita'
    FROM tb_citas AS cita
    INNER JOIN tb_centros_medicos AS centro ON centro.Id_centro = cita.Lugar
    INNER JOIN tb_tipos_citas AS tipo ON tipo.Id_tipo_cita = cita.Tipo_cita
    WHERE cita.Estado = _estadoPendiente;
END //
DELIMITER ; 

DROP PROCEDURE IF EXISTS sp_detalle_cita_medica;
DELIMITER //
CREATE PROCEDURE sp_detalle_cita_medica(iNId_cita INT)
BEGIN
	SELECT cita.Id_cita AS 'IdCita',
		cita.Paciente_id AS 'IdPaciente', 
		centro.Centro AS 'CentroMedico',
		cita.Fecha_solicitud AS 'FechaSolicitud',
		cita.Fecha_cita AS 'FechaCita',
		estado.Estado,
		cita.Motivo_cita AS 'MotivoCita',
		cita.Motivo_rechazo AS 'MotivoRechazo',
		citaMed.Medico_id AS 'MedicoId',
		CONCAT(usr.Primer_nombre, usr.Primer_apellido) AS 'Medico',
		esp.Especialidad
	FROM tb_citas AS cita
	INNER JOIN tb_citas_medicas AS citaMed ON citaMed.Id_cita = cita.Id_cita
	INNER JOIN tb_medicos AS med ON med.Id_medico = citaMed.Medico_id
	INNER JOIN tb_especialidades AS esp ON esp.Id_especialidad = med.Especialidad
	INNER JOIN tb_usuarios AS usr ON usr.Id_usuario = med.Id_usuario
	INNER JOIN tb_centros_medicos AS centro ON centro.Id_centro = cita.Lugar
	INNER JOIN tb_stados AS estado ON estado.Id_estado = cita.Estado
	WHERE cita.Id_cita = iNId_cita;
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS sp_detalle_cita_laboratorio;
DELIMITER //
CREATE PROCEDURE sp_detalle_cita_laboratorio(iNId_cita INT)
BEGIN
	SELECT cita.Id_cita AS 'IdCita',
		cita.Paciente_id AS 'IdPaciente', 
		centro.Centro AS 'CentroMedico',
		cita.Fecha_solicitud AS 'FechaSolicitud',
		cita.Fecha_cita AS 'FechaCita',
		estado.Estado,
		cita.Motivo_cita AS 'MotivoCita',
		cita.Motivo_rechazo AS 'MotivoRechazo',
		citaLab.Examenes_realizar AS 'ExamenesRealizar'
	FROM tb_citas AS cita
	INNER JOIN tb_citas_laboratorio AS citaLab ON citaLab.Id_cita = cita.Id_cita
	INNER JOIN tb_centros_medicos AS centro ON centro.Id_centro = cita.Lugar
	INNER JOIN tb_stados AS estado ON estado.Id_estado = cita.Estado
	WHERE cita.Id_cita = iNId_cita;
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS sp_obtener_info_general_paciente;
DELIMITER //
CREATE PROCEDURE sp_obtener_info_general_paciente(iNId_usuario INT)
BEGIN
	SELECT Primer_nombre AS 'PrimerNombre', usr.Segundo_nombre AS 'SegundoNombre', 
		usr.Primer_apellido AS 'PrimerApellido', usr.Segundo_apellido AS 'SegundoApellido',
        usr.Cedula,
        usr.Correo,
        gen.Genero,
        usr.Fecha_nacimiento AS 'FechaNacimiento',
        pac.Numero_inss AS 'NumeroINSS',
        oc.Ocupacion,
        rel.Religion,
        esc.Escolaridad,
        pac.Edad,
        est_civ.Estado_civil AS 'EstadoCivil',
        pac.Cantidad_hermanos AS 'CantidadHermanos'
    FROM tb_usuarios AS usr
    JOIN tb_generos AS gen ON gen.Id_genero = usr.Genero
    JOIN tb_pacientes AS pac ON pac.Id_usuario = usr.Id_usuario
    JOIN tb_ocupaciones AS oc ON oc.Id_ocupacion = pac.Ocupacion
    JOIN tb_religiones AS rel ON rel.Id_religion = pac.Religion
    JOIN tb_escolaridad AS esc ON esc.Id_escolaridad = pac.Escolaridad
    JOIN tb_estado_civil AS est_civ ON est_civ.Id_estado_civil = pac.Estado_civil
    WHERE usr.Id_usuario = iNId_usuario;
END //
DELIMITER ;
