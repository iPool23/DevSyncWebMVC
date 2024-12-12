-- PROCEDIMIENTO ALMACENADOS PARA DEVSYNC
-- BASE DE DATOS: bdGestionPro
-- Integrantes: 
--   - Acu�a Mendoza Irvin Yair
--   - Deza Millones Pool Anthony
--   - Maza Huaman Jorge Alexander
--   - Pantaleon Villegas Victor Anthony
--   - Vieira Abad Collins Pool

-- ====================================== Deza Millones Pool Anthony ======================================

USE bdGestionPro
GO

-- Autenticar
CREATE OR ALTER PROCEDURE SP_Autenticar
    @NombreUsuario NVARCHAR(50),
    @Contrasenia NVARCHAR(50)
AS
BEGIN
    -- Declarar una variable para el resultado
    DECLARE @Resultado INT;

    -- Verificar si el usuario existe con el nombre de usuario y contrase�a
    SELECT @Resultado = COUNT(*)
    FROM Usuario
    WHERE NombreUsuario = @NombreUsuario
    AND Contrasenia = @Contrasenia;
	-- AND ContraseniaHash = HASHBYTES('SHA2_256', @Contrasenia);

    -- Devolver el resultado
    SELECT @Resultado;
END;
GO

-- Registrar Usuarios
CREATE OR ALTER PROCEDURE SP_RegistrarUsuario
    @NombreUsuario NVARCHAR(50),
    @Correo NVARCHAR(50),
    @Contrasenia NVARCHAR(50),
    @Nombres NVARCHAR(50),
    @Apellidos NVARCHAR(50),
    @ImgUrl NVARCHAR(200),
    @CodigoRol INT
AS
BEGIN
    INSERT INTO usuario (NombreUsuario, Correo, Contrasenia, Nombres, Apellidos, ImgUrl, CodigoRol)
    VALUES (@NombreUsuario, @Correo, @Contrasenia, @Nombres, @Apellidos, @ImgUrl, @CodigoRol)
END
GO

-- Procedimiento para obtener un usuario por nombre
CREATE OR ALTER PROCEDURE SP_ObtenerUsuarioPorNombre
    @NombreUsuario NVARCHAR(255)
AS
BEGIN
    SELECT u.codigo, u.nombreUsuario, u.correo, u.nombres, u.apellidos, u.imgUrl, u.codigoRol, r.nombre AS nombreRol
    FROM usuario u
    INNER JOIN rol r ON u.codigoRol = r.codigo
    WHERE u.nombreUsuario = @NombreUsuario
END
GO

-- Procedimiento para obtener los primeros 25 usuarios
CREATE OR ALTER PROCEDURE SP_ObtenerPrimeros25Usuarios
AS
BEGIN
    SELECT TOP 25 u.codigo, u.nombreUsuario, u.correo, u.nombres, u.apellidos, u.imgUrl, u.codigoRol, r.nombre AS nombreRol
    FROM usuario u
    INNER JOIN rol r ON u.codigoRol = r.codigo
    ORDER BY u.codigo
END
GO

-- Procedimiento para actualizar usuario
CREATE OR ALTER PROCEDURE SP_ActualizarUsuario
    @Codigo INT,
    @NombreUsuario NVARCHAR(255),
    @Correo NVARCHAR(255),
    @Nombres NVARCHAR(255),
    @Apellidos NVARCHAR(255),
    @ImgUrl NVARCHAR(255),
    @CodigoRol INT
AS
BEGIN
    UPDATE usuario
    SET nombreUsuario = @NombreUsuario,
        correo = @Correo,
        nombres = @Nombres,
        apellidos = @Apellidos,
        imgUrl = @ImgUrl,
        codigoRol = @CodigoRol
    WHERE codigo = @Codigo
END
GO

-- Procedimiento para eliminar usuario
CREATE OR ALTER PROCEDURE SP_EliminarUsuario
    @Codigo INT
AS
BEGIN
    DELETE FROM usuario WHERE codigo = @Codigo
END
GO

-- Procedimiento para buscar usuario por nombre
CREATE OR ALTER PROCEDURE SP_BuscarUsuariosPorNombre
    @NombreUsuario NVARCHAR(255)
AS
BEGIN
    SELECT u.codigo, u.nombreUsuario, u.correo, u.nombres, u.apellidos, u.imgUrl, u.codigoRol, r.nombre AS nombreRol
    FROM usuario u
    INNER JOIN rol r ON u.codigoRol = r.codigo
    WHERE u.nombreUsuario LIKE @NombreUsuario
    ORDER BY u.codigo
END
GO

-- ====================================== Acu�a Mendoza Irvin Yair ======================================

-- Registrar insumo en sprint
CREATE OR ALTER PROCEDURE SP_RegistrarInsumo
    @nombre NVARCHAR(100),
    @descripcion NVARCHAR(255),
    @cantidad INT,
    @codigoSprint INT
AS
BEGIN
    INSERT INTO insumo (nombre, descripcion, cantidad, codigoSprint)
    VALUES (@nombre, @descripcion, @cantidad, @codigoSprint)
END;
GO

-- Obtener los primeros 30 insumos
CREATE OR ALTER PROCEDURE SP_ObtenerPrimeros30Insumos
AS
BEGIN
    SELECT TOP 30 i.codigo, i.nombre, i.descripcion, i.cantidad, i.codigoSprint, s.nombre AS nombreSprint
    FROM insumo i
    INNER JOIN sprint s ON i.codigoSprint = s.codigo
    ORDER BY i.codigo
END
GO

-- Obtener insumo por nombre
CREATE OR ALTER PROCEDURE SP_ObtenerInsumoPorNombre
    @nombre NVARCHAR(100)
AS
BEGIN
    SELECT i.codigo, i.nombre, i.descripcion, i.cantidad, i.codigoSprint, s.nombre AS nombreSprint
    FROM insumo i
	INNER JOIN sprint s ON i.codigoSprint = s.codigo
    WHERE i.nombre = @nombre
END
GO

-- Actualizar insumo
CREATE OR ALTER PROCEDURE SP_ActualizarInsumo
    @codigo INT,
	@nombre NVARCHAR(100),
	@descripcion NVARCHAR(255),
	@cantidad INT,
	@codigoSprint INT
AS
BEGIN
    UPDATE insumo
    SET nombre = @nombre,
        descripcion = @descripcion,
		cantidad = @cantidad,
        codigoSprint = @codigo
    WHERE codigo = @codigo
END
GO

-- Eliminar insumo
CREATE OR ALTER PROCEDURE SP_EliminarInsumo
    @codigo INT
AS
BEGIN
    DELETE FROM insumo WHERE codigo = @codigo
END
GO

-- Buscar insumos por nombre
CREATE OR ALTER PROCEDURE SP_BuscarInsumosPorNombre
    @nombre NVARCHAR(100)
AS
BEGIN
    SELECT i.codigo, i.nombre, i.descripcion, i.cantidad, i.codigoSprint, s.nombre AS nombreSprint
    FROM insumo i
    INNER JOIN sprint s ON i.codigoSprint = s.codigo
    WHERE i.nombre LIKE @nombre
    ORDER BY i.codigo
END
GO

-- Registrar Actividad
DROP PROCEDURE IF EXISTS SP_RegistrarActividad
GO

