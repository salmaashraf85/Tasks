
create procedure AddProduct
@Name nvarchar(10),
@Price Decimal(10,2),
@CategoryId int
as
begin
insert into Products
values(@Name,@Price,@CategoryId)
end

create procedure AddCategory
@Name nvarchar(10)
as
begin
insert into Products
values(@Name);
end


create procedure GetProduct
@id int
as
begin
select *
from Products
where Id=@id
end

create procedure GetCategory
@id int
as
begin
select *
from Categories
where Id=@id
end

create procedure UpdateProduct
@Id int,
@Name nvarchar(10),
@Price Decimal(10,2),
@CategoryId int

as
begin
update Products 
set Name=@Name ,Price=@Price,CategoryId=@CategoryId
where Id=@Id 
end

create procedure UpdateCategory
@Id int,
@Name nvarchar(10)
as
begin
update Categories 
set Name=@Name
where Id=@Id 
end


create procedure DeleteProduct
@Id int
as
begin
delete from Products
where Id=@Id
end

create procedure DeleteCategory
@Id int
as
begin
delete from Products
where CategoryId=@Id
delete from Categories
where Id=@Id
end


