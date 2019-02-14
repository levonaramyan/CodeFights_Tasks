-------- Students In Clubs -------
----------------------------------
CREATE PROCEDURE studentsInClubs()
    SELECT * FROM students
    WHERE EXISTS (
        SELECT * from clubs where clubs.id = students.club_id
    )
    ORDER BY students.id;
----------------------------------
-------- Empty Departments -------
----------------------------------
CREATE PROCEDURE emptyDepartments()
BEGIN
	select dep_name from departments
    where id not in (select department from employees);
END
----------------------------------
--------- Sunny Holidays ---------
----------------------------------
CREATE PROCEDURE sunnyHolidays()
BEGIN
	select holiday_date as ski_date from holidays as h
    inner join weather as w on h.holiday_date = w.sunny_date;    
END
----------------------------------
---------- Closest Cells ---------
----------------------------------
CREATE PROCEDURE closestCells()
BEGIN
	
    select p1.id as id1,
    (select p2.id from positions as p2
    where p1.id <> p2.id
    order by pow((p1.x-p2.x),2)+pow((p1.y-p2.y),2)
    limit 1) as id2 
    from positions as p1;
END
----------------------------------
------- Top 5 Average Grade ------
----------------------------------
CREATE PROCEDURE top5AverageGrade()
BEGIN
	select round(avg(grade),2) as average_grade from (select grade from students
    order by grade desc
    limit 5) as bla;
END
----------------------------------
-------- Salary Difference -------
----------------------------------
CREATE PROCEDURE salaryDifference()
BEGIN
    
    select coalesce(sum(if(salary = (select max(salary) as salary from employees),salary,0)) -
      sum(if(salary = (select min(salary) as salary from employees),salary,0)),0) as difference
    from employees
    order by salary desc;
END
----------------------------------
---------- Recent Hires ----------
----------------------------------
CREATE PROCEDURE recentHires()
BEGIN
	select name as names
    from
    (select name, dep from (select name, '1' as dep from pr_department order by date_joined desc limit 5) as pr
    union all
    select name, dep from (select name, '2' as dep from it_department order by date_joined desc limit 5) as it
    union all
    select name, dep from (select name, '3' as dep from sales_department order by date_joined desc limit 5) as sales)
    as all_recent
    order by dep,name;
END
----------------------------------
-------- Check Expenditure -------
----------------------------------
CREATE PROCEDURE checkExpenditure()
BEGIN
	select ae.id as id, if (sum(ep.expenditure_sum)<= ae.value,0,sum(ep.expenditure_sum)-ae.value)
    as loss from expenditure_plan as ep
    join allowable_expenditure as ae on
            ceiling((datediff(ep.monday_date,concat(year(ep.monday_date),'-01-01')))/7)
                    between ae.left_bound and ae.right_bound
    group by id;
END
----------------------------------
------- Dancing Competition ------
----------------------------------
CREATE PROCEDURE dancingCompetition()
BEGIN
	set @min1 = (select min(first_criterion) from scores);
    set @max1 = (select max(first_criterion) from scores);
    set @min2 = (select min(second_criterion) from scores);
    set @max2 = (select max(second_criterion) from scores);
    set @min3 = (select min(third_criterion) from scores);
    set @max3 = (select max(third_criterion) from scores);
    
    select arbiter_id, first_criterion, second_criterion, third_criterion from scores
    where if(first_criterion in (@min1,@max1),1,0) +
          if(second_criterion in (@min2,@max2),1,0) +
          if(third_criterion in (@min3,@max3),1,0) < 2;
END
----------------------------------
-------- Tracking System ---------
----------------------------------
CREATE PROCEDURE trackingSystem()
BEGIN
	select l_n.anonym_id,l_n.last_null,f_n.first_notnull from
    (select ln.anonym_id as anonym_id,tr.event_name as last_null from tracks tr
    join
      (select anonymous_id as anonym_id,max(received_at)  as rec_at from tracks
      where user_id is null group by anonym_id) ln
    on tr.anonymous_id = ln.anonym_id and ln.rec_at = tr.received_at) as l_n
    left join
      (select ln.anonym_id as anonym_id,tr.event_name as first_notnull from tracks tr
      join
        (select anonymous_id as anonym_id,min(received_at)  as rec_at from tracks
        where user_id is not null group by anonym_id) ln
      on tr.anonymous_id = ln.anonym_id and ln.rec_at = tr.received_at) as f_n
    on l_n.anonym_id = f_n.anonym_id
    order by anonym_id;
END
----------------------------------
------ Storage Optimization ------
----------------------------------
CREATE PROCEDURE storageOptimization()
BEGIN
	select id, 'name' as column_name, name as value from workers_info
    where name is not null
    union
    select id, 'date_of_birth' as column_name, date_of_birth as value from workers_info
    where date_of_birth is not null
    union
    select id, 'salary' as column_name, salary as value from workers_info
    where salary is not null
    order by id, field(column_name,'name','date_of_birth','salary');
END
----------------------------------
-------- Consecutive Ids ---------
----------------------------------
CREATE PROCEDURE consecutiveIds()
BEGIN
	set @newID = 0;

    select id as oldId, @newID := @newID+1 as newId from itemIds;
END
----------------------------------
--------- Holiday Event ----------
----------------------------------
CREATE PROCEDURE holidayEvent()
BEGIN
	set @order = 0;

    select distinct winners from (select buyer_name as winners,@order := @order + 1 as ord from purchases) as enum
    where ord / 4 > 0 and ord % 4 = 0
    order by winners;
END
----------------------------------
------- Hostnames Ordering -------
----------------------------------
CREATE PROCEDURE hostnamesOrdering()
BEGIN
    select id, hostname from hostnames
    group by concat(substring_index(concat('...',hostname),'.',-1),' ',
                    substring_index(concat('...',hostname),'.',-2),' ',hostname);
END
----------------------------------
