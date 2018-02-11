using System;
using VocaVoter.Model.DataContracts;

namespace VocaVoter.Web {

	public partial class Default : BasePage {

		protected string ActionMessage { get; private set; }

		protected bool HasActionMessage {
			get {
				return !string.IsNullOrEmpty(ActionMessage);
			}
		}

		protected PollContract[] Polls { get; private set; }

		protected bool IsAdmin {
			get {
				return LoginManager.IsAdmin;
			}
		}

		protected void Page_Load(object sender, EventArgs e) {

			ActionMessage = (Request["lastAction"] == "pollCreated") ? "Poll created successfully" : null;
			Polls = Services.Polls.GetActivePolls();

			DataBind();

		}

	}

}