CREATE OR ALTER PROCEDURE SP_RegistrarActividad
    @nombre NVARCHAR(100),
    @descripcion NVARCHAR(MAX),
    @progreso INT,
    @codigoTipo INT,
    @codigoSprint INT,
    @codigoEstado INT
AS
BEGIN
    INSERT INTO actividad (nombre, descripcion, progreso, codigoTipo, codigoSprint, codigoEstado)
    VALUES (@nombre, @descripcion, @progreso, @codigoTipo, @codigoSprint, @codigoEstado)
END
GO

-- Obtener las primeras 30 actividades
DROP PROCEDURE IF EXISTS SP_ObtenerPrimeras30Actividades
GO

CREATE OR ALTER PROCEDURE SP_ObtenerPrimeras30Actividades
AS
BEGIN
    SELECT TOP 30 
        a.codigo,
        a.nombre,
        a.descripcion,
        a.progreso,
        t.nombre AS NombreTipo,
        s.nombre AS NombreSprint,
        e.nombre AS NombreEstado
    FROM 
        actividad a
    INNER JOIN 
        tipo_actividad t ON a.codigoTipo = t.codigo
    INNER JOIN 
        sprint s ON a.codigoSprint = s.codigo
    INNER JOIN 
        estado e ON a.codigoEstado = e.codigo
    ORDER BY 
        a.nombre;
END
GO


-- Obtener actividad por nombre
DROP PROCEDURE IF EXISTS SP_ObtenerActividadPorNombre
GO

CREATE OR ALTER PROCEDURE SP_ObtenerActividadPorNombre
    @nombre NVARCHAR(100)
AS
BEGIN
    SELECT 
        a.Codigo, 
        a.Nombre, 
        a.Descripcion, 
        a.Progreso, 
        t.Nombre AS NombreTipo,
        s.Nombre AS NombreSprint,
        e.Nombre AS NombreEstado
    FROM Actividad a
    INNER JOIN tipo_actividad t ON a.codigoTipo = t.Codigo
    INNER JOIN sprint s ON a.codigoSprint = s.Codigo
    INNER JOIN estado e ON a.codigoEstado = e.Codigo
    WHERE a.Nombre = @nombre
END
GO


-- Actualizar actividad
GO
CREATE OR ALTER PROCEDURE SP_ActualizarActividad
    @codigo INT,
    @nombre NVARCHAR(100),
    @descripcion NVARCHAR(MAX),
    @progreso INT,
    @codigoTipo INT,
    @codigoSprint INT,
    @codigoEstado INT
AS
BEGIN
    UPDATE Actividad
    SET Nombre = @nombre,
        Descripcion = @descripcion,
        Progreso = @progreso,
        codigoTipo = @codigoTipo,
        codigoSprint = @codigoSprint,
        codigoEstado = @codigoEstado
    WHERE Codigo = @codigo
END
GO


-- Eliminar actividad
CREATE OR ALTER PROCEDURE SP_EliminarActividad
    @codigo INT
AS
BEGIN
    DELETE FROM Actividad
    WHERE Codigo = @codigo
END
GO

-- Buscar actividades por nombre
CREATE OR ALTER PROCEDURE SP_BuscarActividadesPorNombre
    @nombre NVARCHAR(100)
AS
BEGIN
    SELECT 
        a.Codigo, 
        a.Nombre, 
        a.Descripcion, 
        a.Progreso, 
        t.Nombre AS NombreTipo,
        s.Nombre AS NombreSprint,
        e.Nombre AS NombreEstado
    FROM Actividad a
    INNER JOIN tipo_actividad t ON a.codigoTipo = t.Codigo
    INNER JOIN sprint s ON a.codigoSprint = s.Codigo
    INNER JOIN estado e ON a.codigoEstado = e.Codigo
    WHERE a.Nombre LIKE '%' + @nombre + '%'
    ORDER BY a.Codigo
END
GO


-- Para llenar el combo box de tipos (de actividades)
CREATE OR ALTER PROCEDURE SP_ObtenerTipos
AS
BEGIN
    SELECT 
        Codigo, 
        Nombre
    FROM 
        tipo_actividad
    ORDER BY 
        Nombre;
END;
GO


-- Para llenar el combo box de estados
CREATE OR ALTER PROCEDURE SP_ObtenerEstados
AS
BEGIN
    SELECT 
        Codigo, 
        Nombre
    FROM 
        estado
    ORDER BY 
        Nombre;
END;
GO

-- ====================================== Vieira Abad Collins Pool ======================================
CREATE OR ALTER PROCEDURE SP_BuscarEquipoPorID
    @codigo INT
AS
BEGIN
    SELECT codigo, nombre, imgUrl 
    FROM equipo 
    WHERE codigo = @codigo
END;
GO

CREATE OR ALTER PROCEDURE SP_RegistrarEquipo
    @Nombre VARCHAR(255),
    @imgUrl VARCHAR(255)
AS
BEGIN
    INSERT INTO equipo (nombre, imgUrl)
    VALUES (@Nombre, @imgUrl)
END;
GO

CREATE OR ALTER PROCEDURE SP_ListarUltimos25Equipos
AS
BEGIN
    SELECT TOP 25 codigo, nombre, imgUrl
    FROM equipo
    ORDER BY codigo DESC
END;
GO

CREATE OR ALTER PROCEDURE SP_RegistrarProyecto
    @Nombre VARCHAR(255),
    @Descripcion VARCHAR(255),
    @FechaInicio DATE,
    @FechaFin DATE,
    @Progreso INT,
    @CodigoLider INT,
    @CodigoEquipo INT,
    @CodigoEstado INT,
    @imgUrl VARCHAR(255)
AS
BEGIN
    INSERT INTO proyecto (nombre, descripcion, fechaInicio, fechaFin, progreso, codigoLider, codigoEquipo, codigoEstado, imgUrl)
    VALUES (@Nombre, @Descripcion, @FechaInicio, @FechaFin, @Progreso, @CodigoLider, @CodigoEquipo, @CodigoEstado, @imgUrl)
END;
GO

CREATE OR ALTER PROCEDURE SP_ObtenerProyectoPorID
    @codigo INT
AS
BEGIN
    SELECT 
        p.codigo,
        p.nombre,
        p.descripcion,
        p.fechaInicio,
        p.fechaFin,
        p.progreso,
        CONCAT(uL.nombres, ' ', uL.apellidos) AS Lider,
        STRING_AGG(CONCAT(ISNULL(u.nombres, ''), ' ', ISNULL(u.apellidos, '')), ', ') AS Equipo,
        e.nombre AS Estado,
        p.imgUrl
    FROM 
        proyecto AS p
    LEFT JOIN 
        equipo AS eq ON p.codigoEquipo = eq.codigo
    LEFT JOIN 
        equipo_usuario AS equ ON eq.codigo = equ.codigoEquipo
    LEFT JOIN 
        usuario AS u ON equ.codigoUsuario = u.codigo
    LEFT JOIN 
        usuario AS uL ON p.codigoLider = uL.codigo
    LEFT JOIN 
        estado AS e ON p.codigoEstado = e.codigo
    WHERE 
        p.codigo = @codigo
    GROUP BY 
        p.codigo, p.nombre, p.descripcion, p.fechaInicio, p.fechaFin, p.progreso,
        uL.nombres, uL.apellidos, e.nombre, p.imgUrl;
