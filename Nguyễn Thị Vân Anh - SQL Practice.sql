
select*from employees
select*from job_history

/* 1. Create a query that displays the last name and hire date of any employee in the same department 
as the employee with name = Zlotkey and excluding employee Zlotkey from the result returns*/
--subquery
select last_name, hire_date from employees
where department_id in(select department_id from employees where last_name = 'Zlotkey') and last_name <> 'Zlotkey'

--join
select e1.last_name, e1.hire_date from employees e1
left join employees e2
on e1.department_id = e2.department_id
where e2.last_name = 'Zlotkey' and e1.last_name <> 'Zlotkey'

/* 2. Create a report that displays the employee number, last name, and salary 
of all employees who earn more than the average salary. Sort the results in order of ascending salary*/

select employee_id, last_name, salary from employees
where salary > (select AVG(salary) from employees)
Order by salary asc


/* 3. Write a query that displays the employee number 
and last name of all employees who work in a department with any employee whose last name contains the letter “u”*/

select employee_id, last_name from employees
where department_id in (select department_id from employees where last_name like '%u%')

--Cách 2:
select distinct e1.employee_id, e1.last_name from employees e1
inner join employees e2
on e1.department_id = e2.department_id
where e2 . last_name like '%u%'


/* 4. The HR department needs a report 
that displays the last name, department number, and job ID of all employees whose department location ID is 1700*/

select last_name, e.department_id, job_id from employees e
inner join departments d
on e.department_id = d.department_id
where d.location_id = 1700

/* 4.1. The HR department needs a report 
that displays the last name, department number, and job ID of all employees whose department city is Seattle*/

select last_name, e.department_id, job_id from employees e
inner join departments d on e.department_id = d.department_id
inner join locations l on d.location_id= l.location_id
where city = 'Seattle'

/* 4.2. Lay ra tat ca cacs employee id va department name cua employee do*/

select employee_id, department_name from employees e
left join departments d
on e.department_id = d.department_id

/* 4.3. Hien thi cac nhan vien co department name = 'Finance' va cac nhan vien co location id = 1700*/

select employee_id, last_name from employees e
join departments d on e.department_id = d.department_id
where department_name = 'Finance'
union all
select employee_id, last_name from employees e
join departments d on e.department_id = d.department_id
where location_id = 1700


/* 5. Create a report for HR that displays the last name and salary of every employee who reports to King*/

select last_name, salary from employees
where manager_id in (select employee_id from employees where last_name = 'King')

--Cách 2:
select e1.last_name, e1.salary from employees e1
join employees e2 on e1.manager_id = e2.employee_id
where e2.last_name = 'King'


/* 6. Create a report for HR that displays the department number, last name, and job ID for every employee in the Executive department*/

select e.department_id, last_name, job_id from employees e
inner join departments d
on e.department_id = d. department_id
where department_name = 'Executive'

--Cách 2: 
select department_id, last_name, job_id from employees
where department_id in (select department_id from departments where department_name = 'Executive')

/* 7. Create query to display the employee number, last name, and salary of all the employees who 
earn more than the average salary and who work in a department with any employee whose last name contains a letter “u”*/

select employee_id, last_name, salary from employees
where salary > (select avg(salary) from employees)
union
select employee_id, last_name, salary from employees
where department_id in (select department_id from employees where last_name like '%u%' and last_name not like '%u%u%')

--Cách 2:
select employee_id, last_name, salary from employees
where salary > (select avg(salary) from employees) 
or  department_id in (select department_id from employees where last_name like '%u%' and last_name not like '%u%u%')

 
/* 8. Find the highest, lowest, sum, and average salary of all employees. 
Label the columns as Maximum, Minimum, Sum, and Average, respectively.
Round your results to the nearest whole number*/

select max(salary) as Maximum, min(salary) as Minimum, sum(salary) as Sum, round(avg(salary),0) as Average
from employees

select cast(max(salary) as numeric(10,0)) as Maximum,
cast(min(salary) as numeric(10,0)) as Minimum,
cast(sum(salary) as numeric(10,0)) as Sum,
cast(avg(salary) as numeric(10,0)) as Average
from employees

/* 9. Write a query that displays the last name (with the first letter in uppercase and all the other letters in lowercase)
and the length of the last name for all employees whose name starts with the letters “J,” “A,” or “M.” 
Give each column an appropriate label. Sort the results by the employees’ last names*/

select upper(left(last_name,1)) + lower(right(last_name,len(last_name)-1)) as employee_name, len(last_name) as length_of_name 
from employees
where upper(left(last_name,1)) in ('J', 'A', 'M')
order by last_name asc

--Cách 2:
select upper(substring(last_name,1,1)) + lower(substring(last_name,2,len(last_name))) as employee_name, len(last_name) as length_of_name 
from employees
where upper(substring(last_name,1,1)) in ('J', 'A', 'M')
order by last_name asc

/* 10. The HR department needs a report to display the employee number, last name, salary, 
and salary increased by 15.5% (expressed as a whole number) for each employee. Label the column New Salary*/

select employee_id, last_name, salary, cast(salary * 1.155 as numeric(10,0)) as new_salary from employees

/* 11.The HR department needs a report with the following specifications:
•	Last name and department ID of all employees from the employees table, regardless of whether or not they belong to a department
•	Department ID and department name of all departments from the departments table, 
regardless of whether or not they have employees working in them
Write a compound query to accomplish this*/

select last_name, department_id, cast(NULL as varchar(50)) as department_name from employees
union all
select cast(NULL as varchar(50)),department_id, department_name from departments


/*12. Produce a list of employees who joined the company later than their manager 
and who work in Toronto. Display the employee_id by using the set operators. */

 
select e.employee_id from employees e
inner join employees m
on e.manager_id = m.employee_id
where e.hire_date > m.hire_date
union
select e.employee_id from employees e
inner join departments d on e.department_id = d.department_id
inner join locations l on d.location_id= l.location_id
where city = 'Toronto'