--- DATOS INICIALES

INSERT INTO Estatus(Nombre)
VALUES ('Seleccionar'),('Indefinido'),('Activo'),('Inactivo');

INSERT INTO Sexo(Nombre)
VALUES ('Seleccionar'),('Hombre'), ('Mujer');

INSERT INTO EstadoCivil(Nombre)
VALUES ('Seleccionar'),('Soltero'), ('Casado/a'), ('Viudo/a');

INSERT INTO BautizmoEnAgua(Nombre)
VALUES ('Seleccionar'),('Si, Dentro de la Mision'), ('Si, Fuera de la Mision');

INSERT INTO BautizmoEspirituSanto(Nombre)
VALUES ('Seleccionar'),('Si'), ('No');

INSERT INTO ListaCalendario(Nombre)
VALUES ('Seleccionar'),('Dias'), ('Semanas'), ('Meses'), ('Años');

INSERT INTO Distrito(Numero)
VALUES ('Seleccionar'),('1'), ('2');

INSERT INTO Zona(Numero)
VALUES ('Seleccionar'),('1'), ('2'), ('3');

INSERT INTO Sector(Numero)
VALUES ('Seleccionar'),('1'), ('2'), ('3');

INSERT INTO Celula(Numero)
VALUES ('Seleccionar'),('1'), ('2'), ('3'), ('4'), ('5');

INSERT INTO Privilegios (Nombre)
VALUES  ('Diacono'), ('Diaconisa'), ('Protocolo Masculino'), ('Protocolo Femenino'), ('Anciano'), ('Chalet'),
('Contador'), ('Libreria'), ('Servidor Juvenil'), ('Maestro/a de Iglesia Infantil'), ('Musico/Ministro de Alabanza'),
('Pro-Construccion'), ('Lider de Alabanza'), ('Corista'), ('Mixerista'), ('Multimedia'), ('Director Musical'),
('Coordinador/a de Juventud'), ('Coordinador/a de Chalet'), ('Coordinador de Diaconos'), ('Coordinador de Diaconisas'),
('Coordinador/a de Libreria'), ('Coordinador/a de Maestros de Iglesia Infantil'), ('Coordinador/a de Ministerio de Alabanza'),
('Coordinador/a de Pro-Construccion'), ('Coordinador/a de Multimedia'), ('Ayuda de Coordinador/a de Chalet'),
('Ayuda de Coordinador de Diaconos'), ('Ayuda de Coordinador de Diaconisas'), ('Ayuda de Coordinador/a de Libreria'),
('Ayuda de Coordinador/a de Maestros de Iglesia Infantil'), ('Ayuda de Coordinador/a de Ministerio de Alabanza'),
('Ayuda de Coordinador/a de Pro-Construccion'), ('Ayuda de Coordinador/a de Multimedia'), ('Ayuda de Coordinador/a de Juventud');

INSERT INTO CategoriaParaProfesionUOficio (Nombre)
VALUES  ('Salud y Medicina'), ('Tecnología y Computación'), ('Negocios y Finanzas'),
('Ambito de la Educación'), ('Oficios y Profesiones Técnicas');

INSERT INTO ProfesionUOficio (Nombre, IdCategoria)
VALUES 
('Médico', 1), ('Enfermero/a', 1), ('Farmacéutico/a', 1), ('Terapeuta físico', 1), ('Psicólogo/a', 1), ('Paramédico/a', 1),
('Odontólogo/a', 1), ('Especialista en salud pública', 1), ('Nutricionista', 1), ('Veterinario/a', 1),
('Desarrollador de software', 2), ('Ingeniero/a en sistemas', 2), ('Analista de datos', 2), ('Especialista en ciberseguridad', 2),
('Diseñador/a web', 2), ('Administrador/a de redes', 2), ('Especialista en inteligencia artificial', 2), ('Ingeniero/a de hardware', 2),
('Experto/a en experiencia de usuario (UX)', 2), ('Consultor/a en tecnología', 2), ('Contador/a', 3), ('Financiero/a', 3),
('Gerente de marketing', 3), ('Consultor/a empresarial', 3), ('Agente inmobiliario/a', 3), ('Analista financiero', 3),
('Gestor/a de recursos humanos', 3), ('Analista de mercado', 3), ('Gerente de proyecto', 3), ('Comerciante', 3),
('Maestro/a', 4), ('Profesor/a universitario/a', 4), ('Consejero/a educativo/a', 4), ('Director/a escolar', 4),
('Instructor/a de idiomas', 4), ('Tutor/a', 4), ('Educador/a especializado/a', 4), ('Entrenador/a deportivo/a', 4),
('Bibliotecario/a', 4), ('Orientador/a vocacional', 4), ('Electricista', 5), ('Fontanero/a', 5),
('Carpintero/a', 5), ('Soldador/a', 5), ('Mecánico/a', 5), ('Albañil', 5),
('Técnico/a en aire acondicionado y refrigeración', 5), ('Técnico/a en mantenimiento de equipos', 5),
('Instalador/a de sistemas solares', 5), ('Técnico/a de laboratorio', 5);