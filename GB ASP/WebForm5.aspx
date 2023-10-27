<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm5.aspx.cs" Inherits="GB_ASP.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sales Report</title>
     <link rel="stylesheet"
        href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"
        type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="panel panel-primary">
                <div class="panel-heading">

            <div class="panel-body">
                    <div class="form-group">
                        <label for="inputProductName" class="control-label col-xs-2">
                            Product Name
                        </label>
                        <div class="col-xs-10">
                            <input type="text" runat="server" class="form-control"
                                id="inputProductName" placeholder="Product Name" />
                        </div>
                        
                    </div>
                <asp:DropDownList ID="DDLProduct" runat="server">

                        </asp:DropDownList>

                    <div class="form-group">
                        <label for="inputProductCode" class="control-label col-xs-2">
                            ProductCode
                        </label>
                        <div class="col-xs-10">
                            <input type="text" runat="server" class="form-control"
                                id="inputProductCode" placeholder="Product Code" />
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="inputDivision" class="control-label col-xs-2">
                            Division
                        </label>
                        <div class="col-xs-10">
                            <input type="text" runat="server" class="form-control"
                                id="inputDivision" placeholder="Division" />
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="inputRegion" class="control-label col-xs-2">
                            Region
                        </label>
                        <div class="col-xs-10">
                            <input type="TEXT" runat="server" class="form-control"
                                id="inputRegion" placeholder="Region" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-xs-10 col-xs-offset-2">
                            <asp:Button ID="btnSearch" runat="server" Text="Search"
                                CssClass="btn btn-primary" OnClick="Button1_Click"  />
                            <asp:Button ID="Button2" runat="server" Text="Button" 
                              CssClass="btn btn-primary"   />
                        </div>
                    </div>
                </div>
                    </div>
            </div>

        <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3>Search Results</h3>
                </div>
                <div class="panel-body">
                    <br />
                    <div class="col-xs-10">

            <asp:GridView ID="GridView1" CssClass="table table-bordered" runat="server" AllowPaging="True" BackColor="White" PagerSettings-FirstPageText="First" PagerSettings-Mode="NumericFirstLast" PagerSettings-LastPageText="Last" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" PageSize="100">
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
                    </div>
           

            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />


        </div>
    </form>
</body>
</html>
