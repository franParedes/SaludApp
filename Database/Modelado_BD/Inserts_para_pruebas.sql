SELECT * FROM db_saludapp.tb_stados;

INSERT INTO `db_saludapp`.`tb_tipo_estado` (`Tipo`) VALUES ('Usuario');
INSERT INTO `db_saludapp`.`tb_tipo_estado` (`Tipo`) VALUES ('Cita');

INSERT INTO `db_saludapp`.`tb_stados` (`Estado`, `Tipo_estado`) VALUES ('PENDIENTE', '2');
INSERT INTO `db_saludapp`.`tb_stados` (`Estado`, `Tipo_estado`) VALUES ('APROBADA', '2');
INSERT INTO `db_saludapp`.`tb_stados` (`Estado`, `Tipo_estado`) VALUES ('RECHAZADA', '2');
INSERT INTO `db_saludapp`.`tb_stados` (`Estado`, `Tipo_estado`) VALUES ('REPROGRAMADA', '2');
INSERT INTO `db_saludapp`.`tb_stados` (`Estado`, `Tipo_estado`) VALUES ('CANCELADA', '2');

INSERT INTO `db_saludapp`.`tb_stados` (`Estado`, `Tipo_estado`) VALUES ('ACTIVO', '1');
INSERT INTO `db_saludapp`.`tb_stados` (`Estado`, `Tipo_estado`) VALUES ('INACTIVO', '1');

INSERT INTO `db_saludapp`.`tb_prov_telefonicos` (`Proveedor`) VALUES ('Tigo');
INSERT INTO `db_saludapp`.`tb_prov_telefonicos` (`Proveedor`) VALUES ('Claro');
INSERT INTO `db_saludapp`.`tb_prov_telefonicos` (`Proveedor`) VALUES ('Cootel');

INSERT INTO `db_saludapp`.`tb_tipo_usuarios` (`Tipo_usuario`) VALUES ('Paciente');
INSERT INTO `db_saludapp`.`tb_tipo_usuarios` (`Tipo_usuario`) VALUES ('Médico');
INSERT INTO `db_saludapp`.`tb_tipo_usuarios` (`Tipo_usuario`) VALUES ('Recepcionista');
INSERT INTO `db_saludapp`.`tb_tipo_usuarios` (`Tipo_usuario`) VALUES ('Administrador');
INSERT INTO `db_saludapp`.`tb_tipo_usuarios` (`Tipo_usuario`) VALUES ('Registro');

INSERT INTO `db_saludapp`.`tb_generos` (`Genero`) VALUES ('Femenino');
INSERT INTO `db_saludapp`.`tb_generos` (`Genero`) VALUES ('Masculino');

INSERT INTO `db_saludapp`.`tb_departamentos` (`Departamento`) VALUES ('Chinandega');
INSERT INTO `db_saludapp`.`tb_departamentos` (`Departamento`) VALUES ('Leon');
INSERT INTO `db_saludapp`.`tb_departamentos` (`Departamento`) VALUES ('Managua');
INSERT INTO `db_saludapp`.`tb_departamentos` (`Departamento`) VALUES ('Carazo');
INSERT INTO `db_saludapp`.`tb_departamentos` (`Departamento`) VALUES ('Estelí');
INSERT INTO `db_saludapp`.`tb_departamentos` (`Departamento`) VALUES ('Jinotega');

INSERT INTO `db_saludapp`.`tb_municipios` (`Municipio`, `Departamento_al_que_pertenece`) VALUES ('Chinandega', '1');
INSERT INTO `db_saludapp`.`tb_municipios` (`Municipio`, `Departamento_al_que_pertenece`) VALUES ('El Viejo', '1');
INSERT INTO `db_saludapp`.`tb_municipios` (`Municipio`, `Departamento_al_que_pertenece`) VALUES ('León', '2');
INSERT INTO `db_saludapp`.`tb_municipios` (`Municipio`, `Departamento_al_que_pertenece`) VALUES ('Telica', '2');

