create database ExamenOefenen
go
create table users(
userID int not null primary key identity,
username varchar(50) unique)
go
create table vakken(
vakID int not null primary key identity,
vakNaam varchar(50) unique,
vakBeschrijving varchar(250),
userID int not null foreign key references users(userID))
go
create table vragen(
vraagID int not null primary key identity,
vraagstuk varchar(250),
antwoord varchar(250),
vakID int not null foreign key references vakken(vakID))