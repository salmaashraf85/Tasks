--part2--

--1--
create view v_clerk 
as
select EmpNo,ProjectNo,Enter_Date
from dbo.Works_on
where Job='Clerk'


select *
from v_clerk

--2--
create view v_without_budget
as
select *
from HR.Project
where Budget is null or Budget=0 

select * from dbo.v_without_budget

--3--
create view v_count
as 
select ProjectName,count(Job) as NumOfJobs 
from Works_on w
join hr.Project p on w.ProjectNo=p.ProjectNo 
group by ProjectName

select * from v_count

--4--
create view v_project_p2
AS
select EmpNo
from v_clerk
where ProjectNo=2

select * from v_project_p2

--5--
drop view  v_without_budget
create view  v_without_budget
--or alter view--
as
select *
from hr.Project
where ProjectNo in(1,2)

select * from v_without_budget

--6--
DROP VIEW v_clerk, v_count;

--7--
create view v_EmpInfo
as
select EmpNo,EmpLname 
from hr.Employee
where DeptNo=2

select * from v_EmpInfo

--8--
select EmpLname
from v_EmpInfo
where EmpLname like'%j%'

--9--

create view v_dept
as
select DeptNo,DeptName
from Company.Department

select * from v_dept

--10--

insert into v_dept
values(4,'Development')

--11--

create view v_2006_check
as
select EmpNo,ProjectNo,Enter_Date
from Works_on 
where Enter_Date between '01-01-2006' and '12-31-2006'
with check option

insert into v_2006_check
values(25348,1,'02-01-2006')

