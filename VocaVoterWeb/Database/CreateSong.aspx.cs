using System;
using System.Linq;
using VocaVoter.Model.DataContracts.Songs;
using VocaVoter.Model.DataContracts.UseCases;
using VocaVoter.Model.Domain.Artists;
using VocaVoter.Model.Domain.Songs;
using VocaVoter.Model.Service;

namespace VocaVoter.Web.Database {

	public partial class CreateSong : BasePage {

		protected AlbumContract[] Albums { get; private set; }

		protected SongContract CreatedSong { get; private set; }

		protected bool CreatedSuccessfully {
			get {
				return (CreatedSong != null);
			}
		}

		protected string ErrorMsg { get; private set; }

		protected bool HasErrors {
			get {
				return !string.IsNullOrEmpty(ErrorMsg);
			}
		}

		protected ArtistContract[] Producers { get; private set; }

		protected ArtistContract[] Vocaloids { get; private set; }

		private readonly AlbumContract unknownAlbum = new AlbumContract { Name = "Unknown", Id = -1 };

		private readonly ArtistContract unknownArtist = new ArtistContract { Name = "Unknown", Id = -1 };

		private void LoadArtists() {

			var albums = Services.Songs.GetAlbums();
			Albums = new[] { unknownAlbum }.Concat(albums).ToArray();

			var allArtists = Services.Songs.GetArtists();

			Producers = new[] { unknownArtist }.Concat(allArtists.Where(a => a.ArtistType == ArtistType.Producer)).ToArray();
			Vocaloids = new[] { unknownArtist }.Concat(allArtists.Where(a => a.ArtistType == ArtistType.Performer)).ToArray();

			DataBind();

		}

		protected void Page_Load(object sender, EventArgs e) {

			ErrorMsg = null;

			if (!IsPostBack)
				LoadArtists();

		}

		protected void DoCreateSong(object sender, EventArgs e) {

			string name = nameBox.Text;
			string nicoId = nicoIdBox.Text;
			int albumId = int.Parse(albumList.SelectedValue);
			int producerId = int.Parse(producerList.SelectedValue);
			int vocaloidId = int.Parse(vocaloidList.SelectedValue);

			if (name == string.Empty) {
				ErrorMsg = "Name cannot be empty";
			}

			if (HasErrors) {
				DataBind();
				return;
			}

			var song = new CreateSongContract {
				BasicData = new SongContract {
					Name = name,
					NicoId = nicoId
				},
				AlbumId = albumId,
				ProducerId = producerId,
				PerformerId = vocaloidId
			};

			try {
				CreatedSong = Services.Songs.CreateSong(song);
				DataBind();
			} catch (ServiceException x) {
				ErrorMsg = x.Message;
				DataBind();
				return;
			}

		}

	}
}