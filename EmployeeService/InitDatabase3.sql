alter procedure spGetEmployee
@ID int
as 
begin
	select ID, 
		Name, 
		--Gender, 
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
@Gender nvarchar(50) = null,
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