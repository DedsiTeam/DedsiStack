create database [IdentityDB]
go

use [IdentityDB]
go


-- ----------------------------
-- Table structure for Users
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[Identity].[Users]') AND type IN ('U'))
	DROP TABLE [Identity].[Users]
GO

CREATE TABLE [Identity].[Users] (
  [Id] uniqueidentifier  NOT NULL,
  [UserName] nvarchar(10) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [Account] nvarchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [PassWord] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [Email] nvarchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO

ALTER TABLE [Identity].[Users] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Users
-- ----------------------------
INSERT INTO [Identity].[Users] ([Id], [UserName], [Account], [PassWord], [Email]) VALUES (N'F8AA10EA-F3D9-4252-8593-C38AEABED9F3', N'王晓龙', N'cohen', N'123qwe!@.', N'123123@qq.com')
GO


-- ----------------------------
-- Primary Key structure for table Users
-- ----------------------------
ALTER TABLE [Identity].[Users] ADD CONSTRAINT [PK__Users__3214EC0787452EAA] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]
GO

