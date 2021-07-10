print N'Begin pre deployment process.'

if exists(select 1 from master.dbo.sysdatabases where name = N'$(DatabaseName)'
                                                  and exists(select 1 from sys.objects where Name = 'DbVersion' and type = 'U'))
begin
  declare @curver varchar(max)
  select @curver = Id from [dbo].[DbVersion]

  declare @dbVer nvarchar(8)
  select @dbVer = DbVersion from [dbo].[DbVersion]

  if @curver is null or @curver = 'x.x.xxxx.xxxx'
    set @curver = ''


  print N'Current version is: ' + @curver
end
/*
if @dbVer < N'2021xxxx'
begin
  :r .\Upgrade_predeploy_2021xxxx.sql
end
*/