Create trigger tr_GenerateUserID
on [dbo].[Users]
After insert
As 
	Update [dbo].[Users]
	Set [UserID]=LEFT(i.FirstName,1)+LEFT(i.LastName,1)+REPLICATE('0',3-Len (i.ID))+CONVERT(varchar(3),i.ID)
	from inserted i
	where [dbo].[Users].Id=i.Id
go

insert into Users (FirstName,LastName)
values('AA','remma')
go
select * from Users
go
CREATE PROCEDURE [dbo].[spInsertUser]
	@firstname varchar(20),
	@lastname varchar(20),
	@password varchar(20)
AS
Begin
	Insert into Users(FirstName,LastName,Password)
	values(@firstname,@lastname,@password)
	Select UserID
	From Users
	Where ID= Scope_Identity()
	
end
go
Insert into Users(FirstName,LastName,Password)
	values('ppp','xxxx','')
	
	Select UserID
	From Users
	Where ID= Scope_Identity()
go
exec [dbo].[spInsertUser] 'aa','ff','1236'
go
select * from Users
go
Select * from ProjectFiles
go
Insert into [dbo].[ProjectFiles](NameP,Description)
values('Client Management System','Project is done in ASP.NET MVC using C# ')
go
go
Insert into [dbo].[ProjectFiles](NameP,Description)
values('Retail System','Project is done in ASP.NET WebForms using Visual Basic ')
go
CREATE TABLE [dbo].[tblFileDetails](  
    [SQLID] [int] IDENTITY(1,1) NOT NULL,  
    [FILENAME] [nvarchar](500) NULL,  
    [FILEURL] [nvarchar](1500) NULL  
) 
go
