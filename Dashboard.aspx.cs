using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateCapitalsQuiz
{
    public partial class Dashboard : System.Web.UI.Page
    {
        /* on page load*/
        protected void Page_Load(object sender, EventArgs e)
        {

            // connect to db
            string dbConnect = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            using (SqlConnection newConn = new SqlConnection(dbConnect))
            {
                newConn.Open();

                // get the current user's username ussing the stored ID in session
                SqlCommand cmdGetName = new SqlCommand("dbo.getUsername", newConn);
                cmdGetName.CommandType = System.Data.CommandType.StoredProcedure;
                cmdGetName.Parameters.AddWithValue("@id", Convert.ToInt32(Session["account"]));
                SqlDataReader rdrUsername = cmdGetName.ExecuteReader();

                string userName = "";
                while (rdrUsername.Read())
                {
                    userName = Convert.ToString(rdrUsername["username"]);

                }
                rdrUsername.Close();
                litShowName.Text = "Hello "+userName;

                // get the current user's saved results
                SqlCommand cmdGetResults = new SqlCommand("dbo.getResult", newConn);
                cmdGetResults.CommandType = System.Data.CommandType.StoredProcedure;
                cmdGetResults.Parameters.AddWithValue("@id", Convert.ToInt32(Session["account"]));
                SqlDataReader rdrResults = cmdGetResults.ExecuteReader();

                string str = "";

                // for each record, append to end of literal
                // final result is table of saved results
                while (rdrResults.Read())
                {

                    string quAsked = Convert.ToString(rdrResults["questionsAsked"]);
                    string quRight = Convert.ToString(rdrResults["questionsRight"]);
                    DateTime date = Convert.ToDateTime(rdrResults["date"]);
                    string ss = date.ToString("MMMM, dd yyyy");

                    str += "<div id = '  '>";
                    str += "you got ";
                    str += quRight;
                    str += " out of ";
                    str += quAsked;
                    str += " | Date taken: ";
                    str += ss;
                    str += "</div>";

                }

                litResults.Text = str;

            }

        }
        /*
         * send user to game on click
         */
        protected void btnStartGameClick(object sender, EventArgs e)
        {
            Response.Redirect("CapitalGuesser.aspx");

        }

    }
}