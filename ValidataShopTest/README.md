### What to do for creating fresh new testing environments


For a clean environment, if Migrations exist delete the `Migrations` folder.

Then, delete the database from the Microsoft SQL Server Management Studio
Databases -> right click on the database (`ValidataShop`) -> click Delete -> Select the `Close existing connections` button -> click OK.

From Package Manager Console, run the following:

```
Add-Migration InitialCreate
```

```
Update-Database
```
Click Refresh on the Object Explorer of Microsoft SQL Server Management Studio to see the new database.


Now jumping to Microsoft SQL Management Studio (or VS native SQL Server Object Explorer) the fresh database is created.

Then, I used the `ValidataShopTest.http` file to quickly manually create some data, using the `Send request` button for the following requests:

Create 2 customers:

```
POST {{ValidataShopTest_HostAddress}}/api/Customers
Content-Type: application/json

{
    "FirstName": "John",
    "LastName": "Doe",
    "Address": "123 Main St",
    "PostalCode": "12345"
}
```
```
POST {{ValidataShopTest_HostAddress}}/api/Customers
Content-Type: application/json

{
    "FirstName": "Peter",
    "LastName": "Smith",
    "Address": "43 Ave St",
    "PostalCode": "54321"
}
```

Make sure the customers are created by running the following request:
```
GET {{ValidataShopTest_HostAddress}}/api/Customers
```

Create 2 products:

```
POST {{ValidataShopTest_HostAddress}}/api/Products
Content-Type: application/json

{
    "Name": "Large Pizza",
    "Price": 15.00
}
```

```
POST {{ValidataShopTest_HostAddress}}/api/Products
Content-Type: application/json

{
    "Name": "Small Pizza",
    "Price": 10.00
}
```

Make sure the products are created by running the following request:
```
GET {{ValidataShopTest_HostAddress}}/api/Products
```

Create an order, of the customer with id 1, with 2 items, 4 items of the product with id 1 and 2 items of the product with id 2:
```
POST {{ValidataShopTest_HostAddress}}/api/Orders
Content-Type: application/json

{
    "CustomerId": 1,
    "OrderItems": [
        {
            "ProductId": 1,
            "Quantity": 4
        },
        {
            "ProductId": 2,
            "Quantity": 2
        }
        ]
}
```

Create the same order , but with the customer with id 2:

```
POST {{ValidataShopTest_HostAddress}}/api/Orders
Content-Type: application/json

{
    "CustomerId": 2,
    "OrderItems": [
        {
            "ProductId": 1,
            "Quantity": 4
        },
        {
            "ProductId": 2,
            "Quantity": 2
        }
        ]
}
```

Create another order for customer with id 1, with 2 items of the product with id 1:
```
POST {{ValidataShopTest_HostAddress}}/api/Orders
Content-Type: application/json

{
    "CustomerId": 1,
    "OrderItems": [
        {
            "ProductId": 1,
            "Quantity": 2
        }
        ]
}
```

Finally, test the requested feature of iterating over the orders of a customer by date, by running the following request:
```
GET {{ValidataShopTest_HostAddress}}/api/Orders/OrdersOfCustomer/1
```
