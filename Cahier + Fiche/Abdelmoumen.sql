create database Abdelmoumen

use Abdelmoumen

create table Activite
(
	IdAct int primary key identity(1,1),
	TitreAct varchar(30),
	DescriptionAct  varchar(4000),
)

create table Albume 
(
	IdAlb int primary key identity(1,1),
	TitreAlb varchar(30),
)

create table Publicite
(
	IdPub int primary key  identity(1,1),
	TitrePub varchar(30),
	ContenuPub varchar(4000),
)

create table Images
(
	IdImag int primary key  identity(1,1),
	TitreImag varchar(30),
	images image,
	#IdAct int foreign key references Activite(IdAct),
	#IdAlb int foreign key references Albume(IdAlb),
	#IdPub int foreign key references Publicite(IdPub)
)

create table Filiere 
(
	IdFil int primary key  identity(1,1),
	Libelle varchar(30),
)

insert into Filiere values('SVT'), ('PH')


create table Matiere 
(
	IdMat int primary key  identity(1,1),
	Libelle varchar(30),
	#IdFil int foreign key references Filiere(IdFil)
)

insert into Matiere values('MATH',1)

create table Lecons
(
	IdLecs int primary key  identity(1,1),
	TitreLecs varchar(30),
	Fichier varbinary(MAX),
	#IdMat int foreign key references Matiere(IdMat)
)

create table Enseignant
(
	IdEns int primary key  identity(1,1),
	Nom varchar(30),
	Prenom varchar(30),
	Mail varchar(30),
	MotDePasse varchar(30),
	#IdMat int foreign key references Matiere(IdMat)
)

create table Classe
(
	IdClas int primary key  identity(1,1),
	Libelle varchar(30),
	#IdFil int foreign key references Filiere(IdFil),
	#IdEns int foreign key references Enseignant(IdEns)
)

create table Niveau
(
	IdNiv int primary key  identity(1,1),
	Libelle varchar(30),
)


insert into Niveau values('TCS'), ('1BAC-S'), ('2BAC-S')


create table Administrateur
(
	IdAdmi int primary key  identity(1,1),
	Nom varchar(30),
	Prenom varchar(30),
	Mail varchar(30) unique,
	MotDePasse varchar(30),
)

insert into Administrateur values('Admin','Admin','Admin.Admin@Abdelmoumen.com','Admin123')

create table Visiteur
(
	IdVis int primary key  identity(1,1),
	Nom varchar(30),
	Mail varchar(100),
)

create table Eleve
(
	IdElv int primary key  identity(1,1),
	Numero int,
	Massar varchar(30),
	Nom varchar(30),
	Prenom varchar(30),
	Mail varchar(30) unique,
	MotDePasse varchar(30),
	#IdClas int foreign key references Classe(IdClas),
	#IdNiv int foreign key references Niveau(IdNiv)
)

create table Certificat
(
	IdCert int primary key  identity(1,1),
	Disponibilite varchar(30),
	#IdElv int foreign key references Eleve(IdElv)
)

create table Insat
(
	IdInsat int primary key  identity(1,1),
	Probleme varchar(500),
	#IdElv int foreign key references Eleve(IdElv)
)