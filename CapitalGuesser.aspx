<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CapitalGuesser.aspx.cs" Inherits="StateCapitalsQuiz.CaptialGuesser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>State Capital Quiz</h1>

            <!-- get the number of questions the user would like to have asked  -->
            <p>
                <asp:Label ID="lblNumOfQuestions" runat="server" Text="Enter the number of questions you'd like to have (1-50): ">
                    <asp:TextBox ID="txtNumOfQuestions" runat="server"></asp:TextBox>
                </asp:Label>
            </p>

            <!-- ask user what type of quiz they will take (ask for state or ask for capital) -->
            <p>
                <asp:Literal ID="litQuizType" Text="What type of quiz would you like to play?" runat ="server"></asp:Literal>
                <asp:DropDownList ID="ddlQuizType" runat="server">
                    <asp:ListItem>Guess the state from the given capital</asp:ListItem>
                    <asp:ListItem>Guess the capital from the given state</asp:ListItem>
                </asp:DropDownList>
            </p>

            <!--  submit selections and start game -->
                <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="Submit Choice" />
                <asp:Button ID="btnNext" OnClick="btnNextClick" runat="server" Text="Next Question" />



            <p>
                <asp:Literal ID="litMessage" runat="server"></asp:Literal>
            </p>

            <!-- display state name (from the data base here) -->
            <!-- these two are for testing, remove them later -->
            <p>
                <asp:Literal ID="litDisplayState" runat="server"></asp:Literal>
            </p>
            <p>
                <asp:Literal ID="litDisplayCapital" runat="server"></asp:Literal>
            </p>
            <p>
                <asp:Literal ID="litDisplayCorrect" runat="server"></asp:Literal>
            </p>

            <!-- display the question --> 
            <p>
                <asp:Literal ID="litQuestion" runat="server"></asp:Literal>
            </p>



            <!-- list of mutliple choice answers for the quiz -->
            <asp:RadioButtonList ID="rblAnswers" runat="server">
                <asp:ListItem ID="rbli1" Text = "State choice 1" Value="1"></asp:ListItem>
                <asp:ListItem ID="rbli2" Text = "State choice 2" Value="2"></asp:ListItem>
                <asp:ListItem ID="rbli3" Text = "State choice 3" Value="3"></asp:ListItem>
                <asp:ListItem ID="rbli4" Text = "State choice 4" Value="4"></asp:ListItem>


            </asp:RadioButtonList>


            <!--  submit answer 
                 doesn't do anything but gets mad when i delete it-->

           <asp:Button ID="btnSubmitChoice" OnClick="btnSubmitAnswer" runat="server" Text="Submit Choice" />
                

            <!--  submit answer -->
            <asp:Button ID="btnDoneRedirect_" OnClick="btnDoneRedirect" runat="server" Text="Go to Dashboard" />

            <!-- see if  button works -->
            <p>
                <asp:Literal ID="litTestSub" runat="server"></asp:Literal>
            </p>

        </div>
    </form>
</body>
</html>
