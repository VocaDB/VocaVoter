using System;
using VocaVoter.Model.DataContracts;

namespace VocaVoter.Web {

	public partial class ViewNicoVideo : BasePage {


		protected SongInPollContract Song { get; private set; }

		protected void Page_Load(object sender, EventArgs e) {

			var id = RequestParser.GetIntFromRequest("Id");
			Song = Services.Polls.GetSongInPoll(id);

			DataBind();

		}

	}
}