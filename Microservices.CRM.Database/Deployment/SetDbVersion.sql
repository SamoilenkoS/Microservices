create procedure [dbo].[SetDbVersion]
  @version varchar(64),
  @dbVersion nvarchar(8)
as
update [dbo].[DbVersion]
set Id = @version,
    DbVersion = @dbVersion
  return 0