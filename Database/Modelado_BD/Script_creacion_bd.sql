/*
	SCRIPT INICIAL DE CREACIÓN BD SALUDAPP, DDL
*/
DROP DATABASE IF EXISTS db_saludapp;
CREATE DATABASE db_saludapp CHARACTER SET utf8mb4 COLLATE utf8mb4_spanish_ci;
USE db_saludapp;

/****************** MANEJO GENERAL DE USUARIOS ******************/
-- tabla para saber si es: paciente, médico
CREATE TABLE tb_tipo_usuarios (
	Id_tipo_usuario INT PRIMARY KEY AUTO_INCREMENT,
    Tipo_usuario VARCHAR(50) NOT NULL
) ENGINE = InnoDB;

-- Generos
CREATE TABLE tb_generos (
	Id_genero INT PRIMARY KEY AUTO_INCREMENT,
    Genero VARCHAR(50) NOT NULL
) ENGINE = InnoDB;

-- usuarios generales de la app
CREATE TABLE tb_usuarios (
	Id_usuario INT PRIMARY KEY AUTO_INCREMENT,
    Username VARCHAR(50) NOT NULL,
    Cedula CHAR(16) UNIQUE NOT NULL,
    Primer_nombre VARCHAR(50) NOT NULL,
    Segundo_nombre VARCHAR(50),
    Primer_apellido VARCHAR(50) NOT NULL,
    Segundo_apellido VARCHAR(50),
    Correo VARCHAR(50) NOT NULL UNIQUE,
    Genero INT,
    Fecha_nacimiento DATE NOT NULL,
    Tipo_usuario INT,
    Fecha_creacion DATE NOT NULL,
    Fecha_actualizacion DATE NOT NULL,
    activo BOOLEAN,
    
    FOREIGN KEY (Genero) REFERENCES tb_generos(id_genero) ON UPDATE CASCADE ON DELETE SET NULL,
    FOREIGN KEY (Tipo_usuario) REFERENCES tb_tipo_usuarios(id_tipo_usuario) ON UPDATE CASCADE ON DELETE SET NULL
    
) ENGINE = InnoDB;

-- Tabla de contraseñas
CREATE TABLE tb_passwd (
	Id_passwd INT PRIMARY KEY AUTO_INCREMENT,
    Id_usuario INT UNIQUE NOT NULL,
    hash_passwd TEXT,
    
    FOREIGN KEY (Id_usuario) REFERENCES tb_usuarios(Id_usuario) ON UPDATE RESTRICT ON DELETE RESTRICT
) ENGINE = InnoDB;

-- Compañias telefonicas
CREATE TABLE tb_prov_telefonicos (
	Id_prov_tel INT PRIMARY KEY AUTO_INCREMENT,
    Proveedor VARCHAR(50)
) ENGINE = InnoDB;

-- Número de telefonos, cada usuario puede tener varios
drop table if exists tb_telefonos;
CREATE TABLE tb_telefonos (
	Id_telefono INT PRIMARY KEY AUTO_INCREMENT,
    Telefono INT UNIQUE NOT NULL,
    Id_usuario INT NOT NULL,
    Compania INT,
    
    FOREIGN KEY (Id_usuario) REFERENCES tb_usuarios(Id_usuario) ON UPDATE RESTRICT ON DELETE RESTRICT,
    FOREIGN KEY (Compania) REFERENCES tb_prov_telefonicos(Id_prov_tel) ON UPDATE CASCADE ON DELETE SET NULL
) ENGINE = InnoDB;

-- Departamentos
CREATE TABLE tb_departamentos (
	Id_departamento INT PRIMARY KEY AUTO_INCREMENT,
    Departamento VARCHAR(50)
) ENGINE = InnoDB;

-- Municipios
CREATE TABLE tb_municipios (
	Id_municipio INT PRIMARY KEY AUTO_INCREMENT,
    Municipio VARCHAR(50)
) ENGINE = InnoDB;

-- Barrios
CREATE TABLE tb_barrios (
	Id_barrio INT PRIMARY KEY AUTO_INCREMENT,
    Barrio VARCHAR(50)
) ENGINE = InnoDB;

-- Tabla que guarda todas las direcciones, cada usuario puede tener varias direcciones
CREATE TABLE tb_direcciones (
	Id_direccion INT PRIMARY KEY AUTO_INCREMENT,
    Id_usuario INT NOT NULL,
    Departamento INT,
    Municipio INT,
    Barrio INT,
    Direccion TEXT NOT NULL,
    
    FOREIGN KEY (Id_usuario) REFERENCES tb_usuarios(Id_usuario) ON UPDATE RESTRICT ON DELETE RESTRICT,
    FOREIGN KEY (Departamento) REFERENCES tb_departamentos(Id_departamento) ON UPDATE CASCADE ON DELETE SET NULL,
    FOREIGN KEY (Municipio) REFERENCES tb_municipios(Id_municipio) ON UPDATE CASCADE ON DELETE SET NULL,
    FOREIGN KEY (Barrio) REFERENCES tb_barrios(Id_barrio) ON UPDATE CASCADE ON DELETE SET NULL
) ENGINE = InnoDB;

