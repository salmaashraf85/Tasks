--1--
select d.Dnum,d.Dname,e.SSN ,e.Fname
from Departments d,Employee e
where d.MGRSSN=e.SSN

--2--
select Dname,Pname
from Departments d,Project P
where d.Dnum=P.Dnum

--3--
select d.* ,e.Fname +' '+e.Lname
from Dependent d ,Employee e
where SSN=ESSN

--4--
select Pnumber,Pname,Plocation,City
from Project
where City='Cairo' or City='Alex'

--5--
select * 
from Project
where Pname like'a%';

--6--
select *
from Employee
where Dno=30 and Salary between 1000 and 2000

--7--
select e.Fname
from Employee e,Works_for w,Project p
where w.ESSn=e.SSN and p.Pnumber=w.Pno and p.Pname='AL Rabwah' and w.Hours>=10 and e.Dno=10

--8--
select Emp1.Fname , Emp2.Fname +' ' +Emp2.Lname as FullName 
from Employee Emp1, Employee Emp2
where Emp1.Superssn=Emp2.SSN and Emp2.Fname='Kamel' and Emp2.Lname='Mohamed'

--9--
select Fname,Pname
from Employee e,Works_for w,Project p
where w.ESSn=e.SSN and p.Pnumber=w.Pno
order by p.Pname

--10--
select p.Pnumber,d.Dname,e.Lname,e.Address,e.Bdate
from Project p,Departments d,Employee e
where p.City='Cairo' and p.Dnum=d.Dnum and d.MGRSSN=e.SSN

--11--
select  e.* 
from Employee e,Departments d
where d.MGRSSN=e.SSN

--12--
select e.*,d.*
from Employee e
left join  Dependent d on e.SSN = d.ESSN;


--Data Manipulating Language--

--1--
insert into Employee values('Salma','Ashraf',102672,2004-08-05,'Nasr city','F',3000,112233,30);

--2--
insert into Employee(SSN,Fname,Lname,Dno,Sex)
values(102660,'Maria','Diyaa',30,'F')

--3--
update Employee
set Salary=Salary+0.2*Salary
where SSN=102672;


