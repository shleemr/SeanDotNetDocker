
CREATE DATABASE IF NOT EXISTS seandb;
USE seandb;
DROP TABLE IF EXISTS `Users`;
CREATE TABLE `Users` (
  `Uid` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `UserType` int(1) DEFAULT '1',
  `UserLevel` int(11) DEFAULT '1',
  `Email` varchar(256) NOT NULL,
  `Password` varchar(256) NOT NULL,
  `CombinedPhoneNumber` varchar(25) DEFAULT NULL,
  `PostCode` varchar(20) DEFAULT NULL,
  `Address` varchar(256) DEFAULT NULL,
  `Country` varchar(128) DEFAULT NULL,
  `PerchasedItem` varchar(256) DEFAULT NULL,
  `RegDate` datetime DEFAULT CURRENT_TIMESTAMP,
  `UserName` varchar(256) DEFAULT NULL,
  `SmsSend` int(1) DEFAULT '1',
  `EmailSend` int(1) DEFAULT '1',
  `IsUserValid` int(1) DEFAULT '1',
  `LastLoginTime` datetime DEFAULT CURRENT_TIMESTAMP,
  `LanguageCode` varchar(2) DEFAULT 'ko',
  `DeviceInfo` varchar(256) DEFAULT NULL,
  PRIMARY KEY (`Uid`),
  UNIQUE KEY `Email` (`Email`)
) ENGINE=InnoDB AUTO_INCREMENT=67 DEFAULT CHARSET=utf8;

CREATE TABLE `WebSettings` (
   `Id` int(11) NOT NULL AUTO_INCREMENT,
   `SettingKey` varchar(256) NOT NULL,
   `Value` varchar(256) NOT NULL,
   PRIMARY KEY (`Id`)
 ) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8