/****************** MANEJO DE PACIENTES ******************/
-- Tabla de religiones
CREATE TABLE tb_religiones (
	Id_religion INT PRIMARY KEY AUTO_INCREMENT,
    Religion VARCHAR(50)
) ENGINE = InnoDB;

-- Tabla de religiones
CREATE TABLE tb_ocupaciones (
	Id_ocupacion INT PRIMARY KEY AUTO_INCREMENT,
    Ocupacion VARCHAR(100)
) ENGINE = InnoDB;

-- Pacientes 
CREATE TABLE tb_pacientes (
	Id_paciente INT PRIMARY KEY AUTO_INCREMENT,
    Id_usuario INT NOT NULL UNIQUE,
    Numero_inss CHAR(9) UNIQUE,
    Ocupacion INT,
    Escolaridad ENUM('NO TIENE', 'PRIMARIA', 'SECUNDARIA', 'UNIVERSIDAD') NOT NULL,
    Religion INT,
    Edad INT NOT NULL,
    Estado_civil ENUM('SOLTER@', 'CASAD@', 'DIVORCIAD@', 'VIUD@', 'UNION LIBRE') NOT NULL,
    Cantidad_hermanos INT NOT NULL,
    
    FOREIGN KEY (Id_usuario) REFERENCES tb_usuarios(Id_usuario) ON UPDATE RESTRICT ON DELETE RESTRICT,
    FOREIGN KEY (Ocupacion) REFERENCES tb_ocupaciones(Id_ocupacion) ON UPDATE CASCADE ON DELETE SET NULL,
    FOREIGN KEY (Religion) REFERENCES tb_religiones(Id_religion) ON UPDATE CASCADE ON DELETE SET NULL
) ENGINE = InnoDB;

/****************** MANEJO DE MEDICOS ******************/
-- Tabla de especialidades médicas
CREATE TABLE tb_especialidades (
	Id_especialidad INT PRIMARY KEY AUTO_INCREMENT,
    Especialidad VARCHAR(50)
) ENGINE = InnoDB;

-- Tabla de universidades
CREATE TABLE tb_universidades (
	Id_universidad INT PRIMARY KEY AUTO_INCREMENT,
    Universidad VARCHAR(50)
) ENGINE = InnoDB;

-- Tabla de areas medicas por ejemplo: Ginecología, ER, Labor y parto, etc
CREATE TABLE tb_areas_medicas (
	Id_area INT PRIMARY KEY AUTO_INCREMENT,
    Area VARCHAR(50)
) ENGINE = InnoDB;

-- Tabla de centros médicos es decir, nombre ya sea de hospitales, centros de salud, puestos de salud.
CREATE TABLE tb_centros_medicos (
	Id_centro INT PRIMARY KEY AUTO_INCREMENT,
    Centro VARCHAR(50),
    Departamento INT,
    Municipio INT,
    
    FOREIGN KEY (Departamento) REFERENCES tb_departamentos(Id_departamento) ON UPDATE CASCADE ON DELETE SET NULL,
    FOREIGN KEY (Municipio) REFERENCES tb_municipios(Id_municipio) ON UPDATE CASCADE ON DELETE SET NULL
) ENGINE = InnoDB;

-- Tabla de turnos por ejemplo: nocturno 12 h, 24h, doble turno, etc
CREATE TABLE tb_turnos_medicos (
	Id_turno INT PRIMARY KEY AUTO_INCREMENT,
    Turno VARCHAR(50)
) ENGINE = InnoDB;

