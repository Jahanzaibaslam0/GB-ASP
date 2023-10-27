<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="GB_ASP.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Search</title>
    <link rel="stylesheet"
        href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"
        type="text/css" />
</head>
<body style="padding-top: 10px">
    <div class="col-xs-8 col-xs-offset-2">
        <form id="form1" runat="server" class="form-horizontal">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3>Sales Report</h3>
                </div>

                <div class="panel-body">
                    <div class="form-group">
                        <label for="inputStart" class="control-label col-xs-2">
                            Page Record
                        </label>
                        <div class="col-xs-10">
                            <input type="text" runat="server" class="form-control"
                                id="inputstart" placeholder="Product Name" value="1" />
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="inputend" class="control-label col-xs-2">
                            PageEndRecord
                        </label>
                        <div class="col-xs-10">
                            <input type="text" runat="server" class="form-control"
                                id="inputend" placeholder="Page End Record" />
                        </div>
                    </div>

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
                                CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                            <asp:Button ID="Button1" runat="server" Text="Button" 
                              CssClass="btn btn-primary" OnClick="Button1_Click"  />
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
                        <asp:GridView CssClass="table table-bordered"
                            ID="gvSearchResults" runat="server" Visible="true" 
                            >
                        </asp:GridView>


                    </div>
                    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
                            SelectMethod="btnSearch_Click" 
                            TypeName="WebForm3.aspx.cs"
                            MaximumRowsParameterName="maximumRows"
                            StartRowIndexParameterName="startRowIndex"
                            SelectCountMethod="GetTotalCount"
                            EnablePaging="true" >
                        
                        


                    </asp:ObjectDataSource>
                    <br />
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </div>
            </div>
        </form>
    </div>
</body>
</html>