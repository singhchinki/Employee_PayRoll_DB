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