-- Médicos
CREATE TABLE tb_medicos (
	Id_medico INT PRIMARY KEY AUTO_INCREMENT,
    Id_usuario INT NOT NULL,
    Cod_sanitario VARCHAR(50) NOT NULL UNIQUE,
    Especialidad INT,
    Egresado_de INT,
    Egresado_el DATE NOT NULL,
    Experiencia_anyos INT NOT NULL,
    Area_actual INT,
    Centro_actual INT,
    Turno_actual INT,
    
    FOREIGN KEY (Id_usuario) REFERENCES tb_usuarios(Id_usuario) ON UPDATE RESTRICT ON DELETE RESTRICT,
    FOREIGN KEY (Especialidad) REFERENCES tb_especialidades(Id_especialidad) ON UPDATE CASCADE ON DELETE SET NULL,
    FOREIGN KEY (Egresado_de) REFERENCES tb_universidades(Id_universidad) ON UPDATE CASCADE ON DELETE SET NULL,
    FOREIGN KEY (Area_actual) REFERENCES tb_areas_medicas(Id_area) ON UPDATE CASCADE ON DELETE SET NULL,
    FOREIGN KEY (Centro_actual) REFERENCES tb_centros_medicos(Id_centro) ON UPDATE CASCADE ON DELETE SET NULL,
    FOREIGN KEY (Turno_actual) REFERENCES tb_turnos_medicos(Id_turno) ON UPDATE CASCADE ON DELETE SET NULL
) ENGINE = InnoDB;

/****************** MANEJO DE CITAS MEDICAS ******************/
CREATE TABLE tb_citas_medicas (
	Id_cita INT PRIMARY KEY AUTO_INCREMENT,
    Paciente_id INT NOT NULL,
    Medico_id INT NOT NULL,
    Especialidad INT,
	Fecha_solicitud DATETIME NOT NULL,
    Fecha_cita DATETIME,
    Estado ENUM("pendiente", "aprobada", "rechazada", "reprogramada", "cancelada") DEFAULT "pendiente" NOT NULL,
    Motivo_rechazo TEXT,
    Motivo_cita TEXT,
    
    FOREIGN KEY (Paciente_id) REFERENCES tb_pacientes(Id_paciente) ON UPDATE RESTRICT ON DELETE RESTRICT,
    FOREIGN KEY (Medico_id) REFERENCES tb_medicos(Id_medico) ON UPDATE RESTRICT ON DELETE RESTRICT,
    FOREIGN KEY (Especialidad) REFERENCES tb_especialidades(Id_especialidad) ON UPDATE CASCADE ON DELETE SET NULL
) ENGINE = InnoDB;

/****************** MANEJO DE HISTORIAL MEDICO ******************/
CREATE TABLE tb_antecedentes_familiares_patologicos(
	Id_antecendente_famp INT PRIMARY KEY AUTO_INCREMENT,
    Enf_infecto_contagiosas VARCHAR(250), -- Es una lista, van a ir separadas por coma por ejemplo: "Hepatitis, TB, Malaria"
    Enf_hereditarias VARCHAR(250) -- Igualmente una lista, separada por comas: "Alergias, Enfermedades renales"
) ENGINE = InnoDB;

CREATE TABLE tb_tipo_tabaco(
	Id_tipo_tabaco INT PRIMARY KEY AUTO_INCREMENT,
    Tipo VARCHAR(50) NOT NULL
) ENGINE = InnoDB;

CREATE TABLE tb_es_fumador(
	Id_fumador INT PRIMARY KEY AUTO_INCREMENT,
    Tipo VARCHAR(100), -- Lista seaparada por comas: malboro, puro, marihuana, etc
    Cantidad_unidades INT NOT NULL,
    Freuencia INT NOT NULL,
    Edad_inicio INT NOT NULL,
    Edad_abandono INT,
    Duracion_anyos INT
) ENGINE = InnoDB;

CREATE TABLE tb_es_alcoholico(
	Id_alcoholico INT PRIMARY KEY AUTO_INCREMENT,
    Tipo VARCHAR(100), -- Lista seaparada por comas: ron, agua ardiente
    Cantidad_unidades INT NOT NULL,
    Freuencia INT NOT NULL,
    Edad_inicio INT NOT NULL,
    Edad_abandono INT,
    Duracion_anyos INT
) ENGINE = InnoDB;

CREATE TABLE tb_drogas_legales(
	Id_drogas_legales INT PRIMARY KEY AUTO_INCREMENT,
    Tipo VARCHAR(100), -- Lista seaparada por comas
    Cantidad_unidades INT NOT NULL,
    Freuencia INT NOT NULL,
    Edad_inicio INT NOT NULL,
    Edad_abandono INT,
    Duracion_anyos INT
) ENGINE = InnoDB;

CREATE TABLE tb_farmacos_actuales(
	Id_farmaco INT PRIMARY KEY AUTO_INCREMENT,
    Paciente_id INT NOT NULL,
    Nombre_farmaco VARCHAR(50) NOT NULL,
    Posologia_farmaco VARCHAR(100) NOT NULL,
    Esta_en_uso BOOLEAN NOT NULL DEFAULT 1,
    
    FOREIGN KEY (Paciente_id) REFERENCES tb_pacientes(Id_paciente) ON UPDATE RESTRICT ON DELETE RESTRICT
) ENGINE = InnoDB;

