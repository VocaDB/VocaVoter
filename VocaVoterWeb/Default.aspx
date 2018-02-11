<%@ Page Title="" Language="C#" MasterPageFile="~/VocaVoter.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" 
	Inherits="VocaVoter.Web.Default" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">

	<div class="content">

	<asp:Label runat="server" CssClass="successMsg" Text='<%# ActionMessage %>' Visible='<%# HasActionMessage %>' />

	<h1>Vocaloid poll and database service</h1>

	<asp:PlaceHolder runat="server" ID="adminPanel" Visible='<%# IsAdmin %>' >
		<h2>Admin</h2>
		<a href="CreateWVRPoll.aspx">Create Weekly Vocaloid Ranking Poll</a>
	</asp:PlaceHolder>

	<h2>Active polls</h2>
	<ul>
		<asp:Repeater runat="server" DataSource='<%# Polls %>'><ItemTemplate>
			<li><a class="chartLink textLink" href='<%# "ViewPoll.aspx?pollId=" + Eval("Id") %>'><%# Eval("Name") %></a></li>
		</ItemTemplate></asp:Repeater>
	</ul>

	<h2>Database</h2>
	<ul>
		<li><a class="textLink databaseLink" href="ListPolls.aspx">List of polls</a></li>
		<li><a class="textLink databaseLink" href="ListSongs.aspx">List of songs</a></li>
	</ul>

	<br />
	<p>This site uses icons from <a href="http://www.famfamfam.com/">FamFamFam</a>.</p>

	</div>

</asp:Content>