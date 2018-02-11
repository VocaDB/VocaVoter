using System;
using System.Collections.Generic;
using System.Linq;
using VocaVoter.Model.Domain.Artists;
using VocaVoter.Model.Domain.Globalization;

namespace VocaVoter.Model.Domain.Songs {

	public class Song {

		private IList<SongInAlbum> albums = new List<SongInAlbum>();
		private IList<ArtistForSong> artists = new List<ArtistForSong>();
		private IList<SongMetadataEntry> metadata = new List<SongMetadataEntry>();
		private LocalizedString name;

		protected IEnumerable<Artist> ArtistList {
			get {
				return Artists.Select(a => a.Artist);
			}
		}

		public Song() {
			ArtistString = string.Empty;
			CreateDate = DateTime.Now;
			LocalizedName = new LocalizedString();
		}

		public Song(LocalizedString localizedName, string nicoId)
			: this() {

			LocalizedName = localizedName;
			NicoId = nicoId;

		}

		public virtual IList<SongInAlbum> Albums {
			get { return albums; }
			set {
				ParamIs.NotNull(value, "value");
				albums = value;
			}
		}

		public virtual IList<ArtistForSong> Artists {
			get { return artists; }
			set {
				ParamIs.NotNull(value, "value");
				artists = value;
			}
		}

		public virtual string ArtistString { get; private set; }

		public virtual DateTime CreateDate { get; private set; }

		public virtual int Id { get; set; }

		public virtual IList<SongMetadataEntry> Metadata {
			get { return metadata; }
			set {
				ParamIs.NotNull(value, "value");
				metadata = value;
			}
		}

		public virtual string Name {
			get {
				return LocalizedName.Current;
			}
			set {
				ParamIs.NotNull(value, "value");
				LocalizedName.Current = value;
			}
		}

		public virtual LocalizedString LocalizedName {
			get { return name; }
			set {
				ParamIs.NotNull(value, "value");
				name = value;
			}
		}

		/// <summary>
		/// NicoNicoDouga Id for the PV (for example sm12850213). Is unique, but can be null.
		/// </summary>
		public virtual string NicoId { get; set; }

		public virtual string URL { get; set; }

		public virtual SongInAlbum AddAlbum(Album album, int trackNumber) {

			var link = new SongInAlbum(this, album, trackNumber);
			Albums.Add(link);
			return link;

		}

		public virtual ArtistForSong AddArtist(Artist artist) {

			var link = new ArtistForSong(this, artist);
			Artists.Add(link);
			return link;

		}

		public virtual bool HasArtist(Artist artist) {

			return ArtistList.Contains(artist);

		}

		public virtual void UpdateArtistString() {

			var producers = ArtistList.Where(a => a.ArtistType == ArtistType.Producer).Select(m => m.Name);
			var performers = ArtistList.Where(a => a.ArtistType == ArtistType.Performer).Select(m => m.Name);

			if (producers.Any() && performers.Any())
				ArtistString = string.Format("{0} feat. {1}", string.Join(", ", producers), string.Join(", ", performers));
			else
				ArtistString = string.Join(", ", ArtistList.Select(m => m.Name));

		}

	}

}
