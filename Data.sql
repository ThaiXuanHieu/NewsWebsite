USE [master]
GO
/****** Object:  Database [NewsWebsite]    Script Date: 20/03/2019 23:27:45 ******/
CREATE DATABASE [NewsWebsite]
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NewsWebsite].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NewsWebsite] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NewsWebsite] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NewsWebsite] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NewsWebsite] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NewsWebsite] SET ARITHABORT OFF 
GO
ALTER DATABASE [NewsWebsite] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NewsWebsite] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NewsWebsite] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NewsWebsite] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NewsWebsite] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NewsWebsite] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NewsWebsite] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NewsWebsite] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NewsWebsite] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NewsWebsite] SET  DISABLE_BROKER 
GO
ALTER DATABASE [NewsWebsite] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NewsWebsite] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NewsWebsite] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NewsWebsite] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NewsWebsite] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NewsWebsite] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NewsWebsite] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NewsWebsite] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [NewsWebsite] SET  MULTI_USER 
GO
ALTER DATABASE [NewsWebsite] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NewsWebsite] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NewsWebsite] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NewsWebsite] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NewsWebsite] SET DELAYED_DURABILITY = DISABLED 
GO
USE [NewsWebsite]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 20/03/2019 23:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](200) NULL,
	[Level] [int] NULL,
	[ParentId] [bigint] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedTime] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[DeletedBy] [bigint] NULL,
	[DeletedTime] [datetime] NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 20/03/2019 23:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[PasswordEncrypted] [nvarchar](500) NULL,
	[PasswordSalt] [nvarchar](10) NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[PhoneNumber] [nvarchar](15) NULL,
	[Email] [nvarchar](150) NULL,
	[Address] [nvarchar](500) NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedTime] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[DeletedBy] [bigint] NULL,
	[DeletedTime] [datetime] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Function]    Script Date: 20/03/2019 23:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Function](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Function] [nvarchar](200) NULL,
	[Level] [int] NULL,
	[ParentId] [bigint] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedTime] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifieTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[DeletedBy] [bigint] NULL,
	[DeletedTime] [datetime] NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Function] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 20/03/2019 23:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CategoryId] [bigint] NULL,
	[Title] [nvarchar](500) NULL,
	[Content] [ntext] NULL,
	[Summary] [nvarchar](100) NULL,
	[Resource] [nvarchar](50) NULL,
	[Image] [nvarchar](1000) NULL,
	[View] [bigint] NULL,
	[Tags] [nvarchar](500) NULL,
	[PostStatus] [smallint] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedTime] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[DeletedBy] [bigint] NULL,
	[DeletedTime] [datetime] NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostComment]    Script Date: 20/03/2019 23:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostComment](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PostId] [bigint] NULL,
	[CommentedBy] [bigint] NULL,
	[Content] [nvarchar](200) NULL,
	[CommentedTime] [datetime] NULL,
 CONSTRAINT [PK_PostComment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostRate]    Script Date: 20/03/2019 23:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostRate](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PostId] [bigint] NULL,
	[RatedBy] [bigint] NULL,
	[Mark] [smallint] NULL,
	[RatedTime] [datetime] NULL,
 CONSTRAINT [PK_PostRate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 20/03/2019 23:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Role] [nvarchar](200) NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedTime] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[DeletedBy] [bigint] NULL,
	[DeletedTime] [datetime] NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleFunctionRelationship]    Script Date: 20/03/2019 23:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleFunctionRelationship](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[RoleId] [bigint] NULL,
	[FunctionId] [bigint] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedTime] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[DeletedBy] [bigint] NULL,
	[DeletedTime] [datetime] NULL,
 CONSTRAINT [PK_RoleFunctionRelationship] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 20/03/2019 23:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[PasswordEncrypted] [nvarchar](500) NULL,
	[PasswordSalt] [nvarchar](10) NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nchar](10) NULL,
	[Sex] [smallint] NULL,
	[DateOfBirth] [datetime] NULL,
	[PhoneNumber] [nvarchar](20) NULL,
	[Email] [nvarchar](100) NULL,
	[Address] [nvarchar](500) NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedTime] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[DeletedBy] [bigint] NULL,
	[DeletedTime] [datetime] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoleRelationship]    Script Date: 20/03/2019 23:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoleRelationship](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NULL,
	[RoleId] [bigint] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedTime] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[DeletedBy] [bigint] NULL,
	[DeletedTime] [datetime] NULL,
 CONSTRAINT [PK_UserRoleRelationship] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Function] ADD  CONSTRAINT [DF_Function_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Role] ADD  CONSTRAINT [DF_Role_Status]  DEFAULT ((1)) FOR [Status]
GO
USE [master]
GO
ALTER DATABASE [NewsWebsite] SET  READ_WRITE 
GO
