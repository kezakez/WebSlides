<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
    <script type="text/javascript" src="../../Scripts/jquery-1.4.1.min.js"></script>
    <script type="text/javascript">
        $(function () {
            var serverEvent = new EventSource("/events");
            serverEvent.onmessage = function (event) {
                var slideNumber = $.parseJSON(event.data).PageNumber;
                var fileName = "Slide" + slideNumber + ".png";
                var img = new Image
                img.src = "../../Slides/" + fileName;
                img.alt = "slides";
                $("#slides").empty();
                $("#slides").append(img);
            };
        });
    </script>
    <div id="slides">
        <img id="slide-image" src="../../Slides/Slide1.PNG" alt="slides" />
    </div>
