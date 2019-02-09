------- Interest Club --------
------------------------------
CREATE PROCEDURE interestClub()
    SELECT name
    FROM people_interests
    WHERE interests & if(interests like ('%reading%'),interests,0) AND interests & if(interests like ('%drawing%'),interests,0)
    ORDER BY name
------------------------------
------ Personal Hobbies ------
------------------------------
CREATE PROCEDURE personalHobbies()
BEGIN
	select name from people_hobbies
    where hobbies like ('%reading%') and hobbies like ('%sports%')
    order by name;
END
------------------------------
------- Books Catalogs -------
------------------------------
CREATE PROCEDURE booksCatalogs()
BEGIN
	select substring(xml_doc,
                     position('r>' in xml_doc)+2,
                     position('</a' in xml_doc)-position('r>' in xml_doc)-2)
    as author
    from catalogs
    order by author;
END
------------------------------
-------- Habitat Area --------
------------------------------
CREATE PROCEDURE habitatArea()
BEGIN
	SET @animalPositions =
  (SELECT CONCAT('MULTIPOINT(', GROUP_CONCAT( CONCAT(x, ' ', y) SEPARATOR ','),')') FROM places);

  SELECT ST_Area(ST_ConvexHull(ST_GeomFromText(@animalPositions))) AS area;
END
------------------------------
