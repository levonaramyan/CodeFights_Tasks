------ Website Hacking ------
-----------------------------
CREATE PROCEDURE websiteHacking()
    SELECT id,login,name
    FROM users
    WHERE type='user'
    or true
    ORDER BY id
-----------------------------
-------- Null Intern --------
-----------------------------
CREATE PROCEDURE nullIntern()
BEGIN
	select count(id) number_of_nulls from departments
    where description is null or trim(description) in ('NULL','NIL','-');
END
-----------------------------
-------- Legs Count ---------
-----------------------------
DROP PROCEDURE IF EXISTS legsCount;
CREATE PROCEDURE legsCount()
    SELECT sum(if(type = 'human',2,4)) as summary_legs
    FROM creatures
    ORDER BY id;
-----------------------------
----- Combination Lock ------
-----------------------------
CREATE PROCEDURE combinationLock()
BEGIN
	select Round(EXP(SUM(LOG(Length(characters)))),0) combinations from discs
    order by EXP(SUM(LOG(Length(characters)))) desc
    limit 1;
END
-----------------------------