END;
GO

CREATE OR ALTER PROCEDURE SP_ObtenerProyectosUsuarioLiderProyecto
AS
BEGIN
    SELECT TOP 25
        p.codigo,
        p.nombre AS Proyecto,
        STRING_AGG(CONCAT(u.nombres, ' ', u.apellidos), ', ') AS Equipo,
        CONCAT(uL.nombres, ' ', uL.apellidos) AS Lider,
        p.imgUrl
    FROM 
        proyecto AS p 
    LEFT JOIN 
        equipo AS eq ON p.codigoEquipo = eq.codigo
    LEFT JOIN 
        equipo_usuario AS equ ON eq.codigo = equ.codigoEquipo
    LEFT JOIN 
        usuario AS u ON equ.codigoUsuario = u.codigo
    INNER JOIN 
        usuario AS uL ON p.codigoLider = uL.codigo
    GROUP BY 
        p.nombre, uL.nombres, uL.apellidos, p.codigo, p.imgUrl
    ORDER BY 
        p.codigo DESC;
END;
GO

CREATE OR ALTER PROCEDURE SP_RegistrarEquipoProyecto
    @codigoEquipo INT,
    @codigoUsuario INT
AS
BEGIN
    INSERT INTO equipo_usuario(codigoEquipo, codigoUsuario)
    VALUES(@codigoEquipo, @codigoUsuario)
END;
GO

CREATE OR ALTER PROCEDURE SP_BuscarEquipoUsuarios
    @codigoEquipo INT
AS
BEGIN
    SELECT 
        e.codigo AS CodigoEquipo,
        e.nombre AS NombreEquipo,
        e.imgUrl AS ImagenEquipo,
        u.codigo AS CodigoUsuario,
        u.nombreUsuario AS NombreUsuario,
        u.correo AS CorreoUsuario,
        u.nombres AS NombresUsuario,
        u.apellidos AS ApellidosUsuario,
        u.codigoRol AS CodigoRolUsuario,
        u.ImgUrl AS ImagenUsuario
    FROM 
        equipo e
    INNER JOIN 
        equipo_usuario eu ON e.codigo = eu.codigoEquipo
    INNER JOIN 
        usuario u ON eu.codigoUsuario = u.codigo
    WHERE 
        e.codigo = @codigoEquipo
    ORDER BY 
        e.codigo, u.codigo; -- Ordena por el c�digo del equipo y luego por el c�digo del usuario
END;
GO

CREATE OR ALTER PROCEDURE SP_EliminarUsuarioDeEquipo
    @codigoEquipo INT,
    @codigoUsuario INT
AS
BEGIN
    DELETE FROM equipo_usuario
    WHERE codigoEquipo = @codigoEquipo AND codigoUsuario = @codigoUsuario
END;
GO

CREATE OR ALTER PROCEDURE SP_ObtenerUltimos25Proyectos
AS
BEGIN
    SELECT TOP 50
        nombre,
        descripcion,
        fechaInicio,
        fechaFin,
        progreso,
        codigoLider,
        codigoEquipo,
        codigoEstado,
        imgUrl
    FROM 
        proyecto
    ORDER BY codigo DESC;
END;
GO

CREATE OR ALTER PROCEDURE SP_ObtenerLideresProyectos
AS
BEGIN
    SELECT
        CONCAT(u.nombres, ' ', u.apellidos) AS nombres,
        u.codigo
    FROM 
        usuario AS u
    INNER JOIN
        rol AS r ON u.codigoRol = r.codigo
    WHERE 
        r.codigo = 3
END;
GO

CREATE OR ALTER PROCEDURE SP_ObtenerEquiposProyectos
AS
BEGIN
    SELECT TOP 50
    * 
    FROM
        equipo
    ORDER BY codigo DESC;
END;
GO

-- ========================== Procedimientos JORGE MAZA ===============================

--Procedimiento Listar los primeros 25 filas
CREATE OR ALTER PROCEDURE SP_ListarEtiquetas
AS
BEGIN
    SELECT TOP 25 codigo, nombre
    FROM etiqueta
    WHERE eliminado = 'N'
    ORDER BY codigo DESC;
END;
GO
exec sp_ListarEtiquetas
GO

--Procedimiento para insertar una etiqueta
CREATE or ALTER PROCEDURE sp_InsertarEtiqueta
    @nombre VARCHAR(100)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM etiqueta WHERE nombre = @nombre AND eliminado = 'N')
    BEGIN
        INSERT INTO etiqueta (nombre, eliminado)
        VALUES (@nombre, 'N');
    END
    ELSE
    BEGIN
        RAISERROR('El nombre de la etiqueta ya existe o est� eliminado.', 16, 1);
    END
END;
GO
--Procedimiento para actualizar una etiqueta

CREATE OR ALTER PROCEDURE sp_ActualizarEtiqueta
    @codigo INT,
    @nombre VARCHAR(100)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM etiqueta WHERE codigo = @codigo AND eliminado = 'N')
    BEGIN
        UPDATE etiqueta
        SET nombre = @nombre
        WHERE codigo = @codigo;
    END
    ELSE
    BEGIN
        RAISERROR('La etiqueta no existe o est� eliminada.', 16, 1);
    END
END;
GO

--Procedimiento para buscar una etiqueta
CREATE OR ALTER PROCEDURE SP_BuscarEtiquetaPorNombre
    @nombre VARCHAR(100)
AS
BEGIN
    SELECT codigo, nombre, eliminado
    FROM etiqueta
    WHERE nombre LIKE '%' + @nombre + '%'
      AND eliminado = 'N'
    ORDER BY nombre;
END;
GO

--Procedimiento para borrar de forma logica una etiqueta(se creo un propiedad eliminado en la tabla)--
CREATE OR ALTER PROCEDURE SP_EliminarEtiqueta
    @codigo INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM etiqueta WHERE codigo = @codigo AND eliminado = 'N')
    BEGIN
        UPDATE etiqueta
        SET eliminado = 'S'
        WHERE codigo = @codigo;
    END
    ELSE
    BEGIN
        RAISERROR('La etiqueta no existe o ya est� eliminada.', 16, 1);
    END
END;
GO

--Procedimiento de Obtener Etiqueta por ID de Tarea --
CREATE OR ALTER PROCEDURE SP_ObtenerEtiquetasPorIdTarea
    @TareaID INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Selecciona las etiquetas asociadas al ID de tarea especificado
    SELECT 
        t.codigo AS CodigoTarea,          -- Muestra el c�digo de la tarea
        t.nombre AS NombreTarea,          -- Muestra el nombre de la tarea
        e.codigo AS CodigoEtiqueta,      -- Muestra el c�digo de la etiqueta
        e.nombre AS NombreEtiqueta       -- Muestra el nombre de la etiqueta
    FROM 
        tarea_etiqueta te
    INNER JOIN 
        etiqueta e ON te.codigoEtiqueta = e.codigo
    INNER JOIN
        tarea t ON te.codigoTarea = t.codigo   -- Corregido para unir con la tarea usando el c�digo de tarea
    WHERE 
        te.codigoTarea = @TareaID        -- Filtra por el ID de la tarea
		AND te.eliminado ='N'           
	ORDER BY 
        e.codigo;  -- Ordena las etiquetas por su c�digo
