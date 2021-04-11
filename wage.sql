--@@@@@@@@@@@@@@@@@@@@@
--drop procedure SP_BulkAddOrUpdateGroupManagerSchedules
--drop type TvpGroupManagerSchedules
create type [dbo].[TvpGroupManagerSchedules] as table (
	--[Id] [decimal](18, 0)  NULL,	
	[EntranceDate] [nvarchar](10) NULL,
	[EntranceTime] [nvarchar](5) NULL,
	[ExitTime] [nvarchar](5) NULL,
	[MinTime] [nvarchar](5) NULL,
	[GroupManagerId] [decimal](18, 0)  NULL ,
	[Active] [bit] NULL,
	[IsOnline] [bit] NOT NULL DEFAULT(0)
)
go

create procedure [dbo].[SP_BulkAddOrUpdateGroupManagerSchedules]
(
	--table value parameter
	@tvpSchedule [dbo].[TvpGroupManagerSchedules]  readonly
)
as
begin
	
	MERGE [dbo].[GroupManagerSchedules]  AS Schedule 
    USING @tvpSchedule AS tvpSchedule 
    ON (Schedule.GroupManagerId = tvpSchedule.GroupManagerId 
		and Schedule.EntranceDate = tvpSchedule.EntranceDate 
		and Schedule.EntranceTime = tvpSchedule.EntranceTime 	
		and Schedule.IsOnline = tvpSchedule.IsOnline
	)  
		
    --WHEN  MATCHED THEN 	
	--update set Schedule.ExitTime = tvpSchedule.ExitTime , MinTime=tvpSchedule.MinTime
	
  
    WHEN NOT MATCHED THEN  
        INSERT (EntranceDate ,EntranceTime ,ExitTime ,MinTime,GroupManagerId ,IsOnline,Active)  
        VALUES (tvpSchedule.EntranceDate ,tvpSchedule.EntranceTime ,tvpSchedule.ExitTime ,tvpSchedule.MinTime,tvpSchedule.GroupManagerId  ,tvpSchedule.IsOnline,1);
		
end

go
create type [dbo].[TvpGroupManagerDetailsNewEntrance] as table (	
	[GroupManagerId] [decimal](18, 0)  NULL ,
	[EntranceDate] [nvarchar](10) NULL,
	[EntranceTime] [nvarchar](5) NULL,
	[ExitTime] [nvarchar](5) NULL,
	[IsOnline] [bit] NOT NULL DEFAULT(0) ,
	[Active] [bit] NULL
)
go

create procedure [dbo].[SP_BulkAddGroupManagerDetailsNewEntrance]
(
	--table value parameter
	@tvpGroupManagerDetailsNewEntrance [dbo].[TvpGroupManagerDetailsNewEntrance]  readonly
)
as
begin
	
	insert into GroupManagerDetails (GroupManagerId ,EntranceDate ,EntranceTime ,ExitTime ,Active ,IsOnline)
	select n.GroupManagerId ,n.EntranceDate ,n.EntranceTime ,n.ExitTime ,n.Active ,n.IsOnline
	from @TvpGroupManagerDetailsNewEntrance n
	left join GroupManagerDetails d on cast(n.GroupManagerId as decimal(18,0))  =d.GroupManagerId and n.EntranceDate=d.EntranceDate and cast(n.IsOnline as bit) = d.IsOnline and n.EntranceTime=d.EntranceTime  and n.ExitTime=d.ExitTime
	where d.Id is null
	
	select 1
end




--@@@@@@@@@@@@@@@@@@@@@
--select *  from [dbo].[GroupManagerSchedules] where GroupManagerId=1
--delete  [dbo].[GroupManagerSchedules] where GroupManagerId=1

select 
--ROW_NUMBER() OVER ( PARTITION BY g.Id ORDER BY d.EntranceDate) row_num
g.Id
,g.ProfCode
,g.ProfName
,d.EntranceDate
,d.EntranceTime
,d.ExitTime
--,(LEFT(ExitTime ,2) *60+right(ExitTime ,2) - LEFT(EntranceTime ,2) *60+right(EntranceTime ,2)) /60 as h
--,(LEFT(ExitTime ,2) *60+right(ExitTime ,2) - LEFT(EntranceTime ,2) *60+right(EntranceTime ,2)) %60 as m
,d.IsOnline

