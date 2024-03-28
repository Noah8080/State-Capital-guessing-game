<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="StateCapitalsQuiz.Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Dashboard</h1>

            <asp:Literal ID="litShowName" runat="server"></asp:Literal>


            <p>
                <asp:Label ID="lblStartGame" runat="server" Text="Start a new game"></asp:Label>
            </p>

            <asp:Button ID="btnStartGame" OnClick="btnStartGameClick" runat="server" Text="Play" />


            <p>Here are your results:<br /></p>

            <asp:Literal ID="litResults" runat="server"></asp:Literal>



        </div>
    </form>
</body>
</html>
