<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Q2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Employee <asp:DropDownList ID="listEmployee" runat="server"
    AutoPostBack="True" DataSourceID="DSEmployee" DataTextField="Name" DataValueField="EmployeeID" />
            <asp:SqlDataSource ID="DSEmployee" runat="server" ConnectionString="Data Source=localhost;Initial Catalog=PRN292_SPRING_2017;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [EmployeeID], [Name] FROM [Employee]"></asp:SqlDataSource>
        </div>
        <div>
            <p>List of certificates:</p>
            <asp:GridView ID="gvCertificate" runat="server" />
        </div>
    </form>
</body>
</html>
