-- L�sning p� f�rsta fr�gan
SELECT Products.ProductName, Products.UnitPrice, Categories.CategoryName
FROM Products
INNER JOIN Categories ON Products.CategoryID=Categories.CategoryID
ORDER BY CategoryName, ProductName;

-- L�sning p� andra fr�gan
SELECT CompanyName, COUNT(Orders.CustomerID) AS TotalOrders
FROM Customers
INNER JOIN Orders ON Customers.CustomerID=Orders.CustomerID
GROUP BY CompanyName
ORDER BY TotalOrders DESC;

-- L�sning p� tredje fr�gan
SELECT FirstName, LastName, Territories.TerritoryDescription
FROM Employees
INNER JOIN EmployeeTerritories ON Employees.EmployeeID=EmployeeTerritories.EmployeeID
INNER JOIN Territories ON EmployeeTerritories.TerritoryID=Territories.TerritoryID;
