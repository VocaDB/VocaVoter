using System;
using VocaVoter.Model.DataContracts.UseCases;

namespace VocaVoter.Web.Database {

	public partial class SongDetails : BasePage {

		protected SongDetailsContract SongDetailsContract { get; private set; }

		private int SongId {
			get {
				return RequestParser.GetIntFromRequest("songId");
			}
		}

		private void LoadSong() {

			SongDetailsContract = Services.Songs.GetSongDetails(SongId);
			DataBind();

		}

		protected void Page_Load(object sender, EventArgs e) {

			if (!IsPostBack)
				LoadSong();

		}
	}
}