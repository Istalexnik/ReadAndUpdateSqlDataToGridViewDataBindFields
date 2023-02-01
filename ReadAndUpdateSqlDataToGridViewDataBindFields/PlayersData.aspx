<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="PlayersData.aspx.vb" Inherits="PlayersData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ValidationSummary runat="server" ForeColor="Red" />
    <table>
        <tr>
            <td>
                <asp:Label runat="server" Text="Player ID" /></td>
            <td>
                <asp:TextBox runat="server" ID="txtPlayerID" />
                <asp:Button runat="server" ID="btnGet" Text="Get" />
                <asp:Button runat="server" ID="btnUpdate" Text="Update" ValidationGroup="btnUpdate" />
                <asp:Button runat="server" ID="btnDelete" Text="Delete" />
            </td>
            <td>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPlayerID" Text="*" ForeColor="Red"
                    ErrorMessage="Enter Player ID" ValidationGroup="btnUpdate" /></td>
        </tr>

        <tr>
            <td>
                <asp:Label runat="server" Text="Firstname" /></td>
            <td>
                <asp:TextBox runat="server" ID="txtFirstname" /></td>
            <td>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFirstname" Text="*" ForeColor="Red"
                    ErrorMessage="Enter firstname" ValidationGroup="btnSave" /></td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" Text="Lastname" /></td>
            <td>
                <asp:TextBox runat="server" ID="txtLastname" /></td>
            <td>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtLastname" Text="*" ForeColor="Red"
                    ErrorMessage="Enter lastname" ValidationGroup="btnSave" /></td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" Text="Nickname" /></td>
            <td>
                <asp:TextBox runat="server" ID="txtNickname" /></td>
            <td>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNickname" Text="*" ForeColor="Red"
                    ErrorMessage="Enter nickname" ValidationGroup="btnSave" /></td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" Text="Email" /></td>
            <td>
                <asp:TextBox runat="server" ID="txtEmail" /></td>
            <td>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail" Text="*" ForeColor="Red"
                    ErrorMessage="Enter email" ValidationGroup="btnSave" />
                <asp:RegularExpressionValidator runat="server" ControlToValidate="txtEmail" Text="*" ErrorMessage="Enter a correct email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" Text="Password" /></td>
            <td>
                <asp:TextBox runat="server" ID="txtPassword" /></td>
            <td>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword" Text="*" ForeColor="Red"
                    ErrorMessage="Enter password" ValidationGroup="btnSave" /></td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button runat="server" ID="btnClear" Text="Clear" CausesValidation="false" />
                <asp:Button runat="server" ID="btnSave" Text="Save" ValidationGroup="btnSave" />
                <%--search in grid using LIKE --%>
                <asp:Button runat="server" ID="btnSearch" Text="Search" />
                <asp:Button runat="server" ID="btnLoad" Text="Load" />
                <%--EDIT, DELETE, SELECT--%>
            </td>
            <td></td>
            <asp:Label ID="lblmessage" runat="server" Text=""></asp:Label>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td></td>

        </tr>

    </table>


    <asp:GridView runat="server" ID="gvPlayers" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" OnSorting="gvPlayers_Sorting" OnPageIndexChanging="gvPlayers_PageIndexChanging">
        <Columns>
            <asp:TemplateField HeaderText="Player ID" SortExpression="col_playerid">
                <ItemTemplate>
                    <asp:LinkButton ID="lbPlayerID" runat="server" Text='<%# Bind("col_playerid") %>' CausesValidation="false" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Firstname">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblFirstname" Text='<%# Bind("col_firstname") %>' />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Lastname">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblLastname" Text='<%# Bind("col_lastname") %>' />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Nickname">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblNickname" Text='<%# Bind("col_nickname") %>' />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Email">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblEmail" Text='<%# Bind("col_email") %>' />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Password">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblPassword" Text='<%# Bind("col_password") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

