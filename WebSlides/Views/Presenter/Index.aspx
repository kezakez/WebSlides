<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ServerUpdate.Models.Follower>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Presenter
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript" src="../../Scripts/jquery-1.4.1.min.js"></script>
<script type="text/javascript">
    $(function () {
        $("#previous").click(function () {
            $.post('/Presenter/Previous');
        });
        $("#next").click(function () {
            $.post('/Presenter/Next');
        });
    });
</script>
<div id="presenter-panel">
    <div id="presenter-buttons">
	    <a id="previous" href="#">< previous</a>
	    <a id="next" href="#">next ></a>
    </div>
</div>
<div id="presenter-slides">
<% Html.RenderPartial("Slides"); %>
</div>
</asp:Content>
