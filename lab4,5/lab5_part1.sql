--part1--
select St_Age
from Student
where St_Age is not null ;

--1--
select distinct Ins_Name
from Instructor 

--2--
select 
IsNull(s.St_Id,0) ,concat(isNull(s.St_Fname,'default'),' ',isNull(s.St_Lname,'default')) as Student_Full_Name,isNull(d.Dept_Name,'default')
from Student s 
join Department d 
on s.Dept_Id=d.Dept_Id

--3--
select Ins_Name,d.Dept_Name
from Instructor i
left join Department d
on d.Dept_Id=i.Dept_Id

--4--
select CONCAT(St_Fname,'',St_Lname) as Full_Name,c.Crs_Name as Course_Name
from Student s 
join Stud_Course sc on  s.St_Id=sc.St_Id
join Course c on sc.Crs_Id=c.Crs_Id
where sc.Grade is not null

--5--
select Top_Name,count(Crs_Id) as count_of_courses
from Topic  t join Course c
on t.Top_Id=c.Top_Id
group by Top_Name

--6--
select MIN(Salary),Max(Salary)
from Instructor

--7--
select *
from Instructor
where salary <(select AVG(Salary) from Instructor)

--8--
select d.Dept_Name
from Department d join Instructor i
on d.Dept_Id=i.Dept_Id
where i.Salary=(select MIN(Salary) from Instructor)

--9--
select distinct top(2)  Salary
from Instructor
order by Salary desc

--10--
select Ins_Name,coalesce(Salary,500,0)
from Instructor

--11--
select avg(Salary)
from Instructor;

--12--
select s.St_Fname ,s2.*
from Student s join student s2 
on s.St_super=s2.St_Id

--13--
select *
from (
  select * ,Dense_Rank() over(partition by Dept_Id order by Salary desc) as DR
  from Instructor
  where  Salary is not null
) as new_table
where DR<=2 

--14--
select *
from(
select *,ROW_NUMBER() over(PARTITION by Dept_Id order by NEWID()) as RN
 from Student
 where Dept_Id is not null
 )as new_table
 where RN=1;






