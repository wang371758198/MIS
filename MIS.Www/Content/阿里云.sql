

--用户信息
CREATE TABLE UserInfo(
ID UNIQUEIDENTIFIER PRIMARY KEY,--主键
NickName NVARCHAR(50),--昵称
RealName NVARCHAR(50),--真名
Sex bit ,--性别 1 男 0女
MobilePhone NCHAR(11),--移动电话
TelePhone NVARCHAR(20),--固定电话
Eamil NVARCHAR(50),--Eamil
ContactAddress NVARCHAR(100),--联系住址
FKDepartmentID INT ,--所属部门，部门主键ID
Birthday DATETIME,--生日
[Status]BIT ,--状态 1 可以 0禁用
CreateDateTime DATETIME,
UpdaeDateTime DATETIME
)

GO

--部门信息
CREATE TABLE DepartmentInfo
(
ID INT IDENTITY(1,1) PRIMARY KEY,--主键
DepartmentName NVARCHAR(50) NOT NULL,--部门名称
ParentDepartmentID INT ,--上级部门
[Status] BIT ,--状态 1有效 0禁用
FKUserInfoID UNIQUEIDENTIFIER,--负责人ID
LeadPeople NVARCHAR(50),--负责人名称
Tel NVARCHAR(20),--联系电话
ContactAddress NVARCHAR(100),--联系地址
CreateDateTime DATETIME DEFAULT GETDATE(),
UpdateDateTime DATETIME
)
go

--菜单信息
CREATE TABLE MenuInfo(
ID INT IDENTITY(1,1) PRIMARY KEY,--主键
MenuName NVARCHAR(50),--菜单名称
ParentMenuID INT ,--父级菜单ID
Uri NVARCHAR(500),--访问路径
Grade INT,--从小到大
Remark NVARCHAR(500),--备注
Icon NVARCHAR(500),--图标
CreateDateTime DATETIME DEFAULT GETDATE(),--创建时间
UpdateDateTime DATETIME   --更新时间
)