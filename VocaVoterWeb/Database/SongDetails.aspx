<%@ Page Title="" Language="C#" MasterPageFile="~/VocaVoter.Master" AutoEventWireup="true" CodeBehind="SongDetails.aspx.cs" 
	Inherits="VocaVoter.Web.Database.SongDetails" %>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">

	<h1>Details for song <asp:Literal runat="server" Text='<%# SongDetailsContract.Song.Name %>' /></h1>

	<script type="text/javascript" src='<%# "http://ext.nicovideo.jp/thumb_watch/" + SongDetailsContract.Song.NicoId %>'></script>

	<!--<h2>Metadata</h2>-->
	<h2>Entry information</h2>
	<table>
		<tr>
			<td>Full name:</td>
			<td><%# SongDetailsContract.Song.Name %></td>
		</tr>
		<tr>
			<td>Entry added:</td>
			<td><%# SongDetailsContract.Song.CreateDate %></td>
		</tr>
		<tr>
			<td>NicoNicoDouga ID:</td>
			<td><a href='<%# CreateNicoUrl(SongDetailsContract.Song.NicoId) %>'><%# SongDetailsContract.Song.NicoId %></a></td>
		</tr>
	</table>

	<h2>WVR rankings placements</h2>
	<table class="grid">
	<tr>
		<th>Ranking</th>
		<th colspan="2">Placement</th>
	</tr>
	<asp:Repeater runat="server" ID="placementRepeater" DataSource='<%# SongDetailsContract.WVRPlacements %>'><ItemTemplate>
		<tr>
			<td><a href='<%# "../ViewPoll.aspx?pollId=" + Eval("PollId") %>'><%# Eval("PollName") %></a></td>
			<td><%# Eval("SortIndex") %></td>
			<td>
				<img src="../Res/vbar_blue.png" height="15" width='<%# ((31 - (int)Eval("SortIndex")) * 200 / 30) %>' alt='' />
				<img src="../Res/vbar_white.png" height="15" width='<%# (((int)Eval("SortIndex") - 1) * 200 / 30) %>' alt='' />				
			</td>
		</tr>
	</ItemTemplate></asp:Repeater>
	</table>

</asp:Content>
