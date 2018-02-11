<%@ Page Title="" Language="C#" MasterPageFile="~/VocaVoter.Master" AutoEventWireup="true" 
	CodeBehind="ListSongs.aspx.cs" Inherits="VocaVoter.Web.ListSongs" %>
<%@ Register Assembly="ASPnetPagerV2_8, Version=2.8.3994.41724"
	Namespace="ASPnetControls" TagPrefix="pager" %>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">

	<h1>List of songs</h1>

	<p>
		Filter: 
		<asp:TextBox runat="server" ID="nameFilterBox" MaxLength="255" /> 
		<asp:LinkButton runat="server" ID="searchBtn" Text="Update" OnClick="Search" />
		<a href="ListSongs.aspx">Clear search</a>
	</p>

	<pager:PagerV2_8 runat="server" ID="dataPagerTop" CurrentIndex='<%# PageIndex %>' PageSize='<%# PageSize %>' 
		ItemCount='<%# SongCount %>' OnCommand="ChangePage" />

	<table class="grid">
		<asp:Repeater runat="server" ID="songRepeater" DataSource='<%# Songs %>'><ItemTemplate>
			<tr>
				<td>
					<a><%# Eval("Name") %></a>
				</td>
				<td>
					<a class="nicoLink iconLink" href='<%# CreateNicoUrl((string)Eval("NicoId")) %>' />
					<a class="editTableLink textLink" href="#" onclick="return false;" title="Edit song metadata">Edit data</a>
					<a class="editTableLink iconLink" href='<%# "Database/SongDetails.aspx?songId=" + Eval("Id") %>' title="Details"></a>
				</td>
			</tr>
		</ItemTemplate></asp:Repeater>
	</table>

	<pager:PagerV2_8 runat="server" ID="dataPagerBottom" CurrentIndex='<%# PageIndex %>' PageSize='<%# PageSize %>' 
		ItemCount='<%# SongCount %>' OnCommand="ChangePage" />

</asp:Content>
