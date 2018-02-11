using System;
using System.Web;

namespace VocaVoter.Web
{
	public partial class VocaVoter : System.Web.UI.MasterPage
	{

		protected string RootUrl {
			get {
				return Request.ApplicationPath;
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{

			if (!IsPostBack)
				rootLink.DataBind();

		}
	}
}