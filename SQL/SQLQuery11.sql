select person.BusinessEntityID ,concat(person.FirstName,' ',person.MiddleName,' ',person.LastName) as CompleteName , payHistory.Rate * 40 as WeeklyPay ,
CONVERT(varchar,payHistory.ModifiedDate,34)  as ModifiedDate 
From Person.Person person 
	inner join HumanResources.EmployeePayHistory payHistory on payHistory.BusinessEntityID = person.BusinessEntityID
where payHistory.ModifiedDate = (
	Select Max(ModifiedDate)
	from HumanResources.EmployeePayHistory
	where BusinessEntityID = person.BusinessEntityID
	)
order by CompleteName