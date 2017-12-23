USE [DB_yyyu]
GO

/****** Object:  Table [dbo].[yyyu_tblSysMenu]    Script Date: 2017/11/21 17:51:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[yyyu_tblSysMenu](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Menu_Id] [int] NOT NULL,
	[Menu_Level] [int] NOT NULL,
	[Menu_ParentId] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[ShowName] [varchar](50) NOT NULL,
	[IshasSon] [nchar](10) NULL,
	[NodeUrl] [varchar](50) NULL,
	[IsActive] [char](2) NULL,
	[CreateBy] [varchar](50) NULL,
	[CreateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_yyyu_tblSysMenu] PRIMARY KEY CLUSTERED 
(
	[Menu_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[yyyu_tblSysMenu] ADD  CONSTRAINT [DF_yyyu_tblSysMenu_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自增ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'yyyu_tblSysMenu', @level2type=N'COLUMN',@level2name=N'ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'yyyu_tblSysMenu', @level2type=N'COLUMN',@level2name=N'Menu_Id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'等级' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'yyyu_tblSysMenu', @level2type=N'COLUMN',@level2name=N'Menu_Level'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'yyyu_tblSysMenu', @level2type=N'COLUMN',@level2name=N'Menu_ParentId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'yyyu_tblSysMenu', @level2type=N'COLUMN',@level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'显示名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'yyyu_tblSysMenu', @level2type=N'COLUMN',@level2name=N'ShowName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否有子节点' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'yyyu_tblSysMenu', @level2type=N'COLUMN',@level2name=N'IshasSon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单节点对应的跳转URL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'yyyu_tblSysMenu', @level2type=N'COLUMN',@level2name=N'NodeUrl'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否激活,1:激活 2：关闭' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'yyyu_tblSysMenu', @level2type=N'COLUMN',@level2name=N'IsActive'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'yyyu_tblSysMenu', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'yyyu_tblSysMenu', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO


