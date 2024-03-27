-- 1) Selezionare nome completo customer, company, mail e indirizzo completo-- 2) Selezionare nome completo customer, company, mail e indirizzo completo con alias italiani
--PER ENTRAMBE LE RICHIESTE ORDINAMENTO PER COUNTRYREGION E STATEPROVINCE
-- 3) Selezionare nome completo customer, company, mail e indirizzo completo escludendo--	  le righe che non hanno un MiddleName-- 4) Quante sono le citta, per provincia per CountryRegion--


select case when MiddleName is not null then (FirstName +' '+ MiddleName +' '+ LastName) -- 1
else (FirstName +' '+ LastName)
end as FullName, CompanyName, EmailAddress,
case when AddressLine2 is not null then (AddressLine1 + ' - ' + AddressLine2) 
else (AddressLine1) 
end as address
from SalesLT.Customer, SalesLT.CustomerAddress, SalesLT.Address
where Customer.CustomerID = CustomerAddress.CustomerID and CustomerAddress.AddressID = Address.AddressID
order by CountryRegion, StateProvince


select case when MiddleName is not null then (FirstName +' '+ MiddleName +' '+ LastName) -- 2
else (FirstName +' '+ LastName)
end as Nome_Completo, CompanyName as Nome_Compagnia, EmailAddress as Indirizzo_Email,
case when AddressLine2 is not null then (AddressLine1 + ' - ' + AddressLine2) 
else (AddressLine1) 
end as Indirizzo_Completo
from SalesLT.Customer, SalesLT.CustomerAddress, SalesLT.Address
where Customer.CustomerID = CustomerAddress.CustomerID and CustomerAddress.AddressID = Address.AddressID
order by CountryRegion, StateProvince


select case when MiddleName is not null then (FirstName +' '+ MiddleName +' '+ LastName) -- 3
end as FullName, CompanyName, EmailAddress,
case when AddressLine2 is not null then (AddressLine1 + ' - ' + AddressLine2) 
else (AddressLine1) 
end as address
from SalesLT.Customer, SalesLT.CustomerAddress, SalesLT.Address
where Customer.CustomerID = CustomerAddress.CustomerID and CustomerAddress.AddressID = Address.AddressID and MiddleName is not null
order by CountryRegion, StateProvince


Select distinct CountryRegion, count(CountryRegion), StateProvince, COUNT(StateProvince), City, COUNT(City) -- 4 
from SalesLT.Address, SalesLT.CustomerAddress
where address.AddressID = CustomerAddress.AddressID
group by City, StateProvince, CountryRegion
order by count(City) desc




