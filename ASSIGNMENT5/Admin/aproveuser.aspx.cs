using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASSIGNMENT5.Admin
{
    public partial class aproveuser : System.Web.UI.Page
    {
        DB db = new DB();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataSource = db.Executedataset("select * from tbl_employee e inner join tbl_Login l on e.Login_id=l.Login_id");
                GridView1.DataBind();

                GridView2.DataSource = db.Executedataset("select * from tbl_employee e inner join tbl_Login l on e.Login_id=l.Login_id");
                GridView2.DataBind();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();
            db.Executenonquery("update tbl_Login set Status='Confirmed' where Login_id='" + id + "'");
            GridView1.DataSource = db.Executedataset("select * from tbl_employee e inner join tbl_Login l on e.Login_id=l.Login_id");
            GridView1.DataBind();

        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = GridView2.DataKeys[e.RowIndex].Value.ToString();
            db.Executenonquery("update tbl_Login set Status='Blocked' where Login_id='" + id + "'");
            GridView2.DataSource = db.Executedataset("select * from tbl_employee e inner join tbl_Login l on e.Login_id=l.Login_id");
            GridView2.DataBind();
        }
    }
}