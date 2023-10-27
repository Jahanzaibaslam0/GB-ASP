<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="GB_ASP.Customer" %>

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
                                        <a  href="Customer.aspx">Customer</a>
                                    </li>
                                    <li>
                                            <a  href="Complaint Form.aspx">Complaint</a>
                                        </li>
                                    <li>
                                        <a  href="ComplaintReport.aspx">Complaint Record</a>
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
                        <h1 class="page-header">Customer</h1>
                        <form id="form1" runat="server">
    <div>

<%--        <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>

      <asp:ImageButton ID="ImageButton1" runat="server" 
            onclick="ImageButton1_Click" />
               --%> 
    <div id="complaint" float =center >
        <table class="style1" >
            <%--<tr>
                <td class="style2">
                    <asp:Label ID="lblPhoneno" runat="server" Text="Phone no"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPHno" runat="server" Height="32px" 
                        ontextchanged="TextBox1_TextChanged" Width="331px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor ="red" runat="server" ErrorMessage="Please Enter Valid Phone no: " ControlToValidate="txtPHno"></asp:RequiredFieldValidator>
                    <asp:Label ID="lblRPhone" runat="server"></asp:Label>
                    <asp:CompareValidator ID="CompareValidatorPh" runat="server" ErrorMessage="Please Enter Valid No: " ControlToValidate="txtPHno" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                </td>
            </tr>
            --%><tr>
                <td class="style2">
                    <asp:Label ID="lblCustID" runat="server" Text="Customer ID"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCustID" runat="server" Height="32px" ></asp:TextBox>
                       <%--  ontextchanged="TextBox1_TextChanged" Width="331px"></asp:TextBox>--%>
                    <asp:Label ID="lblrCustID" runat="server"></asp:Label>
                    <%--<asp:CompareValidator ID="CompareValidatoral" runat="server" ErrorMessage="Please Enter Valid No: " ControlToValidate="txtAtno" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>--%>
<%--                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor ="red" runat="server" ErrorMessage="Please Enter Valid Phone no: " ControlToValidate="txtAtno"></asp:RequiredFieldValidator>--%>
                    </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="lblCustName" runat="server" Text="Customer Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCustName" runat="server" Height="33px" Width="330px"></asp:TextBox>
                    <asp:Label ID="lblrCustName" runat="server"></asp:Label>
                   <%-- <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="Please Enter Valid Description" ControlToValidate="txtCustName" operator ="DataTypeCheck" Type="String"> </asp:CompareValidator>
              --%>  </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="lblContactPerson" runat="server" Text="Contact"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPerson" runat="server" Height="32px" 
                         Width="331px"></asp:TextBox>
                    <asp:Label ID="lblrPerson" runat="server" Text="txtPerson" ></asp:Label>
                   <%-- <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Please Enter Valid Description" ControlToValidate="txtPerson" operator ="DataTypeCheck" Type="String"> </asp:CompareValidator>
           --%>     </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="lblAddress" runat="server" Text="Customer Address"></asp:Label>
                
                </td>
                
                <td>
                    <asp:TextBox ID="txtAddress" runat="server" Height="32px" 
                      Width="331px"></asp:TextBox>
                    <asp:Label ID="lblrAddress" runat="server" ></asp:Label>
                   <%-- <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Please Enter Valid Description" ControlToValidate="txtAddress" operator ="DataTypeCheck" Type="String"> </asp:CompareValidator>
           --%>     </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="lblTelephone" runat="server" Text="Telephone"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTelephone" runat="server" Height="32px" 
                        Width="331px"></asp:TextBox>
                    <asp:Label ID="lblrTelephone" runat="server" Text="txtTelephone" ></asp:Label>
                    <%--<asp:CompareValidator ID="CompareValidator4" runat="server" ErrorMessage="Please Enter Valid Description" ControlToValidate="txtTelephone" operator ="DataTypeCheck" Type="String"> </asp:CompareValidator>
               --%> </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="lblRemarks" runat="server" Text="Remarks"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtRemarks" runat="server" Height="32px" 
                        Width="331px"></asp:TextBox>
                    <asp:Label ID="lblrRemarks" runat="server" Text="txtRemarks" ></asp:Label>
                   <%-- <asp:CompareValidator ID="CompareValidator5" runat="server" ErrorMessage="Please Enter Valid Description" ControlToValidate="txtRemarks" operator ="DataTypeCheck" Type="String"> </asp:CompareValidator>
           --%>     </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="lblMobile" runat="server" Text="Mobile"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMobile" runat="server" Height="32px" 
                       Width="331px"></asp:TextBox>
                    <asp:Label ID="lblrMobile" runat="server" Text="txtMobile" ></asp:Label>
                  <%--  <asp:CompareValidator ID="CompareValidator6" runat="server" ErrorMessage="Please Enter Valid Description" ControlToValidate="txtMobile" operator ="DataTypeCheck" Type="String"> </asp:CompareValidator>
              --%>  </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" Height="32px" 
                       Width="331px"></asp:TextBox>
                    <asp:Label ID="lblrEmail" runat="server" Text="txtEmail" ></asp:Label>
                   <%-- <asp:CompareValidator ID="CompareValidator7" runat="server" ErrorMessage="Please Enter Valid Description" ControlToValidate="txtEmail" operator ="DataTypeCheck" Type="String"> </asp:CompareValidator>
          --%>      </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="lblPackage" runat="server" Text="Package"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPackage" runat="server" Height="32px" 
                        Width="331px"></asp:TextBox>
                    <asp:Label ID="lblrPackage" runat="server" Text="txtPackage" ></asp:Label>
                 <%--   <asp:CompareValidator ID="CompareValidator8" runat="server" ErrorMessage="Please Enter Valid Description" ControlToValidate="txtPackage" operator ="DataTypeCheck" Type="String"> </asp:CompareValidator>
             --%>   </td>
            </tr>
            
        </table>
    
       
        <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
    </div>
        </div>
                            <asp:GridView ID="GridView1" runat="server"></asp:GridView>

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
