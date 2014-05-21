<%@ Page Debug="true" ValidateRequest="false" Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditDocument.aspx.cs" Inherits="student_EditDocument" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../script/ckeditor/ckeditor.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="path">
        当前位置： <a href="Default.aspx">课程选择</a>>><a href="Document.aspx">资料</a>>><a href="ReadDocument.aspx">阅读</a>>><a href="EditDocument.aspx">编辑</a>
    </div>
    <div class="document">
        标题： 
        <asp:TextBox ID="Textbox1" runat="server" />
        <br />
        类别： 
        <asp:TextBox ID="Textbox2" runat="server" />
        <textarea class="ckeditor" name="editor1" runat="server" id="textarea1"></textarea>
        <asp:Button ID="Button1" runat="server" Text="保存" CssClass="documentButton" OnClick="Button1_Click" />
    </div>
</asp:Content>

