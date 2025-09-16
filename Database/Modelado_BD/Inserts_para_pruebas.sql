-- SELECT * FROM db_saludapp.tb_prov_telefonicos;

INSERT INTO `db_saludapp`.`tb_prov_telefonicos` (`Proveedor`) VALUES ('Tigo');
INSERT INTO `db_saludapp`.`tb_prov_telefonicos` (`Proveedor`) VALUES ('Claro');
INSERT INTO `db_saludapp`.`tb_prov_telefonicos` (`Proveedor`) VALUES ('Cootel');

INSERT INTO `db_saludapp`.`tb_tipo_usuarios` (`Tipo_usuario`) VALUES ('Paciente');
INSERT INTO `db_saludapp`.`tb_tipo_usuarios` (`Tipo_usuario`) VALUES ('Médico');
INSERT INTO `db_saludapp`.`tb_tipo_usuarios` (`Tipo_usuario`) VALUES ('Contacto');

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

INSERT INTO `db_saludapp`.`tb_turnos_medicos` (`Turno`) VALUES ('8 Horas vespertino');

INSERT INTO `db_saludapp`.`tb_areas_medicas` (`Area`) VALUES ('ER');
INSERT INTO `db_saludapp`.`tb_areas_medicas` (`Area`) VALUES ('Obstetricia');

INSERT INTO `db_saludapp`.`tb_universidades` (`Universidad`) VALUES ('UNAN León');
INSERT INTO `db_saludapp`.`tb_universidades` (`Universidad`) VALUES ('UNAN Managua');
INSERT INTO `db_saludapp`.`tb_universidades` (`Universidad`) VALUES ('Gaspar García Laviana');

INSERT INTO `db_saludapp`.`tb_especialidades` (`Especialidad`) VALUES ('General');
INSERT INTO `db_saludapp`.`tb_especialidades` (`Especialidad`) VALUES ('Ortopedia');
INSERT INTO `db_saludapp`.`tb_especialidades` (`Especialidad`) VALUES ('Cirugía');

INSERT INTO `db_saludapp`.`tb_centros_medicos` (`Centro`, `Departamento`, `Municipio`) VALUES ('José Rubí', '1', '1');

INSERT INTO `db_saludapp`.`tb_tipos_citas` (`Tipo`) VALUES ('Médica');
INSERT INTO `db_saludapp`.`tb_tipos_citas` (`Tipo`) VALUES ('Laboratorio');

INSERT INTO `db_saludapp`.`tb_ocupaciones` (`Ocupacion`) VALUES ('Estudiante');

INSERT INTO `db_saludapp`.`tb_religiones` (`Religion`) VALUES ("Catolica"), ("Evangelica"), ("Mormona"), ("Otras");
