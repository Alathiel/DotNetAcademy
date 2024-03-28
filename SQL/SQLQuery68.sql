Select ProductID , Sum(Quantity)
from Production.ProductInventory
Where (Shelf = 'A' or Shelf = 'H' or Shelf = 'F')
Group by ProductID having Sum(Quantity)> 500
order by ProductID

Select p.BusinessEntityID, FirstName, LastName, PhoneNumber
from Person.Person p left join Person.PersonPhone pp on p.BusinessEntityID = pp.BusinessEntityID
where p.LastName like 'R%E'
order by LastName,FirstName

-- DALLA TABELLA SALES.SALESORDERHEADER UNA QUERY IN SQL PER TROVARE LA MEDIA E LA SOMMA 