using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASSIGNMENT5.Guest
{
    public partial class Login : System.Web.UI.Page
    {
        DB db = new DB();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM tbl_Login WHERE Username='" + uname.Text + "' AND Password='" + pswd.Text + "'";
            DataTable dtobj = db.Executedatatable(sql);

            if (dtobj.Rows.Count == 1)
            {

                Session["uid"] = dtobj.Rows[0]["Login_id"];
                Session["uname"] = dtobj.Rows[0]["Username"].ToString();
                string a = dtobj.Rows[0]["Role"].ToString().Trim();

                if (a == "admin")
                {
                    Response.Write("<script>alert('Admin Login ')</script>");
                    Response.Redirect("../admin/adminhome.aspx");
                }
                else
                {
                    string c = dtobj.Rows[0]["Status"].ToString().Trim();
                    if (c == "Confirmed")
                    {
                        Response.Write("<script>alert('Successfully logged in')</script>");
                        Response.Redirect("../User/profileview.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Failed to login')</script>");
                        Response.Redirect("../Guest/Login.aspx");
                    }


                }
            }
        }
    }
}