from GroupManagers g 
join GroupManagerDetails d on g.Id=d.GroupManagerId

where d.EntranceDate between '1399/07/01' and '1399/07/07'

select * from GroupManagers
select  * from GroupManagerDetails

select * from Users
select * from Roles
select * from UserRoles
select * from [dbo].[RoleAccesses]
select * from [dbo].[AccessLinks]
select * from [dbo].[GroupManagerSchedules] where GroupManagerId=1
delete from [dbo].[GroupManagerSchedules] where GroupManagerId=1
--delete from [dbo].[GroupManagerSchedules] where GroupManagerId=1
--delete from Users where id>3

--delete from Roles where Id>2
--delete from UserRoles where Id>13
--update Roles set RoleName='User' ,DisplayName= N'کاربر' where id=2
--insert into UserRoles(UserId ,RoleId) values(1 ,1) ,(2 ,2) ,(3 ,2)

insert into [dbo].[AccessLinks](Controller ,Action,Active)
values('Home','Schedule' ,1),('Home','NewEntrance',1),('Home','BaseAmount',1),('Home','ReseaechCouncil',1),('Home','PresenceInWeek',1),('Home','PresenceInMonth',1),('Home','Holidys' ,1)

insert into RoleAccesses(RoleId,AccessLinkId,Active)
values(2,1,1),(2,2,1),(2,3,1),(2,4,1),(2,5,1),(2,6,1),(2,7,1)



insert into GroupManagers(ProfCode ,ProfName ,BaseAmount ,[Year] ,[Month],StartAt ,ChkCouncil ,Active)
values
 ('10' ,N'فربد ساسانی','10000','1399','01','1399/01/01' ,0 ,1)
,('11' ,N'مهدی جلالی','10000','1399','01','1399/01/01' ,0,1)
,('12' ,N'محمد سرگزی','10000','1399','01','1399/01/01' ,0,1)

,('10' ,N'فربد ساسانی','10000','1399','02','1399/02/01' ,0 ,1)
,('11' ,N'مهدی جلالی','10000','1399','02','1399/02/01' ,0,1)
,('12' ,N'محمد سرگزی','10000','1399','02','1399/02/01' ,0,1)

,('10' ,N'فربد ساسانی','10000','1399','07','1399/07/01' ,0 ,1)
,('11' ,N'مهدی جلالی','10000','1399','07','1399/07/01' ,0,1)
,('12' ,N'محمد سرگزی','10000','1399','07','1399/07/01' ,0,1)

,('10' ,N'فربد ساسانی','10000','1399','08','1399/08/01' ,0 ,1)
,('11' ,N'مهدی جلالی','10000','1399','08','1399/08/01' ,0,1)
,('12' ,N'محمد سرگزی','10000','1399','08','1399/08/01' ,0,1)

,('10' ,N'فربد ساسانی','10000','1399','12','1399/12/01' ,0 ,1)
,('11' ,N'مهدی جلالی','10000','1399','12','1399/12/01' ,0,1)
,('12' ,N'محمد سرگزی','10000','1399','12','1399/12/01' ,0,1)

/*
EXEC sp_fkeys 'GroupManagers'
--FK_GroupManagerDetails_GroupManagers_GroupManagerId
--FK_GroupManagerSchedules_GroupManagers_GroupManagerId
ALTER TABLE GroupManagers
DROP CONSTRAINT FK_GroupManagerDetails_GroupManagers_GroupManagerId;

ALTER TABLE GroupManagers
DROP CONSTRAINT FK_GroupManagerSchedules_GroupManagers_GroupManagerId;

*/




select gr.Id ,gr.ProfCode ,gr.ProfName ,gr.BaseAmount ,gr.[Year] ,gr.[Month] ,gr.StartAt,gr.ChkCouncil ,
s.EntranceDate ,s.EntranceTime ,s.ExitTime ,s.MinTime ,s.IsOnline,d.EntranceDate as InDate ,d.EntranceTime as InTime ,d.ExitTime as OutTime 
from  GroupManagers gr
join GroupManagerSchedules s on gr.Id=s.GroupManagerId
left join GroupManagerDetails d on d.GroupManagerId=s.GroupManagerId and d.EntranceDate=s.EntranceDate
where gr.year='1399' and gr.Id=1 and s.EntranceDate between '1399/01/01' and '1399/01/07'



