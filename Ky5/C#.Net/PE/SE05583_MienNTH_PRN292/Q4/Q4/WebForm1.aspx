<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Q4.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Project: <asp:DropDownList ID="projectList" 
                AutoPostBack="True"
                runat="server" DataSourceID="SqlDataSource1" DataTextField="name" DataValueField="id" 
                />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=localhost;Initial Catalog=PRN292_SU2018;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [Project]"></asp:SqlDataSource>
        </div>
        <div>
            <asp:GridView ID="gvEmployee" runat="server" />
        </div>
    </form>
</body>
</html>
