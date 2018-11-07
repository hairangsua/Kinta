USE [master]
GO

/****** Object:  Database [Kinta]    Script Date: 11/7/2018 10:41:52 PM ******/
CREATE DATABASE [Kinta]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Kinta', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\Kinta.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Kinta_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\Kinta_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

ALTER DATABASE [Kinta] SET COMPATIBILITY_LEVEL = 130
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Kinta].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Kinta] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Kinta] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Kinta] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Kinta] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Kinta] SET ARITHABORT OFF 
GO

ALTER DATABASE [Kinta] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Kinta] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Kinta] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Kinta] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Kinta] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Kinta] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Kinta] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Kinta] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Kinta] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Kinta] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Kinta] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Kinta] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Kinta] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Kinta] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Kinta] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Kinta] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Kinta] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Kinta] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [Kinta] SET  MULTI_USER 
GO

ALTER DATABASE [Kinta] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Kinta] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Kinta] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Kinta] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [Kinta] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [Kinta] SET QUERY_STORE = OFF
GO

USE [Kinta]
GO

ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO

ALTER DATABASE [Kinta] SET  READ_WRITE 
GO


