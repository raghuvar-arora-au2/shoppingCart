<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ShoppingCartDemo.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="css/bootstrap.min.css">
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/sweetalert.min.js"></script>
    <script>
        function successalert() {
            swal({
             
                text: 'Incorrect Usesrname or Password',
                type: 'error'
            });
        };
    </script>

</head>
<body>
    <form runat="server">
     <div class="jumbotron">
        <div class="container text-center">
            <h1>Shopping Cart Demo</h1>
        </div>
    </div>

        <div class="container justify-content-center">
	<div class="row">
		<div class="col-sm-4">
           
                
		    Login to ShoppingCart.com
		    <div class="form-group pass_show"> 
                <input type="email"  class="form-control" name="email" id="email" placeholder="Username" runat="server"  > 
            </div> 
		    
            <div class="form-group pass_show"> 
                <input type="password"  class="form-control" id="password" name="password" placeholder="Password" runat="server" > 
            </div> 
		      
            <div class="form-group pass_show"> 
                <asp:button ID="button2" class="btn btn-success" runat="server" OnClick="button1_Click" Text="Login"></asp:button>
            </div>
                    
         
            
		</div>  
	</div>
</div>
        </form>
</body>
</html>