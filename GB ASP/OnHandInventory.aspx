﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OnHandInventory.aspx.cs" Inherits="GB_ASP.OnHandInventory1" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ON HAND INVENTORY</title>

   <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
      
        <script type="text/javascript" src="vendor/bootstrap/css/bootstrap.min.js"></script>
  
        <link href="vendor/bootstrap/css/Bootstrap-multiselect.css" rel="stylesheet" />

        <script type="text/javascript" src="vendor/bootstrap/css/Bootstrap-multiselect.js"></script>
        <script src="https://cdn.datatables.net/1.10.12/js/jquery.dataTables.min.js"></script>  
        <script src="https://cdn.datatables.net/1.10.12/js/dataTables.bootstrap.min.js"></script>            
        <link rel="stylesheet" href="https://cdn.datatables.net/1.10.12/css/dataTables.bootstrap.min.css" />  
        <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
        <link href="vendor/metisMenu/metisMenu.min.css" rel="stylesheet" />
        <link href="dist/css/sb-admin-2.css" rel="stylesheet" />
        <link href="vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript" src="js/Script.js"></script>
      <style type="text/css">
        .modal
        {
        position: fixed;
        top: 0;
        left: 0;
        background-color: black;
        z-index: 99;
        opacity: 0.8;
        filter: alpha(opacity=80);
        -moz-opacity: 0.8;
        min-height: 100%;
        width: 100%;
        }
        .loading
        {
        font-family: Arial;
        font-size: 10pt;
        border: 5px none #67CFF5;
        width: 200px;
        height: 100px;
        display: none;
        position: fixed;
        background-color: none;
        z-index: 999;
        }
</style>
  
