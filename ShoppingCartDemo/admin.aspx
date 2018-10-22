<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="ShoppingCartDemo.admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>admin</title>
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <link rel="stylesheet" href="css/bootstrap.min.css">
        <script src="js/jquery.min.js"></script>
        <script src="js/bootstrap.min.js"></script>
        <script src="js/sweetalert.min.js"></script>
    <style>
        /* Remove the navbar's default rounded borders and increase the bottom margin */
        .navbar {
            margin-bottom: 50px;
            border-radius: 0;
        }

        /* Remove the jumbotron's default bottom margin */
        .jumbotron {
            margin-bottom: 0;
        }

        /* Add a gray background color and some padding to the footer */
        footer {
            background-color: #f2f2f2;
            padding: 25px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
            <div class="jumbotron">
        <div class="container text-center">
            <h1>Shopping Cart</h1>
        </div>
    </div>

    <nav class="navbar navbar-inverse">
        <div class="container-fluid">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="#">Logo</a>
            </div>
            <div class="collapse navbar-collapse" id="myNavbar">
                <ul class="nav navbar-nav">
                    <li class="active"><a href="Home.aspx">Home</a></li>
                </ul>
                <ul class="nav navbar-nav navbar-right">
                    <li><a href="#"><span class="glyphicon glyphicon-user"></span>Admin</a></li>
                    
                </ul>
            </div>
        </div>
    </nav>
        <div>

        
        </div>
            <asp:GridView ID="GridView1" CssClass="table table-responsive table-hover" runat="server"  DataSourceID="SqlDataSource2">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                </Columns>
            </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [Products] WHERE [ProductID] = @ProductID"
                InsertCommand="INSERT INTO [Products] ( [ProductName], [Price], [ProductImage]) VALUES (@ProductName, @Price, @ProductImage)"
                SelectCommand="SELECT * FROM [Products] ;"
                UpdateCommand="UPDATE [Products] SET [ProductName] = @ProductName, [Price] = @Price, [ProductImage]=@ProductImage">
                <DeleteParameters>
                    <asp:Parameter Name="ProductID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="ProductName" Type="String" />
                    <asp:Parameter Name="Price" Type="Decimal" />
                    <asp:Parameter Name="ProductImage" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="ProductName" Type="String" />
                    
                    <asp:Parameter Name="Price" Type="Decimal" />
                    <asp:Parameter Name="ProductImage" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>

        <div class="container">
	<div class="row">
		<div class="col-sm-4">
           
                
		    Add new Item
            <form class="form-inline">
		    <div class="form-group pass_show"> 
                <input type="text"  class="form-control" name="name" id="name" placeholder="Product name" runat="server"  > 
            </div> 
		    
            <div class="form-group pass_show"> 
                <input type="text"  class="form-control" id="price" name="price" placeholder="price" runat="server" > 
            </div> 
            <div class="form-group pass_show"> 
                <input type="text"  class="form-control" id="image" name="image" placeholder="product image" runat="server" > 
            </div> 
		      
            <div class="form-group pass_show"> 
                <asp:button ID="button2" class="btn btn-success" runat="server" OnClick="button1_Click" Text="Add new Item"></asp:button>
            </div>


            
            </form>
                    
         
            
		</div>  
	</div>
</div>
        <%--<form class="form-inline" >
                <div class="form-group">
                       <input type="text" class="form-control" id="name" placeholder="Product Name" name="name">
                </div>
                 <div class="form-group">
     
                  <input type="text" class="form-control" id="price" placeholder="Price" name="price">
                  </div>
                <div class="form-group">
     
                  <input type="text" class="form-control" id="image" placeholder="Product Image" name="image">
                  </div>
    
                <button type="submit" class="btn btn-success">Submit</button>
            </form>--%>
    </form>
</body>
</html>
