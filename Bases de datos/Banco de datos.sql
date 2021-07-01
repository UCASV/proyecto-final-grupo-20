--****************************************************
-- Proyecto Base de datos y Programación de Estructuras Dinámicas
-- Grupo 20
--****************************************************

CREATE DATABASE ProyectDB;
USE ProyectDB;
SET LANGUAGE us_english;

-- Creación de tablas

CREATE TABLE Employee(
	id INT PRIMARY KEY,
	nameEmployee VARCHAR(30),
	institutionalEmail VARCHAR(50),
	addressEmployee VARCHAR(100),
	idTypeEmployee INT,
	idAdministrator INT
);

CREATE TABLE TypeEmployee(
	id INT PRIMARY KEY,
	typeEmployee VARCHAR(20)
);

CREATE TABLE Administrator(
	id INT PRIMARY KEY,
	username VARCHAR(30),
	passwordAdmin VARCHAR(15)
);

CREATE TABLE LoginTime(
	id INT IDENTITY PRIMARY KEY,
	dateTimeLogin DATETIME,
	idAdministrator INT,
	idCabin INT
);

CREATE TABLE Cabin(
	id INT PRIMARY KEY,
	addressCabin VARCHAR(100),
	phone INT,
	manager VARCHAR(30),
	email VARCHAR(50)
);

CREATE TABLE Arrival(
	id INT PRIMARY KEY,
	idCabin INT,
	idCitizen INT
);

CREATE TABLE Citizen(
	dui INT PRIMARY KEY,
	nameCitizen VARCHAR(30),
	email VARCHAR(50),
	addressCitizen VARCHAR(100),
	phone INT,
	idPriorityGroup INT,
	idInstitution INT,
	idAppointment INT,
	idCronicDesease INT
);

CREATE TABLE PriorityGroup(
	id INT PRIMARY KEY,
	priorityGroup VARCHAR(30)
);

CREATE TABLE Institution(
	id INT PRIMARY KEY,
	institution VARCHAR(30)
);

CREATE TABLE CronicDesease(
	id INT PRIMARY KEY,
	cronicDesease VARCHAR(30),
	idCitizen INT
);

CREATE TABLE Appointment(
	id INT PRIMARY KEY,
	dateAndTime DATETIME,
	place VARCHAR(20),
	number  INT,
	idVaccination INT
);

CREATE TABLE Vaccination(
	id INT PRIMARY KEY,
	arrivalTime DATETIME,
	vaccinationTime DATETIME,
	secondaryEffect VARCHAR(20),
	timeEffect INT
);

-- Añadiendo llaves foráneas

ALTER TABLE Employee ADD FOREIGN KEY (idTypeEmployee) REFERENCES TypeEmployee (id);
ALTER TABLE Employee ADD FOREIGN KEY (idAdministrator) REFERENCES Administrator (id);
ALTER TABLE LoginTime ADD FOREIGN KEY (idAdministrator) REFERENCES Administrator (id);
ALTER TABLE LoginTime ADD FOREIGN KEY (idCabin) REFERENCES Cabin (id);
ALTER TABLE Arrival ADD FOREIGN KEY (idCabin) REFERENCES Cabin (id);
ALTER TABLE Arrival ADD FOREIGN KEY (idCitizen) REFERENCES Citizen (dui);
ALTER TABLE Citizen ADD FOREIGN KEY (idPriorityGroup) REFERENCES PriorityGroup (id);
ALTER TABLE Citizen ADD FOREIGN KEY (idInstitution) REFERENCES Institution (id);
ALTER TABLE Citizen ADD FOREIGN KEY (idAppointment) REFERENCES Appointment (id);
ALTER TABLE Appointment ADD FOREIGN KEY (idVaccination) REFERENCES Vaccination (id);
ALTER TABLE Citizen ADD FOREIGN KEY (idCronicDesease) REFERENCES CronicDesease (id);

-- Banco de datos

INSERT INTO TypeEmployee VALUES (1, 'Doctor');
INSERT INTO TypeEmployee VALUES (2, 'Enfermera');
INSERT INTO TypeEmployee VALUES (3, 'Vacunador');
INSERT INTO TypeEmployee VALUES (4, 'Gestor');
INSERT INTO TypeEmployee VALUES (5, 'Vigilante');

INSERT INTO Administrator VALUES (1, 'ArmandoLopez', 'armandoL%');
INSERT INTO Administrator VALUES (2, 'MariaLemus', 'mariaL&21');

