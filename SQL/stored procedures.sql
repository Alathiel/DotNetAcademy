declare @rowsAffected int 
exec sp_UpdateEmployees 'Impiegato', 'Fuochista', @rowsAffected = @rowsAffected OUTPUT
select @rowsAffected as 'Righe totali aggiornate'