<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewNicoVideo.aspx.cs" Inherits="VocaVoter.Web.ViewNicoVideo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>NicoNicoDouga Embed</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<h3><a href='<%# CreateNicoUrl(Song.NicoId) %>' target="_blank"><%# Song.Name %></a></h3>

		<script type="text/javascript"
			src='<%# "http://ext.nicovideo.jp/thumb_watch/" + Song.NicoId %>'></script>
    </div>
    </form>
</body>
</html>
