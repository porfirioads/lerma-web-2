USE [master]
GO
/****** Object:  Database [cuenca_conagua]    Script Date: 20/12/2016 01:13:56 p. m. ******/
CREATE DATABASE [cuenca_conagua]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'cuenca_conagua', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\cuenca_conagua.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'cuenca_conagua_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\cuenca_conagua_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
USE [cuenca_conagua]
GO
/****** Object:  Table [dbo].[administrador]    Script Date: 20/12/2016 01:13:56 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[escurrimiento_anual]    Script Date: 20/12/2016 01:13:56 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[precipitacion_ma]    Script Date: 20/12/2016 01:13:56 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[volumen_dr_asignado]    Script Date: 20/12/2016 01:13:56 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[volumen_dr_autorizado]    Script Date: 20/12/2016 01:13:56 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[volumen_dr_utilizado]    Script Date: 20/12/2016 01:13:56 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[volumen_pi_asignado]    Script Date: 20/12/2016 01:13:56 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[volumen_pi_autorizado]    Script Date: 20/12/2016 01:13:56 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[volumen_pi_utilizado]    Script Date: 20/12/2016 01:13:56 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [cuenca_conagua] SET  READ_WRITE 
GO
