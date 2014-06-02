using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class teacher_Document : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["type"] == null || Session["type"].ToString() != "教师")
                Response.Redirect("~/Redirect.html");
        }


    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["document"] = Convert.ToInt32(GridView1.SelectedRow.Cells[0].Text);
        Response.Redirect("ReadDocument.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["document"] = null;
        Response.Redirect("EditDocument.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (GridView2.Visible)
            GridView2.Visible = false;
        else
            GridView2.Visible = true;
    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataClassesDataContext data = new DataClassesDataContext();
        var q = from s in data.Table_Document
                where s.Id == Convert.ToInt32(GridView2.SelectedRow.Cells[0].Text)
                select s;
        foreach (Table_Document d in q)
        {
            d.Status = 1;
        }
        data.SubmitChanges();
        GridView1.DataBind();
        GridView2.DataBind();
    }
}