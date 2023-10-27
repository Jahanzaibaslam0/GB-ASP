﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerTest2.aspx.cs" Inherits="GB_ASP.CustomerTest2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ABCD</title>

        <%--<%--<link rel="stylesheet" href="https://netdna.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css">--%>

        <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
        <%--<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/js/bootstrap.min.js"></script>--%>
        <script type="text/javascript" src="vendor/bootstrap/css/bootstrap.min.js"></script>
        <%--<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-multiselect/0.9.15/css/bootstrap-multiselect.css">--%>
        <link href="vendor/bootstrap/css/Bootstrap-multiselect.css" rel="stylesheet" />
        <%--<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-multiselect/0.9.15/js/bootstrap-multiselect.js"></script>--%>--%>
        <script type="text/javascript" src="vendor/bootstrap/css/Bootstrap-multiselect.js"></script>
        
        <script src="https://cdn.datatables.net/1.10.12/js/jquery.dataTables.min.js"></script>  
        <script src="https://cdn.datatables.net/1.10.12/js/dataTables.bootstrap.min.js"></script>            
        <link rel="stylesheet" href="https://cdn.datatables.net/1.10.12/css/dataTables.bootstrap.min.css" />  
    
    
    <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="vendor/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <link href="dist/css/sb-admin-2.css" rel="stylesheet" />
    <link href="vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/Script.js"></script>
    
   <script>
        $(function () {
            $("#example").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>
    

</head>
<body>
    <div class="container">
<div class="example">
       

    

        </div>


</div>

    </html>
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
                <a class="navbar-brand" href="index.html"> <img style="width:70px; margin-bottom: 10px" src="Images/GB-Logo.png" alt="GhaziBrothers" ></a>
            </div>
            <!-- /.navbar-header -->

            <ul class="nav navbar-top-links navbar-right">
                
                <!-- /.dropdown -->
               
                <!-- /.dropdown -->
             
                <!-- /.dropdown -->
                <li class="dropdown">
                    <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                        <i class="fa fa-user fa-fw"></i> <i class="fa fa-caret-down"></i>
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
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
                                <a href="#"><i class="fa fa-files-o fa-fw"></i> ACCOUNT RECEIVABLE <span class="fa arrow"></span></a>
                                <ul class="nav nav-second-level">
                                    <li>
                                    <a href="#"><i class="fa fa-files-o fa-fw"></i> CUSTOMER <span class="fa arrow"></span></a>
                                        <ul class="nav nav-third-level">
                                    
                                    <li>
                                        <a  href="AllCustomer.aspx">ALL CUSTOMER</a>
                                    </li>
                                    <li>
                                        <a  href="AllCustomerOnHold.aspx">ALL CUSTOMER ON HOLD</a>
                                    </li>
                                        </ul>
                                    </li>
                                    <li>
                                    <a href="#"><i class="fa fa-files-o fa-fw"></i> OPEN CUSTOMER INVOICE <span class="fa arrow"></span></a>
                                        <ul class="nav nav-third-level">
                                     <li>
                                        <a  href="OpenCustomerInvoice.aspx">OPEN CUSTOMER INVOICE</a>
                                    </li>
                                    <li>
                                        <a  href="OpenCustomerInvoicePastDueToday.aspx">CUSTOMER INVOICES DUE TODAY</a>
                                    </li>
                                    <li>
                                        <a  href="OpenCustomerPastDueInvoice.aspx">OPEN CUSTOMER INVOICE PAST DUE</a>
                                    </li>
                                    </ul>
                                    </li>        
                                            
                                     <li>
                                    <a href="#"><i class="fa fa-files-o fa-fw"></i> SALES ORDER <span class="fa arrow"></span></a>
                                        <ul class="nav nav-third-level">
                                    <li>
                                        <a  href="ALLSALESORDER.aspx">ALL SALES ORDER</a>
                                    </li>
                                    <li>
                                        <a  href="ShippedButNotInvoicedSalesOrder.aspx">SHIPPED BUT NOT INVOICED SALES ORDER</a>
                                    </li>   
                                    </ul>
                                    </li>       
                                       
                                    <li>   
                                    <a href="#"><i class="fa fa-files-o fa-fw"></i> INQUIRY <span class="fa arrow"></span></a>
                                        <ul class="nav nav-third-level">
                                    <li>
                                        <a  href="COD.aspx">COD</a>
                                    </li>  
                                    </ul>
                                    </li> 
                                    
                                    
                                    <li>   
                                    <a href="#"><i class="fa fa-files-o fa-fw"></i> CUSTOMER AGING <span class="fa arrow"></span></a>
                                        <ul class="nav nav-third-level">
                                    <li>
                                        <a  href="CustomerAgingConsolidated.aspx">CUSTOMER AGING CONSOLIDATED REPORT</a>
                                    </li>
                                    
                                    <li>
                                        <a  href="CustomerAgingReport.aspx">CUSTOMER AGING REPORT</a>
                                    </li>  
                                    </ul>
                                    </li>  
                                      
                                    
                                    <li>   
                                    <a href="#"><i class="fa fa-files-o fa-fw"></i> GHAZI REPORT <span class="fa arrow"></span></a>
                                        <ul class="nav nav-third-level">
                                    
                                    <li>
                                        <a  href="ChequeReceivedReport.aspx">CHEQUE RECEIVED REPORT</a>
                                    </li>
                                   <li>
                                        <a  href="DivisionWiseBalanceReport(PDC).aspx">DIVISION WISE BALANCE REPORT (PDC)</a>
                                    </li>
                                    <li>
                                        <a  href="CustomerTurnOverCustGroup.aspx">CUSTOMER TURNOVER BY CUSTOMER GROUP</a>
                                    </li>
                                    
                                    <li>
                                        <a  href="DetailDueDayList.aspx">DETAIL DUE DAY LIST</a>
                                    </li>
                                    <li>
                                        <a  href="CollectionReportMonthWise.aspx">COLLECTION REPORT MONTH WISE</a>
                                    </li>
                                    <li>
                                        <a  href="CollectionReportRegionWise.aspx">COLLECTION REPORT REGION WISE</a>
                                    </li>
 
                                    </ul>
                                    </li>  
                                    
                                                         
                                    
                                    
                                    
                                    
                                </ul>
                                </li>
                                <!-- /.nav-second-level -->
                            
                        <li >
                                <a href="#"><i class="fa fa-files-o fa-fw"></i> SALES AND MARKETING <span class="fa arrow"></span></a>
                                <ul class="nav nav-second-level">
                                    
                                     
                                    <li>
                                    <a href="#"><i class="fa fa-files-o fa-fw"></i> RETURN ORDER <span class="fa arrow"></span></a>
                                        <ul class="nav nav-third-level">
                                    <li>
                                        <a  href="AllReturnOrder.aspx">ALL RETURN ORDER</a>
                                    </li>
                                    <li>
                                        <a  href="OpenReturnOrder.aspx">OPEN RETURN ORDER</a>
                                    </li>
                                    
                                    <li>
                                        <a  href="CloseReturnOrder.aspx">CLOSE RETURN ORDER</a>
                                    </li>
                                    <li>
                                        <a  href="CancelledReturnOrder.aspx">CANCELLED RETURN ORDER</a>
                                    </li>
                                       
                                        </ul>
                                        </li>
                                    <li>
                                    <a href="#"><i class="fa fa-files-o fa-fw"></i> SALES ORDER <span class="fa arrow"></span></a>
                                        <ul class="nav nav-third-level">
                                    <li>
                                        <a  href="OpenSalesOrder.aspx">OPEN SALES ORDER</a>
                                    </li>
                                    <li>
                                        <a  href="OpenSalesOrderForCustomerOnHold.aspx">OPEN SALES ORDER FOR CUSTOMER ON HOLD</a>
                                    </li>
                                            </ul>
                                        </li>
                                    <li>
                                    <a href="#"><i class="fa fa-files-o fa-fw"></i> GHAZI SALES REPORT <span class="fa arrow"></span></a>
                                        <ul class="nav nav-third-level">
                                    <li>
                                        <a  href="SalesReportItemWise.aspx">NET SALES REPORT</a>
                                    </li>
                                    <li>
                                        <a  href="MonthWiseItemSales.aspx">MONTH WISE ITEM SALES IN QUANTITY</a>
                                    </li>
                                    <li>
                                        <a  href="MonthWiseItemSaleAmount.aspx">MONTH WISE ITEM SALES IN AMOUNT</a>
                                    </li>
                                    <li>
                                        <a  href="SalesReportInvoiceWise.aspx">SALES REPORT INVOICE WISE</a>
                                    </li>
                                    <li>
                                        <a  href="CustomerBalanceList.aspx">CUSTOMER BALANCE LIST</a>
                                    </li>
                                    <li>
                                        <a  href="InternalAccountStatement.aspx">INTERNAL ACCOUNT STATEMENT</a>
                                    </li>
                                    <li>
                                        <a  href="ItemWiseYearlySaleQty.aspx">ITEM WISE YEARLY SALES IN QUANTITY</a>
                                    </li>
                                    <li>
                                        <a  href="ItemWiseYearlySalesAmount.aspx">ITEM WISE YEARLY SALES IN AMOUNT</a>
                                    </li>
                                    <li>
                                        <a  href="CustomerWiseSalesQty.aspx">CUSTOMER WISE SALES QUANTITY</a>
                                    </li>
                                    <li>
                                        <a  href="CustomerWiseSalesAmount.aspx">CUSTOMER WISE SALES AMOUNT</a>
                                    </li>
                                    <li>
                                        <a  href="CustomerWiseYearlySales.aspx">CUSTOMER WISE YEARLY SALES</a>
                                    </li>
                                            
                                            </ul>
                                        </li>
                                    </ul>
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
               <br />
                 <form id="form1" runat="server">
                <div class="row">
                    <div class="col-md-2">
                    <div class="form-group">
                         <input type="text" runat="server" Class="form-control"
                                id="inputCustomerName" placeholder="Customer Name" />
                        </div>
                     </div>
                    <div class="col-md-2">
                  <div class="form-group">
                         <input type="text" runat="server" Class="form-control"
                                id="inputCustomerCode" placeholder="Customer Code" />
                        </div>
                        </div>
                    
                 <%-- <asp:ListBox ID="multiselect12" runat="server" AutoPostBack="true" SelectionMode="Multiple" OnSelectedIndexChanged="ABCD"></asp:ListBox>--%>

                      <div class="col-md-2">
                  <div class="form-group">
                         <input type="text" runat="server" Class="form-control"
                                id="inputCustGroup" placeholder="Customer Group" />
                        </div>
                        </div>

                      <div class="col-md-2">
                  <div class="form-group">
                         <input type="text" runat="server" Class="form-control"
                                id="inputBranch" placeholder="Deal For Branch" />
                        </div>
                        </div>
                      <div class="col-md-2">
                          <div class="form-group">
                         <input type="text" runat="server" Class="form-control"
                                id="Blocked" visible="false" />
                        </div>
                    </div>

                    <div class="col-md-2">
                          <div class="form-group">
                         <input type="text" runat="server" Class="form-control"
                                id="Text1" visible="false" />
                        </div>
                    </div>

                    <div class="col-md-4">
                          <div class="form-group">
                              <asp:ListBox ID="multiselect1" runat="server" AutoPostBack="false" SelectionMode="Multiple" OnSelectedIndexChanged="Country_Selected">        
                              </asp:ListBox>
                          </div>
                    </div>
                              
                    <div class="col-md-4">
                          <div class="form-group">
                            <asp:ListBox ID="multiselect2" runat="server" AutoPostBack="false" SelectionMode="Multiple" OnSelectedIndexChanged="ListBox2_SelectedIndexChanged">        

                              </asp:ListBox>
                              </div>
                    </div>
                    
                              <asp:TextBox ID="TextBox1" runat="server" visible="false"></asp:TextBox>
                         
                  
                              <asp:TextBox ID="TextBox2" runat="server" visible="false"></asp:TextBox>
                       


                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:Button ID="Button1" runat="server" Text="Run"  OnClick="Button1_Click"
                              CssClass="btn btn-primary"   />
                        </div>
                    </div>
                   
                    
 </div>

                

                            

        <div class="panel panel-primary">
                <div class="panel-heading">
                    ALL CUSTOMER
                </div>
                <div class="panel-body">
                    <br />
                    <div class="a">
            
            <div class="table-responsive">  
            <asp:GridView ID="example" CssClass="table table-bordered" runat="server" AllowPaging="True" BackColor="White" PagerSettings-FirstPageText="First" PagerSettings-Mode="NumericFirstLast" PagerSettings-LastPageText="Last" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" PageSize="100000">
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                <PagerSettings FirstPageText="First" LastPageText="Last" />
                <PagerStyle ForeColor="#003399" HorizontalAlign="Left" BackColor="#99CCCC" />
                <RowStyle BackColor="White" ForeColor="#003399" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                <SortedDescendingHeaderStyle BackColor="#002876" />
            </asp:GridView>
            <asp:Repeater ID="RepeaterPaging" runat="server" OnItemCommand="RepeaterPaging_ItemCommand">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server"
                        Text='<%#Eval("Text") %>'
                        CommandArgument='<%#Eval("Value") %>'
                        Enabled='<%#Eval("Enabled") %>'
                        Onclick="LinkButton_Click">
                        </asp:LinkButton>


                    <%--<asp:LinkButton ID="LinkButton" runat="server"
                        Text='<%#Eval("Text") %>'
                        CommandArgument='<%#Eval("Value") %>'
                        Enabled='<%#Eval("Enabled") %>'
                        onclick="LinkButton_Click">
                        
                    
                    </asp:LinkButton>--%>
                </ItemTemplate>

            </asp:Repeater>
                </div>
           <%-- <asp:Button ID="Button2" runat="server" Text="Export To Excel" CssClass="btn btn-primary" OnClick="ExpToExcel_Click" />--%>
             <asp:Button ID="Button3" runat="server" Text="Export To PDF" CssClass="btn btn-primary"  OnClick="ExpToPDF_Click" />

</div>
                    </div>
           

            <br />
           


        </div>
    </form>
                    </div>
                    <!-- /.col-lg-12 -->
                </div>
                <!-- /.row -->
            </div>
            <!-- /.container-fluid -->
        
        <!-- /#page-wrapper -->

    
 

      
<script type="text/javascript">
        $(document).ready(function() {
            $('#multiselect1').multiselect({
                //includeSelectAllOption: true,
                nonSelectedText: 'Select expertise!',
                
            buttonWidth: 250,
            enableFiltering: true
        });
        });
    </script>

<script type="text/javascript">
        $(document).ready(function() {
            $('#multiselect2').multiselect({
                nonSelectedText: 'Select expertise!',
                
            buttonWidth: 250,
            enableFiltering: true
        });
        });
    </script>


    
   <%-- <script src="vendor/metisMenu/metisMenu.min.js"></script>
    <script src="dist/js/sb-admin-2.js"></script>--%>

        
        
        


</body>
</html>


