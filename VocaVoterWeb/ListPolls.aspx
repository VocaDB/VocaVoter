<%@ Page Title="" Language="C#" MasterPageFile="~/VocaVoter.Master" AutoEventWireup="true" CodeBehind="ListPolls.aspx.cs" Inherits="VocaVoter.Web.ListPolls" %>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">

	<h1>List of polls</h1>

	<ul>
		<asp:Repeater runat="server" DataSource='<%# Polls %>'><ItemTemplate>
			<li><a class="chartLink textLink" href='<%# "ViewPoll.aspx?pollId=" + Eval("Id") %>'><%# Eval("Name") %></a></li>
		</ItemTemplate></asp:Repeater>
	</ul>

</asp:Content>
