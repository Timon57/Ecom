create table Product
(
Id int identity,
Name varchar(100) not null,
Description varchar(500),
Price money not null,
CategoryId int null,
IsActive bit not null default 1,
IsDeleted bit not null default 0,
CreatedOn datetime2,
UpdatedOn datetime2,
constraint pk_product primary key(Id),
constraint fk_product_category foreign key(CategoryId) references Category(Id)
);