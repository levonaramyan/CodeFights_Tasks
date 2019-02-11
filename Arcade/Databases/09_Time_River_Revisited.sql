------ Important Events -------
-------------------------------
CREATE PROCEDURE importantEvents()
BEGIN
	select id,name,event_date,participants from events
    order by weekday(event_date) asc, participants desc;
END
-------------------------------
------- Date Formatting -------
-------------------------------
CREATE PROCEDURE dateFormatting()
BEGIN
	select date(date_str) as date_iso from documents;
END
-------------------------------
--------- Past Events ---------
-------------------------------
CREATE PROCEDURE pastEvents()
BEGIN
select name, event_date from Events,
(select max(event_date) as max_date from Events) as last_event
where datediff(last_event.max_date,event_date) between 1 and 7
order by event_date desc;
END
-------------------------------
--------- Net Income ----------
-------------------------------
CREATE PROCEDURE netIncome()
BEGIN
	select year(date) as year,quarter(date) as quarter, sum(profit) - sum(loss) as net_profit from accounting
    group by year,quarter
    order by year,quarter;
END
-------------------------------
-------- Alarm Clocks ---------
-------------------------------
CREATE PROCEDURE alarmClocks()
BEGIN
    set @date = (select input_date from userInput);
    set @initial = year(@date);
    drop table if exists alarmDates;
    create table alarmDates (alarm_date datetime);
    
	while year(@date) = @initial do
        insert into alarmDates ( alarm_date )
            select @date;
        set @date = @date + interval 7 day;
    end while;
    
    select * FROM alarmDates;
END
-------------------------------
