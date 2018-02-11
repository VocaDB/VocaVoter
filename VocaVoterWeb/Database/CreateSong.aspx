<%@ Page Title="" Language="C#" MasterPageFile="~/VocaVoter.Master" AutoEventWireup="true" CodeBehind="CreateSong.aspx.cs" Inherits="VocaVoter.Web.Database.CreateSong" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

	<asp:HyperLink runat="server" CssClass="successMsg" Visible='<%# CreatedSuccessfully %>' NavigateUrl='<%# CreatedSuccessfully ? PageMapper.CreateSongDetailsUrl(CreatedSong.Id) : "#" %>' Text="Song added successfully!" />

	<asp:Label runat="server" CssClass="errorMsg" Visible='<%# CreatedSuccessfully %>' Text="Unable to add the song" />

	<table>
		<tr>
			<td>Japanese name:</td>
			<td><asp:TextBox runat="server" ID="nameBox" MaxLength="255" Columns="50" /></td>
		</tr>
		<tr>
			<td>NicoNicoDouga ID:</td>
			<td><asp:TextBox runat="server" ID="nicoIdBox" MaxLength="64" /></td>
		</tr>
		<tr>
			<td>Album:</td>
			<td><asp:DropDownList runat="server" ID="albumList" DataTextField="Name" DataValueField="Id" DataSource='<%# Albums %>' /></td>
		</tr>
		<tr>
			<td>Vocaloid:</td>
			<td><asp:DropDownList runat="server" ID="vocaloidList" DataTextField="Name" DataValueField="Id" DataSource='<%# Vocaloids %>' /></td>
		</tr>
		<tr>
			<td>Producer:</td>
			<td><asp:DropDownList runat="server" ID="producerList" DataTextField="Name" DataValueField="Id" DataSource='<%# Producers %>' /></td>
		</tr>
	</table>

	<asp:Button runat="server" ID="createBtn" Text="Create" OnClick="DoCreateSong" />

</asp:Content>
