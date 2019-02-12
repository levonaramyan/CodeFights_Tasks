---------- Company Employees -----------
----------------------------------------
CREATE PROCEDURE companyEmployees()
BEGIN
	select * from departments,employees
    order by departments.dep_name,employees.emp_name;
END
----------------------------------------
------ Scholarships Distribution -------
----------------------------------------
CREATE PROCEDURE scholarshipsDistribution()
BEGIN
	select candidate_id as student_id from candidates
    where candidate_id not in (select dt.student_id from detentions as dt);
END
----------------------------------------
------------ User Countries ------------
----------------------------------------
CREATE PROCEDURE userCountries()
BEGIN
	select users.id as id, coalesce(cities.country,'unknown') as country from users
    left join cities on users.city = cities.city
    order by id;
END
----------------------------------------
------ Places Of InterestPairs ---------
----------------------------------------
CREATE PROCEDURE placesOfInterestPairs()
BEGIN
	select s1.name as place1, s2.name as place2 from sights as s1
    cross join sights as s2
    where (s1.x - s2.x)*(s1.x - s2.x) + (s1.y - s2.y)*(s1.y - s2.y) < 25
            and s1.name < s2.name
    order by place1,place2;
END
----------------------------------------
------------ Local Calendar ------------
----------------------------------------
CREATE PROCEDURE localCalendar()
BEGIN
	set @st1 = '%Y-%m-%d %h:%i %p';
    set @st2 = '%Y-%m-%d %H:%i';
    select ev.event_id as event_id,
        date_format(date_add(ev.date, interval s.timeshift minute),if(s.hours = 12,@st1,@st2)) as formatted_date
    from events as ev
    left join settings as s on s.user_id = ev.user_id
    order by event_id;
END
----------------------------------------
------------- Route Length -------------
----------------------------------------
CREATE PROCEDURE routeLength()
BEGIN
	select round(sum(power(power((c1.x-c2.x),2)+power((c1.y-c2.y),2),0.5)),9) as total from cities as c1
    cross join cities as c2
    where c2.id - c1.id = 1;
END
----------------------------------------
