using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASSIGNMENT5.Guest
{
    public partial class Userreg : System.Web.UI.Page
    {
        DB db = new DB();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            object ob = db.Executescalar("insert into tbl_Login values('" + uname.Text + "','" + pswd.Text + "','user','not confirmed');select @@IDENTITY");
            db.dbclose();
            if (ob.ToString() != null)
            {
                int i = db.Executenonquery("insert into tbl_employee values('" + name.Text + "','" + mail.Text + "','" + phone.Text + "','" + age.Text + "'," + ob + ")");
                db.dbclose();
                if (i == 1)
                {
                    Response.Write("<script>alert('User Registered Successfully');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Faild');</script>");
                }
            }

        }
    }
}