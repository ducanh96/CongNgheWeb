create table Table_Role(
	RoleId int primary key identity(1,1),
	RoleName Nvarchar(250),
	RoleDiscription nvarchar(250),
)

create table Table_User(
	UserId int primary key identity(1,1),
	UserName Nvarchar(50),
	UserPassword Nvarchar(50)
)

create table UserRole(
	UserId int not null references Table_User(UserId),
	RoleId int not null references Table_Role(RoleId),
	IsActive bit default 1
)

create table UserProfile(
	UserId int not null primary key references Table_User(UserId),
	Name nvarchar(250),
	Sex nvarchar(10),
	[Address] Nvarchar(250),
	IsActive bit default 1,
	UserImage Nvarchar   
)