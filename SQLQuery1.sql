-- todays date and th enumber of months an employee has worked for company. 
-- show the first name, last name, today date


select firstname, lastname, getdate() as "Today's Date", datediff(month, hiredate, getdate()) as "Months Worked" from hr.Employees;

-- Example 13
--same as 12, show today's date without time part

select firstname, lastname, cast(getdate() as date) as "Today's Date", datediff(month, hiredate, getdate()) as "Months Worked" from hr.Employees;

select lastname, birthdate from hr.Employees where month(birthdate) = 12;

select firstname, lastname, DATEFROMPARTS(Year(birthdate), month(birthdate), 1) as BirthMonth from hr.Employees;