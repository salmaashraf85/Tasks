 --part2--
 --1--
 select SalesOrderID,ShipDate 
 from SalesLT.SalesOrderHeader
 where ShipDate between'7/28/2002' and '7/29/2014'

 --2--
 select ProductID,Name
 from SalesLT.Product
 where StandardCost <110

 --3--
 select ProductID,Name
 from SalesLT.Product
 where Weight is null;

 --4--
 select * 
 from SalesLT.Product
 where Color in ('Silver','Black','Red')

 --5--
 select * 
 from SalesLT.Product
 where Name like 'B%'

 --6--
UPDATE SalesLT.ProductDescription
SET Description = 'Chromoly steel_High of defects'
WHERE ProductDescriptionID = 3

select Description
from SalesLT.ProductDescription
where Description like '%\_%' escape '\'

--7--
select sum(TotalDue),OrderDate
from SalesLT.SalesOrderHeader
where OrderDate between  '7/1/2001' and '7/31/2014'
group by OrderDate

--8--
 --i can't find the table--

--9--
 select avg(distinct ListPrice)
 from SalesLT.Product
 
 --10--
 select  'The ' + Name + ' is only! ' + CAST(ListPrice AS VARCHAR) AS ProductInfo
 from SalesLT.Product
 where ListPrice between 100 and 120
 order by ListPrice

 --11--
  --i can't find the table--


 --12--
select CONVERT(VARCHAR, GETDATE(), 101) AS [TodayDate]  
UNION
select CONVERT(VARCHAR, GETDATE(), 113) AS [TodayDate]  
UNION
select CONVERT(VARCHAR, GETDATE(), 120) AS [TodayDate] 
UNION
select CONVERT(VARCHAR, GETDATE(),103 ) AS [TodayDate];