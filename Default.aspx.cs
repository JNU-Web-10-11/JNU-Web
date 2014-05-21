using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataClassesDataContext data = new DataClassesDataContext();
        if (DropDownList1.SelectedIndex == 0)
        {
            var q = from s in data.Table_Student
                    where s.Id == TextBox1.Text && s.Password == TextBox2.Text
                    select s;
            if (q.Count() == 0)
                Response.Write("<script>alert('学生不存在或密码错误')</script>");
            else
            {
                Session["name"] = q.First().Id;
                Session["type"] = "学生";
                Response.Redirect("student/Default.aspx");
            }

        }
        else if (DropDownList1.SelectedIndex == 1)
        {
            var q = from s in data.Table_Teacher
                    where s.Id == TextBox1.Text && s.Password == TextBox2.Text
                    select s;
            if (q.Count() == 0)
                Response.Write("<script>alert('教师不存在或密码错误')</script>");
            else
            {
                Session["name"] = q.First().Id;
                Session["type"] = "教师";
                Response.Redirect("teacher/Default.aspx");
            }
        }
        else
        {
            var q = from s in data.Table_Admin
                    where s.Id == TextBox1.Text && s.Password == TextBox2.Text
                    select s;
            if (q.Count() == 0)
                Response.Write("<script>alert('管理员不存在或密码错误')</script>");
            else
            {
                Session["name"] = q.First().Id;
                Session["type"] = "管理员";
                Response.Redirect("admin/Default.aspx");
            }
        }
    }
}