END;
GO


CREATE OR ALTER PROCEDURE SP_InsertarTareaEtiqueta
    @codigoTarea INT,
    @codigoEtiqueta INT
AS
BEGIN
    -- Verificar si existe una relaci�n con la etiqueta eliminada ('S')
    IF EXISTS (
        SELECT 1
        FROM tarea_etiqueta
        WHERE codigoTarea = @codigoTarea
          AND codigoEtiqueta = @codigoEtiqueta
          AND eliminado = 'S'
    )
    BEGIN
        -- Actualizar la relaci�n existente, cambiando 'eliminado' a 'N'
        UPDATE tarea_etiqueta
        SET eliminado = 'N'
        WHERE codigoTarea = @codigoTarea
          AND codigoEtiqueta = @codigoEtiqueta
          AND eliminado = 'S';
          
        PRINT 'Asignacion de etiqueta restaurada exitosamente.';
    END
    ELSE IF NOT EXISTS (
        -- Verificar si no existe la relaci�n en absoluto
        SELECT 1
        FROM tarea_etiqueta
        WHERE codigoTarea = @codigoTarea
          AND codigoEtiqueta = @codigoEtiqueta
    )
    BEGIN
        -- Insertar la nueva relaci�n
        INSERT INTO tarea_etiqueta (codigoTarea, codigoEtiqueta, eliminado)
        VALUES (@codigoTarea, @codigoEtiqueta, 'N');
        
        PRINT 'Asignacion de etiqueta agregada exitosamente.';
    END
    ELSE
    BEGIN
        PRINT 'Asignacion de etiqueta ya existe.';
    END
END;
GO

CREATE OR ALTER PROCEDURE SP_EliminarTareaEtiqueta
    @codigoTarea INT,
    @codigoEtiqueta INT
AS
BEGIN
    -- Verificar si la relaci�n existe y no est� eliminada
    IF EXISTS (
        SELECT 1
        FROM tarea_etiqueta
        WHERE codigoTarea = @codigoTarea
        AND codigoEtiqueta = @codigoEtiqueta
        AND eliminado = 'N' -- Verifica que la relaci�n no est� eliminada
    )
    BEGIN
        -- Actualizar la columna 'eliminado' a 'S' (o el valor que uses para marcar como eliminado)
        UPDATE tarea_etiqueta
        SET eliminado = 'S'
        WHERE codigoTarea = @codigoTarea
        AND codigoEtiqueta = @codigoEtiqueta;

        PRINT 'Relaci�n de tarea y etiqueta eliminada l�gicamente.';
    END
    ELSE
    BEGIN
        PRINT 'La relaci�n de tarea y etiqueta no existe o ya est� eliminada.';
    END
END;
GO


-- CODIGO PARA OBTENER EL CODIGO DEL PROCEDIMIENTO ALMACENADO

SELECT 
    sm.definition AS Codigo_Procedimiento
FROM 
    sys.sql_modules AS sm
JOIN 
    sys.objects AS o ON sm.object_id = o.object_id
WHERE 
    o.name = 'sp_ObtenerEstados' AND o.type = 'P';

		-- REGISTRAR TAREA
GO

CREATE OR ALTER PROCEDURE SP_RegistrarTarea
    @nombre VARCHAR(100),
    @descripcion VARCHAR(255),
    @fechaInicio DATE,
    @fechaVencimiento DATE,
    @prioridad INT,
    @progreso INT,
    @codigoUsuario INT,
    @codigoActividad INT,
    @codigoEstado INT
AS
BEGIN
    -- Insertar la nueva tarea con la fecha de actualizaci�n igual a la fecha de inicio
    INSERT INTO tarea (
        nombre, 
        descripcion, 
        fechaInicio, 
        fechaVencimiento, 
        prioridad, 
        progreso, 
        codigoUsuario, 
        codigoActividad, 
        codigoEstado, 
        fechaActualizacion
    )
    VALUES (
        @nombre, 
        @descripcion, 
        @fechaInicio, 
        @fechaVencimiento, 
        @prioridad, 
        @progreso, 
        @codigoUsuario, 
        @codigoActividad, 
        @codigoEstado, 
        @fechaInicio
    );
END;
GO

-- SP PARA MODIFICAR - ACTUALIZAR TAREA
	CREATE OR ALTER PROCEDURE SP_ActualizarTarea
    @codigo INT,
    @nombre NVARCHAR(100),
    @descripcion NVARCHAR(MAX),
    @fechaVencimiento DATETIME,
    @prioridad INT,
    @progreso INT,
    @codigoUsuario INT,
    @codigoActividad INT,
    @codigoEstado INT,
    @fechaActualizacion DATETIME
AS  
BEGIN
    UPDATE Tarea
    SET 
        nombre = @nombre,
        descripcion = @descripcion,
        fechaVencimiento = @fechaVencimiento,
        prioridad = @prioridad,
        progreso = @progreso,
        codigoUsuario = @codigoUsuario,
        codigoActividad = @codigoActividad,
        codigoEstado = @codigoEstado,
        fechaActualizacion = @fechaActualizacion
    WHERE 
        codigo = @codigo;
END;
GO

-- SP PARA EL BUSCAR TAREA POR NOMBRE
CREATE OR ALTER PROCEDURE SP_ObtenerTareaPorNombre
    @nombre NVARCHAR(255)
AS  
BEGIN
    SELECT * 
    FROM Tarea 
    WHERE Nombre LIKE '%' + @nombre + '%';
END;
GO

-- SP PARA OBTENER TAREAS 
CREATE OR ALTER PROCEDURE SP_ObtenerPrimeras30Tareas  
AS  
BEGIN
    SELECT TOP 30 * 
    FROM tarea
    ORDER BY codigo ASC;
END;
GO

-- SP PARA ELIMINAR TAREA DE FORMA LOGICA
CREATE OR ALTER PROCEDURE SP_EliminarTarea
    @codigoTarea INT
AS  
BEGIN
    -- Actualizamos la tarea, cambiando su estado a "Eliminado"
    UPDATE tarea
    SET 
        codigoEstado = (SELECT codigo FROM estado WHERE nombre = 'Eliminado'),
        fechaActualizacion = GETDATE()  -- Actualizamos la fecha de actualizaci�n al momento actual
    WHERE 
        codigo = @codigoTarea;
END;
GO

-- SP PARA OBTENER LOS ESTADOS
CREATE OR ALTER PROCEDURE sp_ObtenerEstados  
AS  
BEGIN
    SELECT 
        codigo, 
        nombre
    FROM 
        estado;
END;
GO

-- SP PARA OBTENER ACTIVIDADES
CREATE OR ALTER PROCEDURE sp_ObtenerActividades  
AS  
BEGIN
    SELECT 
        codigo, 
        nombre
    FROM 
        actividad;
END;
GO

-- SP PARA OBTENER USUARIOS
CREATE OR ALTER PROCEDURE sp_ObtenerUsuarios  
AS  
BEGIN
    SELECT 
        codigo, 
        nombres + ' ' + apellidos AS nombre
    FROM 
        usuario;
END;
GO


-- ////////////////////////////////////////////////////////
--         PROCEDIMIENTOS ALMACENADOS PARA TAREA
-- ////////////////////////////////////////////////////////


