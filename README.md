## IReckonU  

###### Back End Engineer Assignment

Build a web app with the features described below.

Backend - C# .NET Core web API

1. Import the file via web API, expect the file to be very large in production

2. Transform the data into a logical model

3. Store the data (two locations - a Database and JSON file)

  - Database (can be either MS SQL or MongoDB - you choose)
  - JSON file on the disk
  
Data: Sample File: https://goo.gl/tJWo1f

Criteria: Your implementation properly follows all SOLID principles.


-----------------------------------------------------------------------------------------

Notes:

- Database is SQL Server.
- Entity Framework Core used for migrations.
- Source file (iru-assignment-2018.csv) is fetch from a fixed route inside the project ("Resources"), and the output JSON file is generated in the same route

Endpoints: 
- https://localhost:5001/api/product/ 
Get all products.
- https://localhost:5001/api/product/productKey
Find a product by productKey (i.e. https://localhost:5001/api/product/00000002groe110)
- https://localhost:5001/api/product/import
Run the import process who fetches the CSV file, saves the contents in the DB and outputs a JSON file with the saved data.

Improvements I left out due to time availability:

- Implement automapper, get rid of those CreateProduct private methods
- Implement logging and custom exceptions. Now as rudimentary logging I'm using action result responses
- Integrate with swagger or at least add some visual interface, for example to upload the file to be processed or select an output path for the json
- Write unit tests (objects are correct type, parameters are correct, amount of retrieved items is correct, import process doesn't fail or if it does it gives the correct exception)
- Robust file management (file integrity, async processing, validations)
- Repo validations (i.e. manaqing insertion of duplicates in the db and similar issues)
- Auth/permissions if necessary
