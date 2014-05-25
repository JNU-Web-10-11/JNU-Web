<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Document.aspx.cs" Inherits="admin_Document" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="path">
        当前位置： <a href="Default.aspx">课程选择</a>>><a href="Document.aspx">资料</a>
    </div>
    <asp:ScriptManager ID="ScriptManager" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
    <ContentTemplate>  
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id" DataSourceID="LinqDataSource1" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDeleting="GridView1_RowDeleting" >
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" SortExpression="Id">
            <HeaderStyle Width="100px" HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="Name" HeaderText="标题" SortExpression="Name">
            <HeaderStyle Width="200px" HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="Author" HeaderText="作者" SortExpression="Author">
            <HeaderStyle Width="200px" HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="Date" HeaderText="发表时间" SortExpression="Date">
            <HeaderStyle Width="200px" HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="Class" HeaderText="类别" SortExpression="Class">
            <HeaderStyle Width="100px" HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:CommandField SelectText="进入阅读" ShowSelectButton="True">
            <HeaderStyle Width="100px" HorizontalAlign="Left" />
            </asp:CommandField>
            <asp:CommandField ShowDeleteButton="True" DeleteText="&lt;div id=&quot;de&quot; onclick=&quot;JavaScript:return confirm('确定删除吗？')&quot;&gt;删除&lt;/div&gt; ">
                <HeaderStyle Width="100px" />
            </asp:CommandField>
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="DataClassesDataContext" EntityTypeName="" TableName="Table_Document">
    </asp:LinqDataSource>
        <div class="document">
        <asp:Button Id="Button1" runat="server" Text="撰写资料" CssClass="documentButton" OnClick="Button1_Click"/>
    </div>
    
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


