using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateCapitalsQuiz
{
    public partial class AccountLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // get user information
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            string dbConnect = ConfigurationManager.ConnectionStrings["db"].ConnectionString;

            // connect to database to find user's account
            using (SqlConnection newConn = new SqlConnection(dbConnect))
            {
                newConn.Open();

                // find if email exists in database
                SqlCommand cmdEmailMatch = new SqlCommand("dbo.checkForEmail", newConn);
                cmdEmailMatch.CommandType = System.Data.CommandType.StoredProcedure;
                cmdEmailMatch.Parameters.AddWithValue("@email", email);

                int emailMatch = Convert.ToInt32(cmdEmailMatch.ExecuteScalar());

                if (emailMatch == 1)
                {
                    // match email and password

                    SqlCommand cmdCredentialMatch = new SqlCommand("dbo.credentialMatch", newConn);
                    cmdCredentialMatch.CommandType = System.Data.CommandType.StoredProcedure;
                    cmdCredentialMatch.Parameters.AddWithValue("@email", email);
                    cmdCredentialMatch.Parameters.AddWithValue("@password", password);
                    SqlDataReader rdrAccount = cmdCredentialMatch.ExecuteReader();

                    int accountID = 0;

                    while (rdrAccount.Read())
                    {
                        accountID = Convert.ToInt32(rdrAccount["accountID"]);
                    }

                    if (accountID != 0)
                    {
                        // create session and redirect
                        Session["account"] = accountID;
                        

                        // end the user to the dashboard);
                        litMessage.Text = "Login Worked";
                        Response.Redirect("Dashboard.aspx");
                    }
                    else
                    {
                        // If their email does not match the password stored
                        litMessage.Text = "Incorrect credentials.";
                    }

                }
                else
                {
                    // user entered email that is not in the database
                    litMessage.Text = "Email does not exist.";

                }

            }

        }

        protected void btnGoToCreateAccount(object sender, EventArgs e)
        {
            Response.Redirect("CreateAccount.aspx");
        }
    }

 }