-- $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
-- $$$$$$$$$$ SP PARA REGISTRAR COMENTARIO $$$$$$$$$$
-- $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

CREATE OR ALTER PROCEDURE SP_RegistrarComentario
    @contenido VARCHAR(100),
    @fechaCreacion DATE,
    @codigoTarea INT,
    @codigoUsuario INT,
    @imgUrl VARCHAR(255)
AS
BEGIN
    INSERT INTO comentario (contenido, fechaCreacion, codigoTarea, codigoUsuario, imgUrl)
    VALUES (@contenido, @fechaCreacion, @codigoTarea, @codigoUsuario, @imgUrl);
END;
GO



-- $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
-- $$$$$$$$$$ SP PARA OBTENER PRIMEROS 30 COMENTARIOS $$$$$$$$$
-- $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

CREATE OR ALTER PROCEDURE SP_ObtenerPrimeros30Comentarios
AS
BEGIN
    SELECT
        comentario.codigo,
        comentario.contenido,
        comentario.fechaCreacion,
        tarea.nombre AS nombreTarea,
        usuario.nombreUsuario AS nombreUsuario,
        comentario.imgUrl
    FROM comentario
    INNER JOIN tarea ON comentario.codigoTarea = tarea.codigo
    INNER JOIN usuario ON comentario.codigoUsuario = usuario.codigo
    ORDER BY comentario.codigo ASC
    OFFSET 0 ROWS FETCH NEXT 30 ROWS ONLY;
END;
GO

-- $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
-- $$$$$$$$$ SP PARA OBTENER COMENTARIOS POR CODIGO $$$$$$$$
-- $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

CREATE OR ALTER PROCEDURE SP_ObtenerComentarioPorCodigo
    @codigo INT
AS
BEGIN
    SELECT * FROM comentario WHERE codigo = @codigo;
END;
GO




-- $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
-- $$$$$$$$$ SP PARA OBTENER COMENTARIOS POR CONTENIDO $$$$$$$$
-- $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

CREATE OR ALTER PROCEDURE SP_BuscarComentarioPorContenido
    @contenido VARCHAR(100)
AS
BEGIN
    SELECT
        c.codigo,
        c.contenido,
        c.fechaCreacion,
        c.codigoTarea,
        c.codigoUsuario,
        c.imgUrl,
        t.nombre AS NombreTarea,
        u.nombreUsuario AS NombreUsuario
    FROM comentario c
    INNER JOIN tarea t ON c.codigoTarea = t.codigo
    INNER JOIN usuario u ON c.codigoUsuario = u.codigo
    WHERE c.contenido LIKE '%' + @contenido + '%';
END;
GO


-- $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
-- $$$$$$$$$$ SP PARA OBTENER ACTUALIZAR COMENTARIOS $$$$$$$$$$
-- $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

CREATE OR ALTER PROCEDURE SP_ActualizarComentario
    @codigo INT,
    @contenido VARCHAR(100),
    @imgUrl VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE comentario
    SET
        contenido = @contenido,
        imgUrl = @imgUrl
    WHERE
        codigo = @codigo;
END;
GO



-- $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
-- $$$$$$$$$$ SP PARA ELIMINAR COMENTARIOS $$$$$$$$$$
-- $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ 

CREATE OR ALTER PROCEDURE SP_EliminarComentario
    @codigo INT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM comentario WHERE codigo = @codigo)
    BEGIN
        DELETE FROM comentario WHERE codigo = @codigo;
        PRINT 'Comentario eliminado exitosamente';
    END
    ELSE
    BEGIN
        PRINT 'No se encontr� un comentario con el c�digo proporcionado';
    END
END;
GO

-- $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
-- $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ 


-- ////////////////////////////////////////////////////////
--         PROCEDIMIENTOS ALMACENADOS PARA TAREA
-- ////////////////////////////////////////////////////////



-- $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
-- $$$$$$$$$$ SP PARA REGISTRAR TAREA $$$$$$$$$$
-- $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

CREATE OR ALTER PROCEDURE SP_RegistrarTarea
    @nombre VARCHAR(100),
    @descripcion VARCHAR(255),
    @fechaInicio DATE,
    @fechaVencimiento DATE,
    @prioridad INT,
    @progreso INT,
    @codigoUsuario INT,
    @codigoActividad INT,
    @codigoEstado INT
AS
BEGIN
    INSERT INTO tarea (nombre, descripcion, fechaInicio, fechaVencimiento, prioridad, progreso, codigoUsuario, codigoActividad, codigoEstado, fechaActualizacion)
    VALUES (@nombre, @descripcion, @fechaInicio, @fechaVencimiento, @prioridad, @progreso, @codigoUsuario, @codigoActividad, @codigoEstado, @fechaInicio);
END;
GO

-- $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
-- $$$$$$$$$$ SP PARA ObtenerTareaPorNombre $$$$$$$$$$
-- $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

CREATE OR ALTER PROCEDURE SP_ObtenerTareaPorNombre
    @nombre NVARCHAR(100)
AS
BEGIN
    SELECT
        t.Codigo,
        t.Nombre,
        t.Descripcion,
        t.FechaInicio,
        t.FechaActualizacion,  
        t.FechaVencimiento,
        t.Prioridad,
        t.Progreso,
        t.CodigoUsuario,
        u.nombres AS NombreUsuario,
        t.CodigoActividad,
        a.Nombre AS NombreActividad,
        t.CodigoEstado,
        e.Nombre AS NombreEstado
    FROM Tarea t
    INNER JOIN Usuario u ON t.CodigoUsuario = u.Codigo
    INNER JOIN Actividad a ON t.CodigoActividad = a.Codigo
    INNER JOIN Estado e ON t.CodigoEstado = e.Codigo
    WHERE t.Nombre LIKE '%' + @nombre + '%';
END;
GO



-- $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
-- $$$$$$$$$$ SP PARA SP_BuscarComentarioPorContenido $$$$$$$$$$
-- $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$


CREATE OR ALTER PROCEDURE SP_BuscarComentarioPorContenido
    @contenido VARCHAR(100)
AS
BEGIN
    SELECT
        c.codigo,
        c.contenido,
        c.fechaCreacion,
        c.codigoTarea,
        c.codigoUsuario,
        c.imgUrl,
        t.nombre AS NombreTarea,
        u.nombreUsuario AS NombreUsuario
    FROM comentario c
    INNER JOIN tarea t ON c.codigoTarea = t.codigo
    INNER JOIN usuario u ON c.codigoUsuario = u.codigo
    WHERE c.contenido LIKE '%' + @contenido + '%';  
END;
GO





-- $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
-- $$$$$$$$$$ SP PARA ActualizarTarea $$$$$$$$$$
-- $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$


CREATE OR ALTER PROCEDURE SP_ActualizarTarea
    @codigo INT,
    @nombre NVARCHAR(100),
    @descripcion NVARCHAR(MAX),
    @fechaVencimiento DATETIME,
    @prioridad INT,
    @progreso INT,
    @codigoUsuario INT,
    @codigoActividad INT,
    @codigoEstado INT,
    @fechaActualizacion DATETIME
