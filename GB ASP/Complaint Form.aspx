<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Complaint Form.aspx.cs" Inherits="GB_ASP.Complaint_Form" %>


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
                        <h1 class="page-header">Complaint Form</h1>
                       <form id="form1" runat="server">
    <div>

        <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>

        

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
                    <asp:Label ID="lblComplaintID" runat="server" Text="Complaint ID"></asp:Label>
                </td>
                <td>
                  
                    <asp:TextBox ID="txtComplaintID" CssClass="form-control" runat="server"></asp:TextBox>
                    
                    <asp:Label ID="lblrAlter" runat="server"></asp:Label>
                    <%--<asp:CompareValidator ID="CompareValidatoral" runat="server" ErrorMessage="Please Enter Valid No: " ControlToValidate="txtAtno" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>--%><%--                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor ="red" runat="server" ErrorMessage="Please Enter Valid Phone no: " ControlToValidate="txtAtno"></asp:RequiredFieldValidator>--%>
                    </td>
            </tr>
            <%--<tr>
                <td class="style2">
                    <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtcity" runat="server" Height="33px" Width="330px"></asp:TextBox>
                    <asp:Label ID="lblrcity" runat="server"></asp:Label>
                    <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="Please Enter Valid Description" ControlToValidate="txtcity" operator ="DataTypeCheck" Type="String"> </asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDesc" runat="server" Height="32px" 
                        ontextchanged="TextBox1_TextChanged" Width="331px"></asp:TextBox>
                    <asp:Label ID="lblrDesc" runat="server" Text="txtDesc" ></asp:Label>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Please Enter Valid Description" ControlToValidate="txtDesc" operator ="DataTypeCheck" Type="String"> </asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="lblIssue" runat="server" Text="Issue"></asp:Label>
                
                </td>
                
                <td>
                    <asp:TextBox ID="txtIssue" runat="server" Height="32px" 
                        ontextchanged="TextBox1_TextChanged" Width="331px"></asp:TextBox>
                    <asp:Label ID="lblrIssue" runat="server" ></asp:Label>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Please Enter Valid Description" ControlToValidate="txtIssue" operator ="DataTypeCheck" Type="String"> </asp:CompareValidator>
                </td>
            </tr>
            --%><tr>
                <td class="style2">
                    <asp:Label ID="lblCustID" runat="server" Text="Customer ID"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="19px" Width="338px">
                    </asp:DropDownList>
                    <%-- <asp:Label ID="lblrCustID" runat="server" Text="txtCustID" ></asp:Label>--%>         <%--           <asp:CompareValidator ID="CompareValidator4" runat="server" ErrorMessage="Please Enter Valid Description" ControlToValidate="txtCustID" operator ="DataTypeCheck" Type="String"> </asp:CompareValidator>
         --%>       </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="lblCustName" runat="server" Text="Cust Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCustName" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Label ID="Label2" runat="server" Text="txtCustName" ></asp:Label>
                    <%--<asp:CompareValidator ID="CompareValidator5" runat="server" ErrorMessage="Please Enter Valid Description" ControlToValidate="txtCustName" operator ="DataTypeCheck" Type="String"> </asp:CompareValidator>
             --%>   </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="lblComplaintType" runat="server" Text="ComplaintType"></asp:Label>
                </td>
                <td>
                   <asp:TextBox ID="txtComplaintType" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Label ID="Label3" runat="server" Text="txtComplaintType" ></asp:Label>
                    <%--  <asp:CompareValidator ID="CompareValidator6" runat="server" ErrorMessage="Please Enter Valid Description" ControlToValidate="txtComplaintType" operator ="DataTypeCheck" Type="String"> </asp:CompareValidator>
           --%>     </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="lblComplaintDetails" runat="server" Text="ComplaintDetails"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtComplaintDetails" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Label ID="Label4" runat="server" Text="txtComplaintDetails" ></asp:Label>
                    <%--    <asp:CompareValidator ID="CompareValidator7" runat="server" ErrorMessage="Please Enter Valid Description" ControlToValidate="txtComplaintDetails" operator ="DataTypeCheck" Type="String"> </asp:CompareValidator>
               --%> </td>
            </tr>
                 <tr>
                <td class="style2">
                    <asp:Label ID="lblNature" runat="server" Text="Nature"></asp:Label>
                </td>
                <td>
                   <asp:TextBox ID="txtNature" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Label ID="Label20" runat="server" Text="txtNature" ></asp:Label>
                    <%--  <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Please Enter Valid Description" ControlToValidate="txtNature" operator ="DataTypeCheck" Type="String"> </asp:CompareValidator>
               --%> </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="lblEmployee" runat="server" Text="Employee"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmployee" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Label ID="Label5" runat="server" Text="txtEmployee" ></asp:Label>
                    <%--  <asp:CompareValidator ID="CompareValidator8" runat="server" ErrorMessage="Please Enter Valid Description" ControlToValidate="txtEmployee" operator ="DataTypeCheck" Type="String"> </asp:CompareValidator>
              --%>  </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="lblClosedTo" runat="server" Text="ClosedTo"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtClosedTo" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Label ID="Label7" runat="server" Text="txtClosedTo" ></asp:Label>
                    <%--  <asp:CompareValidator ID="CompareValidator9" runat="server" ErrorMessage="Please Enter Valid Description" ControlToValidate="txtClosedTo" operator ="DataTypeCheck" Type="String"> </asp:CompareValidator>
             --%>   </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="lblClosedDetails" runat="server" Text="ClosedDetails"></asp:Label>
                </td>
                <td>
                   <asp:TextBox ID="txtClosedDetails" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Label ID="Label9" runat="server" Text="txtClosedTo" ></asp:Label>
                    <%--  <asp:CompareValidator ID="CompareValidator10" runat="server" ErrorMessage="Please Enter Valid Description" ControlToValidate="txtClosedDetails" operator ="DataTypeCheck" Type="String"> </asp:CompareValidator>
              --%>  </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="lblClosedRemarks" runat="server" Text="ClosedRemarks"></asp:Label>
                </td>
                <td>
                  <asp:TextBox ID="txtClosedRemarks" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Label ID="Label6" runat="server" Text="txtClosedRemarks" ></asp:Label>
                    <%--     <asp:CompareValidator ID="CompareValidator11" runat="server" ErrorMessage="Please Enter Valid Description" ControlToValidate="txtClosedRemarks" operator ="DataTypeCheck" Type="String"> </asp:CompareValidator>
               --%> </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="lblComplaintDate" runat="server" Text="ComplaintDate"></asp:Label>
                </td>
                <td>
                    <%--<asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" Width="220px" OnSelectionChanged="Calendar1_SelectionChanged">
                        <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                        <OtherMonthDayStyle ForeColor="#CC9966" />
                        <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                        <SelectorStyle BackColor="#FFCC66" />
                        <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                        <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                    </asp:Calendar>--%>
                    <asp:TextBox ID="txtComplaintDate" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Label ID="Label10" runat="server" Text="txtComplaintDate" ></asp:Label>
                    <%--     <asp:CompareValidator ID="CompareValidator12" runat="server" ErrorMessage="Please Enter Valid Description" ControlToValidate="txtComplaintDate" operator ="DataTypeCheck" Type="String"> </asp:CompareValidator>
              --%>  </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="lblONTReplace" runat="server" Text="ONT Replace"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtONTReplace" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Label ID="Label12" runat="server" Text="txtONTReplace" ></asp:Label>
                    <%-- <asp:CompareValidator ID="CompareValidator13" runat="server" ErrorMessage="Please Enter Valid Description" ControlToValidate="txtONTReplace" operator ="DataTypeCheck" Type="String"> </asp:CompareValidator>
             --%>   </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="lblONTOLDSerialNumber" runat="server" Text="ONT OLD Serial Number"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtONTOLDSerialNumber" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Label ID="Label14" runat="server" Text="txtONTOldSerialNo" ></asp:Label>
                    <%--  <asp:CompareValidator ID="CompareValidator14" runat="server" ErrorMessage="Please Enter Valid Description" ControlToValidate="txtONTOldSerialNo" operator ="DataTypeCheck" Type="String"> </asp:CompareValidator>
              --%>  </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="lblONTNewSerialNumber" runat="server" Text="ONT NEW Serial Number"></asp:Label>
                </td>
                <td>
                <asp:TextBox ID="txtONTNewSerialNo" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Label ID="Label16" runat="server" Text="txtONTNewSerialNumber" ></asp:Label>
                    <%-- <asp:CompareValidator ID="CompareValidator15" runat="server" ErrorMessage="Please Enter Valid Description" ControlToValidate="txtONTNewSerialNumber" operator ="DataTypeCheck" Type="String"> </asp:CompareValidator>
              --%>  </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="lblDTPReplace" runat="server" Text="DTP Replace"></asp:Label>
                </td>
                <td>
                 <asp:TextBox ID="txtDTPReplace" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Label ID="Label18" runat="server" Text="txtDTPReplace" ></asp:Label>
                    <%--  <asp:CompareValidator ID="CompareValidator16" runat="server" ErrorMessage="Please Enter Valid Description" ControlToValidate="txtDTPReplace" operator ="DataTypeCheck" Type="String"> </asp:CompareValidator>
            --%>    </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="lblDTPOLDSerialNumber" runat="server" Text="DTP OLD Serial Number"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDTPOLDSerialNumber" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Label ID="Label8" runat="server" Text="txtDTPOldSerialNo" ></asp:Label>
                    <%-- <asp:CompareValidator ID="CompareValidator17" runat="server" ErrorMessage="Please Enter Valid Description" ControlToValidate="txtDTPOLDSerialNumber" operator ="DataTypeCheck" Type="String"> </asp:CompareValidator>
             --%>   </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="lblDTPNewSerialNumber" runat="server" Text="DTP NEW Serial Number"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDTPNEwSerialNumber" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Label ID="Label13" runat="server" Text="txtDTPNEwSerialNumber" ></asp:Label>
                    <%--<asp:CompareValidator ID="CompareValidator18" runat="server" ErrorMessage="Please Enter Valid Description" ControlToValidate="txtDTPNEwSerialNumber" operator ="DataTypeCheck" Type="String"> </asp:CompareValidator>
              --%>  </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="lblRemoteReplace" runat="server" Text="RemoteReplace"></asp:Label>
                </td>
                <td>
                   <asp:TextBox ID="txtRemoteReplace" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Label ID="Label11" runat="server" Text="txtRemoteReplace" ></asp:Label>
                    <%-- <asp:CompareValidator ID="CompareValidator19" runat="server" ErrorMessage="Please Enter Valid Description" ControlToValidate="txtRemoteReplace" operator ="DataTypeCheck" Type="String"> </asp:CompareValidator>
             --%>   </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="lblPowerAdoptor" runat="server" Text="Power Adoptor"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPowerAdoptor" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Label ID="Label15" runat="server" Text="txtPowerAdoptor" ></asp:Label>
                    <%-- <asp:CompareValidator ID="CompareValidator20" runat="server" ErrorMessage="Please Enter Valid Description" ControlToValidate="txtPowerAdoptor" operator ="DataTypeCheck" Type="String"> </asp:CompareValidator>
             --%>   </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="lblPowerAdoptorONT" runat="server" Text="Power Adoptor ONT"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPowerAdoptorONT" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Label ID="Label17" runat="server" Text="txtPowerAdoptorONT" ></asp:Label>
                    <%--<asp:CompareValidator ID="CompareValidator21" runat="server" ErrorMessage="Please Enter Valid Description" ControlToValidate="txtPowerAdoptorONT" operator ="DataTypeCheck" Type="String"> </asp:CompareValidator>
             --%>   </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="lblPowerAdoptorDTU" runat="server" Text="Power Adoptor DTU"></asp:Label>
                </td>
                <td>
                  <asp:TextBox ID="txtPowerAdoptorDTU" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Label ID="Label19" runat="server" Text="txtPowerAdoptorDTU" ></asp:Label>

                   <%-- <asp:CompareValidator ID="CompareValidator22" runat="server" ErrorMessage="Please Enter Valid Description" ControlToValidate="txtPowerAdoptorDTU" operator ="DataTypeCheck" Type="String"> </asp:CompareValidator>
             --%>   </td>
            </tr>
        </table>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    
   
    </div>


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