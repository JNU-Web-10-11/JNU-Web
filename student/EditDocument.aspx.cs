using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class student_EditDocument : System.Web.UI.Page
{
    protected static Table_Document document = new Table_Document(); 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["type"] == null || Session["type"].ToString() != "学生")
                Response.Redirect("~/Redirect.html");
        }
        if (!IsPostBack)
        {
            if (Session["document"] != null)
            {
                DataClassesDataContext data = new DataClassesDataContext();
                var q = from s in data.Table_Document
                        where s.Id == (Int32)Session["document"]
                        select s;
                document = q.First();
                Textbox1.Text = document.Name;
                textarea1.Value = document.Body;
                Textbox2.Text = document.Class;
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Textbox1.Text == "" || textarea1.Value == "")
        {
            Response.Write("<script>alert('标题和正文不能为空！')</script>");
            return;
        }
        if (Session["document"] != null)
        {
            DataClassesDataContext data = new DataClassesDataContext();
            var q = from s in data.Table_Document
                    where s.Id == document.Id
                    select s;
            foreach (Table_Document c in q)
            {
                c.Name = Textbox1.Text;
                c.Body = textarea1.Value;
                c.Date = DateTime.Now;
                c.Class = Textbox2.Text;
                c.Status = 0;
            }

            data.SubmitChanges();
            Response.Redirect("ReadDocument.aspx");
        }
        else
        {
            DataClassesDataContext data = new DataClassesDataContext();
            Table_Document c = new Table_Document();
            c.Author = Session["name"].ToString();
            c.Body = textarea1.Value;
            c.Class = Textbox2.Text;
            c.Course = Session["course"].ToString();
            c.Date = DateTime.Now;
            c.Name = Textbox1.Text;
            c.Status = 0;
            data.Table_Document.InsertOnSubmit(c);
            data.SubmitChanges();
            DataClassesDataContext d = new DataClassesDataContext();
            var q = (from s in d.Table_Document
                     where s.Author == Session["name"].ToString()
                     select s.Id).Max();
            Session["document"] = q;
            Response.Redirect("ReadDocument.aspx");
        }
    }
}