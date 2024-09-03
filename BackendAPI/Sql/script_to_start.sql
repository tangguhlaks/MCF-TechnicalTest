CREATE DATABASE mcf_test;
GO

USE [mcf_test]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ms_storage_location](
	[location_id] [nvarchar](10) NOT NULL,
	[location_name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_ms_storage_location] PRIMARY KEY CLUSTERED 
(
	[location_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [mcf_test]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ms_user](
	[user_id] [bigint] IDENTITY(1,1) NOT NULL,
	[user_name] [nvarchar](20) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[is_active] [bit] NOT NULL,
 CONSTRAINT [PK_ms_user] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [mcf_test]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tr_bpkb](
	[agreement_number] [nvarchar](100) NOT NULL,
	[bpkb_no] [nvarchar](100) NOT NULL,
	[branch_id] [nvarchar](10) NOT NULL,
	[bpkb_date] [datetime2](7) NOT NULL,
	[faktur_no] [nvarchar](100) NOT NULL,
	[faktur_date] [datetime2](7) NOT NULL,
	[location_id] [nvarchar](10) NOT NULL,
	[police_no] [nvarchar](20) NOT NULL,
	[bpkb_date_in] [datetime2](7) NOT NULL,
	[created_by] [nvarchar](20) NOT NULL,
	[created_on] [datetime2](7) NOT NULL,
	[last_updated_by] [nvarchar](20) NOT NULL,
	[last_updated_on] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_tr_bpkb] PRIMARY KEY CLUSTERED 
(
	[agreement_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [mcf_test]
GO

INSERT INTO [dbo].[ms_user]
           ([user_name]
           ,[password]
           ,[is_active])
     VALUES
           ('jhonUmiro'
           ,'admin1*'
           ,1)
GO

INSERT INTO [dbo].[ms_user]
           ([user_name]
           ,[password]
           ,[is_active])
     VALUES
           ('trisNatan'
           ,'admin2@'
           ,1)
GO

INSERT INTO [dbo].[ms_user]
           ([user_name]
           ,[password]
           ,[is_active])
     VALUES
           ('hugoRess'
           ,'admin3#'
           ,0)
GO

USE [mcf_test]
GO

INSERT INTO [dbo].[ms_storage_location] ([location_id], [location_name])
VALUES ('LOC001', 'Storage A')
GO

INSERT INTO [dbo].[ms_storage_location] ([location_id], [location_name])
VALUES ('LOC002', 'Storage B')
GO

INSERT INTO [dbo].[ms_storage_location] ([location_id], [location_name])
VALUES ('LOC003', 'Storage C')
GO


