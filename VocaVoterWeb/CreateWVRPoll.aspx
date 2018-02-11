<%@ Page Title="" Language="C#" MasterPageFile="~/VocaVoter.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="CreateWVRPoll.aspx.cs" 
	Inherits="VocaVoter.Web.CreatePoll" %>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">

	<h1>Create poll</h1>

	<h2>Import ranking from Vocaloidism.com</h2>

	<p>Next WVR number: <asp:TextBox runat="server" ID="wvrIdBox" /> <asp:Button runat="server" ID="discoverBtn" Text="Discover from RSS" /></p>

	<p>Import from article at URL: <asp:TextBox runat="server" ID="articleUrlBox" Columns="50" /> <asp:Button runat="server" ID="importBtn" Text="Import" OnClick="ImportFromArticle" /></p>

	<asp:Label runat="server" CssClass="successMsg" Visible='<%# ImportedSuccessfully %>' Text="Song list imported successfully!" />
	<br />

	<h2>Poll settings</h2>

	<table>
		<tr>
			<td>Name:</td>
			<td><asp:TextBox runat="server" ID="pollNameBox" Columns="50" /></td>
		</tr>
	</table>

	<h2>Song list</h2>

	Format: order|name|NicoId - One song per line
	<br />

	<asp:TextBox runat="server" ID="songList" TextMode="MultiLine" Columns="80" Rows="35" />
	<br />

	<asp:Button runat="server" OnClick="AcceptPoll" Text="Create poll" />

</asp:Content>

