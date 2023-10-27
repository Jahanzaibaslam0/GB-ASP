<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="GB_ASP.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .table table tbody tr td a,
        .table table tbody tr td span
        {
            position:relative;
            float:left;
            padding:6px 12px;
            margin-left:-1px;
            line-height:1.42857143;
            color:#337ab7;
            text-decoration:none;
            background-color:#fff;
            border:1px solid #ddd;
        }
        .table table > tbody > tr > td > span 
        {
            z-index:3;
            color:#fff;
            cursor:default;
            background-color:#337ab7;
            border-color:#337ab7;
        }

        .table table > tbody > tr > td:first-child > a,
        .table table > tbody > tr > td:first-child > span
         
        {
            margin-left:0;
            border-top-left-radius:4px;
            border-bottom-left-radius:4px;
        }

        .table table > tbody > tr > td:last-child > a,
        .table table > tbody > tr > td:last-child > span
         
        {
            
            border-top-right-radius:4px;
            border-bottom-right-radius:4px;
        }

        .table table > tbody > tr > td > a:hover,
        .table table > tbody > tr > td > span:hover,
        .table table > tbody > tr > td > a:focus,
        .table table > tbody > tr > td > span:focus
        {
            z-index:2;
            color:#23527c;
            background-color:#eee;
            border-color:#ddd;

        }


    </style>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <meta name="viewport" content="width=device-width,initial-scale=1.0,maximum-scale=1.0,user-scalable=no" />
    <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="vendor/bootstrap/css/bootstrap-responsive.min.css" rel="stylesheet" />
    <link href="vendor/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <link href="dist/css/sb-admin-2.css" rel="stylesheet" />
    <script src="jquery/jquery.min.js" type="text/javascript"></script>
    <script src="vendor/bootstrap/css/bootstrap.min.js" type="text/javascript"></script>
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
                 
                        <li onclick="Logout_Click()" ><a href="LogOut.aspx" class="btn btn-default btn-flat">Sign out</a>
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
                                    
                                    <li>
                                        <a  href="pages/Employee.html">Employee</a>
                                    </li>
                                    
                                </ul>
                                <!-- /.nav-second-level -->
                            </li>
                        <li >
                                <a href="#"><i class="fa fa-files-o fa-fw"></i> Sales Report<span class="fa arrow"></span></a>
                                <ul class="nav nav-second-level">
                                    
                                    <li>
                                        <a  href="Webform1.aspx">Net Sales Report</a>
                                    </li>
                                    <li>
                                            <a  href="Webform2.aspx">Division Wise Sales</a>
                                        </li>
                                    <li>
                                        <a  href="pages/locations.html">Region Wise Sales</a>
                                    </li>
                                    
                                    <li>
                                        <a  href="pages/Designation.html">Location Wise Sales</a>
                                    </li>
                                    <li>
                                        <a  href="pages/Category.html">Team Wise Sales</a>
                                    </li>
                                    
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

  <div id="page-wrapper">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-12">
                        <h1> NET SALES REPORT</h1>
    <form id="form1" runat="server">
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <div class="table-responsive"> 
        
        <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered table-hover" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" width="100%" DataSourceID="ObjectDataSource1" PageSize="10" OnPageIndexChanging="GridView1_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="Productcode" HeaderText="Product Code" SortExpression="Productcode" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="ProductName" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="CustGroup" HeaderText="Cust Group" SortExpression="CustGroup" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="DataareaID" HeaderText="Company" SortExpression="DataareaID" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Qty" HeaderText="Quantity" SortExpression="Qty" DataFormatString="{0:f2}" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Itemid" HeaderText="Item ID" SortExpression="Itemid" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="ItemName" HeaderText="Item Name" SortExpression="ItemName" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="SalesPrice" HeaderText="Sales Price" SortExpression="SalesPrice" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="SalesUnit" HeaderText="Sales Unit" SortExpression="SalesUnit" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Division" HeaderText="Division" SortExpression="Division" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Region" HeaderText="Region" SortExpression="Region" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
        <br />
        <br />
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="SalesReport" 
            TypeName="NetSalesReport"
            MaximumRowsParameterName="maximumRows"
            StartRowIndexParameterName="startRowIndex"
            SelectCountMethod="GetTotalCount"
            EnablePaging="true" >
            
            
        </asp:ObjectDataSource>
    </div>
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
