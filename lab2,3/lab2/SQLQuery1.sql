--1--
select *
from Employee

--2--
select Fname,Lname, Salary , Dno
from Employee

--3--
select  Pname, Plocation,Dnum
from Project

--4--
select Fname+' '+Lname AS [fullname], (Salary*12)*0.01 AS [ANNUAL COMM]
from Employee

--5--
select SSN,Fname
from Employee
where Salary>1000

--6--
select SSN,Fname
from Employee
where Salary*12>10000

--7--
select Fname,Salary
from Employee
where Sex='F'

--8--
select Dnum,Dname
from Departments
where MGRSSN=968574

--9--
select Pnumber,Pname,Plocation
from Project
where Dnum=10