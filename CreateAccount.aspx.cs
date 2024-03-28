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
    public partial class CreateAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSubmitClick(object sender, EventArgs e)
        {

            // get email and password
            string userEmail = txtEmail.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string passwordCheck = txtPasswordCheck.Text;

            // Make sure user entered password correctly both times

            if (password == passwordCheck)
            {
                // connect to the data base
                string dbConnect = ConfigurationManager.ConnectionStrings["db"].ConnectionString;

                using (SqlConnection newConn = new SqlConnection(dbConnect))
                {
                    newConn.Open();

                    //  Add an a record to the accounts table with the user's input
                    //SqlCommand addMember = new SqlCommand("INSERT INTO Accounts (email, username, password) VALUES( '" + userEmail + "',  '" + username + "', '" + password + "')", newConn);

                    SqlCommand addMember = new SqlCommand("dbo.cpaCreateAccount", newConn);
                    addMember.CommandType = System.Data.CommandType.StoredProcedure;
                    addMember.Parameters.AddWithValue("@email", userEmail);
                    addMember.Parameters.AddWithValue("username", username);
                    addMember.Parameters.AddWithValue("password", password);

                    addMember.ExecuteNonQuery();
                }

                // clear input boxes 
                txtEmail.Text = "";
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtPasswordCheck.Text = "";
                lblError.Text = "";

            }
            else
            {
                lblError.Text = "Your Passwords do not match";
            }

        }
        /* takes user to the login page
         */
        protected void btnGoToLoginClick(object sender, EventArgs e)
        {
            Response.Redirect("AccountLogin.aspx");

        }

    }
}