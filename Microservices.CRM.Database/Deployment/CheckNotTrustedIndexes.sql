create procedure dbo.CheckNotTrustedIndexes
  as
begin
  --Check Foreign Keys
  declare @checkNotTrustedForeignKeys nvarchar(max)
  set @checkNotTrustedForeignKeys = (
  select string_agg (N'alter table ['
    + cast(s.name as nvarchar(max)) + N'].['
    + cast(o.name as nvarchar(max)) + N'] with check check constraint ['
    + cast(i.name as nvarchar(max)) + N']', char(10))
  from sys.foreign_keys i
  inner join sys.objects o on i.parent_object_id = o.object_id
  inner join sys.schemas s on o.schema_id = s.schema_id
  where i.is_not_trusted = 1 and i.is_not_for_replication = 0);
exec sp_executesql @checkNotTrustedForeignKeys

  --Check Constraints (Unique, Check, etc.)
  declare @checkNotTrustedConstraints nvarchar(max)
  set @checkNotTrustedConstraints = (
  select string_agg (N'alter table ['
    + cast(s.name as nvarchar(max)) + N'].['
    + cast(o.name as nvarchar(max)) + N'] with check check constraint ['
    + cast(i.name as nvarchar(max)) + N']', char(10))
  from sys.check_constraints i
  inner join sys.objects o on i.parent_object_id = o.object_id
  inner join sys.schemas s on o.schema_id = s.schema_id
  where i.is_not_trusted = 1 and i.is_not_for_replication = 0 and i.is_disabled = 0);
exec sp_executesql @checkNotTrustedConstraints
end