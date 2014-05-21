using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class student_Document : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        
        
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
        Session["document"] = Convert.ToInt32(GridView2.SelectedRow.Cells[0].Text);
        Response.Redirect("ReadDocument.aspx");
    }
}