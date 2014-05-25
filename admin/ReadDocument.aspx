<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReadDocument.aspx.cs" Inherits="admin_ReadDocument" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="path">
        当前位置： <a href="Default.aspx">课程选择</a>>><a href="Document.aspx">资料</a>>><a href="ReadDocument.aspx">阅读</a>
    </div>
    <div class="document">
        <h2><%=document.Name %></h2>
        <asp:Button ID="Button1" runat="server" Text="删除" CssClass="documentButton" OnClick="Button1_Click" />
        <br /><br />
        
        <span class="documentInfo">作者【<%=document.Author %>】</span>
        <span class="documentInfo">发表时间【<%=document.Date.ToString() %>】</span>
        <span class="documentInfo">类别【<%=document.Class %>】</span>
        <span class="documentInfo">审核状态【<%=document.Status==1?"已审核":"未审核" %>】</span>
        <br />
        <div class="documentBody"><%=document.Body %></div>
    </div>
</asp:Content>

