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
        if (!IsPostBack)
        {
            if (Session["type"] == null || Session["type"].ToString() != "管理员")
                Response.Redirect("~/Redirect.html");
        }
      
    }
    
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["document"] = Convert.ToInt32(GridView1.SelectedRow.Cells[0].Text);
        Response.Redirect("ReadDocument.aspx");
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
             if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                ((LinkButton)e.Row.Cells[6].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('确认删除：\"" + e.Row.Cells[1].Text + "\"吗?')");
            }
        }
    }
}