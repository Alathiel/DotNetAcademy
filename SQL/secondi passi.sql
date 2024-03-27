select Product.Name, Product.ListPrice, Product.SellStartDate, Product.Weight, model.Name as Model_Name, ProductModelProductDescription.Culture, description.Description
from SalesLT.ProductCategory as Category, 
	SalesLT.Product as Product, 
	SalesLT.ProductModel as model, 
	SalesLT.ProductModelProductDescription, 
	SalesLT.ProductDescription as description
where Category.ProductCategoryID = Product.ProductCategoryID 
	and model.ProductModelID = Product.ProductModelID 
	and model.ProductModelID = ProductModelProductDescription.ProductModelID and 
	description.ProductDescriptionID = ProductModelProductDescription.ProductDescriptionID 


select Product.Name, Product.ListPrice, Product.SellStartDate, Product.Weight, model.Name as Model_Name, model_description.Culture, description.Description 
from SalesLT.ProductCategory
	inner join SalesLT.Product product on SalesLT.ProductCategory.ProductCategoryID = product.ProductCategoryID
	inner join SalesLT.ProductModel model on model.ProductModelID = product.ProductModelID
	inner join SalesLT.ProductModelProductDescription model_description on model_description.ProductModelID = model.ProductModelID
	inner join SalesLT.ProductDescription description on description.ProductDescriptionID = model_description.ProductDescriptionID
where model_description.Culture = 'fr'

--1 Quanti colori comprende il modello Mountain-500 ?--2 Quante misure (e quali) sono comprese nel modello touring-3000 Yellow ?--3 Quali sono gli articoli che non hanno definito un colore, visualizza in ordine di  productmodelid.--4 Il costo medio delle serie Mountain-100,200,300, considerate tutte insieme.-- 1select model.Name, COUNT( distinct product.Color) as Colors_Availablefrom SalesLT.Product as product	inner join SalesLT.ProductModel model on product.ProductModelID = model.ProductModelIDwhere (model.Name) like 'Mountain-500'group by model.Name-- 2select model.Name, product.Size, (select COUNT(product.Size) from SalesLT.Product where product.Name like '%touring-3000 Yellow%') as Sizesfrom SalesLT.Product as product	inner join SalesLT.ProductModel model on product.ProductModelID = model.ProductModelIDwhere product.Name like '%touring-3000 Yellow%'-- 3select product.ProductModelID, product.Namefrom SalesLT.Product as productwhere product.Color is nullorder by product.ProductModelID-- 4select AVG(product.ListPrice)from SalesLT.Product as product	inner join SalesLT.ProductModel model on product.ProductModelID = model.ProductModelIDwhere model.Name like 'Mountain-[123]00'group by product.ProductCategoryID