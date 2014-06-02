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
    <!-- 评论板块 -->
    <hr align="center" width="90%" />
    <asp:ScriptManager ID="ScriptManager1" runat="server" ></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div  style="width:400px;margin-left:50px;word-break:break-all">

    <strong><%=document.Name+"的评论：" %></strong><br />
    <%
        if (comments.Count()==0)
        {
            %>（暂无任何评论）<%
            
        }
        else
        {
            int i = 1;
            foreach (Table_DocumentComment c in comments)
            {
                %><%=i.ToString() + ". " + c.AccountName + "【" + c.AccountType + "】" %><br />&nbsp;&nbsp;<%=c.Comment %>&nbsp;&nbsp;<div align="right" style="font-size:small"><%=c.Date.ToString()%></div>
                <hr  width="95%" />
                <%
                i++;
            }
        }
        %>
    </div>
    <div  style="width:400px;margin-left:50px">
    <br /><br />
    <strong>发表评论</strong><br />
    称呼:
    <%
        if (Session["name"] == null)
        {
            %>
            游客（未登录）
            <%
        }
        else
        {
            %>
            <%=Session["name"] + "【" + Session["type"] + "】"%>
            <%
        }
         %>
    <br />
    内容:<br />
    <asp:TextBox ID="textbox1" runat="server" TextMode="MultiLine" Columns="70" Rows="10" MaxLength="1000"/><br />
    
    验证码：
    <asp:TextBox id="textbox2" runat="server" Columns="2" MaxLength="4"/>
    <asp:Image ID="ValiCode" runat="server" ImageUrl="../ValiCode.aspx"  />
    <br />
    <asp:Button ID="button3" Width="60px" runat="server" Text="评论" onclick="button1_Click" CssClass="button"/>
    <asp:Label ID="Label1" runat="server"  ForeColor="Red" />
    </div>
    <br /><br /><br />
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