AS
BEGIN
    UPDATE Tarea
    SET
        nombre = @nombre,
        descripcion = @descripcion,
        fechaVencimiento = @fechaVencimiento,
        prioridad = @prioridad,
        progreso = @progreso,
        codigoUsuario = @codigoUsuario,
        codigoActividad = @codigoActividad,
        codigoEstado = @codigoEstado,
        fechaActualizacion = @fechaActualizacion
    WHERE
        codigo = @codigo;
END;
GO




-- $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
-- $$$$$$$$$$ SP PARA EliminarTarea $$$$$$$$$$
-- $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

CREATE OR ALTER PROCEDURE SP_EliminarTarea
    @codigoTarea INT
AS
BEGIN
    UPDATE tarea
    SET
        codigoEstado = (SELECT codigo FROM estado WHERE nombre = 'Eliminado'),
        fechaActualizacion = GETDATE()  
    WHERE
        codigo = @codigoTarea;
END;
GO




-- $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
-- $$$$$$$$$$ SP PARA ObtenerUsuarios $$$$$$$$$$
-- $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

CREATE OR ALTER PROCEDURE sp_ObtenerUsuarios
AS
BEGIN
    SELECT
        codigo,
        nombres + ' ' + apellidos AS nombre
    FROM usuario;
END;
GO

-- $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
-- $$$$$$$$$$ SP PARA ObtenerActividades $$$$$$$$$$
-- $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

CREATE OR ALTER PROCEDURE sp_ObtenerActividades
AS
BEGIN
    SELECT
        codigo,
        nombre
    FROM actividad;
END;
GO


-- $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
-- $$$$$$$$$$ SP PARA ObtenerEstados $$$$$$$$$$
-- $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

CREATE OR ALTER PROCEDURE sp_ObtenerEstados
AS
BEGIN
    SELECT
        codigo,
        nombre
    FROM estado;
END;
GO

-- $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
-- $$$$$$$$$$ SP PARA ObtenerPrimeras30Tareas $$$$$$$$$$
-- $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$


CREATE OR ALTER PROCEDURE SP_ObtenerPrimeras30Tareas
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        t.codigo AS Codigo,
        t.nombre AS Nombre,
        t.descripcion AS Descripcion,
        t.fechaInicio AS FechaInicio,
        t.fechaActualizacion AS FechaActualizacion,
        t.fechaVencimiento AS FechaVencimiento,
        t.prioridad AS Prioridad,
        t.progreso AS Progreso,
        u.codigo AS CodigoUsuario,
        u.nombreUsuario AS NombreUsuario,
        a.codigo AS CodigoActividad,
        a.nombre AS NombreActividad,
        e.codigo AS CodigoEstado,
        e.nombre AS NombreEstado
    FROM tarea t
    LEFT JOIN usuario u ON t.codigoUsuario = u.codigo
    LEFT JOIN actividad a ON t.codigoActividad = a.codigo
    LEFT JOIN estado e ON t.codigoEstado = e.codigo
    ORDER BY t.codigo ASC
    OFFSET 0 ROWS FETCH NEXT 30 ROWS ONLY;
END;
GO

-- --------------------------
-- Stored Procedure to Create a Sprint
CREATE OR ALTER PROCEDURE SP_CrearSprint
    @nombre VARCHAR(100),
    @fechaInicio DATE,
    @fechaFin DATE,
    @codigoLider INT,
    @codigoProyecto INT
AS
BEGIN
    INSERT INTO sprint (nombre, progreso, fechaInicio, fechaFin, codigoLider, codigoProyecto)
    VALUES (@nombre, 0, @fechaInicio, @fechaFin, @codigoLider, @codigoProyecto)
END
GO

-- Stored Procedure to Read Sprints
CREATE OR ALTER PROCEDURE SP_ObtenerSprints
AS
BEGIN
	   SELECT 
		s.codigo,
		s.nombre,
		s.progreso,
		s.fechaInicio,
		s.fechaFin,
		l.codigo AS codigoLider,
		l.nombres AS lider,
		p.codigo AS codigoProyecto,
		p.nombre AS proyecto
	FROM 
		Sprint s
	JOIN 
		Usuario l ON s.codigoLider = l.codigo
	JOIN 
		Proyecto p ON s.codigoProyecto = p.codigo
    ORDER BY 
        s.fechaInicio DESC
END
GO

-- Stored Procedure to Update a Sprint
CREATE OR ALTER PROCEDURE SP_ActualizarSprint
    @codigo INT,
    @nombre VARCHAR(100),
    @fechaInicio DATE,
    @fechaFin DATE,
    @codigoLider INT,
    @codigoProyecto INT
AS
BEGIN
    UPDATE sprint
    SET nombre = @nombre,
        fechaInicio = @fechaInicio,
        fechaFin = @fechaFin,
        codigoLider = @codigoLider,
        codigoProyecto = @codigoProyecto
    WHERE codigo = @codigo
END
GO

-- Stored Procedure to Delete a Sprint
CREATE OR ALTER PROCEDURE SP_EliminarSprint
    @codigo INT
AS
BEGIN
    DELETE FROM sprint WHERE codigo = @codigo
END
GO

-- Stored Procedure to Search Sprints by Name
CREATE OR ALTER PROCEDURE SP_BuscarSprintsPorNombre
    @nombre VARCHAR(100)
AS
BEGIN
    SELECT s.codigo, s.nombre, s.progreso, s.fechaInicio, s.fechaFin, 
           u.nombreUsuario AS lider, p.nombre AS proyecto
    FROM sprint s
    INNER JOIN usuario u ON s.codigoLider = u.codigo
    INNER JOIN proyecto p ON s.codigoProyecto = p.codigo
    WHERE s.nombre LIKE '%' + @nombre + '%'
    ORDER BY s.fechaInicio DESC
END
GO

-- Stored Procedure to Get L�deres
CREATE OR ALTER PROCEDURE SP_ObtenerLideres
AS
BEGIN
    SELECT codigo, CONCAT(nombres, ' ', apellidos) AS nombreCompleto
    FROM usuario
    WHERE codigoRol = (SELECT codigo FROM rol WHERE nombre = 'L�der de Sprint')
END
GO

-- Stored Procedure to Get Proyectos
CREATE OR ALTER PROCEDURE SP_ObtenerProyectos
AS
BEGIN
    SELECT codigo, nombre
    FROM proyecto
END
GO

-- ----------------------------------------- --
--                    W E B                  --
-- ----------------------------------------- --

CREATE OR ALTER PROCEDURE SP_ObtenerProyectosPorUsuario
    @CodigoUsuario INT
AS
BEGIN
    SELECT DISTINCT p.codigo, p.nombre, p.progreso, p.descripcion, p.fechaInicio, p.fechaFin, p.imgUrl,
                    u.codigo AS codigoLider, u.nombreUsuario AS nombreLider, u.nombres AS nombresLider, u.apellidos AS apellidosLider,
                    e.codigo AS codigoEquipo, e.nombre AS nombreEquipo,
                    es.codigo AS codigoEstado, es.nombre AS nombreEstado
    FROM proyecto p
    INNER JOIN equipo_usuario eu ON p.codigoEquipo = eu.codigoEquipo
    INNER JOIN usuario u ON p.codigoLider = u.codigo
    INNER JOIN equipo e ON p.codigoEquipo = e.codigo
    INNER JOIN estado es ON p.codigoEstado = es.codigo
    WHERE eu.codigoUsuario = @CodigoUsuario
