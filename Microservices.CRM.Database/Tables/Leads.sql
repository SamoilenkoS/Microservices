create table [dbo].[Leads]
(
  Id            uniqueidentifier not null constraint PK_Leads_Id primary key,
  Created       datetime not null default getutcdate(),
  FirstName     nvarchar(200) not null
)