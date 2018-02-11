<%@ Page Title="" Language="C#" MasterPageFile="~/VocaVoter.Master" AutoEventWireup="true" CodeBehind="ListArtists.aspx.cs" 
	Inherits="VocaVoter.Web.Database.ListArtists" %>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">

	<h1>List of artists</h1>
	
	<table class="grid">
		<asp:Repeater runat="server" ID="artistRepeater" DataSource='<%# Artists %>'><ItemTemplate>
			<tr>
				<td>
					<a><%# Eval("Name") %></a><br />
					<span class="extraInfo"><%# Eval("AdditionalNames") %></span>
				</td>
				<td>
					<!--<a class="editTableLink iconLink" href='<%# "ArtistDetails.aspx?artistId=" + Eval("Id") %>' title="Details"></a>-->
				</td>
			</tr>
		</ItemTemplate></asp:Repeater>
	</table>

</asp:Content>
