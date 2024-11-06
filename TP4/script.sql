CREATE DATABASE Stock;

USE Stock;

CREATE TABLE Article(
    Reference INT PRIMARY KEY,
    Designation VARCHAR(255),
    Prix DECIMAL(10,5)
);