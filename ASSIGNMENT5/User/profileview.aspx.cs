using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASSIGNMENT5.User
{
    public partial class profileview : System.Web.UI.Page
    {
        DB db = new DB();
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = db.Executedataset("select * from tbl_employee where Login_id='" + Session["uid"] + "'");
            GridView1.DataBind();

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string _id = GridView1.DataKeys[e.RowIndex].Value.ToString();
            db.Executenonquery("delete from tbl_employee where EmployeeId='" + _id + "'");
            GridView1.DataSource = db.Executenonquery("select * from tbl_employee where Login_id='" + Session["uid"] + "'");
            GridView1.DataBind();

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataSource = db.Executedataset("select * from tbl_employee where Login_id='" + Session["uid"] + "'");
            GridView1.DataBind();

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string EmployeeId = GridView1.DataKeys[e.RowIndex].Value.ToString();

            TextBox txtname = new TextBox();
            txtname = (TextBox)GridView1.Rows[e.RowIndex].Cells[0].Controls[0];
            TextBox txtemail = new TextBox();
            txtemail = (TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0];
            TextBox txtphone = new TextBox();
            txtphone = (TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0];
            TextBox txtage = new TextBox();
            txtage = (TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0];


            db.Executenonquery("update tbl_employee set Name='" + txtname.Text + "',Email='" + txtemail.Text + "',Phone='" + txtphone.Text + "',Age='" + txtage.Text + "' where EmployeeId='" + EmployeeId + "'");

            GridView1.EditIndex = -1;
            GridView1.DataSource = db.Executedataset("select * from tbl_employee where Login_id='" + Session["uid"] + "'");
            GridView1.DataBind();

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridView1.DataSource = db.Executedataset("select * from tbl_employee where Login_id='" + Session["uid"] + "'");
            GridView1.DataBind();
        }
    }
}