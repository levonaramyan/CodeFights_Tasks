------------------------- Drivers Info --------------------------
-----------------------------------------------------------------
CREATE PROCEDURE driversInfo()
BEGIN
        select summary from
    (
            select '' as id, concat( ' Total miles driven by all drivers combined: ', sum(miles_logged)) as summary
            from inspections
            group by inspection_id is not null
            union
            select driver_name as id,
                concat(' Name: ',driver_name,
                   '; number of inspections: ',count(driver_name),
                   '; miles driven: ',sum(miles_logged)) as summary
            from inspections
            group by driver_name
            union
            select driver_name as id,
                    concat ('  date: ',date,'; miles covered: ',miles_logged) as summary
            from inspections
    ) as log_summary
        order by id,if(summary like '%Name%',0,1),summary asc;
END
-----------------------------------------------------------------
---------------------- Sort Book Chapters -----------------------
-----------------------------------------------------------------
CREATE PROCEDURE sortBookChapters()
BEGIN
        select chapter_name
        from book_chapters
        order by 
        (length(chapter_number)-length(replace(chapter_number,'I','')))*1 +
        (length(chapter_number)-length(replace(chapter_number,'V','')))*5 +
        (length(chapter_number)-length(replace(chapter_number,'X','')))*10 +
        (length(chapter_number)-length(replace(chapter_number,'L','')))*50 +
        (length(chapter_number)-length(replace(chapter_number,'C','')))*100 +
        (length(chapter_number)-length(replace(chapter_number,'D','')))*500 +
        (length(chapter_number)-length(replace(chapter_number,'M','')))*1000 -
        if(chapter_number like '%IX%' or chapter_number like'%IV%',2,0) -
        if(chapter_number like '%XC%' or chapter_number like '%XL%',20,0) -
        if(chapter_number like '%CD%' or chapter_number like'%CM%',200,0) ;
END
-----------------------------------------------------------------
----------------------- Type Inheritance ------------------------
-----------------------------------------------------------------
drop function if exists find_base; 

create function get_base(st varchar(50)) returns int
BEGIN

declare i int;

set i = 100;
   while i > 0 DO
     set st =(select base from inheritance where derived=st);
     if  st  is null then
         return 0;
     end if;
     if  st = 'NUMBER' then
         return 1;
     end if;
     if i = 1 then    
         return 1;
     end if;
     set i = i - 1;
   end while;
END;


CREATE PROCEDURE typeInheritance()
BEGIN     
    select var_name, type as var_type
    from variables
    where get_base(type) = 1;
END
-----------------------------------------------------------------
-------------------- Battleship Game Results --------------------
-----------------------------------------------------------------
/*Please add ; after each select statement*/
CREATE PROCEDURE battleshipGameResults()
BEGIN
	select size,
        sum(if(size = state,1,0)) as undamaged,
        sum(if(state > 0 and state < size,1,0)) as partly_damaged,
        sum(if(state = 0,1,0)) as sunk
    from
    (
        select sh.id,sh.size, sh.size - if(dam.shots is null,0,dam.shots) as state,dam.shots as dam_level from
        (
            select id, (bottom_right_x-upper_left_x+1)*(bottom_right_y-upper_left_y+1) as size from locations_of_ships
        ) as sh
        left join 
        (
            select los.id as id, count(os.id) as shots from locations_of_ships as los
            join opponents_shots as os on os.target_x between los.upper_left_x and bottom_right_x
            and os.target_y between los.upper_left_y and bottom_right_y
            group by los.id
        ) as dam on sh.id = dam.id
    ) as all_stats
    group by size;
END
-----------------------------------------------------------------
--------------------- Tictactoe Tournament ----------------------
-----------------------------------------------------------------
/*Please add ; after each select statement*/
CREATE PROCEDURE tictactoeTournament()
BEGIN
  select
    n.name,
    sum(if(r.res = n.name,2,if(r.res = 'draw',1,0))) as points,
    count(n.name) as played,
    sum(if(r.res = n.name,1,0)) as won,
    sum(if(r.res = 'draw',1,0)) as draw,
    sum(if(r.res != n.name and r.res != 'draw',1,0)) as lost
  from 
    (
      select name_crosses as name from results
      union
      select name_naughts as name from results
    ) as n
  join  
  (select name_naughts as o, name_crosses as x,
    if
    (
      (
        board like "XXX______" or board like "______XXX" 
        or board like "___XXX___" or board like "X__X__X__" or board like "_X__X__X_"
        or board like "__X__X__X" or board like "__X_X_X__" or board like "X___X___X"
      ),name_crosses,
      if
      (
        board like "OOO______" or board like "______OOO" 
        or board like "___OOO___" or board like "O__O__O__" or board like "_O__O__O_"
        or board like "__O__O__O" or board like "__O_O_O__" or board like "O___O___O" 
        ,name_naughts,'draw'
      )
    ) as res from results) as r
  on r.o = n.name or r.x = n.name
  group by n.name
  order by points desc,played asc,won desc,name asc;
END
-----------------------------------------------------------------
