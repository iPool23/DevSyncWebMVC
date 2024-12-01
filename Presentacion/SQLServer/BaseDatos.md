-- Crear la base de datos
CREATE DATABASE bdGestionPro;
GO

-- Usar la base de datos
USE bdGestionPro;
GO

-- Tabla rol
CREATE TABLE rol (
    codigo INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(100) UNIQUE
);

-- Tabla usuario
CREATE TABLE usuario (
    codigo INT PRIMARY KEY IDENTITY(1,1),
    nombreUsuario VARCHAR(255) UNIQUE,
    correo VARCHAR(255) UNIQUE,
	contrasenia VARCHAR(255),
    nombres VARCHAR(255) ,
    apellidos VARCHAR(255) ,
    codigoRol INT,
	imgUrl VARCHAR(255),
    FOREIGN KEY (codigoRol) REFERENCES rol(codigo)
);

-- Tabla equipo
CREATE TABLE equipo (
    codigo INT PRIMARY KEY IDENTITY(1,1),
	imgUrl VARCHAR(255) null,
    nombre VARCHAR(100) UNIQUE
);

-- Tabla equipo_usuario
CREATE TABLE equipo_usuario (
    codigoEquipo INT,
    codigoUsuario INT,
    PRIMARY KEY (codigoEquipo, codigoUsuario),
    FOREIGN KEY (codigoEquipo) REFERENCES equipo(codigo),
    FOREIGN KEY (codigoUsuario) REFERENCES usuario(codigo)
);

-- Tabla estado
CREATE TABLE estado (
    codigo INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(50) UNIQUE
);

-- Tabla proyecto
CREATE TABLE proyecto (
    codigo INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(255) UNIQUE,
    progreso INT DEFAULT 0,
    descripcion VARCHAR(255),
    fechaInicio DATE,
    fechaFin DATE,
    codigoLider INT,
    codigoEquipo INT,
    codigoEstado INT,
	imgUrl VARCHAR(255),
    FOREIGN KEY (codigoLider) REFERENCES usuario(codigo),
    FOREIGN KEY (codigoEquipo) REFERENCES equipo(codigo),
    FOREIGN KEY (codigoEstado) REFERENCES estado(codigo)
);

-- Tabla Rol Proyecto
CREATE TABLE rol_proyecto
(
	codigoProyecto INT,
	codigoUsuario INT,
	codigoRol INT,
	FOREIGN KEY (codigoProyecto) REFERENCES proyecto(codigo),
	FOREIGN KEY (codigoUsuario) REFERENCES usuario(codigo),
	FOREIGN KEY (codigoRol) REFERENCES rol(codigo),
)

-- Tabla sprint
CREATE TABLE sprint (
    codigo INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(100) UNIQUE,
    progreso INT DEFAULT 0,
    fechaInicio DATE,
    fechaFin DATE,
    codigoLider INT,
    codigoProyecto INT,
    FOREIGN KEY (codigoLider) REFERENCES usuario(codigo),
    FOREIGN KEY (codigoProyecto) REFERENCES proyecto(codigo)
);

-- Tabla insumo
CREATE TABLE insumo (
    codigo INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(100) UNIQUE,
    descripcion VARCHAR(255),
    cantidad INT,
    codigoSprint INT,
    FOREIGN KEY (codigoSprint) REFERENCES sprint(codigo)
);

-- Tabla tipo_actividad
CREATE TABLE tipo_actividad (
    codigo INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(100) UNIQUE
);

-- Tabla actividad
CREATE TABLE actividad (
    codigo INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(100) UNIQUE,
    descripcion VARCHAR(255),
    progreso INT DEFAULT 0,
    codigoTipo INT,
    codigoSprint INT,
    codigoEstado INT,
    FOREIGN KEY (codigoTipo) REFERENCES tipo_actividad(codigo),
    FOREIGN KEY (codigoSprint) REFERENCES sprint(codigo),
    FOREIGN KEY (codigoEstado) REFERENCES estado(codigo)
);

-- Tabla etiqueta
CREATE TABLE etiqueta (
    codigo INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(100) UNIQUE
);

-- Se agrega la columna eliminado a la tabla etiqueta-- 
ALTER TABLE etiqueta
add eliminado char(1) null

-- Tabla tarea
CREATE TABLE tarea (
    codigo INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(100) UNIQUE,
    descripcion VARCHAR(255),
    fechaInicio DATE,
    fechaActualizacion DATE,
    fechaVencimiento DATE,
    prioridad INT,
    progreso INT DEFAULT 0,
    codigoUsuario INT,
    codigoActividad INT,
    codigoEstado INT,
    FOREIGN KEY (codigoUsuario) REFERENCES usuario(codigo),
    FOREIGN KEY (codigoActividad) REFERENCES actividad(codigo),
    FOREIGN KEY (codigoEstado) REFERENCES estado(codigo)
);

-- Tabla tarea_etiqueta
CREATE TABLE tarea_etiqueta (
    codigoTarea INT,
    codigoEtiqueta INT,
    PRIMARY KEY (codigoTarea, codigoEtiqueta),
    FOREIGN KEY (codigoTarea) REFERENCES tarea(codigo),
    FOREIGN KEY (codigoEtiqueta) REFERENCES etiqueta(codigo)
);
-- Se agrega la columna eliminado a la tabla tarea_etiqueta-- 

ALTER TABLE tarea_etiqueta
add eliminado char(1) null

-- Tabla comentario
CREATE TABLE comentario (
    codigo INT PRIMARY KEY IDENTITY(1,1),
    contenido VARCHAR(100),
    fechaCreacion DATE,
    codigoTarea INT,
    codigoUsuario INT,
	imgUrl VARCHAR(255),
    FOREIGN KEY (codigoTarea) REFERENCES tarea(codigo),
    FOREIGN KEY (codigoUsuario) REFERENCES usuario(codigo)
);
