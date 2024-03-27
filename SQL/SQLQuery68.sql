Select ProductID , Sum(Quantity)
from Production.ProductInventory
Where (Shelf = 'A' or Shelf = 'H' or Shelf = 'F')
Group by ProductID having Sum(Quantity)> 500
order by ProductID

Select p.BusinessEntityID, FirstName, LastName, PhoneNumber
from Person.Person p left join Person.PersonPhone pp on p.BusinessEntityID = pp.BusinessEntityID
where p.LastName like 'R%E'
order by LastName,FirstName

-- DALLA TABELLA SALES.SALESORDERHEADER UNA QUERY IN SQL PER TROVARE LA MEDIA E LA SOMMA -- DEL SUBTOTALE PER OGNI CLIENTE. RESTITUIRE L'ID CLIENTE, LA MEDIA E LA SOMMA -- DEL SUBTOTALE. RAGGRUPPARE IL RISULTATO SU CUSTOMERID E SALESPERSONID. -- ORDINARE IL RISULTATO NELLA COLONNA CUSTOMERID IN ORDINE DECRESCENTE.select c.customerID, AVG(SubTotal) as Media, SUM(SubTotal) as Sommafrom Sales.Customer c inner join Sales.SalesOrderHeader s on c.CustomerID = s.CustomerIDgroup by c.CustomerID, s.SalesPersonIDorder by CustomerID desc