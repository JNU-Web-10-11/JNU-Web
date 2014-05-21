<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="student_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="path">
        当前位置： <a href="Default.aspx">课程选择</a>
    </div>
    <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="False" CellPadding="4" DataSourceID="LinqDataSource1" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDeleting="GridView1_RowDeleting">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    <Columns>
        <asp:BoundField DataField="Course" HeaderText="课程" ReadOnly="True" SortExpression="Course" >
        <HeaderStyle Width="400px" />
        </asp:BoundField>
        <asp:BoundField DataField="Teacher" HeaderText="教师" ReadOnly="True" SortExpression="Teacher" >
        <HeaderStyle Width="400px" />
        </asp:BoundField>
        <asp:CommandField ShowSelectButton="True" SelectText="进入课件">
        <HeaderStyle Width="100px" />
        </asp:CommandField>
        <asp:CommandField DeleteText="进入资料" ShowDeleteButton="True">
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

<asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="DataClassesDataContext" EntityTypeName="" Select="new (Course, Teacher)" TableName="Table_Course_Select" Where="Student == @Student">
    <WhereParameters>
        <asp:SessionParameter DefaultValue="" Name="Student" SessionField="name" Type="String" />
    </WhereParameters>
</asp:LinqDataSource>

</asp:Content>

