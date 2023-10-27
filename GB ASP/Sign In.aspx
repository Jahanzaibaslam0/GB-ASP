<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sign In.aspx.cs" Inherits="GB_ASP.Sign_In" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>GhaziBrothers Login &amp; Register Templates</title>
    <!-- CSS -->
    <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Roboto:400,100,300,500">
    <link rel="stylesheet" href="assets/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" href="assets/font-awesome/css/font-awesome.min.css">
    <link rel="stylesheet" href="assets/css/form-elements.css">
    <link rel="stylesheet" href="assets/css/style.css">
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <!-- Favicon and touch icons -->
    <link rel="shortcut icon" href="assets/ico/favicon.png">
    <link rel="apple-touch-icon-precomposed" sizes="144x144" href="assets/ico/apple-touch-icon-144-precomposed.png">
    <link rel="apple-touch-icon-precomposed" sizes="114x114" href="assets/ico/apple-touch-icon-114-precomposed.png">
    <link rel="apple-touch-icon-precomposed" sizes="72x72" href="assets/ico/apple-touch-icon-72-precomposed.png">
    <link rel="apple-touch-icon-precomposed" href="assets/ico/apple-touch-icon-57-precomposed.png">
    <style type="text/css">
        .auto-style1 {
            margin-bottom: 15px;
            text-align: left;
        }
    </style>
</head>
<body>
    <div class="text-left">
    <form id="form1" runat="server"> 
    <!-- Top content -->
    <div class="top-content">

        <div class="inner-bg">
            <div class="container">

                <div class="row">
                    <div class="col-sm-8 col-sm-offset-2 text">
                        <h1><strong>GhaziBrothers</strong> Login &amp; Register Forms</h1>
                        <div class="description">
                            <%--<p>
                                This is a free responsive <strong>"login and register forms"</strong> template made with Bootstrap.
                                Download it on <a href="http://azmind.com" target="_blank"><strong>AZMIND</strong></a>,
                                customize and use it as you like!
                            </p>--%>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-3">

                    </div>
                    <div class="col-md-6">

                        <div class="form-box">
                            <div class="form-top">
                                <div class="form-top-left">
                                    <h3 class="text-left">Login to our site</h3>
                                    <p class="text-left">Enter username and password to log on:</p>
                                </div>
                                <div class="form-top-right">
                                    <i class="fa fa-key"></i>
                                </div>
                            </div>
                            <div class="form-bottom">
                                <form role="form" action="" method="post" class="login-form">
                                    <div class="auto-style1">
                                        <div class="text-right">
                                        <%-- <label class="sr-only" for="form-username">Username</label>--%>
                                        <asp:Label ID="lblUserName" CssClass="sr-only" runat="server"></asp:Label>
                                        </div>
                                        <asp:TextBox ID="txtUserName" CssClass="form-username form-control" Placeholder="User Name" name="form-username" runat="server"></asp:TextBox>
                                        <%--<input type="text" name="form-username" placeholder="Username..." class="form-username form-control" id="form-username">--%>
                                    </div>
                                    <div class="auto-style1">
                                        <asp:Label ID="lblPassword" CssClass="sr-only" runat="server" Text="UserName"></asp:Label>
                                        <asp:TextBox ID="txtPassword" CssClass="form-password form-control" placeholder="Password" TextMode="Password" runat="server"></asp:TextBox>
                                        <%--<label class="sr-only" for="form-password">Password</label>
                                        <input type="password" name="form-password" placeholder="Password..." class="form-password form-control" id="form-password">--%>
                                    </div>
                                    <div class="text-left">
                                    <asp:Button ID="btnSubmit" runat="server" CssClass="table table-bordered" Text="Sign In" OnClick="btnSubmit_Click" />
                                    <%--<button type="submit" class="btn">Sign in!</button>--%>
                                    </div>
                                </form>
                            </div>
                        </div>

                        <div class="social-login">
                            <h3>...or login with:</h3>
                            <div class="social-login-buttons">
                                <a class="btn btn-link-1 btn-link-1-facebook" href="#">
                                    <i class="fa fa-facebook"></i>Facebook
                                </a>
                                <a class="btn btn-link-1 btn-link-1-twitter" href="#">
                                    <i class="fa fa-twitter"></i>Twitter
                                </a>
                                <a class="btn btn-link-1 btn-link-1-google-plus" href="#">
                                    <i class="fa fa-google-plus"></i>Google Plus
                                </a>
                            </div>
                        </div>

                    </div>

                    <div class="col-md-3">

                    </div>
                    <%--                    <div class="col-sm-1 middle-border"></div>
                    <div class="col-sm-1"></div>

                    <div class="col-sm-5">

                        <div class="form-box">
                            <div class="form-top">
                                <div class="form-top-left">
                                    <h3>Sign up now</h3>
                                    <p>Fill in the form below to get instant access:</p>
                                </div>
                                <div class="form-top-right">
                                    <i class="fa fa-pencil"></i>
                                </div>
                            </div>
                            <div class="form-bottom">
                                <form role="form" action="" method="post" class="registration-form">
                                    <div class="form-group">
                                        <label class="sr-only" for="form-first-name">First name</label>
                                        <input type="text" name="form-first-name" placeholder="First name..." class="form-first-name form-control" id="form-first-name">
                                    </div>
                                    <div class="form-group">
                                        <label class="sr-only" for="form-last-name">Last name</label>
                                        <input type="text" name="form-last-name" placeholder="Last name..." class="form-last-name form-control" id="form-last-name">
                                    </div>
                                    <div class="form-group">
                                        <label class="sr-only" for="form-email">Email</label>
                                        <input type="text" name="form-email" placeholder="Email..." class="form-email form-control" id="form-email">
                                    </div>
                                    <div class="form-group">
                                        <label class="sr-only" for="form-about-yourself">About yourself</label>
                                        <textarea name="form-about-yourself" placeholder="About yourself..."
                                                  class="form-about-yourself form-control" id="form-about-yourself"></textarea>
                                    </div>
                                    <button type="submit" class="btn">Sign me up!</button>
                                </form>
                            </div>
                        </div>

                    </div>--%>
                </div>

            </div>
        </div>

    </div>
    <!-- Footer -->
    <footer>
        <div class="container">
            <div class="row">

                <div class="col-sm-8 col-sm-offset-2">
                    <div class="footer-border"></div>
                    <p>
                        Made by Ghazi Team at <a href="http://ghazibrothers.com" target="_blank"><strong>GhaziBrothers</strong></a>
                        having a lot of fun. <i class="fa fa-smile-o"></i>
                    </p>
                </div>

            </div>
        </div>
    </footer>
    <!-- Javascript -->
    <script src="assets/js/jquery-1.11.1.min.js"></script>
    <script src="assets/bootstrap/js/bootstrap.min.js"></script>
    <script src="assets/js/jquery.backstretch.min.js"></script>
    <script src="assets/js/scripts.js"></script>

    <!--[if lt IE 10]>
        <script src="assets/js/placeholder.js"></script>
    <![endif]-->
        </form>
    </div>
</body>
</html>

