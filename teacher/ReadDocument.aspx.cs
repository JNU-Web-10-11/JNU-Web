using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class teacher_ReadDocument : System.Web.UI.Page
{
    protected static Table_Document document = new Table_Document();
    protected void Page_Load(object sender, EventArgs e)
    {
        Button2.Attributes.Add("onclick", "return confirm('确认删除？');");
        if (!IsPostBack)
        {
            DataClassesDataContext data = new DataClassesDataContext();
            var q = from s in data.Table_Document
                    where s.Id == (Int32)Session["document"]
                    select s;
            document = q.First();

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
}