<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="ResolucionExamenParcial14.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <address>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </address>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    <br />
    <asp:Label ID="Label1" runat="server" Text="----"></asp:Label>
    <br />
</asp:Content>
