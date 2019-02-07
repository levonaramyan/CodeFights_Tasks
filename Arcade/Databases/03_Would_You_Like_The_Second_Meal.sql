------ Suspects Investigation -----
-----------------------------------
CREATE PROCEDURE suspectsInvestigation()
BEGIN
	select id,name,surname from Suspect
    where height <= 170 and
            name like('b%') and
            surname like('Gre_n');
END
-----------------------------------
----- Suspects Investigation 2 ----
-----------------------------------
CREATE PROCEDURE suspectsInvestigation2()
BEGIN
	select id,name,surname from Suspect
    where height <= 170 or
            name not like('b%') or
            surname not like('Gre_n');
END
-----------------------------------
-------- Security Breach ----------
-----------------------------------
CREATE PROCEDURE securityBreach()
BEGIN
	select * from users
    where attribute like(concat('%_\%',first_name,'\_',second_name,'\%%')) COLLATE utf8_bin
            or attribute like(concat('%\%',first_name,'\_',second_name,'\%_%')) COLLATE utf8_bin
    order by attribute;
END
-----------------------------------
----------- Test Check ------------
-----------------------------------
CREATE PROCEDURE testCheck()
    SELECT id, IF ( given_Answer is not null,if(correct_answer = given_Answer,'correct','incorrect'),'no answer' ) AS checks
    FROM answers
    ORDER BY id;
-----------------------------------
----- Expressions Verification ----
-----------------------------------
CREATE PROCEDURE expressionsVerification()
BEGIN
    select * from expressions
    where c = case operation
    when '+' then a+b
    when '-' then a-b
    when '*' then a*b
    else a/b END
    order by id;
END
-----------------------------------
--------- New Subscribers ---------
-----------------------------------
CREATE PROCEDURE newsSubscribers()
BEGIN
	select distinct subscriber from (select * from full_year
    union
    select * from half_year as NewTable) as NewTable
    where newspaper like('%Daily%')
    order by subscriber;

END
-----------------------------------