INSERT INTO Employee VALUES (1, 'Luis Gonzales', 'LuisGonzales@salud.gov.sv', 'Avenida Monseñor Romero y Final Calle 5 de Noviembre entre 21a y 23a Calle Oriente', 1, NULL);
INSERT INTO Employee VALUES (2, 'Ana Perez', 'AnnaPerez@salud.gov.sv', 'Colonia Buenos Aires 3, Diagonal Centroamérica, Avenida Alvarado, contiguo al Ministerio de Hacienda', 2, NULL);
INSERT INTO Employee VALUES (3, 'Jorge Alonso', 'JorgeAlonso@salud.gov.sv', '1a Calle Poniente entre 60a Avenida Norte y Boulevard Constitución No. 3549', 3, NULL);
INSERT INTO Employee VALUES (4, 'Armando Lopez', 'ArmandoLopez@salud.gov.sv', 'Colonia San Francisco, Avenida Las Camelias y Calle Los Abetos No. 21', 4, 1);
INSERT INTO Employee VALUES (5, 'Maria Lemus', 'MariaLemus@salud.gov.sv', '10a Avenida Sur y Calle Lara No. 934, Barrio San Jacinto', 4, 2);

INSERT INTO Cabin VALUES (1, 'Urb La Cima I Cl A Bl B No 26, San Salvador, San Salvador', 71321205, 'Kenia Delgado', 'KeniaDelgado@min.gov.sv');
INSERT INTO Cabin VALUES (2, 'Col San Francisco Av Las Dalias No 160, San Salvador, San Salvador', 71500115, 'Gerardo Torres', 'GerardoTorres@min.gov.sv');
INSERT INTO Cabin VALUES (3, 'Av Olimpica y 57 Av Sur No 8-B, San Salvador, San Salvador', 74576240, 'Armando Lopez', 'ArmandoLopez@salud.gov.sv');

INSERT INTO PriorityGroup VALUES (1, 'Persona arriba de los 60 años');
INSERT INTO PriorityGroup VALUES (2, 'Persona del sistema integrado de salud');
INSERT INTO PriorityGroup VALUES (3, 'Encargados de seguridad nacional');
INSERT INTO PriorityGroup VALUES (4, 'Personas mayores de 18 años con enfermedades no transmitibles o alguna indiscapacidad');
INSERT INTO PriorityGroup VALUES (5, 'Persona del gobierno central');

INSERT INTO Institution VALUES (1, 'Educacion');
INSERT INTO Institution VALUES (2, 'Salud');
INSERT INTO Institution VALUES (3, 'PNC');
INSERT INTO Institution VALUES (4, 'Fuerza Armada');
INSERT INTO Institution VALUES (5, 'Gobierno');
INSERT INTO Institution VALUES (6, 'Periodismo');

INSERT INTO Vaccination VALUES(1, '2021-04-08 14:45:00.000', '2021-04-08 15:00:00.000', NULL, NULL);
INSERT INTO Vaccination VALUES(2, '2021-04-09 08:45:00.000', '2021-04-09 09:00:00.000', 'Mareo', 15);

INSERT INTO Appointment VALUES (1, '2021-04-08 15:00:00.000', 'Hospital Rosales', 1, 1);
INSERT INTO Appointment VALUES (2, '2021-04-09 09:00:00.000', 'Hospital El Salvador', 1, 2);

INSERT INTO Citizen VALUES (159504158, 'Hector Rodriguez', 'hectorrodri58@gmail.com', 'Carrt Litoral Km 57 Cl Ppal 1 Av Sur, Zacatecoluca, La Paz', 76313161, 2, 2, 1);
INSERT INTO Citizen VALUES (285219153, 'Karla Martinez', 'karlitamartinez555@gmail.com', 'Urb Palmira Av Grenoble Pol?g C No 2 Sta Tecla, Santa Tecla, La Libertad', 65156001, 4, 6, 2);

INSERT INTO CronicDesease VALUES (1, 'Diabetes', 285219153);

INSERT INTO LoginTime VALUES (1, 1, '2021-04-07 08:00:00.000');
INSERT INTO LoginTime VALUES (1, 3, '2021-04-08 08:00:00.000');

INSERT INTO Arrival VALUES (1, 285219153);
INSERT INTO Arrival VALUES (2, 159504158);
