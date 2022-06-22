create database Payroll_Service_DB;
CREATE TABLE employee_payroll 
(
   id int identity primary key,
   name varchar(Max) Not null,
   salary money default 1000,
   startDate DateTime default GetDate()
);

select * from employee_payroll;
INSERT INTO employee_payroll (name,salary,startDate) VALUES
('Suraj', 20000, '2022-04-10'),
('Sanket', 20000, '2021-03-11'),
('Akshay', 30000, '2020-10-15');
INSERT INTO employee_payroll (name,salary,startDate) VALUES
('Nita', 20000, '2022-01-6'),
('Aditi', 20000, '2021-02-14'),
('Shikha', 30000, '2020-8-15');
INSERT INTO employee_payroll (name,salary,startDate) VALUES
('Terissa', 20000, '2022-01-6');
--Retrive data from Table
select * from employee_payroll;
-- Ability to retrieve salary data for a particular employee as well as all employees who have
-- joined in a particular data range from the  payroll service database
select * from employee_payroll where name = 'Suraj';   
select * from employee_payroll
where startDate BETWEEN CAST('2021-01-01' as DATE) AND GETDATE();
--UC 6 to add column gender and set gender
Alter Table employee_payroll add Gender varchar(1);

update employee_payroll set gender = 'M' where name = 'Suraj';
update employee_payroll set gender = 'M' where name = 'Sanket';
update employee_payroll set gender = 'M' where name = 'Akshay';
update employee_payroll set gender = 'F' where name = 'Nita';
update employee_payroll set gender = 'F' where name = 'Aditi';
update employee_payroll set gender = 'F' where name = 'Shikha';

--UC 7 to get Sum, Avg, Min, Max and no. of male and Female employee.
SELECT SUM(salary) FROM employee_payroll     
WHERE Gender = 'M' 
GROUP BY Gender;

SELECT SUM(salary) FROM employee_payroll       -- The SUM() function returns the total sum of a numeric column. 
WHERE Gender = 'F' 
GROUP BY Gender;

Select Gender, SUM(salary) From employee_payroll GROUP BY Gender;
Select Gender, AVG(salary) From employee_payroll GROUP BY Gender;
Select Gender, MIN(salary) From employee_payroll GROUP BY Gender;
Select Gender, MAX(salary) From employee_payroll GROUP BY Gender;
Select Gender, COUNT(name) From employee_payroll GROUP BY Gender;

--UC8 Alter table to add phone no., address, department

alter table employee_payroll add phone_number bigint;
alter table employee_payroll add address varchar(200) NOT NULL default'Mumbai';
alter table employee_payroll add department varchar(100) NOT NULL default 'Developer';
select * from employee_payroll;

--UC9 Alter table to add basic pay, deductions, Taxable pay, Income Tax, Net Pay
alter table employee_payroll add basic_pay money default 1000;
alter table employee_payroll add deductions float;
alter table employee_payroll add Taxable_Pay float;
alter table employee_payroll add Income_Tax float;
alter table employee_payroll add Net_Pay float;
select * from employee_payroll;

--UC10 add terissa in sales and marketing department
UPDATE employee_payroll set department = 'Sales' where name = 'Terissa';
INSERT INTO employee_payroll
(name, salary, startDate, Gender, phone_number, department, basic_pay, deductions, Taxable_Pay, Income_Tax, Net_Pay) VALUES
('Terissa',30000, '2018-01-03','F',9876543210, 'Marketting',30000, 3000, 1000, 100, 25900);

select * from employee_payroll where name='Terissa';

--UC11 ER Diagram
create table Department(Dept_id int not null identity(1,1) primary key,DeptName varchar(50) not null);
select * from Department;

insert into Department(DeptName) values
('Marketing'),
('Sales'),
('Development'),
('Testing');
select * from Department; 

create table EmployeeDetails 
(
Emp_id int not null Primary Key identity(1,1),
Emp_Name varchar(50) not null,
Gender char(1) not null,
Phone_Number varchar(50),
Payroll_id int not null Foreign key References employee_payroll(id),
Start_Date Date default GetDate()
);
select * from EmployeeDetails;

INSERT into EmployeeDetails(Emp_Name,Gender,Phone_Number,Payroll_id) values
('Suraj','M','9049091087','4'),
('Sanket','M','912345678','5'),
('Akshay','M','8876543219','6'),
('Terissa','F','9876543210','11');

select * from EmployeeDetails;

create table DeptEmployee(
Emp_id int not null Foreign key references EmployeeDetails(Emp_id),
Dept_id int not null Foreign key references Department(Dept_id) 
);

select * from DeptEmployee;
insert into DeptEmployee values(4,3);
select * from DeptEmployee;

--UC12 ensure all retieve queries done
select Emp_id,Emp_Name,Income_Tax from EmployeeDetails,employee_payroll where EmployeeDetails.Payroll_id=employee_payroll.id;

select Emp_id,Emp_Name,Income_Tax from EmployeeDetails,employee_payroll where Start_Date between CAST('1900-01-01' as date) and GETDATE() and  
EmployeeDetails.Payroll_id=employee_payroll.id;
