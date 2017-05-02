create table tblEmployee
(
	ID int,
	Name nvarchar(50),
	Gender nvarchar(50),
	DateOfBirth datetime
)
GO

insert into tblEmployee values (1, 'Mark', 'Male', '10/10/1980')
insert into tblEmployee values (2, 'Mark', 'Female', '11/10/1981')
insert into tblEmployee values (3, 'Mark', 'Male', '8/10/1997')
GO

create procedure spGetEmployee
@ID int
as
begin
	select ID. Name, Gender, DateOfBirth
	from tblEmployee
	where ID = @ID
end
GO

create procedure spSaveEmployee
@ID int,
@Name nvarchar(50),
@Gender nvarchar(50),
@DateOfBirth datetime
as 
begin
	insert into tblEmployee
	values (@ID, @Name, @Gender, @DateOfBirth)
end
GO