using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace VocaVoter.Web {
	/// <summary>
	/// Summary description for imghandler
	/// </summary>
	public class imghandler : IHttpHandler {

		public void ProcessRequest(HttpContext context) {
			var bytes = File.ReadAllBytes("C:\\DSC00129.jpg");
			context.Response.ContentType = "image/jpeg";
			context.Response.AddHeader("content-disposition", "inline;filename=\"test test.jpg\"");
			context.Response.BinaryWrite(bytes);
		}

		public bool IsReusable {
			get {
				return false;
			}
		}
	}
}