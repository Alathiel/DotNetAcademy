execute sp_Insert

declare @totalRows int 

execute sp_Delete '2024-03-27 09:56:15.583', 'si', @totalRows = @totalRows output

select @totalRows as 'Rows Affected'
