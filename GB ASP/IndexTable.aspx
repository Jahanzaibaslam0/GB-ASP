<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexTable.aspx.cs" Inherits="GB_ASP.IndexTable" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="vendor/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <link href="dist/css/sb-admin-2.css" rel="stylesheet" />
<link href="vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />

</head>
<body>


 <div id="wrapper" >

        <!-- Navigation -->
        <nav class="navbar navbar-default navbar-static-top" role="navigation" style="margin-bottom: 0">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="index.html"> <img style="width:70px; margin-bottom: 10px" src="images/gb.png" alt="Logo" ></a>
            </div>
            <!-- /.navbar-header -->

            <ul class="nav navbar-top-links navbar-right">
                
                <!-- /.dropdown -->
               
                <!-- /.dropdown -->
             
                <!-- /.dropdown -->
                <li class="dropdown">
                    <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                        <i class="fa fa-user fa-fw"></i> <i class="fa fa-caret-down"></i>
                    </a>
                    <ul class="dropdown-menu dropdown-user">
                        <li><a href="#"><i class="fa fa-user fa-fw"></i> User Profile</a>
                        </li>
                        <li><a href="#"><i class="fa fa-gear fa-fw"></i> Settings</a>
                        </li>
                        <li class="divider"></li>
                        <li onclick="logout()" ><a href="#" ><i class="fa fa-sign-out fa-fw"></i>  Logout</a>
                        </li>
                    </ul>
                    <!-- /.dropdown-user -->
                </li>
                <!-- /.dropdown -->
            </ul>
            <!-- /.navbar-top-links -->

            <div class="navbar-default sidebar" role="navigation">
                <div class="sidebar-nav navbar-collapse">
                    <ul class="nav" id="side-menu">
                        <li class="sidebar-search">
                            <div class="input-group custom-search-form">
                                <input type="text" class="form-control" placeholder="Search...">
                                <span class="input-group-btn">
                                    <button class="btn btn-default" type="button">
                                        <i class="fa fa-search"></i>
                                    </button>
                                </span>
                            </div>
                            <!-- /input-group -->
                        </li>
                        <li class="active">
                            <a href="index.html"><i class="fa fa-dashboard fa-fw"></i> Dashboard</a>
                        </li>
                        
                       
                        
                        <li >
                                <a href="#"><i class="fa fa-files-o fa-fw"></i> Admin<span class="fa arrow"></span></a>
                                <ul class="nav nav-second-level">
                                    
                                    <li>
                                        <a  href="pages/Company.html">Company</a>
                                    </li>
                                    <li>
                                            <a  href="pages/Division.html">Division</a>
                                        </li>
                                    <li>
                                        <a  href="pages/locations.html">Locations</a>
                                    </li>
                                    
                                    <li>
                                        <a  href="pages/Designation.html">Designation</a>
                                    </li>
                                    <li>
                                        <a  href="pages/Category.html">Category</a>
                                    </li>
                                    <hr />
                                    <li>
                                        <a  href="pages/Employee.html">Employee</a>
                                    </li>
                                    
                                </ul>
                                <!-- /.nav-second-level -->
                            </li>
                    </ul>
                </div>
                <!-- /.sidebar-collapse -->
            </div>
            <!-- /.navbar-static-side -->
        </nav>

        <!-- Page Content -->
        <div id="page-wrapper">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">Index</h1>
                        <form id="form1" runat="server">
                        <asp:TextBox ID="txtItemID" CssClass="form-control" placeholder="Item ID" runat="server"></asp:TextBox>
                            <asp:TextBox ID="txtQty" CssClass="form-control" placeholder="Quantity" runat="server"></asp:TextBox> <br />

                   <%--         <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" DataSourceID="SqlDataSource1" DataTextField="ITEMID" DataValueField="ITEMID"></asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GBAX12ConnectionString %>" SelectCommand="SELECT [ITEMID] FROM [INVENTTABLE]"></asp:SqlDataSource>
                    --%>    <%--                        <div class="row">
                        <div class="col-lg-6">
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        Category List
                                    </div>
                                    <!-- /.panel-heading -->
                                    <div class="panel-body">
                                        <div class="table-responsive">
                                            <table class="table table-striped table-bordered table-hover" id="loctable">
                                                <thead>
                                                    <tr >
                                                        <th style="text-align:center"  >#</th>
                                                        <th style="text-align:center">Category Name</th>
                                                        <th style="text-align:center" colspan="2" >Action</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr id="trow">
                                                    <td id="tid"></td>
                                                    <td id="locname"></td>
                                                    <td id="Edit" ></td>
                                                    <td id="Delete"></td>
                                                    </tr>
                                                           </tbody>
                                                
                                            </table>
                                        </div>
                                        <!-- /.table-responsive -->
                                    </div>
                                    <!-- /.panel-body -->
                                </div>
                                <!-- /.panel -->
                            </div>
                </div>--%>
                         
    <asp:PlaceHolder  ID = "PlaceHolder1" runat="server" />  
    

<%--                            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click1" />--%>
                            </form>
                    </div>
                    <!-- /.col-lg-12 -->
                </div>
                <!-- /.row -->
            </div>
            <!-- /.container-fluid -->
        </div>
        <!-- /#page-wrapper -->

    </div>


        <script src="vendor/jquery/jquery.min.js"></script>
        <script src="vendor/bootstrap/js/bootstrap.min.js"></script>
    <script src="vendor/metisMenu/metisMenu.min.js"></script>
    <script src="dist/js/sb-admin-2.js"></script>


</body>
</html>
