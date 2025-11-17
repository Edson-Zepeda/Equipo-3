-- Tablas base para biblioteca

CREATE TABLE IF NOT EXISTS socios (
  id INT AUTO_INCREMENT PRIMARY KEY,
  nombre VARCHAR(150) NOT NULL,
  documento VARCHAR(50) NOT NULL UNIQUE,
  email VARCHAR(150),
  estado VARCHAR(20) NOT NULL DEFAULT 'ACTIVO',
  fecha_alta DATETIME NOT NULL
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS libros (
  id INT AUTO_INCREMENT PRIMARY KEY,
  titulo VARCHAR(200) NOT NULL,
  autor VARCHAR(150),
  categoria VARCHAR(150),
  isbn VARCHAR(40) UNIQUE,
  precio DECIMAL(10,2),
  stock INT DEFAULT 0
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS ejemplares (
  id INT AUTO_INCREMENT PRIMARY KEY,
  libro_id INT NOT NULL,
  codigo_barra VARCHAR(80) NOT NULL UNIQUE,
  estado VARCHAR(20) NOT NULL DEFAULT 'DISPONIBLE',
  ubicacion VARCHAR(120),
  CONSTRAINT fk_ej_libro FOREIGN KEY (libro_id) REFERENCES libros(id) ON DELETE CASCADE
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS prestamos (
  id INT AUTO_INCREMENT PRIMARY KEY,
  socio_id INT NOT NULL,
  ejemplar_id INT NOT NULL,
  fecha_prestamo DATETIME NOT NULL,
  fecha_vencimiento DATETIME NOT NULL,
  fecha_devolucion DATETIME NULL,
  estado VARCHAR(20) NOT NULL,
  CONSTRAINT fk_pr_soc FOREIGN KEY (socio_id) REFERENCES socios(id),
  CONSTRAINT fk_pr_ej FOREIGN KEY (ejemplar_id) REFERENCES ejemplares(id)
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS reservas (
  id INT AUTO_INCREMENT PRIMARY KEY,
  socio_id INT NOT NULL,
  libro_id INT NOT NULL,
  fecha DATETIME NOT NULL,
  estado VARCHAR(20) NOT NULL,
  CONSTRAINT fk_res_soc FOREIGN KEY (socio_id) REFERENCES socios(id),
  CONSTRAINT fk_res_lib FOREIGN KEY (libro_id) REFERENCES libros(id)
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS multas (
  id INT AUTO_INCREMENT PRIMARY KEY,
  socio_id INT NOT NULL,
  prestamo_id INT NOT NULL,
  monto DECIMAL(10,2) NOT NULL,
  fecha DATETIME NOT NULL,
  pagada BIT NOT NULL DEFAULT 0,
  CONSTRAINT fk_mu_soc FOREIGN KEY (socio_id) REFERENCES socios(id),
  CONSTRAINT fk_mu_pr FOREIGN KEY (prestamo_id) REFERENCES prestamos(id)
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS auditoria (
  id INT AUTO_INCREMENT PRIMARY KEY,
  usuario_id INT NULL,
  accion VARCHAR(50) NOT NULL,
  entidad VARCHAR(50) NOT NULL,
  entidad_id INT NULL,
  fecha DATETIME NOT NULL,
  detalle TEXT
) ENGINE=InnoDB;
