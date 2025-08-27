--sp and trigger and xml--

--1--
use ITI
go
create procedure StudentsPerDept
as
select Dept_Name,count(St_Id) as Num_Of_Students
from Student s 
join Department d on s.Dept_Id=d.Dept_Id
group by Dept_Name

--2--

use Company_SD
go

create procedure CheckThreeEmps
as
declare  @empCount int
select  @empCount =COUNT(*)
from works_for 
where Pno=100
 

if(@empCount>=3)
begin
print('The number of employees in the project p1 is 3 or more')
end
else
begin
print('The following employees work for the project p1')

select Fname,Lname
from  works_for w 
join employee e on w.ESSn=e.SSN
where Pno=100
end

--3--

create procedure UpdateWorksOn 
@oldId int,
@newId int,
@projectNo int
as
begin
update works_for
set ESSn=@newId
where ESSn=@oldId and Pno=@projectNo
end

UpdateWorksOn 669955, 112233, 300

--4--
 alter table project 
 add budget int;

create table P_Audit (
    ProjectNo     int,
    UserName      varchar(100),
    ModifiedDate  datetime,
    Budget_Old   int,
    Budget_New    int
);

alter trigger budget_audit
on project 
for update
as
begin
if (update(budget))
begin
insert into P_Audit(ProjectNo, UserName, ModifiedDate, Budget_Old, Budget_New)
select i.Pnumber ,
SUSER_NAME(),
GETDATE(),
d.budget,
i.Pnumber
from deleted d join 
inserted i on d.Pnumber=i.Pnumber
end
end

update project
set budget=500
where Pnumber=200

--5--
use ITI
go
create trigger prevent_insertion_departement
on Department
for insert
as
begin 
print('you can not insert new record in this table')
ROLLBACK TRANSACTION;
end

insert into Department
values(2,'s','','',12,'1-1-2001')


--6--
use Company_SD
go
create trigger prevent_insertion_march
on employee
instead of insert
as
begin 
 if(MONTH(GETDATE())=3)
 print'it is prevented in march'
end

--7--

use iti
go

create table audit_student(
UserName varchar(100),
mdate datetime, 
Note varchar(100)
)

alter trigger insert_student
on student
after insert
as
begin
declare @KeyValue int
SELECT @KeyValue = St_Id
 FROM inserted;
insert into audit_student(UserName,mdate,Note)
select SUSER_NAME(),GETDATE(),
SUSER_NAME()+'Insert New Row with Key='+ cast(@KeyValue as varchar(10)) 'in table student'
from inserted
end

insert into Student
values(700,'','','',20,10,2)


--8--
alter trigger delete_student
on student
instead of delete
as
begin
declare @KeyValue int
SELECT @KeyValue = St_Id
 FROM deleted;
insert into audit_student(UserName,mdate,Note)
select SUSER_NAME(),GETDATE(),
SUSER_NAME()+'try to delete Row with Key='+ cast(@KeyValue as varchar(10)) +'in table student'
from deleted
end

delete from student 
where St_Id=700

--9--

use AdventureWorksLT2022       
go
--attributes-
select *
from employee
for xml raw 

--elements
select *
from employee
for xml raw('employee') ,elements

--10--
use iti 
go
 
--auto--
select Dept_Name,Ins_Name
from Department d join Instructor i 
on d.Dept_Manager=i.Ins_Id
for xml auto

--path--
select Dept_Name,Ins_Name
from Department d join Instructor i 
on d.Dept_Manager=i.Ins_Id
for xml path  

--11--

declare @docs xml ='<customers>
              <customer FirstName="Bob" Zipcode="91126">
                     <order ID="12221">Laptop</order>
              </customer>
              <customer FirstName="Judy" Zipcode="23235">
                     <order ID="12221">Workstation</order>
              </customer>
              <customer FirstName="Howard" Zipcode="20009">
                     <order ID="3331122">Laptop</order>
              </customer>
              <customer FirstName="Mary" Zipcode="12345">
                     <order ID="555555">Server</order>
              </customer>
       </customers>'

declare @hdoc int
exec sp_xml_preparedocument @hdoc OUTPUT, @docs;

SELECT *
FROM OPENXML(@hdoc, '/customers/customer', 2)
WITH (
   firstName varchar(20) '@FirstName',
   zipCode  int '@Zipcode',
   orderName varchar(20) 'order',
   orderId int 'order/@ID'
);














