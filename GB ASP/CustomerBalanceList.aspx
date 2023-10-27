<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerBalanceList.aspx.cs" Inherits="GB_ASP.CustomerBalanceList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CUSTOMER BALANCE LIST</title>
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
                       </li>
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
        <asp:ValidationSummary ID="quizvalidationsummary" runat="server" ShowMessageBox="true" DisplayMode="BulletList" ShowSummary="true" HeaderText="<br />&nbsp;&nbsp;Please check the following:-" ForeColor="Red" ValidationGroup="quizvalidation" BorderColor="Red" BorderStyle="Solid" BorderWidth="1px" Width="280px" /><br />
                    
                         <input type="text" runat="server" Class="form-control" visible="false"
                                id="inputCustomerName" placeholder="Customer Name" />
                        
                         <input type="text" runat="server" Class="form-control" visible="false"
                                id="inputCustomerCode" placeholder="Customer Code" />
                        
                         <input type="text" runat="server" Class="form-control" visible="false"
                                id="inputDivision" placeholder="Division" />
                        
                    <%--<div class="col-md-2">
                    <div class="form-group">
                         <input type="text" runat="server" Class="form-control"
                                id="inputRegion" placeholder="Region" />
                        </div>
                     </div>--%>

                    <div class="col-md-3">
                          <div class="form-group">
                              <asp:ListBox ID="multiselect1" runat="server" AutoPostBack="false" SelectionMode="Multiple" OnSelectedIndexChanged="multiselect1_SelectedIndexChanged">        
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
                              <asp:ListBox ID="multiselect2" runat="server" AutoPostBack="false" SelectionMode="Multiple" OnSelectedIndexChanged="multiselect2_SelectedIndexChanged">        
                              </asp:ListBox>
                          </div>
                    </div>

                              

                     <div class="col-md-3">
                          <div class="form-group">
                            <asp:ListBox ID="multiselect4" runat="server" AutoPostBack="false" SelectionMode="Multiple" OnSelectedIndexChanged="multiselect4_SelectedIndexChanged">        

                              </asp:ListBox>
                              </div>
                    </div>

                    <div class="col-md-3">
                          <div class="form-group">
                            <asp:ListBox ID="multiselect5" runat="server" AutoPostBack="false" SelectionMode="Multiple" OnSelectedIndexChanged="multiselect5_SelectedIndexChanged">
                                
                              </asp:ListBox>
                              </div>
                    </div>


                    <div class="col-md-2">
                        <div class="form-group">
                         <input type="text" runat="server" Class="form-control"
                                id="inputStartInvoiceDate" placeholder="StartInvoiceDate" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="inputStartInvoiceDate" Display="Dynamic" CssClass="field-validation-error" ErrorMessage="Start Date required" ValidationGroup="quizvalidation" Text="*" SetFocusOnError="true" />

                            <a href="javascript:OpenPopupPage('Calendar.aspx','<%= inputStartInvoiceDate.ClientID %>','<%= Page.IsPostBack %>');">
                    <span class="glyphicon glyphicon-calendar"></span> Calendar</a>
                        </div>
                    </div>

                    <div class="col-md-2">
                        <div class="form-group">
                         <input type="text" runat="server" Class="form-control" 
                                id="inputEndInvoiceDate" placeholder="EndInvoiceDate" />
                            <%--<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>--%>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="inputEndInvoiceDate" Display="Dynamic" CssClass="field-validation-error" ErrorMessage="End Date required" ValidationGroup="quizvalidation" Text="*" SetFocusOnError="true" />
                            <a href="javascript:OpenPopupPage('Calendar.aspx','<%= inputEndInvoiceDate.ClientID %>','<%= Page.IsPostBack %>');">
                    <span class="glyphicon glyphicon-calendar"></span> Calendar</a>
                        </div>

                    </div>

                        
                         <input type="text" runat="server" Class="form-control" visible="false"
                                id="inputGroup" placeholder="Customer Group" />
                       
                         <input type="text" runat="server" Class="form-control" visible="false"
                                id="inputBranch" placeholder="Deal For Branch" />
                        
               

                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:Button ID="Button1" runat="server" Text="Run"  OnClick="Button1_Click" ValidationGroup="quizvalidation"
                              CssClass="btn btn-primary"   />
                        </div>
                    </div>
                   </div>
                    
 </div>

                

                            

        <div class="panel panel-primary">
                <div class="panel-heading">
                    CUSTOMER BALANCE LIST
                </div>
                <div class="panel-body">
                    <br />
                    <div class="a">
            
            <div class="table-responsive">  
            <asp:GridView ID="GridView1" CssClass="table table-bordered" runat="server" ValidationGroup="quizvalidation" AllowPaging="True" BackColor="White" PagerSettings-FirstPageText="First" PagerSettings-Mode="NumericFirstLast" PagerSettings-LastPageText="Last" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" PageSize="50">
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                <PagerStyle ForeColor="#003399" HorizontalAlign="Left" BackColor="#99CCCC" />
                <RowStyle BackColor="White" ForeColor="#003399" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                <SortedDescendingHeaderStyle BackColor="#002876" />
            </asp:GridView>
                </div>
            <asp:Repeater ID="RepeaterPaging" runat="server"  OnItemCommand="RepeaterPaging_ItemCommand">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton" runat="server" 
                        Text='<%#Eval("Text") %>'
                        CommandArgument='<%#Eval("Value") %>'
                        Enabled='<%#Eval("Enabled") %>'
                        onclick="LinkButton_Click"> 
                        
                    
                    </asp:LinkButton>
                </ItemTemplate>

            </asp:Repeater>
                
           <%-- <asp:Button ID="Button2" runat="server" Text="Export To Excel" CssClass="btn btn-primary" OnClick="ExpToExcel_Click" />--%>
             <asp:Button ID="Button3" runat="server" Text="Export To PDF" CssClass="btn btn-primary" ValidationGroup="quizvalidation" OnClick="ExpToPDF_Click" />

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
    
</script>
<script type="text/javascript">
        $(document).ready(function() {
            $('#multiselect1').multiselect({
                //includeSelectAllOption: true,
                nonSelectedText: 'Select Customer ID!',
                
            buttonWidth: 250,
            enableFiltering: true
        });
        });
        $(document).ready(function () {
            $('#multiselect2').multiselect({
                nonSelectedText: 'Select Group!',

                buttonWidth: 250,
                enableFiltering: true
            });
        });
  
        $(document).ready(function() {
            $('#multiselect3').multiselect({
                nonSelectedText: 'Select Customer Name!',
                
            buttonWidth: 250,
            enableFiltering: true
        });
        });

        $(document).ready(function () {
            $('#multiselect4').multiselect({
                nonSelectedText: 'Select Branch!',

                buttonWidth: 250,
                enableFiltering: true
            });
        });

        $(document).ready(function () {
            $('#multiselect5').multiselect({
                nonSelectedText: 'Select Division!',

                buttonWidth: 250,
                enableFiltering: true
            });
        });

              </script>


    
    <script src="vendor/metisMenu/metisMenu.min.js"></script>
    <script src="dist/js/sb-admin-2.js"></script>


</body>
</html>


