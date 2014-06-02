using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class teacher_ReadDocument : System.Web.UI.Page
{
    protected static Table_Document document = new Table_Document();
    protected static List<Table_DocumentComment> comments = new List<Table_DocumentComment>();
    protected void Page_Load(object sender, EventArgs e)
    {
        Button2.Attributes.Add("onclick", "return confirm('确认删除？');");
        if (!IsPostBack)
        {
            if (Session["type"] == null || Session["type"].ToString() != "教师")
                Response.Redirect("~/Redirect.html");
        }
        if (!IsPostBack)
        {
            DataClassesDataContext data = new DataClassesDataContext();
            var q = from s in data.Table_Document
                    where s.Id == (Int32)Session["document"]
                    select s;
            document = q.First();
            var p = from s in data.Table_DocumentComment
                    where s.DocumentId == document.Id
                    select s;
            comments = p.ToList();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditDocument.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        DataClassesDataContext data = new DataClassesDataContext();
        var q = from s in data.Table_Document
                where s.Id == (Int32)Session["document"]
                select s;
        data.Table_Document.DeleteAllOnSubmit(q);
        data.SubmitChanges();
        Response.Redirect("Document.aspx");
    }
    protected void button1_Click(object sender, EventArgs e)
    {
        if (textbox1.Text.Equals(String.Empty) || textbox2.Text.Equals(String.Empty))
        {
            Label1.Text = "评论内容与验证码不能为空";
            return;
        }
        try
        {
            if (!Request.Cookies["ValiCode"].Value.ToString().Equals(textbox2.Text))
            {
                Label1.Text = "验证码错误";
                return;
            }
            Table_DocumentComment comment = new Table_DocumentComment();
            comment.AccountName = Session["name"].ToString();
            comment.AccountType = Session["type"].ToString();
            comment.Comment = textbox1.Text;
            comment.Date = DateTime.Now;
            comment.DocumentId = (Int32)Session["document"];
            DataClassesDataContext data = new DataClassesDataContext();
            data.Table_DocumentComment.InsertOnSubmit(comment);
            data.SubmitChanges();
            comments.Add(comment);
            textbox1.Text = String.Empty;
            textbox2.Text = String.Empty;
            Label1.Text = String.Empty;

        }
        catch (Exception) { }
    }
}