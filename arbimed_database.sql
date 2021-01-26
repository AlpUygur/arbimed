USE [master]
GO
/****** Object:  Database [arbimed]    Script Date: 26.01.2021 16:52:25 ******/
CREATE DATABASE [arbimed]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'arbimed', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\arbimed.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'arbimed_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\arbimed_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [arbimed] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [arbimed].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [arbimed] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [arbimed] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [arbimed] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [arbimed] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [arbimed] SET ARITHABORT OFF 
GO
ALTER DATABASE [arbimed] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [arbimed] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [arbimed] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [arbimed] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [arbimed] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [arbimed] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [arbimed] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [arbimed] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [arbimed] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [arbimed] SET  DISABLE_BROKER 
GO
ALTER DATABASE [arbimed] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [arbimed] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [arbimed] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [arbimed] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [arbimed] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [arbimed] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [arbimed] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [arbimed] SET RECOVERY FULL 
GO
ALTER DATABASE [arbimed] SET  MULTI_USER 
GO
ALTER DATABASE [arbimed] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [arbimed] SET DB_CHAINING OFF 
GO
ALTER DATABASE [arbimed] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [arbimed] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [arbimed] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [arbimed] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'arbimed', N'ON'
GO
ALTER DATABASE [arbimed] SET QUERY_STORE = OFF
GO
USE [arbimed]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 26.01.2021 16:52:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Driver]    Script Date: 26.01.2021 16:52:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Driver](
	[DriverId] [int] IDENTITY(1,1) NOT NULL,
	[LicenseNumber] [nvarchar](50) NULL,
	[UsedVehicleCount] [int] NOT NULL,
 CONSTRAINT [PK_Driver] PRIMARY KEY CLUSTERED 
(
	[DriverId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trip]    Script Date: 26.01.2021 16:52:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trip](
	[VehicleId] [int] NOT NULL,
	[DriverId] [int] NOT NULL,
	[DistanceInKilometers] [decimal](18, 2) NOT NULL,
	[FuelConsumptionInLitres] [decimal](18, 2) NOT NULL,
	[TripId] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Trip] PRIMARY KEY CLUSTERED 
(
	[TripId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicle]    Script Date: 26.01.2021 16:52:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicle](
	[VehicleID] [int] IDENTITY(1,1) NOT NULL,
	[PlateNumber] [nvarchar](10) NULL,
	[LastTripDateTime] [datetime2](7) NOT NULL,
	[TotalTravelDistanceInKilometers] [decimal](18, 2) NOT NULL,
	[AverageFuelConsumptionInLitres] [decimal](6, 2) NOT NULL,
 CONSTRAINT [PK_Vehicle] PRIMARY KEY CLUSTERED 
(
	[VehicleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Driver] ADD  DEFAULT ((0)) FOR [UsedVehicleCount]
GO
ALTER TABLE [dbo].[Vehicle] ADD  DEFAULT ((0.0)) FOR [TotalTravelDistanceInKilometers]
GO
USE [master]
GO
ALTER DATABASE [arbimed] SET  READ_WRITE 
GO
