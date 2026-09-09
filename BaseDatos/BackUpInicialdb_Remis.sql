-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         8.4.3 - MySQL Community Server - GPL
-- SO del servidor:              Win64
-- HeidiSQL Versión:             12.16.0.7229
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Volcando estructura de base de datos para bd_remis2026
CREATE DATABASE IF NOT EXISTS `bd_remis2026` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `bd_remis2026`;

-- Volcando estructura para tabla bd_remis2026.autos
CREATE TABLE IF NOT EXISTS `autos` (
  `IdAuto` int NOT NULL AUTO_INCREMENT,
  `numero_movil` varchar(10) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `patente` varchar(15) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `marca` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `modelo` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `anio` varchar(4) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `color` varchar(20) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `fecha_alta` date DEFAULT NULL,
  `activo` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`IdAuto`),
  UNIQUE KEY `patente` (`patente`),
  UNIQUE KEY `numero_movil` (`numero_movil`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Volcando datos para la tabla bd_remis2026.autos: ~0 rows (aproximadamente)

-- Volcando estructura para tabla bd_remis2026.chofer_movil
CREATE TABLE IF NOT EXISTS `chofer_movil` (
  `IdChoferMovil` int NOT NULL AUTO_INCREMENT,
  `id_chofer` int DEFAULT NULL,
  `id_auto` int DEFAULT NULL,
  `fechaDesde` date DEFAULT NULL,
  `fechaHasta` date DEFAULT NULL,
  PRIMARY KEY (`IdChoferMovil`),
  KEY `FK_chofer_movil_choferes` (`id_chofer`),
  KEY `FK_chofer_movil_autos` (`id_auto`),
  CONSTRAINT `FK_chofer_movil_autos` FOREIGN KEY (`id_auto`) REFERENCES `autos` (`IdAuto`),
  CONSTRAINT `FK_chofer_movil_choferes` FOREIGN KEY (`id_chofer`) REFERENCES `choferes` (`IdChofer`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Volcando datos para la tabla bd_remis2026.chofer_movil: ~0 rows (aproximadamente)

-- Volcando estructura para tabla bd_remis2026.choferes
CREATE TABLE IF NOT EXISTS `choferes` (
  `IdChofer` int NOT NULL AUTO_INCREMENT,
  `id_persona` int DEFAULT NULL,
  `nro_licencia` varchar(20) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `categoria_licencia` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `vencimiento_licencia` date DEFAULT NULL,
  `fecha_ingreso` date DEFAULT NULL,
  `tipo_relacion` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `activo` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`IdChofer`),
  UNIQUE KEY `nro_licencia` (`nro_licencia`),
  KEY `FK_choferes_personas` (`id_persona`),
  CONSTRAINT `FK_choferes_personas` FOREIGN KEY (`id_persona`) REFERENCES `personas` (`IdPersona`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Volcando datos para la tabla bd_remis2026.choferes: ~0 rows (aproximadamente)

-- Volcando estructura para tabla bd_remis2026.clientes
CREATE TABLE IF NOT EXISTS `clientes` (
  `IdCliente` int NOT NULL AUTO_INCREMENT,
  `id_persona` int DEFAULT NULL,
  `codigoCliente` varchar(10) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `observacion` text COLLATE utf8mb4_general_ci,
  `activo` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`IdCliente`),
  UNIQUE KEY `codigoCliente` (`codigoCliente`),
  KEY `FK_clientes_personas` (`id_persona`),
  CONSTRAINT `FK_clientes_personas` FOREIGN KEY (`id_persona`) REFERENCES `personas` (`IdPersona`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Volcando datos para la tabla bd_remis2026.clientes: ~0 rows (aproximadamente)

-- Volcando estructura para tabla bd_remis2026.historial_estado_viaje
CREATE TABLE IF NOT EXISTS `historial_estado_viaje` (
  `Idhistorial` int NOT NULL AUTO_INCREMENT,
  `id_viaje` int DEFAULT NULL,
  `id_usuario` int DEFAULT NULL,
  `observacion` text COLLATE utf8mb4_general_ci,
  `fecha` date DEFAULT NULL,
  PRIMARY KEY (`Idhistorial`),
  KEY `FK_historial_estado_viaje_viajes` (`id_viaje`),
  KEY `FK_historial_estado_viaje_usuarios` (`id_usuario`),
  CONSTRAINT `FK_historial_estado_viaje_usuarios` FOREIGN KEY (`id_usuario`) REFERENCES `usuarios` (`IdUsuario`),
  CONSTRAINT `FK_historial_estado_viaje_viajes` FOREIGN KEY (`id_viaje`) REFERENCES `viajes` (`IdViaje`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Volcando datos para la tabla bd_remis2026.historial_estado_viaje: ~0 rows (aproximadamente)

-- Volcando estructura para tabla bd_remis2026.personas
CREATE TABLE IF NOT EXISTS `personas` (
  `IdPersona` int NOT NULL AUTO_INCREMENT,
  `apellido` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `nombre` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `dni` varchar(10) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `telefono` varchar(20) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `email` varchar(100) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `direccion` varchar(100) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `fecha_alta` date DEFAULT NULL,
  `activo` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`IdPersona`),
  UNIQUE KEY `dni` (`dni`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Volcando datos para la tabla bd_remis2026.personas: ~0 rows (aproximadamente)

-- Volcando estructura para tabla bd_remis2026.roles
CREATE TABLE IF NOT EXISTS `roles` (
  `IdRol` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(255) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `descripcion` varchar(255) COLLATE utf8mb4_general_ci DEFAULT NULL,
  PRIMARY KEY (`IdRol`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Volcando datos para la tabla bd_remis2026.roles: ~0 rows (aproximadamente)

-- Volcando estructura para tabla bd_remis2026.usuario_rol
CREATE TABLE IF NOT EXISTS `usuario_rol` (
  `id_rol` int NOT NULL,
  `id_usuario` int NOT NULL,
  PRIMARY KEY (`id_rol`,`id_usuario`),
  KEY `FK_usuario_rol_usuarios` (`id_usuario`),
  CONSTRAINT `FK_usuario_rol_roles` FOREIGN KEY (`id_rol`) REFERENCES `roles` (`IdRol`),
  CONSTRAINT `FK_usuario_rol_usuarios` FOREIGN KEY (`id_usuario`) REFERENCES `usuarios` (`IdUsuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Volcando datos para la tabla bd_remis2026.usuario_rol: ~0 rows (aproximadamente)

-- Volcando estructura para tabla bd_remis2026.usuarios
CREATE TABLE IF NOT EXISTS `usuarios` (
  `IdUsuario` int NOT NULL AUTO_INCREMENT,
  `id_persona` int DEFAULT NULL,
  `usuario` varchar(100) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `password_hash` varchar(255) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `ultimoLogin` timestamp NULL DEFAULT NULL,
  `fechaCreacion` datetime DEFAULT NULL,
  `fechaActualizacion` datetime DEFAULT NULL,
  `activo` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`IdUsuario`),
  UNIQUE KEY `usuario` (`usuario`),
  KEY `FK_usuarios_personas` (`id_persona`),
  CONSTRAINT `FK_usuarios_personas` FOREIGN KEY (`id_persona`) REFERENCES `personas` (`IdPersona`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Volcando datos para la tabla bd_remis2026.usuarios: ~0 rows (aproximadamente)

-- Volcando estructura para tabla bd_remis2026.viajes
CREATE TABLE IF NOT EXISTS `viajes` (
  `IdViaje` int NOT NULL AUTO_INCREMENT,
  `id_chofer` int DEFAULT NULL,
  `id_cliente` int DEFAULT NULL,
  `id_auto` int DEFAULT NULL,
  `id_usuario` int DEFAULT NULL,
  `origen` varchar(255) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `destino` varchar(255) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `fecha_solicitud` datetime DEFAULT NULL,
  `importe` decimal(10,2) DEFAULT NULL,
  `estado` varchar(20) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `observacion` text COLLATE utf8mb4_general_ci,
  `activo` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`IdViaje`),
  KEY `FK_viajes_choferes` (`id_chofer`),
  KEY `FK_viajes_clientes` (`id_cliente`),
  KEY `FK_viajes_autos` (`id_auto`),
  KEY `FK_viajes_usuarios` (`id_usuario`),
  CONSTRAINT `FK_viajes_autos` FOREIGN KEY (`id_auto`) REFERENCES `autos` (`IdAuto`),
  CONSTRAINT `FK_viajes_choferes` FOREIGN KEY (`id_chofer`) REFERENCES `choferes` (`IdChofer`),
  CONSTRAINT `FK_viajes_clientes` FOREIGN KEY (`id_cliente`) REFERENCES `clientes` (`IdCliente`),
  CONSTRAINT `FK_viajes_usuarios` FOREIGN KEY (`id_usuario`) REFERENCES `usuarios` (`IdUsuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Volcando datos para la tabla bd_remis2026.viajes: ~0 rows (aproximadamente)

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
