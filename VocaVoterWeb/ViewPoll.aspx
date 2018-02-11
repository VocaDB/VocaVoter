<%@ Page Title="" Language="C#" MasterPageFile="~/VocaVoter.Master" AutoEventWireup="true" 
	CodeBehind="ViewPoll.aspx.cs" Inherits="VocaVoter.Web.ViewPoll" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
	Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Head" ContentPlaceHolderID="HeadContent" runat="server">

	<script language="javascript" type="text/javascript">

		function OpenNicoLink(id) {

			window.open("ViewNicoVideo.aspx?Id=" + id, 'nicoPreview', 'height=500,width=500');

		}
	
	</script>

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">

	<div class="content">

	<h1>Poll: <%# Poll.Name %></h1>
	<p><%# Poll.Description %></p>
	<p>Created: <%# Poll.CreateDate %>, ends: <%# Poll.EndDate %></p>
	<br />

	<div style="<%# "display:" + (HasVoted ? "block" : "none") %>" id="chartDiv">
		<asp:Chart ID="resultChart" runat="server" ImageStorageMode="UseImageLocation" Height="500" Width="700">
			<Series>
				<asp:Series Name="Songs" ChartType="Bar" YValueType="Int32" CustomProperties="DrawingStyle=Cylinder" Palette="SeaGreen">
				</asp:Series>
			</Series>
			<ChartAreas>
				<asp:ChartArea Name="ChartArea">
					<AxisY />
				</asp:ChartArea>
			</ChartAreas>
		</asp:Chart>
	</div>

	<a id="showResults" class="textLink chartLink" onclick='$("#chartDiv").show("slow"); $("#showResults").hide(); return false;' href="#" style='<%# "display:" + (HasVoted ? "none" : "block") %>'>
		Display results
	</a>

	<p class="successMsg" style='<%# "display:" + (JustVoted ? "inline-block" : "none") %>'>Your vote has been added</p>

	<br />

	<table class="grid">
		<asp:Repeater runat="server" DataSource='<%# Poll.Songs.Reverse() %>'><ItemTemplate>
			<tr>
				<td>#<%# Eval("SortIndex") %></td>
				<td><a href='#' onclick='<%# "OpenNicoLink(\"" + Eval("Id") + "\"); return false;" %>'><%# Eval("Name") %></a></td>
				<td>
					<a href='<%# CreateNicoUrl((string)(Eval("NicoId"))) %>' target="_blank"><img src="Res/nico.png" alt="View on NicoNicoDouga" title="View on NicoNicoDouga" /></a>
					<a href='<%# CreateYoutubeSearchUrl((string)(Eval("Name"))) %>' target="_blank"><img src="Res/youtube.png" alt="Search on Youtube" title="Search on Youtube" /></a>
					<a href='<%# PageMapper.CreateSongDetailsUrl((int)Eval("SongId")) %>' class="editTableLink iconLink" title="Details" />
				</td>
				<td><asp:LinkButton runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="AddVote" Visible='<%# CanVote %>' CssClass="acceptLink textLink">Add vote</asp:LinkButton></td>
			</tr>
		</ItemTemplate></asp:Repeater>
	</table>

	</div>

</asp:Content>
