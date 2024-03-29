USE [master]
GO
DROP DATABASE IF EXISTS [cuenca_conagua]
/****** Object:  Database [cuenca_conagua]    Script Date: 24-Jun-18 4:10:49 PM ******/
CREATE DATABASE [cuenca_conagua]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'cuenca_conagua', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\cuenca_conagua.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'cuenca_conagua_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\cuenca_conagua_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [cuenca_conagua] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [cuenca_conagua].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [cuenca_conagua] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [cuenca_conagua] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [cuenca_conagua] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [cuenca_conagua] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [cuenca_conagua] SET ARITHABORT OFF 
GO
ALTER DATABASE [cuenca_conagua] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [cuenca_conagua] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [cuenca_conagua] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [cuenca_conagua] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [cuenca_conagua] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [cuenca_conagua] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [cuenca_conagua] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [cuenca_conagua] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [cuenca_conagua] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [cuenca_conagua] SET  DISABLE_BROKER 
GO
ALTER DATABASE [cuenca_conagua] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [cuenca_conagua] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [cuenca_conagua] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [cuenca_conagua] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [cuenca_conagua] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [cuenca_conagua] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [cuenca_conagua] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [cuenca_conagua] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [cuenca_conagua] SET  MULTI_USER 
GO
ALTER DATABASE [cuenca_conagua] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [cuenca_conagua] SET DB_CHAINING OFF 
GO
ALTER DATABASE [cuenca_conagua] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [cuenca_conagua] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [cuenca_conagua] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [cuenca_conagua] SET QUERY_STORE = OFF
GO
USE [cuenca_conagua]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [cuenca_conagua]
GO
/****** Object:  Table [dbo].[administrador]    Script Date: 24-Jun-18 4:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[administrador](
	[nombre_usuario] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_administrador] PRIMARY KEY CLUSTERED 
(
	[nombre_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[almacenamiento_historico_chapala]    Script Date: 24-Jun-18 4:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[almacenamiento_historico_chapala](
	[fecha] [date] NOT NULL,
	[almacenamiento] [real] NULL,
 CONSTRAINT [PK_almacenamiento_historico_chapala] PRIMARY KEY CLUSTERED 
(
	[fecha] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[almacenamientos_principales]    Script Date: 24-Jun-18 4:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[almacenamientos_principales](
	[anio] [varchar](50) NOT NULL,
	[alzate] [real] NULL,
	[ramirez] [real] NULL,
	[tepetitlan] [real] NULL,
	[tepuxtepec] [real] NULL,
	[solis] [real] NULL,
	[yuriria] [real] NULL,
	[allende] [real] NULL,
	[m_ocampo] [real] NULL,
	[purisima] [real] NULL,
	[chapala] [real] NULL,
 CONSTRAINT [PK_almacenamientos_principales] PRIMARY KEY CLUSTERED 
(
	[anio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[escurrimiento_anual]    Script Date: 24-Jun-18 4:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[escurrimiento_anual](
	[ciclo] [varchar](10) NOT NULL,
	[alzate] [real] NULL,
	[ramirez] [real] NULL,
	[tepetitaln] [real] NULL,
	[tepuxtepec] [real] NULL,
	[solis] [real] NULL,
	[begona] [real] NULL,
	[ameche] [real] NULL,
	[pericos] [real] NULL,
	[yuriria] [real] NULL,
	[salamanca] [real] NULL,
	[adjuntas] [real] NULL,
	[angulo] [real] NULL,
	[corrales] [real] NULL,
	[yurecuaro] [real] NULL,
	[duero] [real] NULL,
	[zula] [real] NULL,
	[chapala] [real] NULL,
 CONSTRAINT [PK_escurrimiento_anual] PRIMARY KEY CLUSTERED 
(
	[ciclo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[lluvia_ae]    Script Date: 24-Jun-18 4:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lluvia_ae](
	[ciclo] [nchar](10) NOT NULL,
	[celaya] [real] NULL,
	[guanajuato] [real] NULL,
	[irapuato] [real] NULL,
	[adjuntas] [real] NULL,
	[leon] [real] NULL,
	[p_penuelitas] [real] NULL,
	[p_solis] [real] NULL,
	[san_felipe] [real] NULL,
	[san_luis_de_la_paz] [real] NULL,
	[yuriria] [real] NULL,
	[chapala] [real] NULL,
	[fuerte] [real] NULL,
	[tule] [real] NULL,
	[tizapan] [real] NULL,
	[yurecuaro] [real] NULL,
	[atlacomulco] [real] NULL,
	[toluca_rectoria] [real] NULL,
	[chincua] [real] NULL,
	[cuitzeo_au] [real] NULL,
	[melchor_ocampo] [real] NULL,
	[morelia] [real] NULL,
	[tepuxtepec] [real] NULL,
	[zacapu] [real] NULL,
	[zamora] [real] NULL,
	[queretaro_obs] [real] NULL,
 CONSTRAINT [PK_lluvia_ae] PRIMARY KEY CLUSTERED 
(
	[ciclo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[precipitacion_ma]    Script Date: 24-Jun-18 4:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[precipitacion_ma](
	[ciclo] [varchar](50) NOT NULL,
	[nov] [real] NULL,
	[dic] [real] NULL,
	[ene] [real] NULL,
	[feb] [real] NULL,
	[mar] [real] NULL,
	[abr] [real] NULL,
	[may] [real] NULL,
	[jun] [real] NULL,
	[jul] [real] NULL,
	[ago] [real] NULL,
	[sep] [real] NULL,
	[oct] [real] NULL,
 CONSTRAINT [PK_precipitacion_ma] PRIMARY KEY CLUSTERED 
(
	[ciclo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO [dbo].[precipitacion_ma]
	([ciclo] ,[nov] ,[dic] ,[ene] ,[feb] ,[mar] ,[abr] ,[may] ,[jun] ,[jul] ,[ago] ,[sep] ,[oct])
VALUES
	('89-90', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 852.2),
	('90-91', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 821.5),
	('91-92', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 875.9),
	('92-93', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 663.0),
	('93-94', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 670.0),
	('94-95', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 716.4),
	('95-96', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 647.5),
	('96-97', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 645.8),
	('97-98', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 810.9),
	('98-99', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 494.3),
	('99-00', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 560.7),
	('00-01', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 742.7),
	('01-02', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 803.8)		   
GO

/****** Object:  Table [dbo].[volumen_ag_asignado]    Script Date: 24-Jun-18 4:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[volumen_ag_asignado](
	[ciclo] [varchar](10) NOT NULL,
	[volumen] [real] NULL,
 CONSTRAINT [PK_volumen_ag_asignado] PRIMARY KEY CLUSTERED 
(
	[ciclo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[volumen_ag_autorizado]    Script Date: 24-Jun-18 4:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[volumen_ag_autorizado](
	[ciclo] [varchar](10) NOT NULL,
	[volumen] [real] NULL,
 CONSTRAINT [PK_volumen_ag_autorizado] PRIMARY KEY CLUSTERED 
(
	[ciclo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[volumen_ag_utilizado]    Script Date: 24-Jun-18 4:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[volumen_ag_utilizado](
	[ciclo] [varchar](10) NOT NULL,
	[volumen] [real] NULL,
 CONSTRAINT [PK_volumen_ag_utilizado] PRIMARY KEY CLUSTERED 
(
	[ciclo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[volumen_dr_asignado]    Script Date: 24-Jun-18 4:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[volumen_dr_asignado](
	[ciclo] [varchar](10) NOT NULL,
	[dr033] [real] NULL,
	[dr045] [real] NULL,
	[dr011] [real] NULL,
	[dr085] [real] NULL,
	[dr087] [real] NULL,
	[dr022] [real] NULL,
	[dr061] [real] NULL,
	[dr024] [real] NULL,
	[dr013] [real] NULL,
 CONSTRAINT [PK_volumen_dr_asignado] PRIMARY KEY CLUSTERED 
(
	[ciclo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[volumen_dr_autorizado]    Script Date: 24-Jun-18 4:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[volumen_dr_autorizado](
	[ciclo] [varchar](10) NOT NULL,
	[dr033] [real] NULL,
	[dr045] [real] NULL,
	[dr011] [real] NULL,
	[dr085] [real] NULL,
	[dr087] [real] NULL,
	[dr022] [real] NULL,
	[dr061] [real] NULL,
	[dr024] [real] NULL,
	[dr013] [real] NULL,
 CONSTRAINT [PK_volumen_dr_autorizado] PRIMARY KEY CLUSTERED 
(
	[ciclo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[volumen_dr_utilizado]    Script Date: 24-Jun-18 4:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[volumen_dr_utilizado](
	[ciclo] [varchar](10) NOT NULL,
	[dr033] [real] NULL,
	[dr045] [real] NULL,
	[dr011] [real] NULL,
	[dr085] [real] NULL,
	[dr087] [real] NULL,
	[dr022] [real] NULL,
	[dr061] [real] NULL,
	[dr024] [real] NULL,
	[dr013] [real] NULL,
 CONSTRAINT [PK_volumen_dr_utilizado] PRIMARY KEY CLUSTERED 
(
	[ciclo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[volumen_gt_asignado]    Script Date: 24-Jun-18 4:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[volumen_gt_asignado](
	[ciclo] [varchar](10) NOT NULL,
	[volumen] [real] NULL,
 CONSTRAINT [PK_vol_gt_asignado] PRIMARY KEY CLUSTERED 
(
	[ciclo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[volumen_gt_autorizado]    Script Date: 24-Jun-18 4:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[volumen_gt_autorizado](
	[ciclo] [varchar](10) NOT NULL,
	[volumen] [real] NULL,
 CONSTRAINT [PK_volumen_gt_autorizado] PRIMARY KEY CLUSTERED 
(
	[ciclo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[volumen_gt_utilizado]    Script Date: 24-Jun-18 4:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[volumen_gt_utilizado](
	[ciclo] [varchar](10) NOT NULL,
	[volumen] [real] NULL,
 CONSTRAINT [PK_volumen_gt_utilizado] PRIMARY KEY CLUSTERED 
(
	[ciclo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[volumen_pi_asignado]    Script Date: 24-Jun-18 4:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[volumen_pi_asignado](
	[ciclo] [varchar](10) NOT NULL,
	[pi_alzate] [real] NULL,
	[pi_ramirez] [real] NULL,
	[pi_tepetitlan] [real] NULL,
	[pi_tepuxtepec] [real] NULL,
	[pi_solis] [real] NULL,
	[pi_begona] [real] NULL,
	[pi_queretaro] [real] NULL,
	[pi_pericos] [real] NULL,
	[pi_adjuntas] [real] NULL,
	[pi_angulo] [real] NULL,
	[pi_corrales] [real] NULL,
	[pi_yurecuaro] [real] NULL,
	[pi_duero] [real] NULL,
	[pi_zula] [real] NULL,
	[pi_chapala] [real] NULL,
 CONSTRAINT [PK_volumen_pi_asignado] PRIMARY KEY CLUSTERED 
(
	[ciclo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[volumen_pi_autorizado]    Script Date: 24-Jun-18 4:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[volumen_pi_autorizado](
	[ciclo] [varchar](10) NOT NULL,
	[pi_alzate] [real] NULL,
	[pi_ramirez] [real] NULL,
	[pi_tepetitlan] [real] NULL,
	[pi_tepuxtepec] [real] NULL,
	[pi_solis] [real] NULL,
	[pi_begona] [real] NULL,
	[pi_queretaro] [real] NULL,
	[pi_pericos] [real] NULL,
	[pi_adjuntas] [real] NULL,
	[pi_angulo] [real] NULL,
	[pi_corrales] [real] NULL,
	[pi_yurecuaro] [real] NULL,
	[pi_duero] [real] NULL,
	[pi_zula] [real] NULL,
	[pi_chapala] [real] NULL,
 CONSTRAINT [PK_volumen_pi_autorizado] PRIMARY KEY CLUSTERED 
(
	[ciclo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[volumen_pi_utilizado]    Script Date: 24-Jun-18 4:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[volumen_pi_utilizado](
	[ciclo] [varchar](10) NOT NULL,
	[pi_alzate] [real] NULL,
	[pi_ramirez] [real] NULL,
	[pi_tepetitlan] [real] NULL,
	[pi_tepuxtepec] [real] NULL,
	[pi_solis] [real] NULL,
	[pi_begona] [real] NULL,
	[pi_queretaro] [real] NULL,
	[pi_pericos] [real] NULL,
	[pi_adjuntas] [real] NULL,
	[pi_angulo] [real] NULL,
	[pi_corrales] [real] NULL,
	[pi_yurecuaro] [real] NULL,
	[pi_duero] [real] NULL,
	[pi_zula] [real] NULL,
	[pi_chapala] [real] NULL,
 CONSTRAINT [PK_volumen_pi_utilizado] PRIMARY KEY CLUSTERED 
(
	[ciclo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [cuenca_conagua]
GO

/****** Object:  Table [dbo].[volumen_pi_autorizado_old]    Script Date: 05-Jul-18 2:53:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[volumen_pi_autorizado_old](
	[ciclo] [varchar](10) NOT NULL,
	[pi_alto_lerma] [real] NOT NULL,
	[pi_rio_queretaro] [real] NOT NULL,
	[pi_bajio] [real] NOT NULL,
	[pi_angulo_duero] [real] NOT NULL,
	[pi_bajo_lerma] [real] NOT NULL,
 CONSTRAINT [PK_volumen_pi_old_utilizado] PRIMARY KEY CLUSTERED 
(
	[ciclo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [cuenca_conagua]
GO

/****** Object:  Table [dbo].[volumen_pi_utilizado_old]    Script Date: 05-Jul-18 2:54:14 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[volumen_pi_utilizado_old](
	[ciclo] [varchar](10) NOT NULL,
	[pi_alto_lerma] [real] NOT NULL,
	[pi_rio_queretaro] [real] NOT NULL,
	[pi_bajio] [real] NOT NULL,
	[pi_angulo_duero] [real] NOT NULL,
	[pi_bajo_lerma] [real] NOT NULL,
 CONSTRAINT [PK_volumen_pi_utilizado_old] PRIMARY KEY CLUSTERED 
(
	[ciclo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [master]
GO
ALTER DATABASE [cuenca_conagua] SET  READ_WRITE 
GO
