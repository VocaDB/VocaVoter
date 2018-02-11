using System;
using VocaVoter.Model.DataContracts.Songs;

namespace VocaVoter.Web.Database {

	public partial class ListArtists : BasePage {

		protected ArtistWithAdditionalNamesContract[] Artists {
			get {
				return Services.Songs.GetArtistsWithAdditionalNames();
			}
		}

		protected void Page_Load(object sender, EventArgs e) {

			DataBind();

		}
	}
}