alter table tblEmployee 
add EmployeeType int,
	AnnualSalary int,
	HourlyPay int,
	HoursWorked int
Go

alter procedure spGetEmployee
@ID int
as 
begin
	select ID, 
		Name, 
		Gender, 
		DateOfBirth, 
		EmployeeType,
		AnnualSalary, 
		HourlyPay, 
		HoursWorked
	from tblEmployee
	where ID = @ID
end
GO

alter procedure spSaveEmployee
@ID int,
@Name nvarchar(50),
@Gender nvarchar(50),
@DateOfBirth datetime,
@EmployeeType int,
@AnnualSalary int = null,
@HourlyPay int = null,
@HoursWorked int = null
as 
begin
	insert into tblEmployee
	values (@ID, @Name, @Gender, @DateOfBirth, @EmployeeType, @AnnualSalary, @HourlyPay, @HoursWorked)
end
GO

update tblEmployee 
set EmployeeType = 1, 
	AnnualSalary = 15000,
	HourlyPay = 0,
	HoursWorked = 0
where ID = 1 

update tblEmployee 
set EmployeeType = 1, 
	AnnualSalary = 24500,
	HourlyPay = 0,
	HoursWorked = 0
where ID = 2 

update tblEmployee 
set EmployeeType = 2, 
	AnnualSalary = 0,
	HourlyPay = 500,
	HoursWorked = 20
where ID = 3