END
GO


CREATE OR ALTER PROCEDURE SP_CrearProyecto
    @Nombre VARCHAR(255),
    @Descripcion VARCHAR(255),
    @ImgUrl VARCHAR(255),
    @CodigoLider INT,
    @NombreEquipo VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @FechaInicio DATE = GETDATE();
    DECLARE @FechaFin DATE = DATEADD(WEEK, 1, @FechaInicio);
    DECLARE @CodigoEstado INT = 1;
    DECLARE @Progreso INT = 0;

    -- Insertar equipo
    INSERT INTO equipo (nombre)
    VALUES (@NombreEquipo);
    DECLARE @CodigoEquipo INT = SCOPE_IDENTITY();

    -- Asignar usuario al equipo
    INSERT INTO equipo_usuario (codigoEquipo, codigoUsuario)
    VALUES (@CodigoEquipo, @CodigoLider);

    -- Insertar proyecto
    INSERT INTO proyecto (
        nombre,
        descripcion,
        imgUrl,
        codigoLider,
        codigoEquipo,
        fechaInicio,
        fechaFin,
        codigoEstado,
        progreso
    )
    VALUES (
        @Nombre,
        @Descripcion,
        @ImgUrl,
        @CodigoLider,
        @CodigoEquipo,
        @FechaInicio,
        @FechaFin,
        @CodigoEstado,
        @Progreso
    );
    DECLARE @CodigoProyecto INT = SCOPE_IDENTITY();

    -- Asignar rol al usuario en el proyecto
    INSERT INTO rol_proyecto (codigoProyecto, codigoUsuario, codigoRol)
    VALUES (@CodigoProyecto, @CodigoLider, 3); -- Rol 3: Líder de Proyecto
END
GO 

CREATE OR ALTER PROCEDURE SP_ActualizarProyectoU
    @CodigoProyecto INT,
    @Nombre VARCHAR(255),
    @Descripcion VARCHAR(255),
    @ImgUrl VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE proyecto
    SET nombre = @Nombre,
        descripcion = @Descripcion,
        imgUrl = @ImgUrl
    WHERE codigo = @CodigoProyecto;
END
GO

CREATE OR ALTER PROCEDURE SP_EliminarProyecto
    @CodigoProyecto INT
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        BEGIN TRANSACTION;
            
        DECLARE @CodigoEquipo INT;
        SELECT @CodigoEquipo = codigoEquipo FROM proyecto WHERE codigo = @CodigoProyecto;
            
        DELETE FROM rol_proyecto WHERE codigoProyecto = @CodigoProyecto;
            
        DELETE FROM sprint WHERE codigoProyecto = @CodigoProyecto;
            
        DELETE FROM proyecto WHERE codigo = @CodigoProyecto;
            
        DELETE FROM equipo_usuario WHERE codigoEquipo = @CodigoEquipo;
            
        DELETE FROM equipo WHERE codigo = @CodigoEquipo;
            
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE SP_ActualizarEquipoProyecto
    @CodigoProyecto INT,
    @NombreEquipo VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE equipo
    SET nombre = @NombreEquipo
    WHERE codigo = (
        SELECT codigoEquipo 
        FROM proyecto 
        WHERE codigo = @CodigoProyecto
    );
END
GO

CREATE OR ALTER PROCEDURE SP_ObtenerProyectoId
    @CodigoProyecto INT
AS
BEGIN
    SELECT 
        p.*,
        e.codigo as codigoEquipo,
        e.nombre as nombreEquipo
    FROM proyecto p
    LEFT JOIN equipo e ON p.codigoEquipo = e.codigo
    WHERE p.codigo = @CodigoProyecto;
END
GO

CREATE OR ALTER PROCEDURE SP_ObtenerUsuariosPorProyecto
    @ProyectoId INT
AS
BEGIN
    SELECT DISTINCT
        u.codigo AS iCodigo,
        u.nombreUsuario AS sNombreUsuario,
        u.correo AS sCorreo,
        u.nombres AS sNombres,
        u.apellidos AS sApellidos,
        u.imgUrl AS sImgUrl,
        rp.codigoRol AS iCodigoRol,
        r.nombre AS sNombreRol
    FROM usuario u
    INNER JOIN equipo_usuario eu ON u.codigo = eu.codigoUsuario
    INNER JOIN equipo e ON eu.codigoEquipo = e.codigo
    INNER JOIN proyecto p ON p.codigoEquipo = e.codigo
    LEFT JOIN rol_proyecto rp ON rp.codigoUsuario = u.codigo AND rp.codigoProyecto = p.codigo
    LEFT JOIN rol r ON rp.codigoRol = r.codigo
    WHERE p.codigo = @ProyectoId;
END

CREATE PROCEDURE AgregarUsuarioAEquipo
    @EquipoId INT,
    @UsuarioId INT
AS
BEGIN
    INSERT INTO equipo_usuario (codigoEquipo, codigoUsuario)
    VALUES (@EquipoId, @UsuarioId)
END

CREATE OR ALTER PROCEDURE SP_AsignarRolUsuarioEnProyecto
    @CodigoProyecto INT,
    @CodigoUsuario INT,
    @CodigoRol INT
AS
BEGIN
    IF NOT EXISTS (
        SELECT 1 
        FROM rol_proyecto 
        WHERE codigoProyecto = @CodigoProyecto 
        AND codigoUsuario = @CodigoUsuario
    )
    BEGIN
        INSERT INTO rol_proyecto (codigoProyecto, codigoUsuario, codigoRol)
        VALUES (@CodigoProyecto, @CodigoUsuario, @CodigoRol)
    END
    ELSE
    BEGIN
        UPDATE rol_proyecto
        SET codigoRol = @CodigoRol
        WHERE codigoProyecto = @CodigoProyecto 
        AND codigoUsuario = @CodigoUsuario
    END
END

CREATE OR ALTER PROCEDURE SP_ObtenerUsuarioPorCorreo
    @Correo NVARCHAR(255)
AS
BEGIN
    SELECT 
        u.codigo AS iCodigo,
        u.nombreUsuario AS sNombreUsuario,
        u.correo AS sCorreo,
        u.nombres AS sNombres,
        u.apellidos AS sApellidos,
        u.imgUrl AS sImgUrl,
        u.codigoRol AS iCodigoRol,
        r.nombre AS sNombreRol
    FROM usuario u
    INNER JOIN rol r ON u.codigoRol = r.codigo
    WHERE u.correo = @Correo
END

-- ---------------------------------------- --
--    Stored Procedure to Create a Sprint   --
-- ---------------------------------------- --

CREATE OR ALTER PROCEDURE SP_CrearSprintWeb
    @nombre VARCHAR(100),
	@progreso INT,
    @fechaInicio DATE,
    @fechaFin DATE,
    @codigoLider INT,
    @codigoProyecto INT
AS
BEGIN
    INSERT INTO sprint (nombre, progreso, fechaInicio, fechaFin, codigoLider, codigoProyecto)
    VALUES (@nombre, @progreso, @fechaInicio, @fechaFin, @codigoLider, @codigoProyecto)
END
GO

-- Stored Procedure to Read Sprints
CREATE OR ALTER PROCEDURE SP_ObtenerSprintsWeb 
    @codigoProyecto INT
