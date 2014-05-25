using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /*protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //应该加是否删除提醒
        DataClassesDataContext data = new DataClassesDataContext();
        var q = from s in data.Table_Course_Setup
                where s.Course == GridView1.Rows[e.RowIndex].Cells[0].Text && s.Teacher == GridView1.Rows[e.RowIndex].Cells[2].Text
                select s;
        data.Table_Course_Setup.DeleteAllOnSubmit(q);
        data.SubmitChanges();
        GridView1.DataBind();
    }*/
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //在此加入课件页面的链接
        Response.Redirect("#");
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Session["course"] = GridView1.Rows[e.RowIndex].Cells[0].Text;
        Response.Redirect("Document.aspx");
    }
}