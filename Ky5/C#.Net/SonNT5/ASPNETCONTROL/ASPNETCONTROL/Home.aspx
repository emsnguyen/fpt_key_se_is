<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ASPNETCONTROL.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="btnOK" OnClick="btnOK_Click"  runat="server" Text="Button" />
        <br/>
        <asp:DropDownList ID="cbxStudents" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cbxStudents_SelectedIndexChanged"></asp:DropDownList>
        <input type="text" value="abc" name="txtValue" />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        </div>
    </form>
</body>
</html>
