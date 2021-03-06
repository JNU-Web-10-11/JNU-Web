﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class student_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["type"] == null || Session["type"].ToString() != "学生")
                Response.Redirect("~/Redirect.html");
        }
    }
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