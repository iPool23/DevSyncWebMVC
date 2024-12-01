/*select * from tarea_etiqueta

select * from comentario

delete from comentario

Comando para reiniciar el contador
DBCC CHECKIDENT ('nombre de tabla', RESEED, 0);*/


USE MASTER;
GO

USE bdGestionPro;
GO

insert into rol (nombre) values ('Administrador');
insert into rol (nombre) values ('Desarrollador');
insert into rol (nombre) values ('Líder de Proyecto');
insert into rol (nombre) values ('Líder de Sprint');
insert into rol (nombre) values ('Product Owner');
insert into rol (nombre) values ('Reader');
insert into rol (nombre) values ('User');

insert into equipo (nombre) values ('Diseño UX/UI');
insert into equipo (nombre) values ('Desarrollo Web');
insert into equipo (nombre) values ('QA Testing');
insert into equipo (nombre) values ('DevOps');
insert into equipo (nombre) values ('Administrador');
insert into equipo (nombre) values ('Programador');
insert into equipo (nombre) values ('Programador Proyect1');



insert into tipo_actividad (nombre) values ('Bug');
insert into tipo_actividad (nombre) values ('Epic');
insert into tipo_actividad (nombre) values ('Feature');
insert into tipo_actividad (nombre) values ('Backlog');


insert into estado (nombre) values ('Nuevo');
insert into estado (nombre) values ('En progreso');
insert into estado (nombre) values ('Realizado');
insert into estado (nombre) values ('Eliminado');

insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('ttirte0', 'Tamera', 'Tirte', 'ttirte0@storify.com', '2', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('dkolodziej1', 'Debor', 'Kolodziej', 'dkolodziej1@google.it', '4', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('hdemorena2', 'Hadrian', 'De Morena', 'hdemorena2@ucoz.ru', '2', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('dtolan3', 'Dolli', 'Tolan', 'dtolan3@aol.com', '1', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('ialp4', 'Ianthe', 'Alp', 'ialp4@cnn.com', '1', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('epattrick5', 'Ekaterina', 'Pattrick', 'epattrick5@forbes.com', '5', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('tsleeman6', 'Terrance', 'Sleeman', 'tsleeman6@123-reg.co.uk', '3', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('aralestone7', 'Alyda', 'Ralestone', 'aralestone7@biglobe.ne.jp', '4', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('mbellson8', 'Merle', 'Bellson', 'mbellson8@hugedomains.com', '6', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('ayuryshev9', 'Audra', 'Yuryshev', 'ayuryshev9@barnesandnoble.com', '6', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('lyakobovicza', 'Lorant', 'Yakobovicz', 'lyakobovicza@sciencedaily.com', '1', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('rnussenb', 'Rosalinda', 'Nussen', 'rnussenb@gov.uk', '1', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('zsotworthc', 'Zorah', 'Sotworth', 'zsotworthc@nature.com', '2', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('tdaffernd', 'Towny', 'Daffern', 'tdaffernd@nsw.gov.au', '4', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('abradee', 'Abraham', 'Brade', 'abradee@ning.com', '2', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('ospauntonf', 'Orelle', 'Spaunton', 'ospauntonf@symantec.com', '5', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('ekeoughg', 'Emera', 'Keough', 'ekeoughg@ifeng.com', '3', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('charkh', 'Charissa', 'Hark', 'charkh@mozilla.com', '3', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('acuddehyi', 'Arvy', 'Cuddehy', 'acuddehyi@soup.io', '5', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('sgunnyj', 'Salem', 'Gunny', 'sgunnyj@networkadvertising.org', '4', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('djudkink', 'Dalston', 'Judkin', 'djudkink@china.com.cn', '4', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('lclellandl', 'Lionello', 'Clelland', 'lclellandl@qq.com', '2', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('rfreynm', 'Ronnie', 'Freyn', 'rfreynm@hibu.com', '3', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('gjoutapaitisn', 'Glen', 'Joutapaitis', 'gjoutapaitisn@wired.com', '2', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('olocheado', 'Orlando', 'Lochead', 'olocheado@aboutads.info', '4', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('bbenedettip', 'Bancroft', 'Benedetti', 'bbenedettip@sohu.com', '3', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('pshoreq', 'Patti', 'Shore', 'pshoreq@blogs.com', '1', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('cbaskeyfieldr', 'Codie', 'Baskeyfield', 'cbaskeyfieldr@hatena.ne.jp', '2', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('omessengers', 'Oliy', 'Messenger', 'omessengers@ebay.co.uk', '5', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('abowndt', 'Alethea', 'Bownd', 'abowndt@xrea.com', '2', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('eharmouru', 'Elfie', 'Harmour', 'eharmouru@blogs.com', '3', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('nbullusv', 'Nicolette', 'Bullus', 'nbullusv@cnbc.com', '2', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('gcowserw', 'Gerri', 'Cowser', 'gcowserw@addthis.com', '4', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('dgruszczakx', 'Donalt', 'Gruszczak', 'dgruszczakx@newsvine.com', '2', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('teastmeady', 'Tammy', 'Eastmead', 'teastmeady@princeton.edu', '6', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('pbramsenz', 'Paige', 'Bramsen', 'pbramsenz@shareasale.com', '1', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('adevaux10', 'Anni', 'De Vaux', 'adevaux10@bbb.org', '2', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('bosant11', 'Bobbe', 'Osant', 'bosant11@irs.gov', '4', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('cstucke12', 'Conney', 'Stucke', 'cstucke12@woothemes.com', '2', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('jberntsson13', 'Jerry', 'Berntsson', 'jberntsson13@1und1.de', '3', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('rdomniney14', 'Rozella', 'Domniney', 'rdomniney14@wordpress.org', '6', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('jvittel15', 'Juliana', 'Vittel', 'jvittel15@cisco.com', '3', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('zbreens16', 'Zebulen', 'Breens', 'zbreens16@msn.com', '1', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('kbathow17', 'Karlik', 'Bathow', 'kbathow17@list-manage.com', '5', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('tdallaway18', 'Tabb', 'Dallaway', 'tdallaway18@economist.com', '3', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('weveringham19', 'Woodie', 'Everingham', 'weveringham19@123-reg.co.uk', '3', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('klemar1a', 'Kassi', 'Lemar', 'klemar1a@dion.ne.jp', '1', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('cpray1b', 'Con', 'Pray', 'cpray1b@altervista.org', '2', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('cautrie1c', 'Carolyn', 'Autrie', 'cautrie1c@businessweek.com', '4', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('bbanthorpe1d', 'Billy', 'Banthorpe', 'bbanthorpe1d@imageshack.us', '5', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('yair', 'Irvin Yair', 'Acuna Mendoza', 'amendozairvinya@uss.edu.pe', '1', 'yair');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('pool', 'Pool Anthony', 'Deza Millones', 'dmillonespoolan@uss.edu.pe', '1', 'pool1234');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('jorge', 'Jorge Alexander', 'Maza Huaman', 'mhuamanjorgeale@uss.edu.pe', '1', 'Basis2024');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('anthony', 'Anthony', 'Pantaleon Villegas', 'pvillegasanto@uss.edu.pe', '1', '12345');
insert into usuario (nombreUsuario, nombres, apellidos, correo, codigoRol, contrasenia) values ('collins', 'Collins', 'Vieira Abad', 'vabadcollins@uss.edu.pe', '1', '12345');



insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('2', '1');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('4', '2');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('1', '3');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('2', '4');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('2', '5');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('2', '6');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('2', '7');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('2', '8');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('4', '9');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('3', '10');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('3', '11');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('1', '12');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('4', '13');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('3', '14');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('4', '15');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('2', '16');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('3', '17');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('3', '18');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('1', '19');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('2', '20');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('4', '21');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('4', '22');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('4', '23');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('3', '24');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('3', '25');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('2', '26');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('3', '27');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('3', '28');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('3', '29');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('1', '30');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('1', '31');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('3', '32');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('4', '33');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('2', '34');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('1', '35');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('1', '36');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('1', '37');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('3', '38');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('1', '39');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('2', '40');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('4', '41');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('1', '42');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('1', '43');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('1', '44');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('1', '45');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('2', '46');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('4', '47');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('2', '48');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('2', '49');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('4', '50');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('3', '1');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('1', '50');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('3', '3');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('3', '5');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('4', '5');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('4', '6');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('3', '7');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('1', '8');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('2', '9');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('4', '10');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('4', '11');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('4', '12');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('4', '14');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('3', '30');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('2', '15');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('4', '16');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('1', '17');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('4', '18');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('3', '19');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('2', '25');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('2', '21');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('3', '23');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('1', '23');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('3', '35');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('2', '30');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('2', '12');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('2', '27');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('2', '29');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('4', '29');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('3', '20');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('2', '32');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('4', '32');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('2', '33');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('3', '42');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('3', '49');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('3', '36');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('3', '37');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('3', '48');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('3', '39');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('1', '40');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('1', '41');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('2', '42');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('4', '43');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('3', '44');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('4', '45');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('4', '46');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('2', '47');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('2', '45');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('2', '14');
insert into equipo_usuario (codigoEquipo, codigoUsuario) values ('2', '50');


INSERT INTO proyecto (nombre, descripcion, fechaInicio, fechaFin, progreso, codigoLider, codigoEquipo, codigoEstado)
VALUES 
('AI Solutions', 'Desarrollo de IA avanzada.', '2024-03-28 22:11:19', '2025-06-20 00:22:53', 4, '25', '6', '2'),
('Analytics Frontier', 'Soluciones integradas emergentes.', '2024-03-29 11:11:56', '2025-06-01 19:35:15', 55, '3', '4', '3'),
('Tech Innovate', 'Evolución de nuevas tecnologías.', '2024-01-12 23:32:17', '2025-04-30 15:49:11', 39, '11', '3', '1'),
('Data Discovery', 'Optimización de datos digitales.', '2025-06-02 02:52:01', '2025-06-07 03:22:21', 90, '2', '1', '3'),
('Cognitive Lab', 'Algoritmos para problemas complejos.', '2024-01-20 05:11:20', '2025-04-16 02:12:05', 72, '49', '2', '1'),
('AI Network', 'Red de conocimientos en IA.', '2024-10-12 02:48:57', '2025-02-04 07:02:34', 1, '10', '5', '2'),
('Data Precision', 'Análisis de datos optimizados.', '2024-05-26 01:17:39', '2025-02-05 15:57:07', 66, '12', '6', '3'),
('TechnoVation', 'Sistemas inteligentes adaptativos.', '2024-11-03 14:53:57', '2025-03-12 01:57:46', 46, '38', '6', '2'),
('Innovative AI', 'Mejoras en redes neuronales.', '2025-04-19 07:35:52', '2025-04-23 16:30:13', 31, '36', '5', '1'),
('Future Dynamics', 'Impacto digital en empresas.', '2024-11-01 02:32:10', '2025-04-22 12:21:43', 37, '21', '5', '2'),
('Smart Tech', 'Tecnología inteligente avanzada.', '2024-03-15 09:30:22', '2025-06-11 10:40:52', 62, '15', '2', '3'),
('AI Frontier', 'Expansión de IA en áreas clave.', '2024-04-10 15:05:12', '2025-05-22 21:59:35', 48, '17', '3', '1'),
('Quantum Leap', 'Computación cuántica avanzada.', '2024-05-05 18:55:32', '2025-06-02 13:25:10', 22, '13', '6', '2'),
('Deep Learning', 'Aplicación de redes profundas.', '2024-02-25 08:42:15', '2025-05-19 07:59:45', 79, '8', '4', '3'),
('Next-Gen AI', 'Nuevos sistemas de IA.', '2024-03-10 07:20:47', '2025-05-15 18:12:13', 52, '20', '5', '2'),
('Digital Lab', 'Transformación digital con IA.', '2024-02-02 10:17:36', '2025-04-26 23:48:19', 85, '7', '3', '1'),
('AI Ethics', 'Impacto ético de la IA.', '2024-01-25 12:45:14', '2025-04-05 16:18:45', 60, '5', '5', '2'),
('Smart Cities', 'IA aplicada en ciudades.', '2024-05-09 04:21:34', '2025-05-25 05:31:22', 34, '9', '7', '3'),
('Autonomous Systems', 'Sistemas autónomos avanzados.', '2024-04-17 03:11:25', '2025-05-11 10:41:03', 41, '6', '5', '1'),
('Tech Leadership', 'Foro sobre liderazgo tecnológico.', '2024-03-27 14:35:01', '2025-05-09 14:59:29', 67, '18', '2', '3');

--	Data Rol Proyecto  -- Puse los roles de los usuarios en un proyecto de acuerdo al orden de los usuarios...
insert into rol_proyecto values (1,51,2);
insert into rol_proyecto values (1,52,5);
insert into rol_proyecto values (1,53,2);
insert into rol_proyecto values (1,54,2);


-- Data Sprint

INSERT INTO sprint (nombre, fechaInicio, fechaFin, progreso, codigoProyecto, codigoLider) 
VALUES ('Sprint 1 - Definición de Requisitos', '2024-06-01 08:00:00', '2024-06-30 18:00:00', 100, '1', '13');
INSERT INTO sprint (nombre, fechaInicio, fechaFin, progreso, codigoProyecto, codigoLider) 
VALUES ('Sprint 2 - Diseño de Arquitectura', '2024-07-01 08:00:00', '2024-07-31 18:00:00', 100, '1', '13');
INSERT INTO sprint (nombre, fechaInicio, fechaFin, progreso, codigoProyecto, codigoLider) 
VALUES ('Sprint 3 - Implementación del Backend', '2024-08-01 08:00:00', '2024-08-31 18:00:00', 100, '1', '13');
INSERT INTO sprint (nombre, fechaInicio, fechaFin, progreso, codigoProyecto, codigoLider) 
VALUES ('Sprint 4 - Pruebas Unitarias', '2024-09-01 08:00:00', '2024-09-25 18:00:00', 40, '1', '13');
insert into sprint (nombre, fechaInicio, fechaFin, progreso, codigoProyecto, codigoLider) 
values ('Sprint 1 - Planificación Inicial', '2024-03-29 08:00:00', '2024-04-05 18:00:00', 100, '2', '4');

insert into sprint (nombre, fechaInicio, fechaFin, progreso, codigoProyecto, codigoLider) 
values ('Sprint 2 - Análisis de Requisitos', '2024-04-06 08:00:00', '2024-04-20 18:00:00', 100, '2', '4');

insert into sprint (nombre, fechaInicio, fechaFin, progreso, codigoProyecto, codigoLider) 
values ('Sprint 3 - Diseño de la Arquitectura', '2024-04-21 08:00:00', '2024-05-05 18:00:00', 100, '2', '4');

insert into sprint (nombre, fechaInicio, fechaFin, progreso, codigoProyecto, codigoLider) 
values ('Sprint 4 - Implementación del Backend', '2024-05-06 08:00:00', '2024-05-20 18:00:00', 100, '2', '4');

insert into sprint (nombre, fechaInicio, fechaFin, progreso, codigoProyecto, codigoLider) 
values ('Sprint 5 - Pruebas Unitarias', '2024-05-21 08:00:00', '2024-06-05 18:00:00', 100, '2', '4');

insert into sprint (nombre, fechaInicio, fechaFin, progreso, codigoProyecto, codigoLider) 
values ('Sprint 6 - Optimización de Desempeño', '2024-06-06 08:00:00', '2024-06-20 18:00:00', 100, '2', '4');

insert into sprint (nombre, fechaInicio, fechaFin, progreso, codigoProyecto, codigoLider) 
values ('Sprint 7 - Pruebas de Integración', '2024-06-21 08:00:00', '2024-07-05 18:00:00', 100, '2', '4');

insert into sprint (nombre, fechaInicio, fechaFin, progreso, codigoProyecto, codigoLider) 
values ('Sprint 8 - Despliegue en Entorno de Pruebas', '2024-07-06 08:00:00', '2024-07-20 18:00:00', 100, '2', '4');

insert into sprint (nombre, fechaInicio, fechaFin, progreso, codigoProyecto, codigoLider) 
values ('Sprint 9 - Ajustes Finales', '2024-07-21 08:00:00', '2024-08-05 18:00:00', 100, '2', '4');

insert into sprint (nombre, fechaInicio, fechaFin, progreso, codigoProyecto, codigoLider) 
values ('Sprint 10 - Preparación para Producción', '2024-08-06 08:00:00', '2024-08-20 18:00:00', 100, '2', '4');

insert into sprint (nombre, fechaInicio, fechaFin, progreso, codigoProyecto, codigoLider) 
values ('Sprint 11 - Mantenimiento Inicial', '2024-08-21 08:00:00', '2024-09-05 18:00:00', 100, '2', '4');

insert into sprint (nombre, fechaInicio, fechaFin, progreso, codigoProyecto, codigoLider) 
values ('Sprint 12 - Correcciones Basadas en Feedback', '2024-09-06 08:00:00', '2024-09-20 18:00:00', 100, '2', '4');

insert into sprint (nombre, fechaInicio, fechaFin, progreso, codigoProyecto, codigoLider) 
values ('Sprint 13 - Implementación de Funcionalidades Nuevas', '2024-09-21 08:00:00', '2024-10-05 18:00:00', 40, '2', '4');

--Data insumo
insert into insumo (nombre, descripcion, cantidad, codigoSprint) 
values ('IDE de Desarrollo', 'Software para el desarrollo y pruebas del backend', 5, '1');

insert into insumo (nombre, descripcion, cantidad, codigoSprint) 
values ('Herramientas de Diseño', 'Software de diseño arquitectónico', 3, '2');

insert into insumo (nombre, descripcion, cantidad, codigoSprint) 
values ('Equipo de pruebas', 'Hardware necesario para pruebas de integración', 7, '3');

insert into insumo (nombre, descripcion, cantidad, codigoSprint) 
values ('Servicios en la nube', 'Suscripciones para almacenamiento de datos y despliegue', 2, '4');

insert into insumo (nombre, descripcion, cantidad, codigoSprint) 
values ('Plataforma de APIs', 'Plataforma para la integración de APIs', 6, '5');

insert into insumo (nombre, descripcion, cantidad, codigoSprint) 
values ('Herramienta de pruebas unitarias', 'Software para pruebas automatizadas', 10, '6');

insert into insumo (nombre, descripcion, cantidad, codigoSprint) 
values ('Entorno de integración continua', 'Software para el proceso de integración y despliegue', 4, '7');

insert into insumo (nombre, descripcion, cantidad, codigoSprint) 
values ('Documentación técnica', 'Guía y soporte para la optimización de rendimiento', 12, '8');

insert into insumo (nombre, descripcion, cantidad, codigoSprint) 
values ('Equipo de desarrollo', 'Documentación y herramientas para desarrollo de backend', 9, '9');

insert into insumo (nombre, descripcion, cantidad, codigoSprint) 
values ('Servidor de pruebas', 'Equipo necesario para ejecutar pruebas de rendimiento', 5, '10');

insert into insumo (nombre, descripcion, cantidad, codigoSprint) 
values ('Software de documentación', 'Herramientas para la generación de documentación del proyecto', 8, '11');

insert into insumo (nombre, descripcion, cantidad, codigoSprint) 
values ('Entorno de producción', 'Herramienta de despliegue en entorno de pruebas', 3, '12');

insert into insumo (nombre, descripcion, cantidad, codigoSprint) 
values ('Licencias de seguridad', 'Software para asegurar la protección del código', 4, '13');

insert into insumo (nombre, descripcion, cantidad, codigoSprint) 
values ('Mantenimiento de hardware', 'Soporte técnico para mantener el entorno de desarrollo', 7, '14');

insert into insumo (nombre, descripcion, cantidad, codigoSprint) 
values ('Software de feedback', 'Herramientas para integrar correcciones en función del feedback', 6, '15');

insert into insumo (nombre, descripcion, cantidad, codigoSprint) 
values ('Servicios de soporte', 'Asistencia técnica para el mantenimiento del proyecto', 3, '16');

--Data Actividad
INSERT INTO actividad (nombre, descripcion, progreso, codigoTipo, codigoSprint, codigoEstado) 
VALUES ('Licencia de software', 'Recolección y análisis de requisitos del cliente para el proyecto', 57, 1, 1, 3);

INSERT INTO actividad (nombre, descripcion, progreso, codigoTipo, codigoSprint, codigoEstado) 
VALUES ('Bases de datos', 'Diseño de la interfaz de usuario para garantizar una buena experiencia de usuario', 41, 1, 2, 1);

INSERT INTO actividad (nombre, descripcion, progreso, codigoTipo, codigoSprint, codigoEstado) 
VALUES ('Licencia de herramientas de diseño', 'Desarrollo del software según los requisitos especificados en el proyecto', 62, 1, 3, 3);
INSERT INTO actividad (nombre, descripcion, progreso, codigoTipo, codigoSprint, codigoEstado) 
VALUES ('Biblioteca de componentes de software', 'Implementación de nuevas funcionalidades en el software', 98, 3, 3, 3);

INSERT INTO actividad (nombre, descripcion, progreso, codigoTipo, codigoSprint, codigoEstado) 
VALUES ('Servicio de soporte técnico', 'Prueba y producción', 93, 1, 4, 1);
INSERT INTO actividad (nombre, descripcion, progreso, codigoTipo, codigoSprint, codigoEstado) 
VALUES ('Herramienta de pruebas automatizadas', 'Configuración de los entornos de desarrollo', 93, 3, 4, 1);

INSERT INTO actividad (nombre, descripcion, progreso, codigoTipo, codigoSprint, codigoEstado) 
VALUES ('Hardware de pruebas', 'Creación de documentación técnica que describa el software y su funcionamiento', 96, 2, 5, 3);

INSERT INTO actividad (nombre, descripcion, progreso, codigoTipo, codigoSprint, codigoEstado) 
VALUES ('Licencia de software1', 'Recolección y análisis de requisitos del cliente para el proyecto', 42, 2, 6, 3);

INSERT INTO actividad (nombre, descripcion, progreso, codigoTipo, codigoSprint, codigoEstado) 
VALUES ('Equipo de red', 'Implementación de nuevas funcionalidades en el software', 84, 3, 7, 1);

INSERT INTO actividad (nombre, descripcion, progreso, codigoTipo, codigoSprint, codigoEstado) 
VALUES ('Herramienta de pruebas automatizadas1', 'Desarrollo del software según los requisitos especificados en el proyecto', 9, 1, 8, 1);

INSERT INTO actividad (nombre, descripcion, progreso, codigoTipo, codigoSprint, codigoEstado) 
VALUES ('Servicio de seguridad informática', 'Pruebas para asegurar que las diferentes partes del software funcionen correctamente juntas', 89, 1, 9, 2);

INSERT INTO actividad (nombre, descripcion, progreso, codigoTipo, codigoSprint, codigoEstado) 
VALUES ('Servidor de pruebas', 'Prueba y producción', 64, 2, 10, 1);

INSERT INTO actividad (nombre, descripcion, progreso, codigoTipo, codigoSprint, codigoEstado) 
VALUES ('Herramienta de integración continua', 'Pruebas para asegurar que las diferentes partes del software funcionen correctamente juntas', 44, 2, 11, 3);

INSERT INTO actividad (nombre, descripcion, progreso, codigoTipo, codigoSprint, codigoEstado) 
VALUES ('Herramienta de pruebas automatizadas12', 'Configuración de los entornos de desarrollo', 83, 3, 12, 1);

INSERT INTO actividad (nombre, descripcion, progreso, codigoTipo, codigoSprint, codigoEstado) 
VALUES ('Entorno de desarrollo integrado (IDE)', 'Creación de documentación técnica que describa el software y su funcionamiento', 25, 3, 13, 2);

INSERT INTO actividad (nombre, descripcion, progreso, codigoTipo, codigoSprint, codigoEstado) 
VALUES ('Sistema de control de versiones', 'Creación de documentación técnica que describa el software y su funcionamiento', 76, 2, 14, 1);

INSERT INTO actividad (nombre, descripcion, progreso, codigoTipo, codigoSprint, codigoEstado) 
VALUES ('Servicio de seguridad informátic1', 'Prueba y producción', 69, 3, 15, 2);

INSERT INTO actividad (nombre, descripcion, progreso, codigoTipo, codigoSprint, codigoEstado) 
VALUES ('Herramienta de integración continua1', 'Identificación y análisis de posibles riesgos asociados al proyecto', 30, 1, 16, 2);

INSERT INTO actividad (nombre, descripcion, progreso, codigoTipo, codigoSprint, codigoEstado) 
VALUES ('Herramienta de gestión de proyectos', 'Desarrollo de scripts y herramientas para pruebas automatizadas del software', 46, 3, 17, 3);


--Data tarea
INSERT INTO tarea (nombre, descripcion, fechaInicio, fechaActualizacion, fechaVencimiento, prioridad, progreso, codigoUsuario, codigoActividad, codigoEstado) VALUES 
('Recolección de requisitos', 'Reunir requisitos de los usuarios y partes interesadas.', '2024-09-01 09:00:00', '2024-09-05 10:00:00', '2024-09-15 17:00:00', 1, 100, '1', '1', '1'),
('Diseño de la arquitectura del sistema', 'Definir la arquitectura del sistema basado en los requisitos recolectados.', '2024-09-16 09:00:00', '2024-09-20 10:00:00', '2024-09-30 17:00:00', 1, 100, '2', '2', '1'),
('Implementación del backend1', 'Desarrollar la lógica del backend según la arquitectura definida.', '2024-10-01 09:00:00', '2024-10-10 10:00:00', '2024-10-31 17:00:00', 1, 100, '3', '3', '1'),
('Pruebas unitarias del backend', 'Ejecutar pruebas unitarias para asegurar la calidad del backend.', '2024-11-01 09:00:00', '2024-11-10 10:00:00', '2024-11-15 17:00:00', 2, 40, '4', '4', '1'),
('Planificación del proyecto', 'Definir el alcance y los recursos necesarios.', '2024-09-01 09:00:00', '2024-09-05 10:00:00', '2024-09-10 17:00:00', 1, 100, '5', '1', '1'),
('Análisis de requisitos', 'Identificar y documentar los requisitos del sistema.', '2024-09-11 09:00:00', '2024-09-20 10:00:00', '2024-09-25 17:00:00', 1, 100, '6', '2', '1'),
('Diseño de la arquitectura', 'Crear un diseño arquitectónico para el sistema.', '2024-09-26 09:00:00', '2024-10-05 10:00:00', '2024-10-10 17:00:00', 1, 100, '7', '3', '1'),
('Implementación del backend', 'Desarrollar el backend según la arquitectura definida.', '2024-10-11 09:00:00', '2024-10-20 10:00:00', '2024-10-31 17:00:00', 1, 100, '8', '4', '1'),
('Pruebas unitarias', 'Realizar pruebas unitarias para asegurar el correcto funcionamiento.', '2024-11-01 09:00:00', '2024-11-10 10:00:00', '2024-11-15 17:00:00', 2, 100, '9', '5', '1'),
('Optimización de desempeño', 'Mejorar la eficiencia del sistema.', '2024-11-16 09:00:00', '2024-12-01 10:00:00', '2025-01-10 17:00:00', 1, 100, '10', '6', '1'),
('Pruebas de integración', 'Probar la integración entre los módulos.', '2025-01-11 09:00:00', '2025-01-20 10:00:00', '2025-01-31 17:00:00', 1, 100, '11', '7', '1'),
('Despliegue en entorno de pruebas', 'Desplegar la aplicación en el entorno de pruebas.', '2025-02-01 09:00:00', '2025-02-10 10:00:00', '2025-02-20 17:00:00', 1, 100, '12', '8', '1'),
('Ajustes finales', 'Realizar ajustes finales según el feedback recibido.', '2025-02-21 09:00:00', '2025-03-01 10:00:00', '2025-03-10 17:00:00', 1, 100, '13', '9', '1'),
('Preparación para producción', 'Preparar el sistema para su lanzamiento en producción.', '2025-03-11 09:00:00', '2025-03-20 10:00:00', '2025-03-31 17:00:00', 1, 100, '14', '10', '1');

--Data Comentario

INSERT INTO comentario (contenido, fechaCreacion, codigoTarea, codigoUsuario) VALUES 
('Comentario sobre la recolección de requisitos', '2024-01-05', '1', '1'),
('Comentario sobre el diseño de arquitectura', '2024-01-12', '2', '2'),
('Comentario sobre la implementación del backend', '2024-02-05', '3', '3'),
('Comentario sobre las pruebas unitarias', '2024-02-20', '4', '4'),
('Comentario sobre la planificación del proyecto', '2024-01-08', '5', '5'),
('Comentario sobre el análisis de requisitos', '2024-01-15', '6', '6'),
('Comentario sobre el diseño de la arquitectura', '2024-02-01', '7', '7'),
('Comentario sobre la implementación del backend', '2024-02-12', '8', '8'),
('Comentario sobre las pruebas unitarias', '2024-02-25', '9', '9'),
('Comentario sobre la optimización de desempeño', '2024-03-01', '10', '10'),
('Comentario sobre las pruebas de integración', '2024-03-05', '11', '11'),
('Comentario sobre el despliegue en entorno de pruebas', '2024-03-10', '12', '12'),
('Comentario sobre los ajustes finales', '2024-03-15', '13', '13'),
('Comentario sobre la preparación para producción', '2024-03-20', '14', '14');

--Data Comentario
INSERT INTO etiqueta (nombre) VALUES 
('Stormie'),
('Galen'),
('Opal'),
('Jarrad'),
('Nanette'),
('Veriee'),
('Dorian'),
('Jasmine'),
('Wandis'),
('Eduardo'),
('Renata'),
('Cleopatra'),
('Sheila'),
('Waly'),
('Stearne'),
('Aubert'),
('Shandeigh'),
('Maryanna'),
('Fabien'),
('Esmeralda'),
('Leilah'),
('Angil'),
('Lanny'),
('Cathee'),
('Granny'),
('Rakel'),
('Selina'),
('Napoleon'),
('Garnette'),
('Krystal');


--Data tarea_etiqueta
INSERT INTO tarea_etiqueta (codigoTarea, codigoEtiqueta) VALUES 
('1', '1'),
('1', '2'),
('2', '3'),
('2', '4'),
('3', '5'),
('3', '6'),
('4', '7'),
('4', '8'),
('5', '9'),
('6', '10'),
('7', '11'),
('8', '12'),
('9', '13'),
('10', '14'),
('11', '14'),
('12', '16'),
('13', '17'),
('14', '18');