--part1--

--1--
create view vstudent
as
select concat(St_Fname,' ',St_Lname) as Full_name,Crs_Name
from Student s 
join Stud_Course sc on s.St_Id=sc.St_Id 
join Course c on c.Crs_Id=sc.Crs_Id
where Grade>50

select * from vstudent

--2--
create view v_Manager
with Encryption
as
select 

--3--
create view v_Instructor
as
select Ins_Name,Dept_Name
from Instructor i join Department d on  i.Dept_Id=d.Dept_Id
where Dept_Name in ('SD','JAVA')

select *from v_Instructor;


--4--

create view v_Student
as
select *
from Student
where st_address IN ('alex', 'cairo')
with check option


--5--
use Company_SD 
go

create view v_EmpOnProject
as
select Pname,COUNT(ESSn) as EmployeeCount
from Project p 
join Works_for w on p.Pnumber=w.Pno
group by p.Pname

select * from v_EmpOnProject


--6--
create NONCLUSTERED index indx_Hiredate
on department(Manager_hiredate)

--7--

create unique index indx_uniqueAge
on student(St_Age);

--8--

create table Daily_Transaction(
     UserID int not null, 
	 TransactionAmount int
)
create table Last_Transaction(
     UserID int not null, 
	 TransactionAmount int
)

MERGE Daily_Transaction AS T
USING Last_Transaction AS S
 ON T.UserID = S.UserID 
WHEN MATCHED THEN
   UPDATE 
	SET T.TransactionAmount = S.TransactionAmount
WHEN NOT MATCHED BY TARGET THEN
    INSERT (UserID, TransactionAmount)
    values (S.UserID, S.TransactionAmount)

WHEN NOT MATCHED BY SOURCE THEN
    DELETE;







