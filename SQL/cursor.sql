declare @FullName varchar(50)
declare @Age int

declare cur_emp cursor local for
select FullName, Age from Employees
open cur_emp
	fetch next from cur_emp into @FullName, @Age
	while @@FETCH_STATUS = 0
		begin
			print @FullName + ' ' + Convert(varchar(50), @Age)
			fetch next from cur_emp into @FullName, @Age
		end
close cur_emp