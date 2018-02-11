using System;
using VocaVoter.Model.DataContracts;

namespace VocaVoter.Web {

	public partial class ListPolls : BasePage {

		protected PollContract[] Polls { get; private set; }

		private void LoadPolls() {

			Polls = Services.Polls.GetPolls();
			DataBind();

		}

		protected void Page_Load(object sender, EventArgs e) {

			if (!IsPostBack)
				LoadPolls();

		}

	}

}