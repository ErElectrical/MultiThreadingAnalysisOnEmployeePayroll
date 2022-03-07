create database Employee_Payroll_Normalisation;

use Employee_Payroll_Normalisation;
go;


-- Table Creations

create table Company(
	Company_id int not null identity primary key,
	startdate date not null,
	Emp_Name varchar(30) not null default 'Anonymos',
	gender varchar(10) not null
	
);

create table Employee(
	Emp_id int not null identity primary key,
	Emp_phonenumber varchar(15) not null unique,
	Emp_Address varchar(200) not null default 'office',
	Company_id int foreign key REFERENCES Company(Company_id)
	
);

alter table Employee
add Company_id int, 
add state varchar(50),
add country varchar(50);

create table Department(
	 Dept_id int identity primary key,
	 Dept_Name varchar(20) not null ,
	 Emp_id int foreign key REFERENCES Employee(Emp_id)

);

alter table Department
add  Emp_id int

create table Payroll
(
	Employee_id int not null identity Primary key,
	Basic_Pay int not null,
	Tax_Pay int not null,
	Deductions int ,
	Income_Tax int ,
	Net_Pay int not null,
	Company_id int foreign key REFERENCES Company(Company_id)
	
);

alter table Payroll
add Company_id int

--Insertion of data

insert into Company
(startdate,gender,Emp_Name)
values
('2021-12-13','male','Mohit'),
('2012-11-23','Female','Jyoti'),
('2019-02-21','male','Chinu'),
('2020-09-29','Female','chnitu');



insert into Employee
(Emp_Address,Emp_phonenumber)
values
('Mumbai chole','25632633'),
('Jaipur','343662'),
('rohtak','35637253'),
('jhajar','357362743');



insert into Department
(Dept_Name)
values
('Hr'),
('Sale'),
('Advertisment'),
('Marketing');

insert into Payroll
(Basic_Pay,Net_Pay,Income_Tax,Deductions,Tax_Pay)
values
(15000,16500,1500,120,376),
(17000,17894,637,890,367),
(10000,13900,876,90,364),
(18900,20000,786,900,467);


-- Uc4 retrive data from the table

select *
from Company
inner join  Payroll on Payroll.Employee_id=Company.Company_id;

select *
from Company
inner join  Department on Department.Dept_id=Company.Company_id;

select *
from Company
inner join  Department on Department.Dept_id=Company.Company_id;


--Uc5 ability to retrive data based on condition

select Emp_Name,startdate,Basic_Pay
from Company
inner join  Payroll on Payroll.Employee_id=Company.Company_id and Emp_Name='Jyoti';

select Emp_Name,startdate,Basic_Pay
from Company
inner join  Payroll on Payroll.Employee_id=Company.Company_id and startdate between CAST('2019-05-29' as date) and GETDATE();

-- Uc7 sum,avg,min,max,count

select sum(Basic_Pay)
from Company
inner join  Payroll on Payroll.Employee_id=Company.Company_id and gender='Male';

select sum(Basic_Pay)
from Company
inner join  Payroll on Payroll.Employee_id=Company.Company_id and gender='FeMale';


select avg(Deductions)
from Company
inner join  Payroll on Payroll.Employee_id=Company.Company_id and gender='Male';

select avg(Deductions)
from Company
inner join  Payroll on Payroll.Employee_id=Company.Company_id and gender='FeMale';


select min(Net_Pay)
from Company
inner join  Payroll on Payroll.Employee_id=Company.Company_id ;

select max(Income_Tax)
from Company
inner join  Payroll on Payroll.Employee_id=Company.Company_id;

create procedure dbo.spInsertData
 @EmployeeId int,
 @EmployeeName varchar,
 @Phonenumber varchar,
 @Address varchar,
 @Department varchar,
 @gender varchar,
 @basicPay int,
 @Deducations int,
 @TaxPay int,
 @Tax int,
 @NetPay int,
 @stratdate datetime,
 @state varchar,
 @Country varchar
as
begin
 insert into Company(Emp_Name,startdate,gender)
 values(@EmployeeName,@stratdate,@gender)
 insert into Employee(Emp_id,Emp_Address,Emp_phonenumber,state,country)
 values(@EmployeeId,@Address,@Phonenumber,@state,@Country)
 insert into Department(Dept_Name)
 value(@Department)
 insert into Payroll(Tax_Pay,Net_Pay,Basic_Pay,Deductions,Income_Tax)
 values(@Tax,@NetPay,@basicPay,@Deducations,@TaxPay)
end
go