AS
BEGIN
    SELECT 
        s.codigo,
        s.nombre,
        s.progreso,
        s.fechaInicio,
        s.fechaFin,
        l.codigo AS codigoLider,
        l.nombres AS lider,
        p.codigo AS codigoProyecto,
        p.nombre AS proyecto
    FROM 
        Sprint s
    JOIN 
        Usuario l ON s.codigoLider = l.codigo
    JOIN 
        Proyecto p ON s.codigoProyecto = p.codigo
    WHERE 
        p.codigo = @codigoProyecto
    ORDER BY 
        s.fechaInicio DESC;
END
GO

-- Stored Procedure to Read sprints
CREATE OR ALTER PROCEDURE SP_ObtenerSprintPorCodigoWeb 
    @codigoSprint INT
AS
BEGIN
    SELECT 
        s.codigo,
        s.nombre,
        s.progreso,
        s.fechaInicio,
        s.fechaFin,
        l.codigo AS codigoLider,
        l.nombres AS lider,
        p.codigo AS codigoProyecto,
        p.nombre AS proyecto
    FROM 
        Sprint s
    JOIN 
        Usuario l ON s.codigoLider = l.codigo
    JOIN 
        Proyecto p ON s.codigoProyecto = p.codigo
    WHERE 
        s.codigo = @codigoSprint; -- Filtro espec�fico por c�digo de sprint
END
GO


-- Stored Procedure to Update a Sprint
CREATE OR ALTER PROCEDURE SP_ActualizarSprintWeb
    @codigo INT,
    @nombre VARCHAR(100),
	@progreso INT,
    @fechaInicio DATE,
    @fechaFin DATE,
    @codigoLider INT,
    @codigoProyecto INT
AS
BEGIN
    UPDATE sprint
    SET nombre = @nombre,
		progreso = @progreso,
        fechaInicio = @fechaInicio,
        fechaFin = @fechaFin,
        codigoLider = @codigoLider,
        codigoProyecto = @codigoProyecto
    WHERE codigo = @codigo
END
GO

-- Stored Procedure to Delete a Sprint
CREATE OR ALTER PROCEDURE SP_EliminarSprintWeb
    @codigo INT
AS
BEGIN
    DELETE FROM sprint WHERE codigo = @codigo
END
GO

--- INSUMOS ---

CREATE OR ALTER PROCEDURE SP_ObtenerInsumosPorCodigoSprint
    @codigoSprint INT
AS
BEGIN
    SELECT i.codigo, i.nombre, i.descripcion, i.cantidad, i.codigoSprint, s.nombre AS nombreSprint
    FROM insumo i
    INNER JOIN sprint s ON i.codigoSprint = s.codigo
    WHERE i.codigoSprint = @codigoSprint
    ORDER BY i.codigo
END
GO
CREATE OR ALTER PROCEDURE SP_ObtenerInsumosPorCodigoInsumo
    @codigoInsumo INT
AS
BEGIN
    SELECT i.codigo, i.nombre, i.descripcion, i.cantidad, i.codigoSprint, s.nombre AS nombreSprint
    FROM insumo i
    INNER JOIN sprint s ON i.codigoSprint = s.codigo
    WHERE i.codigo = @codigoInsumo
    ORDER BY i.codigo
END
GO


-- Registrar insumo en sprint
CREATE OR ALTER PROCEDURE SP_RegistrarInsumoWeb
    @nombre NVARCHAR(100),
    @descripcion NVARCHAR(255),
    @cantidad INT,
    @codigoSprint INT
AS
BEGIN
    INSERT INTO insumo (nombre, descripcion, cantidad, codigoSprint)
    VALUES (@nombre, @descripcion, @cantidad, @codigoSprint)
END;
GO

-- Actualizar insumo
CREATE OR ALTER PROCEDURE SP_ActualizarInsumoWeb
    @codigo INT,
	@nombre NVARCHAR(100),
	@descripcion NVARCHAR(255),
	@cantidad INT
AS
BEGIN
    UPDATE insumo
    SET nombre = @nombre,
        descripcion = @descripcion,
		cantidad = @cantidad
    WHERE codigo = @codigo
END
GO
-- Eliminar Insumo
CREATE OR ALTER PROCEDURE SP_EliminarInsumo
    @codigo INT
AS
BEGIN
    DELETE FROM insumo WHERE codigo = @codigo
END
GO

-- ------------------------------------ --
--          A C T I V I D A D           --
-- ------------------------------------ --

CREATE PROCEDURE SP_ListarActividadesPorSprintWeb
    @CodigoSprint INT
AS
BEGIN
    SELECT 
        a.codigo,
        a.nombre,
        a.descripcion,
        a.progreso,
        a.codigoTipo AS codigoTipoActividad,
        ta.nombre AS nombreTipoActividad,
        a.codigoEstado,
        e.nombre AS nombreEstado
    FROM actividad a
    INNER JOIN tipo_actividad ta ON a.codigoTipo = ta.codigo
    INNER JOIN estado e ON a.codigoEstado = e.codigo
    WHERE a.codigoSprint = @CodigoSprint
END
GO

CREATE PROCEDURE SP_RegistrarActividadWeb
    @Nombre NVARCHAR(100),
    @Descripcion NVARCHAR(MAX),
    @Progreso INT,
    @CodigoTipoActividad INT,
    @CodigoSprint INT,
    @CodigoEstado INT
AS
BEGIN
    INSERT INTO actividad (nombre, descripcion, progreso, codigoTipo, codigoSprint, codigoEstado)
    VALUES (@Nombre, @Descripcion, @Progreso, @CodigoTipoActividad, @CodigoSprint, @CodigoEstado)
END
GO

CREATE PROCEDURE SP_ActualizarActividadWeb
    @Codigo INT,
    @Nombre NVARCHAR(100),
    @Descripcion NVARCHAR(MAX),
    @Progreso INT,
    @CodigoTipoActividad INT,
    @CodigoEstado INT
AS
BEGIN
    UPDATE actividad
    SET 
        nombre = @Nombre,
        descripcion = @Descripcion,
        progreso = @Progreso,
        codigoTipo = @CodigoTipoActividad,
        codigoEstado = @CodigoEstado
    WHERE codigo = @Codigo
END
GO

CREATE PROCEDURE SP_ObtenerActividadPorCodigoWeb
    @Codigo INT
AS
BEGIN
    SELECT 
        a.codigo,
        a.nombre,
        a.descripcion,
        a.progreso,
        a.codigoTipo AS codigoTipoActividad,
        ta.nombre AS nombreTipoActividad,
        a.codigoEstado,
        e.nombre AS nombreEstado,
        a.codigoSprint
    FROM actividad a
    INNER JOIN tipo_actividad ta ON a.codigoTipo = ta.codigo
    INNER JOIN estado e ON a.codigoEstado = e.codigo
    WHERE a.codigo = @Codigo
END
GO

CREATE PROCEDURE SP_ListarTipoActividadWeb
AS
BEGIN
    SELECT 
        codigo,
        nombre
    FROM tipo_actividad
END
GO

CREATE PROCEDURE SP_EliminarActividadWeb
    @Codigo INT
AS
BEGIN
    DELETE FROM actividad WHERE codigo = @Codigo
END
GO