CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(95) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
);


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190326220318_init') THEN

    CREATE TABLE `Configurations` (
        `Id` int NOT NULL,
        `Name` longtext NULL,
        `Value` longtext NULL,
        CONSTRAINT `PK_Configurations` PRIMARY KEY (`Id`)
    );

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190326220318_init') THEN

    CREATE TABLE `Folders` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `CreatedBy` longtext NULL,
        `CreatedAt` datetime(6) NOT NULL,
        `UpdatedBy` longtext NULL,
        `UpdatedAt` datetime(6) NULL,
        `Name` longtext NULL,
        `Path` varchar(255) NULL,
        `Crc` varchar(255) NULL,
        `EntryCreateAt` datetime(6) NOT NULL,
        `EntryModifiedAt` datetime(6) NOT NULL,
        `Status` int NOT NULL,
        `FolderType` int NOT NULL,
        `FolderId` int NULL,
        CONSTRAINT `PK_Folders` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_Folders_Folders_FolderId` FOREIGN KEY (`FolderId`) REFERENCES `Folders` (`Id`) ON DELETE RESTRICT
    );

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190326220318_init') THEN

    CREATE TABLE `Archive` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `CreatedBy` longtext NULL,
        `CreatedAt` datetime(6) NOT NULL,
        `UpdatedBy` longtext NULL,
        `UpdatedAt` datetime(6) NULL,
        `Name` longtext NULL,
        `Path` varchar(255) NULL,
        `Crc` varchar(255) NULL,
        `EntryCreateAt` datetime(6) NOT NULL,
        `EntryModifiedAt` datetime(6) NOT NULL,
        `ArchiveStatus` int NOT NULL,
        `Mediatype` int NOT NULL,
        `MetaDada` longtext NULL,
        `FolderId` int NULL,
        CONSTRAINT `PK_Archive` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_Archive_Folders_FolderId` FOREIGN KEY (`FolderId`) REFERENCES `Folders` (`Id`) ON DELETE RESTRICT
    );

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190326220318_init') THEN

    INSERT INTO `Configurations` (`Id`, `Name`, `Value`)
    VALUES (0, 'Root Path', 'E:\\MediaRoot');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190326220318_init') THEN

    INSERT INTO `Configurations` (`Id`, `Name`, `Value`)
    VALUES (1, 'Time Out', '10');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190326220318_init') THEN

    INSERT INTO `Configurations` (`Id`, `Name`, `Value`)
    VALUES (2, 'Drop Location', 'E:\\Drop');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190326220318_init') THEN

    CREATE INDEX `IX_Archive_Crc` ON `Archive` (`Crc`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190326220318_init') THEN

    CREATE INDEX `IX_Archive_FolderId` ON `Archive` (`FolderId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190326220318_init') THEN

    CREATE INDEX `IX_Archive_Path` ON `Archive` (`Path`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190326220318_init') THEN

    CREATE INDEX `IX_Folders_Crc` ON `Folders` (`Crc`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190326220318_init') THEN

    CREATE INDEX `IX_Folders_FolderId` ON `Folders` (`FolderId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190326220318_init') THEN

    CREATE INDEX `IX_Folders_Path` ON `Folders` (`Path`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190326220318_init') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20190326220318_init', '2.2.3-servicing-35854');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

