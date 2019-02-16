--------- Currency Codes ---------
----------------------------------
CREATE PROCEDURE currencyCodes()
BEGIN
    DELETE FROM currencies
    where Length(code) <> 3;

    SELECT * FROM currencies ORDER BY code;
END
----------------------------------
------ Courses Distribution ------
----------------------------------
CREATE PROCEDURE coursesDistribution()
BEGIN
    ALTER TABLE groupcourses ADD FOREIGN KEY (course_id)
    references courses (id) ON DELETE CASCADE;

    ALTER TABLE groupexams ADD FOREIGN KEY (course_id)
    references courses (id) ON DELETE CASCADE;

    DELETE FROM courses WHERE name LIKE '%-toremove';


    SELECT group_id, course_id
      FROM groupcourses
     UNION
    SELECT group_id, course_id
      FROM groupexams
     ORDER BY group_id, course_id;
END
----------------------------------
----------- Nicknames ------------
----------------------------------
CREATE PROCEDURE nicknames()
BEGIN
	UPDATE reservedNicknames
    SET nickname = concat('rename - ',nickname), id = concat('rename - ',id)
    WHERE LENGTH(nickname) <> 8;

    SELECT * FROM reservedNicknames ORDER BY id;
END
----------------------------------
--------- Table Security ---------
----------------------------------
CREATE PROCEDURE tableSecurity()
BEGIN
    CREATE OR REPLACE VIEW emp
    AS SELECT id,name,year(date_joined) as date_joined,'-' as salary from employees;

    SELECT id, name, date_joined, salary
    FROM emp
    ORDER BY id;
END
----------------------------------
--------- Office Branches --------
----------------------------------
CREATE PROCEDURE officeBranches()
BEGIN
    ALTER TABLE branches ADD FOREIGN KEY (branchtype_id)
    references branch_types (id) on DELETE set null;

    DELETE FROM branch_types WHERE name LIKE '%-outdated';

    SELECT * FROM branches
    ORDER BY branch_id;
END
----------------------------------
--------- Restaurant Info --------
----------------------------------
CREATE PROCEDURE restaurantInfo()
BEGIN
    alter table restaurants
    add column description varchar(100) default 'TBD',
    add column active int default 1;

    SELECT * FROM restaurants ORDER BY id;
END
----------------------------------
