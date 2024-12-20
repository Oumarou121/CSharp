-- Active: 1731016369274@@127.0.0.1@3306@TP6
CREATE DATABASE TP6;

USE TP6;

CREATE TABLE Fournisseur (
    Code INT PRIMARY KEY AUTO_INCREMENT,
    Nom VARCHAR(255) NOT NULL
);

CREATE TABLE Article (
    Reference INT PRIMARY KEY AUTO_INCREMENT,
    CodeF INT NOT NULL,
    Designation VARCHAR(255) NOT NULL,
    Prix DECIMAL(10, 3) NOT NULL,
    CONSTRAINT fk_code 
    FOREIGN KEY (CodeF)
    REFERENCES Fournisseur (Code)
        ON DELETE CASCADE 
        ON UPDATE CASCADE
);