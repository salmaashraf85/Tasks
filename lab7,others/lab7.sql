--1--
create function GetMonth(@date DATETIME)
returns varchar(20)
as
begin
return DATENAME(month, @date);
end

select dbo.GetMonth('05-20-2020');

--2--
create function GetInBetween(@x int ,@y int)
returns @Range table (number int)
as
begin
declare @start int;
set @start=@x;
while @start<=@y
begin 
insert into @Range (number)
values(@start);
set @start=@start+1;
end
return;
end;

select * from 
dbo.GetInBetween(3,10);

--3--
create function GetFullNameDept(@id int)
returns @Data table (fullname varchar(20),dept_name varchar(20))
as
begin
insert into @Data(fullname,dept_name)
select CONCAT(St_Fname,' ',St_Lname),dept_Name
from dbo.Student s join dbo.Department d 
on s.Dept_Id=d.Dept_Id
WHERE s.St_Id = @id
return
end

select * from dbo.GetFullNameDept(5);

--4--
create function DisplayMessage(@id int)
returns varchar(50)
as 
begin
DECLARE @Fname NVARCHAR(50),@Lname NVARCHAR(50),@Message VARCHAR(50);

select @Fname=St_Fname,@Lname=St_Lname
from dbo.Student 
where St_Id=@id

if(@Fname is null and @Lname is null )
begin
set @Message='First name & last name are null';
end

else if(@Lname is null)
begin
set @Message='last name is null'
end

else if(@Fname is null)
begin
set @Message='First name is null'
end

else
begin 
set @Message='First name & last name are not null';
end

return @Message;
end

select dbo.DisplayMessage(14);

--5--

create function GetManagerData(@id int)
returns @manager table (department_name varchar(10),Manager_Name varchar(10),hiring_date Date)
as
begin
insert into  @manager(department_name,Manager_Name,hiring_date)
select Dept_Name,Ins_Name,Manager_hiredate
from dbo.Instructor join  dbo.Department
on Dept_Manager=Ins_Id
where Ins_Id=@id

return 
end

select *
from dbo.GetManagerData(13);

--6--
create function DisplayName(@condition varchar(30))
returns @student table (name varchar(20))
as
begin
if(@condition='first name')
begin
insert into @student(name)
select isNull(St_Fname,'no first name')
from dbo.Student 
end

else if(@condition='last name')
begin
insert into @student(name)
select  isNull(St_Lname,'no last name')
from dbo.Student 
end

else if(@condition='full name')
begin
insert into @student(name)
select CONCAT( isNull(St_Fname,'no first name'),' ', isNull(St_Lname,'no last name')) 
from dbo.Student 
end

return 
end

select * from 
dbo.DisplayName('full name');

--7--
select St_Id,left(St_Fname,len(St_Fname)-1)
from Student

--8--
update Stud_Course
set Grade=null
from Department d  join  Student s on d.Dept_Id=s.Dept_Id
join Stud_Course sc on s.St_Id=sc.St_Id
where d.Dept_Name='SD'

--Bonus--

--1--
create table person(
 id int,
 name varchar(20),
 position hierarchyid
)

insert into person
values(1,'manager',hierarchyid::GetRoot());

insert into person
values(2,'employee',hierarchyid::GetRoot().GetDescendant(NULL, NULL));


--2--
USE CompanyDB;
GO

declare @iterator int
set @iterator=1

while(@iterator<=3000)
begin
insert into Employee (emp_no, emp_lname, emp_fname, dept_no)
values('Jane', ' Smith', 'd1')
set @iterator=@iterator+1;
end