</head>
<body>

    <div class="loading" align="center">
    
    <img src="Images/cloader.gif" alt="" />
    </div>



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
               <a class="navbar-brand" href="index.html"> <img style="width:70px; margin-bottom: 10px" src="Images/GB-Logo.png" alt="GhaziBrother" ></a>
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
                                        <a  href="ALLSALESORDER.aspx">ALL SALES ORDER</a>
                                    </li>
                                    <li>
                                        <a  href="ShippedButNotInvoicedSalesOrder.aspx">SHIPPED BUT NOT INVOICED SALES ORDER</a>
                                    </li> 
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
                                            </ul>
                                        </li>
                                    </ul>
                           <!-- /.nav-second-level -->
                            
                       <li >
                                <a href="#"><i class="fa fa-files-o fa-fw"></i> INVENTORY AND WAREHOUSE <span class="fa arrow"></span></a>
                                <ul class="nav nav-second-level">
                                    
                                     
                                    <li>
                                    <a href="#"><i class="fa fa-files-o fa-fw"></i> INVENTORY <span class="fa arrow"></span></a>
                                        <ul class="nav nav-third-level">
                                    <li>
                                        <a  href="OnHandInventory.aspx">ON HAND INVENTORY   </a>
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
                    
                         <input type="text" runat="server" Class="form-control" visible="false"
                                id="inputProductID" placeholder="PRODUCT ID" />
                       
                         <input type="text" runat="server" Class="form-control" visible="false"
                                id="inputProductName" placeholder="Product Name" />
                       
                         <input type="text" runat="server" Class="form-control" visible="false"
                                id="inputWarehouse" placeholder="Warehouse" />
                      
                         <input type="text" runat="server" Class="form-control" visible="false"
                                id="inputBatch" placeholder="Invent Batch ID" />
                       
                  
                            <input type="text" runat="server" Class="form-control" visible="false"
                                id="inputDivision" placeholder="Division" />
                        
                         <input type="text" runat="server" Class="form-control" visible="false"
                                id="inputSample" placeholder="Sample" />
                      
                         <input type="text" runat="server" Class="form-control" visible="false"
                                id="inputSite" placeholder="Site" />
                        <input type="text" runat="server" Class="form-control" visible="false"
                                id="inputProductGroup" placeholder="Product Group" />
                        <input type="text" runat="server" Class="form-control" visible="false"
                                id="inputItemInventory" placeholder="Item Inventory type" />
                    


                    <div class="col-md-3">
                          <div class="form-group">
                              <asp:ListBox ID="multiselect1" runat="server" AutoPostBack="false" SelectionMode="Multiple" OnSelectedIndexChanged="multiselect1_SelectedIndexChanged">        
                              </asp:ListBox>
                          </div>
                    </div>


                    <div class="col-md-3">
                          <div class="form-group">
                            <asp:ListBox ID="multiselect2" runat="server" AutoPostBack="false" SelectionMode="Multiple" OnSelectedIndexChanged="multiselect2_SelectedIndexChanged">        

                              </asp:ListBox>
                              </div>
                    </div>

                    <div class="col-md-3">
                          <div class="form-group">
                            <asp:ListBox ID="multiselect3" runat="server" AutoPostBack="false" SelectionMode="Multiple" OnSelectedIndexChanged="multiselect3_SelectedIndexChanged">        

                              </asp:ListBox>
                              </div>
                    </div>
                              
                    


                    <div class="col-md-3">
                          <div class="form-group">
                            <asp:ListBox ID="multiselect4" runat="server" AutoPostBack="false" SelectionMode="Multiple" OnSelectedIndexChanged="multiselect4_SelectedIndexChanged">
                                <asp:ListItem>FEED TECH DIVISION</asp:ListItem>
                                <asp:ListItem>POULTRY HEALTH DIVISION</asp:ListItem>
                                <asp:ListItem>SPECIALITY PRODUCT DIVISION</asp:ListItem>
                                <asp:ListItem>ANIMAL HEALTH DIVISION</asp:ListItem>
                                <asp:ListItem>HUMAN HEALTH DIVISION</asp:ListItem>
                              </asp:ListBox>
                              </div>
                    </div>

                    <div class="col-md-3">
                          <div class="form-group">
                            <asp:ListBox ID="multiselect5" runat="server" AutoPostBack="false" SelectionMode="Multiple" OnSelectedIndexChanged="multiselect5_SelectedIndexChanged">
                                
                              </asp:ListBox>
                              </div>
                    </div>

                    <div class="col-md-3">
                          <div class="form-group">
                            <asp:ListBox ID="multiselect6" runat="server" AutoPostBack="false" SelectionMode="Multiple" OnSelectedIndexChanged="multiselect6_SelectedIndexChanged">
                                <asp:ListItem>ADSITE</asp:ListItem>
                                <asp:ListItem>FSB</asp:ListItem>
                                <asp:ListItem>GUJ</asp:ListItem>
                                <asp:ListItem>HYD</asp:ListItem>
                                <asp:ListItem>KHI</asp:ListItem>
                                <asp:ListItem>LHR</asp:ListItem>
                                <asp:ListItem>MUX</asp:ListItem>
                                <asp:ListItem>RWP</asp:ListItem>
                                

                              </asp:ListBox>
                              </div>
                    </div>

                    <div class="col-md-3">
                          <div class="form-group">
                            <asp:ListBox ID="multiselect7" runat="server" AutoPostBack="false" SelectionMode="Multiple" OnSelectedIndexChanged="multiselect7_SelectedIndexChanged">
                                <asp:ListItem>YES</asp:ListItem>
                                <asp:ListItem>NO</asp:ListItem>
                                
                                

                              </asp:ListBox>
                              </div>
                    </div>

                    <div class="col-md-3">
                          <div class="form-group">
                            <asp:ListBox ID="multiselect8" runat="server" AutoPostBack="false" SelectionMode="Multiple" OnSelectedIndexChanged="multiselect8_SelectedIndexChanged">
                                <asp:ListItem>Blank</asp:ListItem>
                                <asp:ListItem>Merchandise</asp:ListItem>
                                <asp:ListItem>Non Merchandise</asp:ListItem>
                                
                              </asp:ListBox>
                              </div>
                    </div>

                    <div class="col-md-3">
                          <div class="form-group">
                            <asp:ListBox ID="multiselect9" runat="server" AutoPostBack="false" SelectionMode="Multiple" OnSelectedIndexChanged="multiselect9_SelectedIndexChanged">
                                <asp:ListItem>Health Group A</asp:ListItem>
                                <asp:ListItem>Biological Group</asp:ListItem>
                                <asp:ListItem>Nutrition Group</asp:ListItem>
                                <asp:ListItem>Aqua Group</asp:ListItem>
                                <asp:ListItem>Disinfection Group</asp:ListItem>
                                <asp:ListItem>Health Group B</asp:ListItem>
                                <asp:ListItem>Minerals</asp:ListItem>
                                <asp:ListItem>Organic Acids</asp:ListItem>
                                <asp:ListItem>Feed Ingredients</asp:ListItem>
                                <asp:ListItem>Enzymes</asp:ListItem>
                                <asp:ListItem>Vitamins</asp:ListItem>
                                <asp:ListItem>Anticoccidials</asp:ListItem>
                                <asp:ListItem>Antiparasitic</asp:ListItem>
                                <asp:ListItem>Essential Oils</asp:ListItem>
                                <asp:ListItem>Antioxidant</asp:ListItem>
                                <asp:ListItem>Organic Nutrients</asp:ListItem>
                                <asp:ListItem>Toxin Binderand Detoxifiers</asp:ListItem>
                                <asp:ListItem>Pellet Performance Enhancer</asp:ListItem>
                                <asp:ListItem>Antibiotic Growth Promoters</asp:ListItem>
                                <asp:ListItem>Ruminants Specific Feed Additives</asp:ListItem>
                                <asp:ListItem>Fat Metabolizers and Absorption Enhancer</asp:ListItem>
                                <asp:ListItem>Organic Minerals</asp:ListItem>
                                <asp:ListItem>Minerals and Vitamins</asp:ListItem>
                                <asp:ListItem>Pellet Performance Enhancer1</asp:ListItem>
                                <asp:ListItem>Feed Pigments</asp:ListItem>
                                <asp:ListItem>Companion Animal Group Team B</asp:ListItem>
                                <asp:ListItem>CRI Group Team A</asp:ListItem>
                                <asp:ListItem>Medicine Group Team A</asp:ListItem>
                                <asp:ListItem>Medicine Group Team B</asp:ListItem>
                                <asp:ListItem>Nutrition Group Team A</asp:ListItem>
                                <asp:ListItem>Nutrition Group Team B</asp:ListItem>
                                <asp:ListItem>TeamA.HHD</asp:ListItem>
                                <asp:ListItem>PM.TeamB.HHD</asp:ListItem>
                                <asp:ListItem>BM.TeamC.HHD</asp:ListItem>
                                <asp:ListItem>Alpha Group</asp:ListItem>
                                <asp:ListItem>Bravo Group</asp:ListItem>
                                <asp:ListItem>Charli Group</asp:ListItem>
                                
                              </asp:ListBox>
                              </div>
                    </div>

    <%--                <div class="col-md-3">
                          <div class="form-group">
                            <asp:ListBox ID="multiselect7" runat="server" AutoPostBack="false" SelectionMode="Multiple" OnSelectedIndexChanged="multiselect_SelectedIndexChanged">
                                
                              </asp:ListBox>
                              </div>
                    </div>--%>


                    <div class="col-md-3">
                        <div class="form-group">
                         <input type="text" runat="server" Class="form-control"
                                id="inputStartInvoiceDate" placeholder="StartInvoiceDate" />
                            <a href="javascript:OpenPopupPage('Calendar.aspx','<%= inputStartInvoiceDate.ClientID %>','<%= Page.IsPostBack %>');">
                    <span class="glyphicon glyphicon-calendar"></span> Calendar</a>
                        </div>
                    </div>

                    <div class="col-md-3">
                        <div class="form-group">
                         <input type="text" runat="server" Class="form-control"
                                id="inputEndInvoiceDate" placeholder="EndInvoiceDate" />
                            <a href="javascript:OpenPopupPage('Calendar.aspx','<%= inputEndInvoiceDate.ClientID %>','<%= Page.IsPostBack %>');">
                    <span class="glyphicon glyphicon-calendar"></span> Calendar</a>
                        </div>

                    </div>

                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:Button ID="Button1" runat="server" Text="Run"  OnClick="Button1_Click"
                              CssClass="btn btn-primary"   />
                        </div>
                    </div>
                   
                    
 </div>

                

                            

        <div class="panel panel-primary">
                <div class="panel-heading">
                    ON HAND INVENTORY
                </div>
                <div class="panel-body">
                    <br />
                    <div class="a">
            
            <div class="table-responsive">  
            <asp:GridView ID="GridView1" CssClass="table table-bordered" runat="server" AllowPaging="True" BackColor="White" PagerSettings-FirstPageText="First" PagerSettings-Mode="NumericFirstLast" PagerSettings-LastPageText="Last" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" PageSize="50">
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
                    <asp:LinkButton ID="LinkButton" runat="server"
                        Text='<%#Eval("Text") %>'
                        CommandArgument='<%#Eval("Value") %>'
                        Enabled='<%#Eval("Enabled") %>'
                        onclick="LinkButton_Click"
                        > 
                        
                    
                    </asp:LinkButton>
                </ItemTemplate>

            </asp:Repeater>
                </div>
         <%--   <asp:Button ID="Button2" runat="server" Text="Export To Excel" CssClass="btn btn-primary" OnClick="ExpToExcel_Click" />--%>
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
    function ShowProgress() {
        setTimeout(function () {
            var modal = $('<div />');
            modal.addClass("modal");
            $('body').append(modal);
            var loading = $(".loading");
            loading.show();
            var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
            var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
            loading.css({ top: top, left: left });
        }, 200);
    }
    $('#form1').on("submit", function () {
        ShowProgress();
    });
    $('#form1').on("load", function () {
        ShowProgress();
    });
