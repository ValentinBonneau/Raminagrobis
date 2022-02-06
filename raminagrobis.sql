/****** Créer au préalable la base de donnée ******/
USE [raminagrobis]
GO
/****** Object:  Table [dbo].[Adherent]    Script Date: 09/12/2021 22:09:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Adherent](
	[id] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[AssoRefFournisseur]    Script Date: 09/12/2021 22:09:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssoRefFournisseur](
	[idRef] [int] NOT NULL,
	[idFournisseur] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fournisseur]    Script Date: 09/12/2021 22:09:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fournisseur](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nom] [varchar](50) NOT NULL,
	[prenomC] [varchar](50) NOT NULL,
	[nomC] [varchar](50) NOT NULL,
	[sexeC] [varchar](50) NOT NULL,
	[email] [varchar](250) NOT NULL,
	[adresse] [varchar](250) NOT NULL,
 CONSTRAINT [PK_Fournisseur] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LignePanier]    Script Date: 09/12/2021 22:09:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LignePanier](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idRef] [int] NOT NULL,
	[quantite] [int] NOT NULL,
	[idPanier] [int] NOT NULL,
 CONSTRAINT [PK_LignePanier] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LignePanierG]    Script Date: 09/12/2021 22:09:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LignePanierG](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idPanierG] [int] NOT NULL,
	[idRef] [int] NOT NULL,
	[quantite] [int] NOT NULL,
 CONSTRAINT [PK_LignePanierG] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Panier]    Script Date: 09/12/2021 22:09:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Panier](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idAdherent] [int] NOT NULL,
	[idPanierG] [int] NULL,
 CONSTRAINT [PK_Panier] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PanierGlobal]    Script Date: 09/12/2021 22:09:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PanierGlobal](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [date] NOT NULL,
 CONSTRAINT [PK_PanierGlobale] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prix]    Script Date: 09/12/2021 22:09:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prix](
	[idLignePanierG] [int] IDENTITY(1,1) NOT NULL,
	[idFournisseur] [int] NOT NULL,
	[prix] [float] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reference]    Script Date: 09/12/2021 22:09:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reference](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ref] [varchar](250) NOT NULL,
	[nom] [varchar](250) NOT NULL,
	[marque] [varchar](250) NOT NULL,
 CONSTRAINT [PK_Reference] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
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
ALTER TABLE [dbo].[LignePanierG]  WITH CHECK ADD  CONSTRAINT [FK_LignePanierG_PanierG] FOREIGN KEY([idPanierG])
REFERENCES [dbo].[PanierGlobal] ([id])
GO
ALTER TABLE [dbo].[LignePanierG] CHECK CONSTRAINT [FK_LignePanierG_PanierG]
GO
ALTER TABLE [dbo].[LignePanierG]  WITH CHECK ADD  CONSTRAINT [FK_LignePanierG_Reference] FOREIGN KEY([idRef])
REFERENCES [dbo].[Reference] ([id])
GO
ALTER TABLE [dbo].[LignePanierG] CHECK CONSTRAINT [FK_LignePanierG_Reference]
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
