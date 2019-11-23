<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmBook.aspx.cs" Inherits="Chapter23.frmBook" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<script type = "text/javascript">

     function RadioCheck(rb) {

        var gv = document.getElementById("<%=gridBookList.ClientID%>");

        var rbs = gv.getElementsByTagName("input");

        var row = rb.parentNode.parentNode;

        for (var i = 0; i < rbs.length; i++) {

            if (rbs[i].type == "radio") {

                if (rbs[i].checked && rbs[i] != rb) {

                    rbs[i].checked = false;

                    break;

                }

            }

        }

    }    

</script>
<body>
    <form id="form1" runat="server">
    <div>
    
        <strong>Book&nbsp; Information</strong><br />
    
    </div>
        Title&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtTitle" runat="server" Width="289px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Author&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtAuthor" runat="server" Width="357px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
&nbsp;<br />
        Publisher&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtPublisher" runat="server" Width="293px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Number&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtNumber" runat="server" Width="104px"></asp:TextBox>
        <br />
        <br />
        <strong><em>Book List&nbsp; ist&nbsp; </em&nbsp;
        <br />
        <asp:GridView ID="gridBookList" runat="server" Width="857px" AllowPaging="True" AllowSorting="True"
            onrowdeleting="gridBookList_RowDeleting" 
            OnRowUpdating="gridBookList_RowUpdating"
            OnRowCanceling="gridBookList_RowCancelingEdit"
            onrowediting="gridBookList_RowEditing"
            CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gridBookList_SelectedIndexChanged" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" style="margin-left: 0px" BorderStyle="Solid" BorderWidth="1px" PageSize="5">
            <AlternatingRowStyle BackColor="White" />
            <Columns>

                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                             <asp:RadioButton ID="RadioButton1" runat="server" onclick = "RadioCheck(this);"/>
                             <asp:HiddenField ID="HiddenField1" runat="server" Value = '<%#Eval("BookCode")%>' />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="Publisher" HeaderText="Publisher" />
                <asp:BoundField DataField="BookNumber" HeaderText="Book Number" />
                <asp:CommandField ButtonType="Button" HeaderText="Delete" ShowDeleteButton="True" ShowHeader="True" />

            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />


        </asp:GridView>
        <br />
        <asp:Button ID="btnAddNoew" runat="server" OnClick="btnAddNoew_Click" Text="AddNew" Width="104px" style="height: 26px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="Exit" Width="113px" />
        </em></strong>
    <div>
    
        <strong>
        <br />
        Copy Book&nbsp; Information</strong></div>
        Book Code&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtCopyBookCode" runat="server" Width="114px" Enabled="False"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Copy number&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtCopyNumber" runat="server" Width="357px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
&nbsp;<br />
        Sequence Number&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtSequenceNumber" runat="server" Width="111px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; Type&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtType" runat="server" Width="104px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Price&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtPrice" runat="server" Width="104px"></asp:TextBox>
        <br />
        <br />
        <strong><em>Book ListBook List&nbsp; ist&nbsp; </em&nbsp;
        <br />
        <asp:GridView ID="gridCopyBookList" runat="server" Width="857px" AllowPaging="True" AllowSorting="True"
            onrowdeleting="gridCopyBookList_RowDeleting" 
            OnRowUpdating="gridBookList_RowUpdating"
            OnRowCanceling="gridBookList_RowCancelingEdit"
            onrowediting="gridBookList_RowEditing"
            CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gridBookList_SelectedIndexChanged" AutoGenerateColumns="False" style="margin-left: 0px" BorderStyle="Solid" BorderWidth="1px" EnableSortingAndPagingCallbacks="True" EnableTheming="True" PageSize="5">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="CopyCode" HeaderText="Copy Code" SortExpression="CopyCode" />
                <asp:BoundField DataField="BookCode" HeaderText="Book Code" />
                <asp:BoundField DataField="SequenceNumber" HeaderText="Sequence Number" />
                <asp:BoundField DataField="Type" HeaderText="Type" />
                <asp:BoundField DataField="Price" HeaderText="Price" />
                <asp:CommandField ButtonType="Button" HeaderText="Delete" ShowDeleteButton="True" ShowHeader="True" />
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
        <br />
&nbsp;<asp:Button ID="btnAddCopy" runat="server" OnClick="btnAddCopy_Click" Text="Add Copy" Width="94px" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" Text="Exit" Width="113px" />
    </form>
</body>
</html>
