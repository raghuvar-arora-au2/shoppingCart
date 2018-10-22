# ShoppingCartDemo
Shopping Cart Demo - ASP.NET Web Forms

Database:
CREATE DATABASE [ShoppingCartDB]  

Tables:

1.	Products
    CREATE TABLE [dbo].[Products](  
        [ProductID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,  
        [ProductName] [nvarchar](50) NULL,  
        [Price] [decimal](18, 2) NULL,  
        [ProductImage] [nvarchar](max) NULL)
 
2.	Orders
    CREATE TABLE [dbo].[Orders](  
        [OrderID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,    
        [CustomerID] [int] NULL,  
        [OrderDateTime] [datetime] NULL,  
        [TotalAmount] [decimal](18, 2) NULL)

3. OrderDetails
    CREATE TABLE [dbo].[OrderDetails](  
        [RecordID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
        [OrderID] [int] NULL,  
        [ProductID] [int] NULL,  
        [Quantity] [int] NULL,  
        [Amount] [decimal](18, 2) NULL)

3.	Cart
    CREATE TABLE [dbo].[Cart](  
        [ID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,  
        [ProductID] [int] NULL,  
        [Quantity] [int] NULL,  
        [Price] [decimal](18, 2) NULL,  
        [Amount] [decimal](18, 2) NULL,  
        [CartID] [nvarchar](50) NULL)

Pages:
 
1. Home.aspx => All Products are displayed here.

<img src="https://raw.githubusercontent.com/maunashjani/ShoppingCartDemo/master/Home.png" alt="Home"/>

2. ProductDetails.aspx => On clicking Buy Now button next to the product on Home page the product details page opens up with all details of the product along with “Add To Cart” button and Quantity TextBox.

<img src="https://raw.githubusercontent.com/maunashjani/ShoppingCartDemo/master/ProductDetails.png" alt="ProductDetails"/>

3.  Cart.aspx => Displays the items currently in the cart along with a Checkout button to complete the order process.

<img src="https://raw.githubusercontent.com/maunashjani/ShoppingCartDemo/master/Cart.png" alt="Cart"/>

4.  Account.aspx => Displays list of Orders and OrderDetails of the all the orders placed.

<img src="https://raw.githubusercontent.com/maunashjani/ShoppingCartDemo/master/Account.png" alt="Account"/>

Note:
    
1.	In this demonstration a Customer with CustomerID – 1 is used further modifications can be to select the currently logged in customer. 

2.	The UI is taken and modified from a starter template of Online Store from W3Schools' Bootstrap Templates, 

URL => https://www.w3schools.com/bootstrap/bootstrap_templates.asp

3. As a part of demo purpose not all features like stores, contact page, footer area is developed.
 
4. Here, SessionID is used to uniquely identify the Cart System.
 
5. There is a Cart Table which stores the products added to cart by the customer. There are various other ways like using ViewState, DataTables, etc to develop the Cart System, but this demo uses the Cart Table process.

6. Not all conditions and SQL processes like Joins are applied to the Tables to represent the data.
 
7. The popup messages like Product added to cart and order placed are coded with the help of a JavaScript library – SweetAlert, 

URL => https://sweetalert.js.org/
