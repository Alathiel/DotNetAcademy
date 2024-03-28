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

--1 Quanti colori comprende il modello Mountain-500 ?