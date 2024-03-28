using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateCapitalsQuiz
{
    public partial class CaptialGuesser : System.Web.UI.Page
    {

        static string[,] arr = new string[2, 50];
        static int quizType = 0;
        static int numQu = 0;
        static int currentQu = 2;
        static string answer = "";
        static string userResponse = "";
        static int totalCorrect = 0;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            litQuestion.Text = "";
            rblAnswers.Visible = false;
            rbli1.Text = "";
            rbli2.Text = "";
            rbli3.Text = "";
            rbli4.Text = "";
            btnSubmitChoice.Visible = false;
            btnNext.Visible = false;
            btnDoneRedirect_.Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // get the number of requested question
            // get the requested type of quiz

            quizType = ddlQuizType.SelectedIndex;
            numQu = Convert.ToInt32(txtNumOfQuestions.Text);


            string stateName = "";
            string stateCap = "";

            string dbConnect = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            // connect to database to find state and capital
            using (SqlConnection newConn = new SqlConnection(dbConnect))
            {
                newConn.Open();

                // make array to hold states and their capitals

                // get states and capitals
                SqlCommand cmdFindState = new SqlCommand("dbo.cpaGetState", newConn);
                cmdFindState.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader rdrFindState = cmdFindState.ExecuteReader();

                int num = 0;
                while (rdrFindState.Read())
                {
                    // The information for the state in the question
                    stateName = Convert.ToString(rdrFindState["state"]);
                    stateCap = Convert.ToString(rdrFindState["capital"]);

                    // fill an array with states and their capitals
                    arr[0, num] = stateName;
                    arr[1, num] = stateCap;
                    num++;


                    makeQuestions(arr, quizType);

                }

                quizType = ddlQuizType.SelectedIndex;
                numQu = Convert.ToInt32(txtNumOfQuestions.Text);
                btnNext.Visible = true;
                btnSubmit.Visible = false;

            }

            // hid game generation options
            lblNumOfQuestions.Visible = false;
            litQuizType.Visible = false;
            ddlQuizType.Visible = false;
        }

 

        protected void makeQuestions(string[,] arr, int quizType)
        {

            // get random numbers for populating questions
            Random random = new Random();
            int rand1 = random.Next(0, 50);
            int rand2;
            int rand3;
            int rand4;

            // get 4 unique numbers to act as indexes for the state and caps array
            var randNumList = new List<int>();
            randNumList.Add(rand1);
            do
            {
                rand2 = random.Next(0, 50);
            }
            while (randNumList.Any(x => x == rand2));
            randNumList.Add(rand2);
            do
            {
                rand3 = random.Next(0, 50);
            }
            while (randNumList.Any(x => x == rand3));
            randNumList.Add(rand3);
            do
            {
                rand4 = random.Next(0, 50);
            }
            while (randNumList.Any(x => x == rand4));
            randNumList.Add(rand4);

            
            // making a string array of selected states
            string holdS1 = arr[0, rand1];
            string holdS2 = arr[0, rand2];
            string holdS3 = arr[0, rand3];
            string holdS4 = arr[0, rand4];
            string[] arrHoldS = { holdS1, holdS2, holdS3, holdS4 };

            // make a string array of selected capitals
            string holdC1 = arr[1, rand1];
            string holdC2 = arr[1, rand2];
            string holdC3 = arr[1, rand3];
            string holdC4 = arr[1, rand4];
            string[] arrHoldC = {holdC1, holdC2, holdC3, holdC4};

            // get 4 random and non repeating numbers to randomize order answers appear 
            int r1 = random.Next(0, 4);
            int r2;
            int r3;
            int r4;

            var rSet = new List<int>();
            rSet.Add(r1);
            do
            {
                r2 = random.Next(0, 4);
            }
            while(rSet.Any(x => x == r2));
            rSet.Add(r2);
            do
            {
                r3 = random.Next(0, 4);
            }
            while (rSet.Any(x => x == r3));
            rSet.Add(r3);
            do
            {
                r4 = random.Next(0, 4);
            }
            while( rSet.Any(x => x == r4));
            rSet.Add(r4);



            if (quizType == 0) // quess the state from the given capital 
            {

                litQuestion.Text = arr[1,rand1] + " is the capital of what state?";
                answer = arr[0,rand1];
                rblAnswers.Visible = true;

                rbli1.Text  = arrHoldS[r1];
                rbli1.Value = arrHoldS[r1];
                rbli2.Text  = arrHoldS[r2];
                rbli2.Value = arrHoldS[r2];
                rbli3.Text  = arrHoldS[r3];
                rbli3.Value = arrHoldS[r3];
                rbli4.Text  = arrHoldS[r4];
                rbli4.Value = arrHoldS[r4];

                // saves the answer for checking with user input
                answer = arr[0, rand1];

            }
            else
            {
                litQuestion.Text = "What is the capital of " + arr[0,rand1];
                answer = arr[1, rand1];

                rblAnswers.Visible = true;
                rbli1.Text  = arrHoldC[r1];
                rbli1.Value = arrHoldC[r1];
                rbli2.Text  = arrHoldC[r2];
                rbli2.Value = arrHoldC[r2];
                rbli3.Text  = arrHoldC[r3];
                rbli3.Value = arrHoldC[r3];
                rbli4.Text  = arrHoldC[r4];
                rbli4.Value = arrHoldC[r4];


                // saves the answer for checking with user input
                answer = arr[1, rand1];


            }

        }

        protected void btnNextClick(object sender, EventArgs e)
        {
            userResponse = rblAnswers.SelectedValue.ToString();
            //int uu = int.Parse(userResponse);
              

            if(userResponse == answer)
            {
                totalCorrect++;
            }
            
            btnSubmit.Visible = false;
            if (currentQu <= numQu)
            {
                litDisplayState.Text = userResponse + " is what you said, " + answer + " was the answer";
                makeQuestions(arr, quizType);
                currentQu++;
                btnNext.Visible = true;
            }
            else
            {
                litDisplayCapital.Text = "you have finished. Your score is " + totalCorrect + "/" + numQu;
                btnDoneRedirect_.Visible = true;

                // send the results to the database
                string dbConnect = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
                using (SqlConnection newConn = new SqlConnection(dbConnect))
                {
                    newConn.Open();

                    SqlCommand cmdAddResult = new SqlCommand("addResult", newConn);
                    cmdAddResult.CommandType = System.Data.CommandType.StoredProcedure;
                    cmdAddResult.Parameters.AddWithValue("@amountCorrect", totalCorrect);
                    cmdAddResult.Parameters.AddWithValue("@amountOfQuestions", numQu);
                    cmdAddResult.Parameters.AddWithValue("@date",DateTime.Today);
                    cmdAddResult.Parameters.AddWithValue("accountID", Convert.ToInt32(Session["account"]));

                    cmdAddResult.ExecuteNonQuery();

                }


            }
            rblAnswers.ClearSelection();

        }

        protected void btnSubmitAnswer(object sender, EventArgs e)
        {}

        protected void btnDoneRedirect(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");

        }

    }
}