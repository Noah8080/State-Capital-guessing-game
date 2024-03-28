<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountLogin.aspx.cs" Inherits="StateCapitalsQuiz.AccountLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

           <p>
                <asp:Label ID="lblEmail" runat="server" Text="Email: ">
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </asp:Label>
           </p>


            <p>
                <asp:Label ID="lblPassword" runat="server" Text="Password: ">
                    <asp:TextBox ID="txtPassword" textMode="password" runat="server"></asp:TextBox>
                </asp:Label>
            </p>

                <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="Submit" />

            <p>
                <asp:Literal ID="litMessage" runat="server"></asp:Literal>
            </p>

            <p>
                <asp:Label ID="lblCreateAccount" runat="server" Text="Don't have an account? "></asp:Label>

            </p>

            <asp:Button ID="btnNewAccount" OnClick="btnGoToCreateAccount" runat="server" Text="Create Account" />


        </div>
    </form>
</body>
</html>
