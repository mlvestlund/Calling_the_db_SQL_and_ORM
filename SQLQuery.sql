-- Lösning på första frågan
SELECT Products.ProductName, Products.UnitPrice, Categories.CategoryName
FROM Products
INNER JOIN Categories ON Products.CategoryID=Categories.CategoryID
ORDER BY CategoryName, ProductName;

-- Lösning på andra frågan
SELECT CompanyName, COUNT(Orders.CustomerID) AS TotalOrders
FROM Customers
INNER JOIN Orders ON Customers.CustomerID=Orders.CustomerID
GROUP BY CompanyName
ORDER BY TotalOrders DESC;

-- Lösning på tredje frågan
SELECT FirstName, LastName, Territories.TerritoryDescription
FROM Employees
INNER JOIN EmployeeTerritories ON Employees.EmployeeID=EmployeeTerritories.EmployeeID
INNER JOIN Territories ON EmployeeTerritories.TerritoryID=Territories.TerritoryID;
