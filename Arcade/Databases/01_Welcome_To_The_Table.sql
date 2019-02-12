--------------- Project List ---------------
CREATE PROCEDURE projectList()
BEGIN
	select project_name, team_lead, income
from Projects;
END
--------------------------------------------
----------- Countries Selection ------------
CREATE PROCEDURE countriesSelection()
BEGIN
	select
    name, continent, population
    from
    countries
    where continent = 'Africa';
END
--------------------------------------------
----------- Monthly Scholarships -----------
CREATE PROCEDURE monthlyScholarships()
BEGIN
	select
    id as id, scholarship/12.0 as scholarship
    from
    scholarships;
END
--------------------------------------------
--------------- Projects Team --------------
CREATE PROCEDURE projectsTeam()
BEGIN
	select distinct name
    from projectLog
    order by name asc;
END
--------------------------------------------
---------- Automatic Notifications ---------
CREATE PROCEDURE automaticNotifications()
    SELECT email
    FROM users
    WHERE role not in ("admin", "premium")

    ORDER BY email;
--------------------------------------------
