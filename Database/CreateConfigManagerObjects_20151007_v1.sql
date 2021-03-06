/****** Object:  Table [dbo].[ConfigLines]    Script Date: 07/10/2015 16:27:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConfigLines](
	[ConfigLineID] [int] IDENTITY(0,1) NOT NULL,
	[ConfigSetTargetID] [int] NOT NULL,
	[ConfigLine] [nvarchar](800) NOT NULL,
 CONSTRAINT [PK_ConfigLines] PRIMARY KEY CLUSTERED 
(
	[ConfigLineID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ConfigSets]    Script Date: 07/10/2015 16:27:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConfigSets](
	[ConfigSetID] [int] IDENTITY(0,1) NOT NULL,
	[ConfigSetName] [nvarchar](100) NOT NULL,
	[Note] [nvarchar](500) NULL,
 CONSTRAINT [PK_ConfigSets] PRIMARY KEY CLUSTERED 
(
	[ConfigSetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ConfigSetTargets]    Script Date: 07/10/2015 16:27:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConfigSetTargets](
	[ConfigSetTargetID] [int] IDENTITY(0,1) NOT NULL,
	[ConfigSetID] [int] NOT NULL,
	[ConfigTargetID] [int] NOT NULL,
 CONSTRAINT [PK_ConfigSetTargets] PRIMARY KEY CLUSTERED 
(
	[ConfigSetTargetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ConfigTargets]    Script Date: 07/10/2015 16:27:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConfigTargets](
	[ConfigTargetID] [int] IDENTITY(0,1) NOT NULL,
	[TargetGroup] [nvarchar](50) NOT NULL default 'default',
	[TargetName] [nvarchar](100) NOT NULL,
	[TargetIP] [nvarchar](15) NOT NULL,
	[DeviceVendor] [nvarchar](50) NOT NULL,
	[JumpServerIP] [nvarchar](10) NULL,
	[Protocol] [nvarchar](15) NOT NULL,
	[Port] [int] NULL,
	[Note] [nvarchar](500) NULL,
 CONSTRAINT [PK_ConfigTargets] PRIMARY KEY CLUSTERED 
(
	[ConfigTargetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ConfigLines]  WITH CHECK ADD  CONSTRAINT [FK_ConfigLines_ConfigSetTargets] FOREIGN KEY([ConfigSetTargetID])
REFERENCES [dbo].[ConfigSetTargets] ([ConfigSetTargetID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ConfigLines] CHECK CONSTRAINT [FK_ConfigLines_ConfigSetTargets]
GO
ALTER TABLE ConfigTargets add constraint UC_TargetGroupTargetIP unique (TargetGroup, TargetIP, Port)
GO
ALTER TABLE [dbo].[ConfigSetTargets]  WITH CHECK ADD  CONSTRAINT [FK_ConfigSetTargets_ConfigSets] FOREIGN KEY([ConfigSetID])
REFERENCES [dbo].[ConfigSets] ([ConfigSetID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ConfigSetTargets] CHECK CONSTRAINT [FK_ConfigSetTargets_ConfigSets]
GO
ALTER TABLE [dbo].[ConfigSetTargets]  WITH CHECK ADD  CONSTRAINT [FK_ConfigSetTargets_ConfigTargets] FOREIGN KEY([ConfigTargetID])
REFERENCES [dbo].[ConfigTargets] ([ConfigTargetID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ConfigSetTargets] CHECK CONSTRAINT [FK_ConfigSetTargets_ConfigTargets]
GO
CREATE PROCEDURE [dbo].[CloneConfigSet]
	@OriginalConfigSetID int,
	@NewConfigSetName nvarchar(100)
AS
BEGIN
  declare @CTID int;
  declare @NewConfigSetID int;
  declare @OldNote nvarchar(500);
  -- Create the new Configuration Set --
  select @OldNote = Note from ConfigSets where ConfigSetID = @OriginalConfigSetID;
  insert into ConfigSets(ConfigSetName, Note) values  (@NewConfigSetName, @OldNote);
  select @NewConfigSetID = SCOPE_IDENTITY();
  --
  declare c1 cursor for select ConfigTargetID from ConfigSetTargets where ConfigSetID = @OriginalConfigSetID;
  open c1;
  fetch next from c1 into @CTID;
  while @@fetch_status = 0
  begin
    insert into ConfigSetTargets(ConfigSetID, ConfigTargetID) values (@NewConfigSetID, @CTID); 
    fetch next from c1 into @CTID;
  end
  select @NewConfigSetID;
END
GO
CREATE PROCEDURE [dbo].[CopyConfigLines]
	@SourceSetTargetID int,
	@DestinationSetTargetID int
AS
BEGIN
  declare @cLine nvarchar(800)
  declare @NewConfigSetID int;
  -- delete existing config lines
  delete from ConfigLines where ConfigSetTargetID = @DestinationSetTargetID;
  --
  declare c1 cursor for select ConfigLine from ConfigLines where ConfigSetTargetID = @SourceSetTargetID
  open c1;
  fetch next from c1 into @cLine;
  while @@fetch_status = 0
  begin
    insert into ConfigLines(ConfigSetTargetID, ConfigLine) values (@DestinationSetTargetID, @cLine); 
    fetch next from c1 into @cLine;
  end
END
GO
CREATE NONCLUSTERED INDEX [IDX_ConfigLines_ID]
ON [dbo].[ConfigLines] ([ConfigSetTargetID])
INCLUDE ([ConfigLineID],[ConfigLine])
GO