CREATE TABLE tb_antecedentes_personales_no_patologicos(
	Id_antecedente_per_nop INT PRIMARY KEY AUTO_INCREMENT,
    Inmunizacion_completa BOOLEAN NOT NULL,
    Horas_suenyo INT NOT NULL,
    Horas_laborales INT NOT NULL,
    Tipo_act_fisica VARCHAR(250), -- Es una lista, van a ir separadas por coma por ejemplo: Gimnacio, correo, bicicleta, ninguna
    Hora_act_fisica TIME,
    Alimentacion VARCHAR(250),
    Fumador INT
) ENGINE = InnoDB;

CREATE TABLE tb_antecedentes_personales_patologicos(
	Id_antecendente_personal_p INT PRIMARY KEY AUTO_INCREMENT,
    Enf_infecto_contagiosas VARCHAR(250), -- Es una lista, van a ir separadas por coma por ejemplo: "Hepatitis, TB, Malaria"
    Enf_cronicas VARCHAR(250), -- Lista
    Cirugias_previas_realizadas VARCHAR(250) -- Lista
) ENGINE = InnoDB;

-- Buscar en pag 67 de normas 04
CREATE TABLE tb_hospitalizaciones(
	Id_hospitalizacion INT PRIMARY KEY AUTO_INCREMENT,
    Paciente_id INT NOT NULL,
    Fecha DATETIME NOT NULL,
    Causa TEXT,
    
    FOREIGN KEY (Paciente_id) REFERENCES tb_pacientes(Id_paciente) ON UPDATE RESTRICT ON DELETE RESTRICT
) ENGINE = InnoDB;

-- Historial médico
CREATE TABLE tb_historial_medico (
	Id_historial INT PRIMARY KEY AUTO_INCREMENT,
    Id_paciente INT NOT NULL,
    Id_direccion_habitual INT NOT NULL,
    Cantidad_citas_hechas INT,
    Anteced_fam_patologicos INT NOT NULL, -- aplica para todos
    -- aplica cuando es adulto --
    Anteced_per_no_patologicos INT, 
    Es_fumador INT,
    Es_alcoholico INT,
    Drogas_legales INT,
    Otros_habitos VARCHAR(250),
    
    FOREIGN KEY (Id_paciente) REFERENCES tb_pacientes(Id_paciente) ON UPDATE RESTRICT ON DELETE RESTRICT,
    FOREIGN KEY (Anteced_fam_patologicos) REFERENCES tb_antecedentes_familiares_patologicos(Id_antecendente_famp) ON UPDATE CASCADE ON DELETE SET NULL,
    FOREIGN KEY (Anteced_fam_patologicos) REFERENCES tb_antecedentes_familiares_patologicos(Id_antecendente_famp) ON UPDATE CASCADE ON DELETE SET NULL,
    FOREIGN KEY (Es_fumador) REFERENCES tb_es_fumador(Id_fumador) ON UPDATE CASCADE ON DELETE SET NULL,
    FOREIGN KEY (Es_alcoholico) REFERENCES tb_es_alcoholico(Id_alcoholico) ON UPDATE CASCADE ON DELETE SET NULL,
    FOREIGN KEY (Drogas_legales) REFERENCES tb_drogas_legales(Id_drogas_legales) ON UPDATE CASCADE ON DELETE SET NULL
    
)ENGINE = InnoDB;

-- Buscar en pag 66 de normas 04
CREATE TABLE tb_enfermedades_infecto_contagiosas(
	Id_enfermedad INT PRIMARY KEY AUTO_INCREMENT,
    Enfermedad VARCHAR(100) NOT NULL
) ENGINE = InnoDB;

-- Buscar en pag 66 de normas 04
CREATE TABLE tb_enfermedades_hereditarias(
	Id_enfermedad INT PRIMARY KEY AUTO_INCREMENT,
    Enfermedad VARCHAR(100) NOT NULL
) ENGINE = InnoDB;

-- Buscar en pag 66 de normas 04
CREATE TABLE tb_enfermedades_cronicas(
	Id_enfermedad_cronica INT PRIMARY KEY AUTO_INCREMENT,
    Enfermedad VARCHAR(100) NOT NULL
) ENGINE = InnoDB;

-- Buscar en pag 66 de normas 04
CREATE TABLE tb_tipo_act_fisica(
	Id_tip_act INT PRIMARY KEY AUTO_INCREMENT,
    Actividad VARCHAR(50)
) ENGINE = InnoDB;

-- Buscar en pag 67 de normas 04
CREATE TABLE tb_cirugias(
	Id_cirugias INT PRIMARY KEY AUTO_INCREMENT,
    Cirugia VARCHAR(100) NOT NULL
) ENGINE = InnoDB;
