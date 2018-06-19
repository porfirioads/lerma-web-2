USE [master]
GO
/****** Object:  Database [cuenca_conagua]    Script Date: 06-Jun-18 11:09:45 PM ******/
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
/****** Object:  Table [dbo].[administrador]    Script Date: 06-Jun-18 11:09:45 PM ******/
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
/****** Object:  Table [dbo].[escurrimiento_anual]    Script Date: 06-Jun-18 11:09:45 PM ******/
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
/****** Object:  Table [dbo].[lluvia_ae]    Script Date: 06-Jun-18 11:09:45 PM ******/
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
/****** Object:  Table [dbo].[precipitacion_ma]    Script Date: 06-Jun-18 11:09:45 PM ******/
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
/****** Object:  Table [dbo].[volumen_dr_asignado]    Script Date: 06-Jun-18 11:09:45 PM ******/
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
/****** Object:  Table [dbo].[volumen_dr_autorizado]    Script Date: 06-Jun-18 11:09:45 PM ******/
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
/****** Object:  Table [dbo].[volumen_dr_utilizado]    Script Date: 06-Jun-18 11:09:45 PM ******/
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
/****** Object:  Table [dbo].[volumen_pi_asignado]    Script Date: 06-Jun-18 11:09:45 PM ******/
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
/****** Object:  Table [dbo].[volumen_pi_autorizado]    Script Date: 06-Jun-18 11:09:45 PM ******/
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
/****** Object:  Table [dbo].[volumen_pi_utilizado]    Script Date: 06-Jun-18 11:09:45 PM ******/
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

/****** Object:  Table [dbo].[almacenamientos_principales]    Script Date: 19-Jun-18 10:03:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[almacenamientos_principales](
	[anio] [varchar](10) NOT NULL,
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

USE [master]
GO
ALTER DATABASE [cuenca_conagua] SET  READ_WRITE 
GO
