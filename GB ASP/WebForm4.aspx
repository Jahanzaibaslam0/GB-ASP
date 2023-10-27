<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="GB_ASP.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <input type="text" runat="server" class="form-control"
                                id="input" placeholder="Product Code" />
        <input id="inputProductCode" runat="server" class="form-control" type="text" placeholder="ProductCode" />
        <input id="inputProductName" runat="server" class="form-control"  type="text" placeholder="ProductName" />
        <input id="inputDivision" runat="server" class="form-control" type="text" placeholder="Division" />
        <input id="inputRegion" runat="server" class="form-control" type="text" placeholder="Region" />
        <input id="Text1" type="text" />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="true"
    OnPageIndexChanging="OnPageIndexChanging" PageSize="10" >
    <Columns>
        <asp:BoundField ItemStyle-Width="150px" DataField="CustomerID" HeaderText="Customer ID" />
        <asp:BoundField ItemStyle-Width="150px" DataField="ContactName" HeaderText="Contact Name" />
        <asp:BoundField ItemStyle-Width="150px" DataField="City" HeaderText="City" />
        <asp:BoundField ItemStyle-Width="150px" DataField="Country" HeaderText="Country" />
    </Columns>
</asp:GridView>
        <asp:GridView ID="GridView2" runat="server" AllowPaging="true" PageSize="10" OnPageIndexChanging="GridView2_PageIndexChanging" ></asp:GridView>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    </div>
    </form>
</body>
</html>
