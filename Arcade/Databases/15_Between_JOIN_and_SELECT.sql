----------- Film Library -----------
------------------------------------
CREATE PROCEDURE filmLibrary()
BEGIN
	set @ganre = (select genre from movies group by genre order by count(*) desc limit 1);
    select aa.actor, aa.age from starring_actors as sa
    join movies as mv on sa.movie_name = mv.movie and mv.genre = @ganre
    join actor_ages as aa on aa.actor = sa.actor
    order by age desc, actor;
END
------------------------------------
--------- Bugs In Component --------
------------------------------------
CREATE PROCEDURE bugsInComponent()
BEGIN    
    select b.title as bug_title,c.title as component_title,bcg.num as bugs_in_component from Bug as b    
    join BugComponent as bc on b.num = bc.bug_num
    join Component as c on c.id = bc.component_id
    join (select component_id as id, count(*) as num from BugComponent group by component_id) as bcg
                                                                        on bcg.id = bc.component_id
    where b.num in (select bug_num from(
                        select bug_num,
                        count(distinct component_id) as number
                        from BugComponent
                        group by bug_num   
                        having number > 1) as asdsadasd)
    order by bugs_in_component desc,bcg.id,b.num;

    
END
------------------------------------
------------ Free Seats ------------
------------------------------------
CREATE PROCEDURE freeSeats()
BEGIN
	select fl.flight_id, pl.number_of_seats - coalesce(pc.reserved,0) as free_seats from flights as fl
    left join planes as pl on fl.plane_id = pl.plane_id
    left join (select flight_id,count(*) as reserved from purchases group by flight_id) as pc
        on pc.flight_id = fl.flight_id
    order by flight_id;
END
------------------------------------
---------- Gift Packaging ----------
------------------------------------
CREATE PROCEDURE giftPackaging()
BEGIN
    select f.package_type, count(f.package_type) as number
    from (
    select dd.package_type 
    from
    (
        select pack.id as id, min(pack.length * pack.width * pack.height) as box_dim
        from (select g.id, p.* from gifts g
            join packages p on g.length <= p.length and g.width <= p.width and g.height <= p.height
            ) as pack
        group by pack.id
    ) e
    join (select package_type,(length * width * height) as box_dim from packages) as dd on dd.box_dim = e.box_dim
    ) f 
    group by f.package_type
    order by f.package_type;
END
------------------------------------
-------- Strings Statistics --------
------------------------------------
CREATE PROCEDURE stringsStatistics()
BEGIN
	drop table if exists letters;
    CREATE table letters (letter char(1));
    insert into letters
    values ('a'),('b'),('c'),('d'),('e'),('f'),('g'),('h'),('i'),('j'),('k'),('l'),('m'),
            ('n'),('o'),('p'),('q'),('r'),('s'),('t'),('u'),('v'),('w'),('x'),('y'),('z');

    select letter, total, occurrence, max_occurrence,
        sum(length(s2.str)-length(replace(s2.str,letter,'')) = max_occurrence) as max_occurrence_reached
    from (select
        l.letter as letter,
        sum(length(s.str)-length(replace(s.str,l.letter,''))) as total,
        count(*) as occurrence,
        max(length(s.str)-length(replace(s.str,l.letter,''))) as max_occurrence
    from letters as l
    join strs as s on s.str like concat('%',l.letter,'%')
    group by letter) as s1
    join strs  as s2 on s2.str like concat('%',s1.letter,'%')
    group by letter;
        
END
------------------------------------
--------- Unlucky Employees --------
------------------------------------
CREATE PROCEDURE unluckyEmployees()
BEGIN
    set @c = 0;
    select name as dep_name,empl_count as emp_number,sal as total_salary
    from
    (
        select @c := @c + 1 as id, name, empl_count, sal
        from
        (
            select d.name as name,count(e.id) as empl_count,coalesce(sum(e.salary),0) as sal from Department as d
            left join Employee as e on d.id = e.department
            group by d.name,d.id
            having empl_count < 6
            order by sal desc, empl_count desc,d.id asc
        ) as list
    ) as final
    where id % 2 = 1;
END
------------------------------------
