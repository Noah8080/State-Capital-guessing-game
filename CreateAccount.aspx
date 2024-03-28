<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="StateCapitalsQuiz.CreateAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <h2>Create an account</h2>

            <p>
                <asp:Label ID="lblEmail" runat="server" Text="Email: ">
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </asp:Label>
            </p>
            <p>
                <asp:Label ID="lblUsername" runat="server" Text="Username: ">
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                </asp:Label>
            </p>
            <p>
                <asp:Label ID="password" runat="server" Text="Password: ">
                <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                </asp:Label>
            </p>
             <p>
                <asp:Label ID="passwordCheck" runat="server" Text="Re-enter your Password: ">
                <asp:TextBox ID="txtPasswordCheck" runat="server"></asp:TextBox>
                </asp:Label>
            </p>
            
            <asp:Button ID="btnSubmit" OnClick="btnSubmitClick" runat="server" Text="Submit" />

            <p>
                <asp:Label ID="lblError" Text="" BorderColor ="#FFFFFF" runat="server"></asp:Label>
            </p>

            <p>
                <asp:Label ID="lblLogin" runat="server" Text="Already have an account? "></asp:Label>

            </p>

            <asp:Button ID="btnGoToLogin" OnClick="btnGoToLoginClick" runat="server" Text="Login" />

        </div>
    </form>
</body>
</html>
