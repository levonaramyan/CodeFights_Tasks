---------- Find Table ----------
--------------------------------
CREATE PROCEDURE findTable()
BEGIN
	select
  	table_name as tab_name,column_name as col_name,data_type
    from
  	information_schema.columns
    where table_schema = 'ri_db' and table_name like 'e%s'
  order by tab_name,col_name;
END
--------------------------------
------- Queries Execution ------
--------------------------------
CREATE PROCEDURE queriesExecution()
BEGIN
    set @a = concat(
        (select group_concat(concat('select "',query_name,'" query_name, (',code,') val')
                            separator ' union ') from queries),
        ' order by 1');

    prepare constructed_query from @a;
    execute constructed_query;
END
--------------------------------