INSERT INTO `db_saludapp`.`tb_barrios` (`Barrio`, `Municipio_al_que_pertenece`) VALUES ('Roberto Gonzales', '1');
INSERT INTO `db_saludapp`.`tb_barrios` (`Barrio`, `Municipio_al_que_pertenece`) VALUES ('Bello Amanecer', '2');
INSERT INTO `db_saludapp`.`tb_barrios` (`Barrio`, `Municipio_al_que_pertenece`) VALUES ('Guadalupe', '3');

INSERT INTO `db_saludapp`.`tb_religiones` (`Religion`) VALUES ("Catolica"), ("Evangelica"), ("Mormona"), ("Otras");

INSERT INTO `db_saludapp`.`tb_ocupaciones` (`Ocupacion`) VALUES ('Estudiante');

INSERT INTO `db_saludapp`.`tb_escolaridad` (`Escolaridad`) VALUES ('NO TIENE');
INSERT INTO `db_saludapp`.`tb_escolaridad` (`Escolaridad`) VALUES ('PRIMARIA');
INSERT INTO `db_saludapp`.`tb_escolaridad` (`Escolaridad`) VALUES ('SECUNDARIA');
INSERT INTO `db_saludapp`.`tb_escolaridad` (`Escolaridad`) VALUES ('UNIVERSIDAD');

INSERT INTO `db_saludapp`.`tb_estado_civil` (`Estado_civil`) VALUES ('SOLTERO/A');
INSERT INTO `db_saludapp`.`tb_estado_civil` (`Estado_civil`) VALUES ('CASADO/A');
INSERT INTO `db_saludapp`.`tb_estado_civil` (`Estado_civil`) VALUES ('DIVORCIADO/A');
INSERT INTO `db_saludapp`.`tb_estado_civil` (`Estado_civil`) VALUES ('VIUDO/A');
INSERT INTO `db_saludapp`.`tb_estado_civil` (`Estado_civil`) VALUES ('UNION LIBRE');

INSERT INTO `db_saludapp`.`tb_especialidades` (`Especialidad`) VALUES ('General');
INSERT INTO `db_saludapp`.`tb_especialidades` (`Especialidad`) VALUES ('Ortopedia');
INSERT INTO `db_saludapp`.`tb_especialidades` (`Especialidad`) VALUES ('Cirugía');

INSERT INTO `db_saludapp`.`tb_universidades` (`Universidad`) VALUES ('UNAN León');
INSERT INTO `db_saludapp`.`tb_universidades` (`Universidad`) VALUES ('UNAN Managua');
INSERT INTO `db_saludapp`.`tb_universidades` (`Universidad`) VALUES ('Gaspar García Laviana');

INSERT INTO `db_saludapp`.`tb_areas_medicas` (`Area`) VALUES ('ER');
INSERT INTO `db_saludapp`.`tb_areas_medicas` (`Area`) VALUES ('Obstetricia');

INSERT INTO `db_saludapp`.`tb_centros_medicos` (`Centro`, `Departamento`, `Municipio`) VALUES ('José Rubí', '1', '1');

INSERT INTO `db_saludapp`.`tb_turnos_medicos` (`Turno`) VALUES ('8 Horas vespertino');

INSERT INTO `db_saludapp`.`tb_tipos_citas` (`Tipo`) VALUES ('Médica');
INSERT INTO `db_saludapp`.`tb_tipos_citas` (`Tipo`) VALUES ('Laboratorio');

INSERT INTO `db_saludapp`.`tb_examenes_disponibles_lab` (`Examen`) VALUES ('ASO');
INSERT INTO `db_saludapp`.`tb_examenes_disponibles_lab` (`Examen`) VALUES ('Sangre');
INSERT INTO `db_saludapp`.`tb_examenes_disponibles_lab` (`Examen`) VALUES ('Orina');
INSERT INTO `db_saludapp`.`tb_examenes_disponibles_lab` (`Examen`) VALUES ('Heces');

INSERT INTO `db_saludapp`.`tb_vias_adminitracion` (`Via_adm`) VALUES ('Oral');
INSERT INTO `db_saludapp`.`tb_vias_adminitracion` (`Via_adm`) VALUES ('Intravenosa');
