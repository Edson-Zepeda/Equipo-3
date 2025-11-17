CREATE DATABASE IF NOT EXISTS `prototipo2_db` CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE `prototipo2_db`;

CREATE TABLE IF NOT EXISTS `usuarios` (
  `id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `Usuario` VARCHAR(100) NOT NULL UNIQUE,
  `Clave` VARCHAR(255) NOT NULL,
  `EsAdmin` TINYINT(1) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS `libros` (
  `id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `Titulo` VARCHAR(200) NOT NULL,
  `Autor` VARCHAR(150) NOT NULL,
  `Categoria` VARCHAR(100) NOT NULL,
  `ISBN` VARCHAR(50) NOT NULL UNIQUE,
  `Stock` INT NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS `prestamos` (
  `id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `UsuarioId` INT NOT NULL,
  `LibroId` INT NOT NULL,
  `FechaInicio` DATETIME NOT NULL,
  `FechaLimite` DATETIME NOT NULL,
  `FechaDevolucion` DATETIME NULL,
  FOREIGN KEY (UsuarioId) REFERENCES usuarios(id),
  FOREIGN KEY (LibroId) REFERENCES libros(id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS `multas` (
  `id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `PrestamoId` INT NOT NULL UNIQUE,
  `Monto` DECIMAL(10,2) NOT NULL,
  `Pagada` TINYINT(1) NOT NULL DEFAULT 0,
  FOREIGN KEY (PrestamoId) REFERENCES prestamos(id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

INSERT IGNORE INTO usuarios (Usuario, Clave, EsAdmin) VALUES ('admin', 'admin', 1);

-- 5 sample books only; additional books will be added at runtime via BookSeeder
INSERT INTO libros (Titulo, Autor, Categoria, ISBN, Stock) VALUES
('Libro Demo 1','Autor Demo','General','ISBN0001',3),
('Libro Demo 2','Autor Demo','General','ISBN0002',2),
('Libro Demo 3','Autor Demo','General','ISBN0003',4),
('Libro Demo 4','Autor Demo','General','ISBN0004',1),
('Libro Demo 5','Autor Demo','General','ISBN0005',5);
