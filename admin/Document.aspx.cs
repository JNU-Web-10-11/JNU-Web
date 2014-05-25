using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Document : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataClassesDataContext data = new DataClassesDataContext();
        var q = from s in data.Table_Document
                where s.Id == Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[0].Text)
                select s;
        data.Table_Document.DeleteAllOnSubmit(q);
        data.SubmitChanges();
        GridView1.DataBind();
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
    
}