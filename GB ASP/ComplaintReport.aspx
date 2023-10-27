<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComplaintReport.aspx.cs" Inherits="GB_ASP.ComplaintReport" %>

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
                        <h1 class="page-header">Index</h1>
                        <form id="form1" runat="server">
                        <asp:TextBox ID="txtItemID" CssClass="form-control" placeholder="Item ID" runat="server"></asp:TextBox>
                        <asp:TextBox ID="txtQty" CssClass="form-control" placeholder="Quantity" runat="server"></asp:TextBox> <br />
<%--                        <div class="row">
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
                             <div class="table-responsive">                            
                                 <asp:GridView ID="GridView1" runat="server" CssClass="table-responsive" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ComplaintID" DataSourceID="SqlDataSource1">
                                     <Columns>
                                         <asp:TemplateField HeaderText="Operation" ShowHeader="False">
                                             <EditItemTemplate>
                                                 <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                                                 &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                             </EditItemTemplate>
                                             <ItemTemplate>
                                                 <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                                                 &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Select" Text="Select"></asp:LinkButton>
                                                 &nbsp;<asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                             </ItemTemplate>
                                             <ItemStyle HorizontalAlign="Center" />
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Complaint ID" InsertVisible="False" SortExpression="ComplaintID">
                                             <EditItemTemplate>
                                                 <asp:Label ID="Label1" runat="server" Text='<%# Eval("ComplaintID") %>'></asp:Label>
                                             </EditItemTemplate>
                                             <ItemTemplate>
                                                 <asp:Label ID="Label1" runat="server" Text='<%# Bind("ComplaintID") %>'></asp:Label>
                                             </ItemTemplate>
                                             <ItemStyle HorizontalAlign="Center" />
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Customer ID" SortExpression="CustID">
                                             <EditItemTemplate>
                                                 <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CustID") %>'></asp:TextBox>
                                             </EditItemTemplate>
                                             <ItemTemplate>
                                                 <asp:Label ID="Label2" runat="server" Text='<%# Bind("CustID") %>'></asp:Label>
                                             </ItemTemplate>
                                             <ItemStyle HorizontalAlign="Center" />
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Complaint Type" SortExpression="Complaint Type">
                                             <EditItemTemplate>
                                                 <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("[Complaint Type]") %>'></asp:TextBox>
                                             </EditItemTemplate>
                                             <ItemTemplate>
                                                 <asp:Label ID="Label3" runat="server" Text='<%# Bind("[Complaint Type]") %>'></asp:Label>
                                             </ItemTemplate>
                                             <ItemStyle HorizontalAlign="Center" />
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Complaint Details" SortExpression="Complaint Details">
                                             <EditItemTemplate>
                                                 <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("[Complaint Details]") %>'></asp:TextBox>
                                             </EditItemTemplate>
                                             <ItemTemplate>
                                                 <asp:Label ID="Label4" runat="server" Text='<%# Bind("[Complaint Details]") %>'></asp:Label>
                                             </ItemTemplate>
                                             <ItemStyle HorizontalAlign="Center" />
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Assigned To" SortExpression="Assigned To">
                                             <EditItemTemplate>
                                                 <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("[Assigned To]") %>'></asp:TextBox>
                                             </EditItemTemplate>
                                             <ItemTemplate>
                                                 <asp:Label ID="Label5" runat="server" Text='<%# Bind("[Assigned To]") %>'></asp:Label>
                                             </ItemTemplate>
                                             <ItemStyle HorizontalAlign="Center" />
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Closed To" SortExpression="Closed To">
                                             <EditItemTemplate>
                                                 <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("[Closed To]") %>'></asp:TextBox>
                                             </EditItemTemplate>
                                             <ItemTemplate>
                                                 <asp:Label ID="Label6" runat="server" Text='<%# Bind("[Closed To]") %>'></asp:Label>
                                             </ItemTemplate>
                                             <ItemStyle HorizontalAlign="Center" />
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Closed Detail" SortExpression="Closed Detail">
                                             <EditItemTemplate>
                                                 <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("[Closed Detail]") %>'></asp:TextBox>
                                             </EditItemTemplate>
                                             <ItemTemplate>
                                                 <asp:Label ID="Label7" runat="server" Text='<%# Bind("[Closed Detail]") %>'></asp:Label>
                                             </ItemTemplate>
                                             <ItemStyle HorizontalAlign="Center" />
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Closed Remarks" SortExpression="Closed Remarks">
                                             <EditItemTemplate>
                                                 <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("[Closed Remarks]") %>'></asp:TextBox>
                                             </EditItemTemplate>
                                             <ItemTemplate>
                                                 <asp:Label ID="Label8" runat="server" Text='<%# Bind("[Closed Remarks]") %>'></asp:Label>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="ComplaintDate" SortExpression="ComplaintDate">
                                             <EditItemTemplate>
                                                 <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("ComplaintDate") %>'></asp:TextBox>
                                             </EditItemTemplate>
                                             <ItemTemplate>
                                                 <asp:Label ID="Label9" runat="server" Text='<%# Bind("ComplaintDate") %>'></asp:Label>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="ONT Replace" SortExpression="ONT Replace">
                                             <EditItemTemplate>
                                                 <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("[ONT Replace]") %>'></asp:TextBox>
                                             </EditItemTemplate>
                                             <ItemTemplate>
                                                 <asp:Label ID="Label10" runat="server" Text='<%# Bind("[ONT Replace]") %>'></asp:Label>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="ONT OLD Serial Number" SortExpression="ONT  OLD Serial No">
                                             <EditItemTemplate>
                                                 <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("[ONT  OLD Serial No]") %>'></asp:TextBox>
                                             </EditItemTemplate>
                                             <ItemTemplate>
                                                 <asp:Label ID="Label11" runat="server" Text='<%# Bind("[ONT  OLD Serial No]") %>'></asp:Label>
                                             </ItemTemplate>
                                             <ItemStyle HorizontalAlign="Center" />
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="ONT NEW Serial Number" SortExpression="ONT NEW Serial No">
                                             <EditItemTemplate>
                                                 <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("[ONT NEW Serial No]") %>'></asp:TextBox>
                                             </EditItemTemplate>
                                             <ItemTemplate>
                                                 <asp:Label ID="Label12" runat="server" Text='<%# Bind("[ONT NEW Serial No]") %>'></asp:Label>
                                             </ItemTemplate>
                                             <ItemStyle HorizontalAlign="Center" />
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="DTP Replace" SortExpression="DTP Replace">
                                             <EditItemTemplate>
                                                 <asp:TextBox ID="TextBox12" runat="server" Text='<%# Bind("[DTP Replace]") %>'></asp:TextBox>
                                             </EditItemTemplate>
                                             <ItemTemplate>
                                                 <asp:Label ID="Label13" runat="server" Text='<%# Bind("[DTP Replace]") %>'></asp:Label>
                                             </ItemTemplate>
                                             <ItemStyle HorizontalAlign="Center" />
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="DTP OLD Serial Number" SortExpression="DTP OLD Serial No">
                                             <EditItemTemplate>
                                                 <asp:TextBox ID="TextBox13" runat="server" Text='<%# Bind("[DTP OLD Serial No]") %>'></asp:TextBox>
                                             </EditItemTemplate>
                                             <ItemTemplate>
                                                 <asp:Label ID="Label14" runat="server" Text='<%# Bind("[DTP OLD Serial No]") %>'></asp:Label>
                                             </ItemTemplate>
                                             <ItemStyle HorizontalAlign="Center" />
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="DTP New Serial Number" SortExpression="DTP New Serial No">
                                             <EditItemTemplate>
                                                 <asp:TextBox ID="TextBox14" runat="server" Text='<%# Bind("[DTP New Serial No]") %>'></asp:TextBox>
                                             </EditItemTemplate>
                                             <ItemTemplate>
                                                 <asp:Label ID="Label15" runat="server" Text='<%# Bind("[DTP New Serial No]") %>'></asp:Label>
                                             </ItemTemplate>
                                             <ItemStyle HorizontalAlign="Center" />
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Remote Replace" SortExpression="Remote Replace">
                                             <EditItemTemplate>
                                                 <asp:TextBox ID="TextBox15" runat="server" Text='<%# Bind("[Remote Replace]") %>'></asp:TextBox>
                                             </EditItemTemplate>
                                             <ItemTemplate>
                                                 <asp:Label ID="Label16" runat="server" Text='<%# Bind("[Remote Replace]") %>'></asp:Label>
                                             </ItemTemplate>
                                             <ItemStyle HorizontalAlign="Center" />
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Power Adopter" SortExpression="Power Adopter">
                                             <EditItemTemplate>
                                                 <asp:TextBox ID="TextBox16" runat="server" Text='<%# Bind("[Power Adopter]") %>'></asp:TextBox>
                                             </EditItemTemplate>
                                             <ItemTemplate>
                                                 <asp:Label ID="Label17" runat="server" Text='<%# Bind("[Power Adopter]") %>'></asp:Label>
                                             </ItemTemplate>
                                             <ItemStyle HorizontalAlign="Center" />
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Power Adopter ONT" SortExpression="Power Adopter ONT">
                                             <EditItemTemplate>
                                                 <asp:TextBox ID="TextBox17" runat="server" Text='<%# Bind("[Power Adopter ONT]") %>'></asp:TextBox>
                                             </EditItemTemplate>
                                             <ItemTemplate>
                                                 <asp:Label ID="Label18" runat="server" Text='<%# Bind("[Power Adopter ONT]") %>'></asp:Label>
                                             </ItemTemplate>
                                             <ItemStyle HorizontalAlign="Center" />
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Power Adopter DTU" SortExpression="Power Adopter DTU">
                                             <EditItemTemplate>
                                                 <asp:TextBox ID="TextBox18" runat="server" Text='<%# Bind("[Power Adopter DTU]") %>'></asp:TextBox>
                                             </EditItemTemplate>
                                             <ItemTemplate>
                                                 <asp:Label ID="Label19" runat="server" Text='<%# Bind("[Power Adopter DTU]") %>'></asp:Label>
                                             </ItemTemplate>
                                             <ItemStyle HorizontalAlign="Center" />
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Nature" SortExpression="Nature">
                                             <EditItemTemplate>
                                                 <asp:TextBox ID="TextBox19" runat="server" Text='<%# Bind("Nature") %>'></asp:TextBox>
                                             </EditItemTemplate>
                                             <ItemTemplate>
                                                 <asp:Label ID="Label20" runat="server" Text='<%# Bind("Nature") %>'></asp:Label>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                     </Columns>
                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                <RowStyle ForeColor="#000066"  />
                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#00547E" />
                            </asp:GridView>
                                 </div>

                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ComplaintConnectionString %>" DeleteCommand="DELETE FROM [Complaint] WHERE [ComplaintID] = @ComplaintID" InsertCommand="INSERT INTO [Complaint] ([CustID], [Complaint Type], [Complaint Details], [Assigned To], [Closed To], [Closed Detail], [Closed Remarks], [ComplaintDate], [ONT Replace], [ONT  OLD Serial No], [ONT NEW Serial No], [DTP Replace], [DTP OLD Serial No], [DTP New Serial No], [Remote Replace], [Power Adopter], [Power Adopter ONT], [Power Adopter DTU], [Nature]) VALUES (@CustID, @Complaint_Type, @Complaint_Details, @Assigned_To, @Closed_To, @Closed_Detail, @Closed_Remarks, @ComplaintDate, @ONT_Replace, @ONT_OLD_Serial_No, @ONT_NEW_Serial_No, @DTP_Replace, @DTP_OLD_Serial_No, @DTP_New_Serial_No, @Remote_Replace, @Power_Adopter, @Power_Adopter_ONT, @Power_Adopter_DTU, @Nature)" SelectCommand="SELECT * FROM [Complaint]" UpdateCommand="UPDATE [Complaint] SET [CustID] = @CustID, [Complaint Type] = @Complaint_Type, [Complaint Details] = @Complaint_Details, [Assigned To] = @Assigned_To, [Closed To] = @Closed_To, [Closed Detail] = @Closed_Detail, [Closed Remarks] = @Closed_Remarks, [ComplaintDate] = @ComplaintDate, [ONT Replace] = @ONT_Replace, [ONT  OLD Serial No] = @ONT_OLD_Serial_No, [ONT NEW Serial No] = @ONT_NEW_Serial_No, [DTP Replace] = @DTP_Replace, [DTP OLD Serial No] = @DTP_OLD_Serial_No, [DTP New Serial No] = @DTP_New_Serial_No, [Remote Replace] = @Remote_Replace, [Power Adopter] = @Power_Adopter, [Power Adopter ONT] = @Power_Adopter_ONT, [Power Adopter DTU] = @Power_Adopter_DTU, [Nature] = @Nature WHERE [ComplaintID] = @ComplaintID">
                                <DeleteParameters>
                                    <asp:Parameter Name="ComplaintID" Type="Int32" />
                                </DeleteParameters>
                                <InsertParameters>
                                    <asp:Parameter Name="CustID" Type="Int32" />
                                    <asp:Parameter Name="Complaint_Type" Type="String" />
                                    <asp:Parameter Name="Complaint_Details" Type="String" />
                                    <asp:Parameter Name="Assigned_To" Type="String" />
                                    <asp:Parameter Name="Closed_To" Type="String" />
                                    <asp:Parameter Name="Closed_Detail" Type="String" />
                                    <asp:Parameter Name="Closed_Remarks" Type="String" />
                                    <asp:Parameter Name="ComplaintDate" Type="DateTime" />
                                    <asp:Parameter Name="ONT_Replace" Type="String" />
                                    <asp:Parameter Name="ONT_OLD_Serial_No" Type="String" />
                                    <asp:Parameter Name="ONT_NEW_Serial_No" Type="String" />
                                    <asp:Parameter Name="DTP_Replace" Type="String" />
                                    <asp:Parameter Name="DTP_OLD_Serial_No" Type="String" />
                                    <asp:Parameter Name="DTP_New_Serial_No" Type="String" />
                                    <asp:Parameter Name="Remote_Replace" Type="String" />
                                    <asp:Parameter Name="Power_Adopter" Type="String" />
                                    <asp:Parameter Name="Power_Adopter_ONT" Type="String" />
                                    <asp:Parameter Name="Power_Adopter_DTU" Type="String" />
                                    <asp:Parameter Name="Nature" Type="String" />
                                </InsertParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="CustID" Type="Int32" />
                                    <asp:Parameter Name="Complaint_Type" Type="String" />
                                    <asp:Parameter Name="Complaint_Details" Type="String" />
                                    <asp:Parameter Name="Assigned_To" Type="String" />
                                    <asp:Parameter Name="Closed_To" Type="String" />
                                    <asp:Parameter Name="Closed_Detail" Type="String" />
                                    <asp:Parameter Name="Closed_Remarks" Type="String" />
                                    <asp:Parameter Name="ComplaintDate" Type="DateTime" />
                                    <asp:Parameter Name="ONT_Replace" Type="String" />
                                    <asp:Parameter Name="ONT_OLD_Serial_No" Type="String" />
                                    <asp:Parameter Name="ONT_NEW_Serial_No" Type="String" />
                                    <asp:Parameter Name="DTP_Replace" Type="String" />
                                    <asp:Parameter Name="DTP_OLD_Serial_No" Type="String" />
                                    <asp:Parameter Name="DTP_New_Serial_No" Type="String" />
                                    <asp:Parameter Name="Remote_Replace" Type="String" />
                                    <asp:Parameter Name="Power_Adopter" Type="String" />
                                    <asp:Parameter Name="Power_Adopter_ONT" Type="String" />
                                    <asp:Parameter Name="Power_Adopter_DTU" Type="String" />
                                    <asp:Parameter Name="Nature" Type="String" />
                                    <asp:Parameter Name="ComplaintID" Type="Int32" />
                                </UpdateParameters>
                            </asp:SqlDataSource>
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
