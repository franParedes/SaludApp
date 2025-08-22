/*
	SCRIPT INICIAL DE CREACIÓN BD SALUDAPP, DDL
*/
DROP DATABASE IF EXISTS db_saludapp;
CREATE DATABASE db_saludapp CHARACTER SET utf8mb4 COLLATE utf8mb4_spanish_ci;
USE db_saludapp;

-- tabla para saber si es: paciente, médico
CREATE TABLE tb_tipo_usuarios (
	Id_tipo_usuario INT PRIMARY KEY AUTO_INCREMENT,
    Tipo_usuario VARCHAR(50)
) ENGINE = InnoDB;

-- Generos
CREATE TABLE tb_generos (
	Id_genero INT PRIMARY KEY AUTO_INCREMENT,
    Genero VARCHAR(50)
) ENGINE = InnoDB;

-- usuarios generales de la app
CREATE TABLE tb_usuarios (
	Id_usuario INT PRIMARY KEY AUTO_INCREMENT,
    Username VARCHAR(50) NOT NULL UNIQUE,
    Cedula CHAR(16) UNIQUE NOT NULL,
    Primer_nombre VARCHAR(50) NOT NULL,
    Segundo_nombre VARCHAR(50),
    Primer_apellido VARCHAR(50) NOT NULL,
    Segundo_apellido VARCHAR(50),
    Correo VARCHAR(50) NOT NULL,
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
CREATE TABLE tb_telefonos (
	Id_telefono INT PRIMARY KEY AUTO_INCREMENT,
    Telefono INT,
    Persona INT NOT NULL,
    Compania INT,
    Is_userapp BOOLEAN,
    
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