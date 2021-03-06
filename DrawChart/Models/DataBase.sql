-- MySQL Script generated by MySQL Workbench
-- Mon Jan 13 22:17:50 2020
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema chartDrawDatabase
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema chartDrawDatabase
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `chartDrawDatabase` DEFAULT CHARACTER SET utf8 ;
USE `chartDrawDatabase` ;

-- -----------------------------------------------------
-- Table `chartDrawDatabase`.`UserData`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `chartDrawDatabase`.`UserData` (
  `UserDataId` INT NOT NULL AUTO_INCREMENT,
  `RangeFrom` DOUBLE NOT NULL,
  `RangeTo` DOUBLE NOT NULL,
  `step` DOUBLE NOT NULL,
  `a` DOUBLE NOT NULL,
  `b` DOUBLE NOT NULL,
  `c` DOUBLE NOT NULL,
  PRIMARY KEY (`UserDataId`),
  UNIQUE INDEX `UserDataId_UNIQUE` (`UserDataId` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `chartDrawDatabase`.`Point`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `chartDrawDatabase`.`Point` (
  `PointId` INT NOT NULL AUTO_INCREMENT,
  `ChartId` INT NOT NULL,
  `PointX` DOUBLE NOT NULL,
  `PointY` DOUBLE NOT NULL,
  PRIMARY KEY (`PointId`),
  INDEX `UserDataToPoint_idx` (`ChartId` ASC) VISIBLE,
  CONSTRAINT `UserDataToPoint`
    FOREIGN KEY (`ChartId`)
    REFERENCES `chartDrawDatabase`.`UserData` (`UserDataId`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;

CREATE USER 'ChartUser' IDENTIFIED BY 'root';

GRANT ALL ON `chartDrawDatabase`.* TO 'ChartUser';
GRANT SELECT ON TABLE `chartDrawDatabase`.* TO 'ChartUser';
GRANT EXECUTE ON ROUTINE `chartDrawDatabase`.* TO 'ChartUser';
GRANT SELECT, INSERT, TRIGGER, UPDATE, DELETE ON TABLE `chartDrawDatabase`.* TO 'ChartUser';
GRANT SELECT, INSERT, TRIGGER ON TABLE `chartDrawDatabase`.* TO 'ChartUser';

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
