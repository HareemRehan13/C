use dotnet;
create table Users (
u_id int primary key identity(1,1),
u_name varchar(100)not null,
u_pass varchar(200) not null,
u_img varchar(200) not null,
r_id int not null, 
foreign key(r_id) references Role (r_id)

);