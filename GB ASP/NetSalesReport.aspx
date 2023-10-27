<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NetSalesReport.aspx.cs" Inherits="GB_ASP.NetSalesReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
  
    
  <script src="Scripts/select2.min.js"></script>

  <link href="Content/css/select2.min.css" rel="stylesheet" />

  
   </head>
    <body>

  <div class="row">

      <br />

      <br />
      <form runat="server">      
          <asp:DropDownList ID="DropDownList1" runat="server"  CssClass="form-control input-sm"></asp:DropDownList>
      </form>

  </div>
<script type="text/javascript">

      $(document).ready(function () {            

          $("#<%=DropDownList1.ClientID%>").select2({

              placeholder: "Select Item",

              allowClear: true

          });

      });

  </script>

</body>
</html>
