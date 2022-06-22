create database Payroll_Service_DB;
CREATE TABLE employee_payroll 
(
   id int identity primary key,
   name varchar(Max) Not null,
   salary money default 1000,
   startDate DateTime default GetDate()
);

select * from employee_payroll;