</script>


    <script type="text/javascript">
        $(document).ready(function() {
            $('#multiselect1').multiselect({
                //includeSelectAllOption: true,
                nonSelectedText: 'Select Product ID!',
                
            buttonWidth: 250,
            enableFiltering: true
        });
        });
  
        $(document).ready(function() {
            $('#multiselect2').multiselect({
                nonSelectedText: 'Select Product Name!',
                
            buttonWidth: 250,
            enableFiltering: true
        });
        });
  
        $(document).ready(function() {
            $('#multiselect3').multiselect({
                nonSelectedText: 'Select Batch!',
                
            buttonWidth: 250,
            enableFiltering: true
        });
        });
   
        $(document).ready(function() {
            $('#multiselect4').multiselect({
                nonSelectedText: 'Select Division!',
                
            buttonWidth: 250,
            enableFiltering: true
        });
        });

        $(document).ready(function () {
            $('#multiselect5').multiselect({
                nonSelectedText: 'Select Warehouse!',

                buttonWidth: 250,
                enableFiltering: true
            });
        });

        $(document).ready(function () {
            $('#multiselect6').multiselect({
                nonSelectedText: 'Select Site!',

                buttonWidth: 250,
                enableFiltering: true
            });
        });

        $(document).ready(function () {
            $('#multiselect7').multiselect({
                nonSelectedText: 'Select Sample!',

                buttonWidth: 250,
                enableFiltering: true
            });
        });
        $(document).ready(function () {
            $('#multiselect8').multiselect({
                nonSelectedText: 'Select Item Inventoy Type!',

                buttonWidth: 250,
                enableFiltering: true
            });
        });
        $(document).ready(function () {
            $('#multiselect9').multiselect({
                nonSelectedText: 'Select Product Group!',

                buttonWidth: 250,
                enableFiltering: true
            });
        });
    </script>


    
    <script src="vendor/metisMenu/metisMenu.min.js"></script>
    <script src="dist/js/sb-admin-2.js"></script>


</body>
</html>