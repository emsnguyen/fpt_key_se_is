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
                        Detailed name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Master
                    </td>
                    <td>
                        <asp:DropDownList ID="masterList" 
                            AutoPostBack="true"
                            runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnFilter" Text="Filter" runat="server" OnClick="btnFilter_Click" />
                    </td>
                </tr>
            </table>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EnableModelValidation="True">
                <Columns>
                    <asp:BoundField DataField="detail_id" HeaderText="ID" />
                    <asp:BoundField DataField="detail_name" HeaderText="Name" />
                    <asp:BoundField DataField="master_name" HeaderText="Master" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
