/*
Post-Deployment Script Template
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.
 Use SQLCMD syntax to include a file in the post-deployment script.
 Example:      :r .\myfile.sql
 Use SQLCMD syntax to reference a variable in the post-deployment script.
 Example:      :setvar TableName MyTable
               SELECT * FROM [$(TableName)]
--------------------------------------------------------------------------------------
Using:
To add new upgrade script after deployment process use the following template:

if @curver like N'X.X.%' and @dbVer < N'2021XXXX'
begin
  :r .\Upgrade_postdeploy_2021XXXX.sql
end

where 'X.X' - current release version, '2021XXXX' - new upgrade script version
*/
print N'Begin post deployment process.'
declare @curver varchar(max)
select @curver = Id from [dbo].[DbVersion]

declare @dbVer nvarchar(8)
select @dbVer = DbVersion from [dbo].[DbVersion]

if @curver is null or @curver = 'x.x.xxxx.xxxx'
  set @curver = ''

print N'Current version is: ' + @curver

if @curver <= ''
begin
  print N'Database initial setup...'  
  insert into dbo.DbVersion(Id,[Type], DbVersion)
  values(@curver, N'$(DbType)', '')
end

set @dbVer = N'20210605'

print N'Setting up version $(DbVer)...'
exec [dbo].[SetDbVersion] N'$(DbVer)', @dbVer;

print N'Checking not trusted indexes...'
exec [dbo].[CheckNotTrustedIndexes]