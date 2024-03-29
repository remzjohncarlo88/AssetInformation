USE [master]
GO
/****** Object:  Database [AssetInformation]    Script Date: 13/01/2024 9:45:10 pm ******/
CREATE DATABASE [AssetInformation]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AssetInformation', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQL2019DEV\MSSQL\DATA\AssetInformation.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AssetInformation_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQL2019DEV\MSSQL\DATA\AssetInformation_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [AssetInformation] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AssetInformation].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AssetInformation] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AssetInformation] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AssetInformation] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AssetInformation] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AssetInformation] SET ARITHABORT OFF 
GO
ALTER DATABASE [AssetInformation] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AssetInformation] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AssetInformation] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AssetInformation] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AssetInformation] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AssetInformation] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AssetInformation] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AssetInformation] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AssetInformation] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AssetInformation] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AssetInformation] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AssetInformation] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AssetInformation] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AssetInformation] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AssetInformation] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AssetInformation] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AssetInformation] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AssetInformation] SET RECOVERY FULL 
GO
ALTER DATABASE [AssetInformation] SET  MULTI_USER 
GO
ALTER DATABASE [AssetInformation] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AssetInformation] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AssetInformation] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AssetInformation] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AssetInformation] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AssetInformation] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'AssetInformation', N'ON'
GO
ALTER DATABASE [AssetInformation] SET QUERY_STORE = OFF
GO
USE [AssetInformation]
GO
/****** Object:  Table [dbo].[Asset]    Script Date: 13/01/2024 9:45:10 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asset](
	[AssetId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NOT NULL,
	[Symbol] [varchar](100) NOT NULL,
	[ISIN] [varchar](500) NOT NULL,
 CONSTRAINT [PK_Asset] PRIMARY KEY CLUSTERED 
(
	[AssetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssetSourcePrice]    Script Date: 13/01/2024 9:45:10 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssetSourcePrice](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AssetId] [int] NOT NULL,
	[SourceId] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_AssetSourcePrice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Source]    Script Date: 13/01/2024 9:45:10 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Source](
	[SourceId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NOT NULL,
 CONSTRAINT [PK_Source] PRIMARY KEY CLUSTERED 
(
	[SourceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Asset] ON 

INSERT [dbo].[Asset] ([AssetId], [Name], [Symbol], [ISIN]) VALUES (1, N'Microsoft Corporation', N'MFT', N'US5949181045')
INSERT [dbo].[Asset] ([AssetId], [Name], [Symbol], [ISIN]) VALUES (2, N'Sample', N'SAMPs', N'SA88')
SET IDENTITY_INSERT [dbo].[Asset] OFF
GO
SET IDENTITY_INSERT [dbo].[AssetSourcePrice] ON 

INSERT [dbo].[AssetSourcePrice] ([Id], [AssetId], [SourceId], [Price], [CreateDate]) VALUES (2, 1, 1, CAST(8.88 AS Decimal(18, 2)), CAST(N'2024-01-13T18:43:59.727' AS DateTime))
SET IDENTITY_INSERT [dbo].[AssetSourcePrice] OFF
GO
SET IDENTITY_INSERT [dbo].[Source] ON 

INSERT [dbo].[Source] ([SourceId], [Name]) VALUES (1, N'Reuters Market Data')
SET IDENTITY_INSERT [dbo].[Source] OFF
GO
ALTER TABLE [dbo].[AssetSourcePrice]  WITH CHECK ADD  CONSTRAINT [FK_AssetSourcePrice_Asset] FOREIGN KEY([AssetId])
REFERENCES [dbo].[Asset] ([AssetId])
GO
ALTER TABLE [dbo].[AssetSourcePrice] CHECK CONSTRAINT [FK_AssetSourcePrice_Asset]
GO
ALTER TABLE [dbo].[AssetSourcePrice]  WITH CHECK ADD  CONSTRAINT [FK_AssetSourcePrice_Source] FOREIGN KEY([SourceId])
REFERENCES [dbo].[Source] ([SourceId])
GO
ALTER TABLE [dbo].[AssetSourcePrice] CHECK CONSTRAINT [FK_AssetSourcePrice_Source]
GO
USE [master]
GO
ALTER DATABASE [AssetInformation] SET  READ_WRITE 
GO
