<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Q3.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        Detailed Name: 
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Master
                    </td>
                    <td>
                        <asp:DropDownList ID="masterList" runat="server" AutoPostBack="true"/>
                    </td>
                </tr>
            </table>
            <asp:Button ID="btnFilter" Text="Filter" runat="server" OnClick="btnFilter_Click" />
            <asp:GridView ID="GridView1" runat="server" />
        </div>
    </form>
</body>
</html>
