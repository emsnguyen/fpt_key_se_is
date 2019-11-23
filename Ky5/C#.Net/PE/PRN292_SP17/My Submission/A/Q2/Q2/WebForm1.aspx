<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Q2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Employee: <asp:DropDownList ID="listEmployee" runat="server"
                AutoPostBack="true" />
        </div>
        <div>
            <p>List of skills: </p>
            <asp:GridView runat="server" ID="gvSkill"></asp:GridView>
        </div>
    </form>
</body>
</html>
