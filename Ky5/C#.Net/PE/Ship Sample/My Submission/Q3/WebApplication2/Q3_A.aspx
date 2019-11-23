<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Q3_A.aspx.cs" Inherits="WebApplication2.Q3_A" %>

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
                        Select ship: 
                    </td>
                    <td>
                        <asp:CheckBox ID="cbSelectShip" runat="server" />
                    </td>
                    <td>
                        <asp:DropDownList ID="listShipName" runat="server" OnSelectedIndexChanged="listShipName_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">Number oNumber of rows: </td>
                    <td>
                        <asp:Label ID="lblNoOfRows" runat="server" Text="0"></asp:Label>
                    </td>
                </tr>
            </table>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ship,battle" DataSourceID="OutcomeDataSource" EnableModelValidation="True">
                <Columns>
                    <asp:BoundField DataField="ship" HeaderText="ship" ReadOnly="True" SortExpression="ship" />
                    <asp:BoundField DataField="battle" HeaderText="battle" ReadOnly="True" SortExpression="battle" />
                    <asp:BoundField DataField="result" HeaderText="result" SortExpression="result" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="OutcomeDataSource" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ShipConnectionString %>" 
                SelectCommand="SELECT * FROM [Outcomes]"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
