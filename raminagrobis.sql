USE [master]
GO
/****** Object:  Database [raminagrobis]    Script Date: 06/02/2022 19:17:40 ******/
CREATE DATABASE [raminagrobis]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'raminagrobis', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\raminagrobis.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'raminagrobis_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\raminagrobis_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [raminagrobis] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [raminagrobis].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [raminagrobis] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [raminagrobis] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [raminagrobis] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [raminagrobis] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [raminagrobis] SET ARITHABORT OFF 
GO
ALTER DATABASE [raminagrobis] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [raminagrobis] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [raminagrobis] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [raminagrobis] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [raminagrobis] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [raminagrobis] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [raminagrobis] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [raminagrobis] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [raminagrobis] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [raminagrobis] SET  DISABLE_BROKER 
GO
ALTER DATABASE [raminagrobis] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [raminagrobis] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [raminagrobis] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [raminagrobis] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [raminagrobis] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [raminagrobis] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [raminagrobis] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [raminagrobis] SET RECOVERY FULL 
GO
ALTER DATABASE [raminagrobis] SET  MULTI_USER 
GO
ALTER DATABASE [raminagrobis] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [raminagrobis] SET DB_CHAINING OFF 
GO
ALTER DATABASE [raminagrobis] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [raminagrobis] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [raminagrobis] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [raminagrobis] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'raminagrobis', N'ON'
GO
ALTER DATABASE [raminagrobis] SET QUERY_STORE = OFF
GO
USE [raminagrobis]
GO
/****** Object:  Table [dbo].[Adherent]    Script Date: 06/02/2022 19:17:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Adherent](
	[id] [int] NOT NULL,
	[nom] [varchar](50) NOT NULL,
	[prenomC] [varchar](50) NOT NULL,
	[nomC] [varchar](50) NULL,
	[sexeC] [varchar](50) NULL,
	[email] [varchar](250) NULL,
	[adresse] [varchar](250) NULL,
	[dateA] [date] NULL,
 CONSTRAINT [PK_Adherent] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssoRefFournisseur]    Script Date: 06/02/2022 19:17:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssoRefFournisseur](
	[idRef] [int] NOT NULL,
	[idFournisseur] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fournisseur]    Script Date: 06/02/2022 19:17:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fournisseur](
	[id] [int] NOT NULL,
	[nom] [varchar](50) NOT NULL,
	[prenomC] [varchar](50) NOT NULL,
	[nomC] [varchar](50) NOT NULL,
	[sexeC] [bit] NOT NULL,
	[email] [varchar](250) NOT NULL,
	[adresse] [varchar](250) NOT NULL,
 CONSTRAINT [PK_Fournisseur] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LignePanier]    Script Date: 06/02/2022 19:17:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LignePanier](
	[id] [int] NOT NULL,
	[idRef] [int] NOT NULL,
	[quantite] [int] NOT NULL,
	[idPanier] [int] NOT NULL,
 CONSTRAINT [PK_LignePanier] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LignePanierG]    Script Date: 06/02/2022 19:17:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LignePanierG](
	[id] [int] NOT NULL,
	[idPanierG] [int] NOT NULL,
	[idRef] [int] NOT NULL,
 CONSTRAINT [PK_LignePanierG] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Panier]    Script Date: 06/02/2022 19:17:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Panier](
	[id] [int] NOT NULL,
	[idAdherent] [int] NOT NULL,
	[idPanierG] [int] NOT NULL,
 CONSTRAINT [PK_Panier] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PanierGlobal]    Script Date: 06/02/2022 19:17:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PanierGlobal](
	[id] [int] NOT NULL,
	[date] [date] NOT NULL,
 CONSTRAINT [PK_PanierGlobale] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prix]    Script Date: 06/02/2022 19:17:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prix](
	[idLignePanierG] [int] NOT NULL,
	[idFournisseur] [int] NOT NULL,
	[prix] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reference]    Script Date: 06/02/2022 19:17:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reference](
	[id] [int] NOT NULL,
	[ref] [varchar](250) NOT NULL,
	[nom] [varchar](250) NOT NULL,
	[marque] [varchar](250) NOT NULL,
 CONSTRAINT [PK_Reference] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AssoRefFournisseur]  WITH CHECK ADD  CONSTRAINT [FK_AssoRefFournisseur_Fournisseur] FOREIGN KEY([idFournisseur])
REFERENCES [dbo].[Fournisseur] ([id])
GO
ALTER TABLE [dbo].[AssoRefFournisseur] CHECK CONSTRAINT [FK_AssoRefFournisseur_Fournisseur]
GO
ALTER TABLE [dbo].[AssoRefFournisseur]  WITH CHECK ADD  CONSTRAINT [FK_AssoRefFournisseur_Reference] FOREIGN KEY([idRef])
REFERENCES [dbo].[Reference] ([id])
GO
ALTER TABLE [dbo].[AssoRefFournisseur] CHECK CONSTRAINT [FK_AssoRefFournisseur_Reference]
GO
ALTER TABLE [dbo].[LignePanier]  WITH CHECK ADD  CONSTRAINT [FK_LignePanier_Panier] FOREIGN KEY([idPanier])
REFERENCES [dbo].[Panier] ([id])
GO
ALTER TABLE [dbo].[LignePanier] CHECK CONSTRAINT [FK_LignePanier_Panier]
GO
ALTER TABLE [dbo].[LignePanier]  WITH CHECK ADD  CONSTRAINT [FK_LignePanier_Reference] FOREIGN KEY([idRef])
REFERENCES [dbo].[Reference] ([id])
GO
ALTER TABLE [dbo].[LignePanier] CHECK CONSTRAINT [FK_LignePanier_Reference]
GO
ALTER TABLE [dbo].[LignePanierG]  WITH CHECK ADD  CONSTRAINT [FK_LignePanierG_PanierGlobal] FOREIGN KEY([idPanierG])
REFERENCES [dbo].[PanierGlobal] ([id])
GO
ALTER TABLE [dbo].[LignePanierG] CHECK CONSTRAINT [FK_LignePanierG_PanierGlobal]
GO
ALTER TABLE [dbo].[LignePanierG]  WITH CHECK ADD  CONSTRAINT [FK_LignePanierG_Reference] FOREIGN KEY([idRef])
REFERENCES [dbo].[Reference] ([id])
GO
ALTER TABLE [dbo].[LignePanierG] CHECK CONSTRAINT [FK_LignePanierG_Reference]
GO
ALTER TABLE [dbo].[Panier]  WITH CHECK ADD  CONSTRAINT [FK_Panier_Adherent] FOREIGN KEY([idAdherent])
REFERENCES [dbo].[Adherent] ([id])
GO
ALTER TABLE [dbo].[Panier] CHECK CONSTRAINT [FK_Panier_Adherent]
GO
ALTER TABLE [dbo].[Panier]  WITH CHECK ADD  CONSTRAINT [FK_Panier_PanierGlobal] FOREIGN KEY([idPanierG])
REFERENCES [dbo].[PanierGlobal] ([id])
GO
ALTER TABLE [dbo].[Panier] CHECK CONSTRAINT [FK_Panier_PanierGlobal]
GO
ALTER TABLE [dbo].[Prix]  WITH CHECK ADD  CONSTRAINT [FK_Prix_Fournisseur] FOREIGN KEY([idFournisseur])
REFERENCES [dbo].[Fournisseur] ([id])
GO
ALTER TABLE [dbo].[Prix] CHECK CONSTRAINT [FK_Prix_Fournisseur]
GO
ALTER TABLE [dbo].[Prix]  WITH CHECK ADD  CONSTRAINT [FK_Prix_LignePanierG] FOREIGN KEY([idLignePanierG])
REFERENCES [dbo].[LignePanierG] ([id])
GO
ALTER TABLE [dbo].[Prix] CHECK CONSTRAINT [FK_Prix_LignePanierG]
GO
USE [master]
GO
ALTER DATABASE [raminagrobis] SET  READ_WRITE 
GO
