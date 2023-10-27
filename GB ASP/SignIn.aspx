<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="GB_ASP.SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login - Ghazi Brothers</title>
    <link rel="icon" type="image/png" href="images/gb.png" sizes="16x16"/>
    
    <meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
<!--===============================================================================================-->	
	<link rel="icon" type="image/png" href="images/icons/favicon.ico"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/bootstrap/css/bootstrap.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.7.0/css/font-awesome.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="fonts/Linearicons-Free-v1.0.0/icon-font.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/animate/animate.css">
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="vendor/css-hamburgers/hamburgers.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/animsition/css/animsition.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/select2/select2.min.css">
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="vendor/daterangepicker/daterangepicker.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="css/util.css">
	<link rel="stylesheet" type="text/css" href="css/main.css">
<!--===============================================================================================-->

</head>
<body>
    <div class="limiter">
		<div class="container-login100">
			<div class="wrap-login100 p-t-50 p-b-90">
			<form id="form1" runat="server" class="login" method="post">		
			<center>
                <img src="images/gb.png" class="img img-responsive" style="width: 170px; margin-top: 20px " alt=""/>
			</center>
					<hr/>
				<div class="login100-form validate-form flex-sb flex-w">
					
					
          <span class="login100-form-title p-b-51">
						Login
					</span>                  
  				
					<div class="wrap-input100 validate-input m-b-16" data-validate = "Username is required">
                        <asp:TextBox ID="txtUserName" CssClass="input100 form-username form-control" Placeholder="User Name" name="form-username" runat="server" ></asp:TextBox>
                        <%--<input id="e-mail" class="input100" type="text" name="username" placeholder="Username"value="" autofocus autocomplete="off" required name="username"/>--%>
						<span class="focus-input100"></span>
					</div>
					
					
					
					<div class="wrap-input100 validate-input m-b-16" data-validate = "Password is required">
                        <asp:TextBox ID="txtPassword" CssClass=" input100 form-password form-control" placeholder="Password" TextMode="Password" runat="server"></asp:TextBox>
						<%--<input id="pass" class="input100" type="password"  placeholder="Password" required name="txtpassword" />--%>
						<span class="focus-input100"></span>
					</div>
					
		

					<div class="container-login100-form-btn m-t-17">
                        <asp:Button ID="btnSubmit" runat="server" CssClass="login100-form-btn" Text="Sign In"  OnClick="btnSubmit_Click" />
					<%--<input class="login100-form-btn" type="submit" name="login" value="Sign In"  />--%>
					<!-- <button class="login100-form-btn" onclick="signin()">
							Login
						</button>
						 -->
					</div>
					<div class="panel-body"style="width:100%; text-align:center">
					
					</div>
					</form>
	
				</div>
			</div>
		</div>
	


    <%--<form id="form1" runat="server">
    <div>
    
    </div>
    </form>--%>

    <!--===============================================================================================-->
	<script src="vendor/jquery/jquery-3.2.1.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/animsition/js/animsition.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/bootstrap/js/popper.js"></script>
	<script src="vendor/bootstrap/js/bootstrap.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/select2/select2.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/daterangepicker/moment.min.js"></script>
	<script src="vendor/daterangepicker/daterangepicker.js"></script>
<!--===============================================================================================-->
	<script src="vendor/countdowntime/countdowntime.js"></script>
<!--===============================================================================================-->
	<script src="js/main.js"></script>

</body>
</html>

