------ Order Of Succession ------
---------------------------------
CREATE PROCEDURE orderOfSuccession()
BEGIN
	select concat(if(gender = 'F','Queen ','King '),name) as name from Successors
    order by birthday;
END
---------------------------------
-------- Ordering Emails --------
---------------------------------
CREATE PROCEDURE orderingEmails()
BEGIN
	select id,email_title,
    if(size >= 1024*1024,
       concat(floor(size/(1024*1024)),' Mb'),
       concat(floor(size/1024),' Kb'))
    as short_size from emails
    order by size desc;
END
---------------------------------
------ Places Of Interest -------
---------------------------------
CREATE PROCEDURE placesOfInterest()
BEGIN
	select country,
    sum(if(leisure_activity_type = 'adventure park',1,0)*number_of_places) as adventure_park,
    sum(if(leisure_activity_type = 'golf',1,0)*number_of_places) as golf,
    sum(if(leisure_activity_type = 'river cruise',1,0)*number_of_places) as river_cruise,
    sum(if(leisure_activity_type = 'kart racing',1,0)*number_of_places) as kart_racing
    from countryActivities
    group by country
    order by country;
END
---------------------------------
------ Soccer Game Series -------
---------------------------------
CREATE PROCEDURE soccerGameSeries()
BEGIN
	select case
                when won_1 > won_2 then 1
                when won_2 > won_1 then 2
                when scored_1 > scored_2 then 1
                when scored_2 > scored_1 then 2
                when away_score_1 > away_score_2 then 1
                when away_score_2 > away_score_1 then 2
                else 0
            END as winner    
    from (select sum(if(first_team_score > second_team_score,1,0)) as won_1,
    sum(if(second_team_score > first_team_score,1,0)) as won_2,
    sum(first_team_score) as scored_1,
    sum(second_team_score) as scored_2,
    sum((match_host - 1)*first_team_score) as away_score_1,
    sum((2 - match_host)*second_team_score) as away_score_2
    from scores) a;
END
---------------------------------
