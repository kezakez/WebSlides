using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServerUpdate.Models;
using System.Web.Script.Serialization;

namespace ServerUpdate.Controllers
{
    [HandleError]
    public class FollowerController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Events()
        {
            ServerSentEventResult eventStream = new ServerSentEventResult();

            Follower followerModel = new Follower();
            eventStream.Version = followerModel.Version;
            eventStream.Content = () =>
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                return serializer.Serialize(followerModel);
            };

            return eventStream;
        }
    }

    

    public class ServerSentEventResult : ActionResult
    {
        public ServerSentEventResult()
        {
        }

        public delegate string GetContent();

        public GetContent Content { get; set; }

        public int Version { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (this.Content != null)
            {
                HttpResponseBase response = context.HttpContext.Response;
                // this is the content type required by chrome 6 for server sent events
                response.ContentType = "text/event-stream";
                response.BufferOutput = false;
                // this is important because chrome fails with a "failed to load resource" error if the server attempts to put the char set after the content type
                response.Charset = null;

                string[] newStrings = context.HttpContext.Request.Headers.GetValues("Last-Event-ID");
                if (newStrings == null || newStrings[0] != this.Version.ToString())
                {
                    string value = this.Content();

                    response.Write(string.Format("data:{0}\n", value));
                    response.Write(string.Format("id:{0}\n", this.Version));
                } else {
                    response.Write("");
                }   
            }
        }
    }
}
