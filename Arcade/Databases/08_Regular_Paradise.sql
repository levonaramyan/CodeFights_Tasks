---------- Correct IPs ----------
---------------------------------
CREATE PROCEDURE correctIPs()
BEGIN
    set @a = '(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)';
    select id, ip
    from ips
    where(ip regexp concat('^(',@a,'\.){2}([1-9][0-9]\.)',@a,'$')
            or ip regexp concat('^(',@a,'\.){3}([1-9][0-9])$'))
    ORDER BY id;
END
---------------------------------
------ Valid Phone Numbers ------
---------------------------------
CREATE PROCEDURE validPhoneNumbers()
BEGIN
	select name, surname, phone_number from phone_numbers
    where (phone_number regexp('^[(]1[)][0-9]{3}-[0-9]{3}-[0-9]{4}$')
          or
          phone_number regexp('^[1]-[0-9]{3}-[0-9]{3}-[0-9]{4}$'))
    order by surname;
END
---------------------------------
