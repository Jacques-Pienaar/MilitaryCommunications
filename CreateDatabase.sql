USE [master]
GO

/****** Object:  Database [MilitaryComms]    Script Date: 2019/05/09 09:29:50 ******/
CREATE DATABASE [MilitaryComms];
GO

ALTER DATABASE [MilitaryComms] SET COMPATIBILITY_LEVEL = 140
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MilitaryComms].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [MilitaryComms] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [MilitaryComms] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [MilitaryComms] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [MilitaryComms] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [MilitaryComms] SET ARITHABORT OFF 
GO

ALTER DATABASE [MilitaryComms] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [MilitaryComms] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [MilitaryComms] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [MilitaryComms] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [MilitaryComms] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [MilitaryComms] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [MilitaryComms] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [MilitaryComms] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [MilitaryComms] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [MilitaryComms] SET  DISABLE_BROKER 
GO

ALTER DATABASE [MilitaryComms] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [MilitaryComms] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [MilitaryComms] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [MilitaryComms] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [MilitaryComms] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [MilitaryComms] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [MilitaryComms] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [MilitaryComms] SET RECOVERY FULL 
GO

ALTER DATABASE [MilitaryComms] SET  MULTI_USER 
GO

ALTER DATABASE [MilitaryComms] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [MilitaryComms] SET DB_CHAINING OFF 
GO

ALTER DATABASE [MilitaryComms] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [MilitaryComms] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [MilitaryComms] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [MilitaryComms] SET QUERY_STORE = OFF
GO

ALTER DATABASE [MilitaryComms] SET  READ_WRITE 
GO

USE MilitaryComms
GO

CREATE TABLE Officers
(
OfficerID		int identity(1,1001) primary key,
FirstName		varchar(50) NOT NULL,		
LastName 		varchar(50) NOT NULL,
Age				int NOT NULL,
[Rank]			int ,
Username		varchar(50) NOT NULL,
Password		varchar(50) NOT NULL,

CHECK(([Rank] >= 0) AND ([Rank] <=2))
)

CREATE TABLE Actions
(
ActionID		int identity(3,1001) primary key,
ActionName		varchar(50) NOT NULL,
[Description]	varchar(250)
)

CREATE TABLE OfficerLogs
(
LogID			int identity(1,101) primary key,
OfficerID		int foreign key(OfficerID) references Officers(OfficerID),
LogPath			varchar(50) NOT NULL,
LogDate			DateTime NOT NULL,
ActionID		int foreign key(ActionID) references actions(ActionID)
)
GO


