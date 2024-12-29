create database [AuthorizationCenterDB]
go;

use [AuthorizationCenterDB]
go;


-- ----------------------------
-- Table structure for OpenIddictApplications
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[OpenIddictApplications]') AND type IN ('U'))
	DROP TABLE [dbo].[OpenIddictApplications]
GO

CREATE TABLE [dbo].[OpenIddictApplications] (
  [Id] nvarchar(450) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [ApplicationType] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [ClientId] nvarchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [ClientSecret] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [ClientType] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [ConcurrencyToken] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [ConsentType] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [DisplayName] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [DisplayNames] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [JsonWebKeySet] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Permissions] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [PostLogoutRedirectUris] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Properties] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [RedirectUris] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Requirements] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Settings] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[OpenIddictApplications] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of OpenIddictApplications
-- ----------------------------
INSERT INTO [dbo].[OpenIddictApplications] ([Id], [ApplicationType], [ClientId], [ClientSecret], [ClientType], [ConcurrencyToken], [ConsentType], [DisplayName], [DisplayNames], [JsonWebKeySet], [Permissions], [PostLogoutRedirectUris], [Properties], [RedirectUris], [Requirements], [Settings]) VALUES (N'b162bfa3-1182-41b6-a65a-b5863b68dbfb', N'web', N'AuthorizationCenterManageWeb', N'AQAAAAEAACcQAAAAED72sv6L8zP/nMtlNLfAFgDD1+N5QPdKCAIgNK9lvKBG9EZ/KZa1w5wGdDZTReqJEA==', N'confidential', N'e9db67e7-6bfd-438b-9b19-cb797827b607', N'implicit', N'AuthorizationCenterManage.Host', NULL, NULL, N'["gt:authorization_code","rst:code","ept:authorization","ept:token","ept:revocation","ept:introspection","gt:password","gt:client_credentials","gt:refresh_token","gt:LinkLogin","gt:Impersonation","scp:address","scp:email","scp:phone","scp:profile","scp:roles","scp:AuthorizationCenterManage.Host"]', NULL, NULL, N'["http://localhost:10085/"]', NULL, NULL)
GO

INSERT INTO [dbo].[OpenIddictApplications] ([Id], [ApplicationType], [ClientId], [ClientSecret], [ClientType], [ConcurrencyToken], [ConsentType], [DisplayName], [DisplayNames], [JsonWebKeySet], [Permissions], [PostLogoutRedirectUris], [Properties], [RedirectUris], [Requirements], [Settings]) VALUES (N'b162bfa3-1182-41b7-a65a-b5863b68dbfb', N'web', N'AuthorizationCenterManage.Host', N'AQAAAAEAACcQAAAAED72sv6L8zP/nMtlNLfAFgDD1+N5QPdKCAIgNK9lvKBG9EZ/KZa1w5wGdDZTReqJEA==', N'confidential', N'e9db67e7-6bfd-438b-9b19-cb797827b607', N'implicit', N'AuthorizationCenterManage.Host', NULL, NULL, N'["gt:authorization_code","rst:code","ept:authorization","ept:token","ept:revocation","ept:introspection","gt:password","gt:client_credentials","gt:refresh_token","gt:LinkLogin","gt:Impersonation","scp:address","scp:email","scp:phone","scp:profile","scp:roles","scp:BookStore"]', NULL, NULL, N'["http://localhost:10085/"]', NULL, NULL)
GO


-- ----------------------------
-- Table structure for OpenIddictAuthorizations
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[OpenIddictAuthorizations]') AND type IN ('U'))
	DROP TABLE [dbo].[OpenIddictAuthorizations]
GO

CREATE TABLE [dbo].[OpenIddictAuthorizations] (
  [Id] nvarchar(450) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [ApplicationId] nvarchar(450) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [ConcurrencyToken] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [CreationDate] datetime2(7)  NULL,
  [Properties] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Scopes] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Status] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Subject] nvarchar(400) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Type] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[OpenIddictAuthorizations] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of OpenIddictAuthorizations
-- ----------------------------

-- ----------------------------
-- Table structure for OpenIddictScopes
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[OpenIddictScopes]') AND type IN ('U'))
	DROP TABLE [dbo].[OpenIddictScopes]
GO

CREATE TABLE [dbo].[OpenIddictScopes] (
  [Id] nvarchar(450) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [ConcurrencyToken] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Description] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Descriptions] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [DisplayName] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [DisplayNames] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Name] nvarchar(200) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Properties] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Resources] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[OpenIddictScopes] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of OpenIddictScopes
-- ----------------------------

