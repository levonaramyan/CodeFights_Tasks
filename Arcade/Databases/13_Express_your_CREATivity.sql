-------- Order Analytics --------
---------------------------------
DROP PROCEDURE IF EXISTS orderAnalytics;
CREATE PROCEDURE orderAnalytics()
BEGIN

    DROP VIEW IF EXISTS order_analytics;
    create view order_analytics as
        SELECT id,
            year(order_date) as year,
            quarter(order_date) as quarter,
            type,
            quantity*price as total_price
        from orders;

    SELECT *
    FROM order_analytics
    ORDER by id;
END;
---------------------------------
------- Customer Messages -------
---------------------------------
DROP FUNCTION IF EXISTS response;
CREATE FUNCTION response(name VARCHAR(40)) RETURNS VARCHAR(200) DETERMINISTIC
BEGIN
    set @nm = substring_index(name,' ',1);
    set @sn = substring_index(name,' ',-1);
    return concat('Dear ',
                  upper(substring(@nm,1,1)),lower(substring(@nm,2)),' ',
                  upper(substring(@sn,1,1)),lower(substring(@sn,2)),
                  '! We received your message and will process it as soon as possible. Thanks for using our service. FooBar On! - FooBarIO team.');
END;

CREATE PROCEDURE customerMessages()
BEGIN
    SELECT id, name, response(name) AS response
    FROM customers;
END;
---------------------------------
---------- Order Prices ---------
---------------------------------
DROP FUNCTION IF EXISTS get_total;
CREATE FUNCTION get_total(items VARCHAR(45)) RETURNS INT DETERMINISTIC
BEGIN
    
    return  (select sum(price) from item_prices
            where concat(';',items,';') like concat('%;',id,';%'));
END;

CREATE PROCEDURE orderPrices()
BEGIN
    SELECT id, buyer, get_total(items) AS total_price
    FROM orders
    ORDER BY id;
END;
---------------------------------
