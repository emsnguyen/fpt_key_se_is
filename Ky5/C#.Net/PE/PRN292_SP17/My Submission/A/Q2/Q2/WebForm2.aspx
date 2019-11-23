<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Q2.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
            Employee: <asp:DropDownList ID="listEmployee" runat="server"
                AutoPostBack="True" DataSourceID="SP17_DataSource" DataTextField="Name" DataValueField="EmployeeID" />
                <asp:SqlDataSource ID="SP17_DataSource" runat="server" ConnectionString="<%$ ConnectionStrings:connectionString %>" SelectCommand="SELECT [EmployeeID], [Name] FROM [Employee]"></asp:SqlDataSource>
        </div>
        <div>
            <p>List of skills: </p>
            <asp:GridView runat="server" ID="gvSkill"></asp:GridView>
        </div>
        </div>
    </form>
</body>
</html>