-- ----------------------------
-- Table structure for OpenIddictTokens
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[OpenIddictTokens]') AND type IN ('U'))
	DROP TABLE [dbo].[OpenIddictTokens]
GO

CREATE TABLE [dbo].[OpenIddictTokens] (
  [Id] nvarchar(450) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [ApplicationId] nvarchar(450) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [AuthorizationId] nvarchar(450) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [ConcurrencyToken] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [CreationDate] datetime2(7)  NULL,
  [ExpirationDate] datetime2(7)  NULL,
  [Payload] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Properties] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [RedemptionDate] datetime2(7)  NULL,
  [ReferenceId] nvarchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Status] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Subject] nvarchar(400) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Type] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[OpenIddictTokens] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of OpenIddictTokens
-- ----------------------------

-- ----------------------------
-- Indexes structure for table OpenIddictApplications
-- ----------------------------
CREATE UNIQUE NONCLUSTERED INDEX [IX_OpenIddictApplications_ClientId]
ON [dbo].[OpenIddictApplications] (
  [ClientId] ASC
)
WHERE ([ClientId] IS NOT NULL)
GO


-- ----------------------------
-- Primary Key structure for table OpenIddictApplications
-- ----------------------------
ALTER TABLE [dbo].[OpenIddictApplications] ADD CONSTRAINT [PK_OpenIddictApplications] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]
GO


-- ----------------------------
-- Indexes structure for table OpenIddictAuthorizations
-- ----------------------------
CREATE NONCLUSTERED INDEX [IX_OpenIddictAuthorizations_ApplicationId_Status_Subject_Type]
ON [dbo].[OpenIddictAuthorizations] (
  [ApplicationId] ASC,
  [Status] ASC,
  [Subject] ASC,
  [Type] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table OpenIddictAuthorizations
-- ----------------------------
ALTER TABLE [dbo].[OpenIddictAuthorizations] ADD CONSTRAINT [PK_OpenIddictAuthorizations] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]
GO


-- ----------------------------
-- Indexes structure for table OpenIddictScopes
-- ----------------------------
CREATE UNIQUE NONCLUSTERED INDEX [IX_OpenIddictScopes_Name]
ON [dbo].[OpenIddictScopes] (
  [Name] ASC
)
WHERE ([Name] IS NOT NULL)
GO


-- ----------------------------
-- Primary Key structure for table OpenIddictScopes
-- ----------------------------
ALTER TABLE [dbo].[OpenIddictScopes] ADD CONSTRAINT [PK_OpenIddictScopes] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]
GO


-- ----------------------------
-- Indexes structure for table OpenIddictTokens
-- ----------------------------
CREATE NONCLUSTERED INDEX [IX_OpenIddictTokens_ApplicationId_Status_Subject_Type]
ON [dbo].[OpenIddictTokens] (
  [ApplicationId] ASC,
  [Status] ASC,
  [Subject] ASC,
  [Type] ASC
)
GO

CREATE NONCLUSTERED INDEX [IX_OpenIddictTokens_AuthorizationId]
ON [dbo].[OpenIddictTokens] (
  [AuthorizationId] ASC
)
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_OpenIddictTokens_ReferenceId]
ON [dbo].[OpenIddictTokens] (
  [ReferenceId] ASC
)
WHERE ([ReferenceId] IS NOT NULL)
GO


-- ----------------------------
-- Primary Key structure for table OpenIddictTokens
-- ----------------------------
ALTER TABLE [dbo].[OpenIddictTokens] ADD CONSTRAINT [PK_OpenIddictTokens] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]
GO


-- ----------------------------
-- Foreign Keys structure for table OpenIddictAuthorizations
-- ----------------------------
ALTER TABLE [dbo].[OpenIddictAuthorizations] ADD CONSTRAINT [FK_OpenIddictAuthorizations_OpenIddictApplications_ApplicationId] FOREIGN KEY ([ApplicationId]) REFERENCES [dbo].[OpenIddictApplications] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table OpenIddictTokens
-- ----------------------------
ALTER TABLE [dbo].[OpenIddictTokens] ADD CONSTRAINT [FK_OpenIddictTokens_OpenIddictApplications_ApplicationId] FOREIGN KEY ([ApplicationId]) REFERENCES [dbo].[OpenIddictApplications] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

ALTER TABLE [dbo].[OpenIddictTokens] ADD CONSTRAINT [FK_OpenIddictTokens_OpenIddictAuthorizations_AuthorizationId] FOREIGN KEY ([AuthorizationId]) REFERENCES [dbo].[OpenIddictAuthorizations] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

