USE [DB_yyyu]
GO
/****** Object:  Table [dbo].[yyyu_tblSysMenu]    Script Date: 01/01/2018 23:20:48 ******/
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
	[MeunNum] [int] NULL,
	[IshasSon] [int] NULL,
	[NodeUrl] [varchar](50) NULL,
	[IsActive] [char](2) NULL,
	[CreateBy] [varchar](50) NULL,
	[CreateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_yyyu_tblSysMenu] PRIMARY KEY CLUSTERED 
(
	[Menu_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'表自增ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'yyyu_tblSysMenu', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'yyyu_tblSysMenu', @level2type=N'COLUMN',@level2name=N'Menu_Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单等级：1,2,3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'yyyu_tblSysMenu', @level2type=N'COLUMN',@level2name=N'Menu_Level'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上级菜单的ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'yyyu_tblSysMenu', @level2type=N'COLUMN',@level2name=N'Menu_ParentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'yyyu_tblSysMenu', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'显示名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'yyyu_tblSysMenu', @level2type=N'COLUMN',@level2name=N'ShowName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'序号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'yyyu_tblSysMenu', @level2type=N'COLUMN',@level2name=N'MeunNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否包含子菜单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'yyyu_tblSysMenu', @level2type=N'COLUMN',@level2name=N'IshasSon'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单节点对应的跳转URL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'yyyu_tblSysMenu', @level2type=N'COLUMN',@level2name=N'NodeUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否激活,1:激活 2：关闭' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'yyyu_tblSysMenu', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'yyyu_tblSysMenu', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'yyyu_tblSysMenu', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
SET IDENTITY_INSERT [dbo].[yyyu_tblSysMenu] ON
INSERT [dbo].[yyyu_tblSysMenu] ([ID], [Menu_Id], [Menu_Level], [Menu_ParentId], [Name], [ShowName], [MeunNum], [IshasSon], [NodeUrl], [IsActive], [CreateBy], [CreateTime]) VALUES (1, 1, 1, -1, N'system', N'系统管理', 1, 1, NULL, N'1 ', N'yyyu', CAST(0x0000A84800000000 AS DateTime))
INSERT [dbo].[yyyu_tblSysMenu] ([ID], [Menu_Id], [Menu_Level], [Menu_ParentId], [Name], [ShowName], [MeunNum], [IshasSon], [NodeUrl], [IsActive], [CreateBy], [CreateTime]) VALUES (2, 2, 1, -1, N'jiegou', N'结构管理', 2, 1, NULL, N'1 ', N'yyyu', CAST(0x0000A84800000000 AS DateTime))
INSERT [dbo].[yyyu_tblSysMenu] ([ID], [Menu_Id], [Menu_Level], [Menu_ParentId], [Name], [ShowName], [MeunNum], [IshasSon], [NodeUrl], [IsActive], [CreateBy], [CreateTime]) VALUES (3, 3, 2, 1, N'databse', N'数据表管理', 1, 1, NULL, N'1 ', N'yyyu', CAST(0x0000A84800000000 AS DateTime))
INSERT [dbo].[yyyu_tblSysMenu] ([ID], [Menu_Id], [Menu_Level], [Menu_ParentId], [Name], [ShowName], [MeunNum], [IshasSon], [NodeUrl], [IsActive], [CreateBy], [CreateTime]) VALUES (4, 4, 3, 3, N'InsertTable', N'创建数据表格', 1, 0, N'/Home/About', N'1 ', N'yyyu', CAST(0x0000A84800000000 AS DateTime))
INSERT [dbo].[yyyu_tblSysMenu] ([ID], [Menu_Id], [Menu_Level], [Menu_ParentId], [Name], [ShowName], [MeunNum], [IshasSon], [NodeUrl], [IsActive], [CreateBy], [CreateTime]) VALUES (5, 5, 2, 1, N'MenuData', N'菜单管理', 2, 1, NULL, N'1 ', N'yyyu', CAST(0x0000A84800000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[yyyu_tblSysMenu] OFF
/****** Object:  Default [DF_yyyu_tblSysMenu_CreateTime]    Script Date: 01/01/2018 23:20:48 ******/
ALTER TABLE [dbo].[yyyu_tblSysMenu] ADD  CONSTRAINT [DF_yyyu_tblSysMenu_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
