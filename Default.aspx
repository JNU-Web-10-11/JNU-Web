<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="info">
        <h2 style="color:#FF9900">【课件管理&资料管理】</h2>
    </div>

    <div class="loginbox">
        <table border="0" cellspacing="10" style="margin:0 auto">
            <tr><td align="left">用户名:</td><td align="left"><asp:TextBox ID="TextBox1" runat="server" /></td></tr>
            <tr><td align="left">密码:</td align="left"><td><asp:TextBox ID="TextBox2" runat="server" TextMode="Password" /></td></tr>
            <tr><td align="left">登陆类型:</td><td align="left"><asp:DropDownList ID="DropDownList1" runat="server"><asp:ListItem>学生</asp:ListItem><asp:ListItem>教师</asp:ListItem>
                <asp:ListItem>管理员</asp:ListItem>
                </asp:DropDownList></td></tr>
            <tr><td align="left"><asp:Button ID="Button1" runat="server" Text="登陆" OnClick="Button1_Click" style="height: 21px"  CssClass="button"/></td></tr>
        </table>        
    </div>
</asp:Content>

