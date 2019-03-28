
CREATE DATABASE IF NOT EXISTS seandb;
USE seandb;

SET foreign_key_checks = 0;

DROP TABLE IF EXISTS `AccountLogs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `AccountLogs` (
  `Id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `UserId` varchar(256) NOT NULL,
  `FailedPasswordAttemptCount` int(11) DEFAULT '0',
  `FailedPasswordAttemptWindowStart` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `AspNetRoles`
--

DROP TABLE IF EXISTS `AspNetRoles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `AspNetRoles` (
  `Id` varchar(255) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` longtext,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `AspNetRoleClaims`
--

DROP TABLE IF EXISTS `AspNetRoleClaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `AspNetRoleClaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `RoleId` varchar(255) NOT NULL,
  `ClaimType` longtext,
  `ClaimValue` longtext,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;



--
-- Table structure for table `AspNetUserClaims`
--

DROP TABLE IF EXISTS `AspNetUserClaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `AspNetUserClaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` varchar(255) NOT NULL,
  `ClaimType` varchar(256) DEFAULT NULL,
  `ClaimValue` varchar(256) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=75 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `AspNetUsers`
--

DROP TABLE IF EXISTS `AspNetUsers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `AspNetUsers` (
  `Id` varchar(255) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` bit(1) NOT NULL,
  `PasswordHash` longtext,
  `SecurityStamp` longtext,
  `ConcurrencyStamp` longtext,
  `PhoneNumber` longtext,
  `PhoneNumberConfirmed` bit(1) NOT NULL,
  `TwoFactorEnabled` bit(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` bit(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  `InstitutionId` longtext,
  `Role` longtext,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `NormalizedUserName` (`NormalizedUserName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Table structure for table `AspNetUserLogins`
--

DROP TABLE IF EXISTS `AspNetUserLogins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `AspNetUserLogins` (
  `LoginProvider` varchar(255) NOT NULL,
  `ProviderKey` varchar(255) NOT NULL,
  `ProviderDisplayName` longtext,
  `UserId` varchar(255) NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_AspNetUserLogins_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `AspNetUserRoles`
--

DROP TABLE IF EXISTS `AspNetUserRoles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `AspNetUserRoles` (
  `UserId` varchar(255) NOT NULL,
  `RoleId` varchar(255) NOT NULL,
  PRIMARY KEY (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `AspNetUserTokens`
--

DROP TABLE IF EXISTS `AspNetUserTokens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `AspNetUserTokens` (
  `UserId` varchar(255) NOT NULL,
  `LoginProvider` varchar(255) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Value` longtext,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`),
  CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;



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
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `WebSettings`;
CREATE TABLE `WebSettings` (
   `Id` int(11) NOT NULL AUTO_INCREMENT,
   `SettingKey` varchar(256) NOT NULL,
   `Value` varchar(256) NOT NULL,
   PRIMARY KEY (`Id`)
 ) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;

INSERT INTO WebSettings (SettingKey, Value)
VALUES ('sean', 'Sean is genius');

DROP TABLE IF EXISTS `Notes`;
CREATE TABLE `Notes`
(
    `Id`              Int(11) unsigned NOT NULL AUTO_INCREMENT,   -- 번호
    `Name`            VarChar(25) Not Null,                      -- 이름
    `Email`           VarChar(100) Null,                         -- 이메일 
    `Title`           VarChar(150) Not Null,                     -- 제목
    `PostDate`        DateTime Default CURRENT_TIMESTAMP,        -- 작성일 
    `PostIp`          VarChar(15) Null,                          -- 작성IP
    `Content`         Text Not Null,                             -- 내용
    `Password`        VarChar(255) Null,                         -- 비밀번호
    `ReadCount`       Int(10) Default 0,                              -- 조회수
    `Encoding`        VarChar(10) Not Null,                      -- 인코딩(HTML/Text)
    `Homepage`        VarChar(100) Null,                         -- 홈페이지
    `ModifyDate`      DateTime Null,                              -- 수정일 
    `ModifyIp`        VarChar(15) Null,                          -- 수정IP
    `FileName`        VarChar(255) Null,                         -- 파일명
    `FileSize`        Int(10) Default 0,                              -- 파일크기
    `DownCount`       Int(10) Default 0,                              -- 다운수 
    `Ref`             Int(10) Default 0,                               -- 참조(부모글)
    `Step`            Int(10) Default 0,                              -- 답변깊이(레벨)
    `RefOrder`        Int(10) Default 0,                              -- 답변순서
    `AnswerNum`       Int(10) Default 0,                              -- 답변수
    `ParentNum`       Int(10) Default 0,                              -- 부모글번호
    `CommentCount`    Int(10) Default 0,                              -- 댓글수
    `Category`        VarChar(10) Default Null,          -- 카테고리(확장...)
    -- 추가: 필요한 항목 추가
    `Num`             Int(10) Null Default 0,                                   -- 번호(확장...)
    `UserId`          Int(10) Null Default -1,                                   -- (확장...) 사용자 테이블 Id
    `CategoryId`      Int(10) Null Default 0,                         -- (확장...) 카테고리 테이블 Id
    `BoardId`         Int(10) Null Default 0,                         -- (확장...) 게시판(Boards) 테이블 Id
    `AplicationId`    Int(10) Null Default 0,                          -- (확장용) 응용 프로그램 Id
    PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `NoteComments`;
CREATE TABLE `NoteComments`
(
    Id          Int(11) unsigned Not Null Primary Key,               -- 일련번호
    BoardName   VarChar(50) Null,                  -- 게시판이름(확장): Notice
    BoardId     Int(10) Not Null,                       -- 해당 게시판의 게시물 번호(ArticleId) 
    Name        VarChar(25) Not Null,              -- 작성자
    Opinion     VarChar(4000) Not Null,            -- 댓글 내용
    PostDate    DATETIME DEFAULT CURRENT_TIMESTAMP,        -- 작성일
    Password    VarChar(255) Not Null              -- 댓글 삭제용 암호
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;

SET foreign_key_checks = 1;