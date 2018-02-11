using System;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using VocaVoter.Model.DataContracts.Songs;
using VocaVoter.Model.DataContracts.UseCases;
using VocaVoter.Model.Domain;
using VocaVoter.Model.Domain.Artists;
using VocaVoter.Model.Domain.Globalization;
using VocaVoter.Model.Domain.Songs;

namespace VocaVoter.Model.Service {

	public class SongService : ServiceBase {

		private T[] GetArtists<T>(Func<Artist, T> func) {

			return HandleQuery(session => session.Linq<Artist>()
				.ToArray()
				.OrderBy(a => a.Name)
				.Select(func)
				.ToArray());

		}

		public SongService(ISessionFactory sessionFactory)
			: base(sessionFactory) {

		}

		public SongContract CreateSong(CreateSongContract contract) {

			return HandleTransaction(session => {

				if (!string.IsNullOrEmpty(contract.BasicData.NicoId)) {

					var existing = session.Linq<Song>().FirstOrDefault(s => s.NicoId == contract.BasicData.NicoId);

					if (existing != null) {
						throw new ServiceException("Song with NicoId '" + contract.BasicData.NicoId + "' has already been added");
					}			
		
				}

				var song = new Song(new LocalizedString(contract.BasicData.Name), contract.BasicData.NicoId);

				if (contract.AlbumId != null)
					song.AddAlbum(session.Load<Album>(contract.AlbumId.Value), 0);

				if (contract.PerformerId != null)
					song.AddArtist(session.Load<Artist>(contract.PerformerId.Value));

				if (contract.ProducerId != null)
					song.AddArtist(session.Load<Artist>(contract.ProducerId.Value));

				song.UpdateArtistString();
				session.Save(song);

				return new SongContract(song);

			});

		}

		public AlbumContract[] GetAlbums() {

			return HandleQuery(session => session.Linq<Album>()
				.ToArray()
				.OrderBy(a => a.Name)
				.Select(a => new AlbumContract(a))
				.ToArray());

		}

		public ArtistContract[] GetArtists() {

			return GetArtists(a => new ArtistContract(a));

		}

		public ArtistWithAdditionalNamesContract[] GetArtistsWithAdditionalNames() {

			return GetArtists(a => new ArtistWithAdditionalNamesContract(a));

		}

		public int GetSongCount(string filter) {

			return HandleQuery(session => session.Linq<Song>()
				.Where(s => string.IsNullOrEmpty(filter) || s.LocalizedName.Japanese.Contains(filter))
				.Count());

		}

		public SongDetailsContract GetSongDetails(int songId) {

			return HandleQuery(session => {

				var song = session.Load<Song>(songId);
				var songInPolls = session.Linq<SongInPoll>().Where(s => s.Song == song).ToArray();

				return new SongDetailsContract(song, songInPolls);

			});

		}

		public SongContract[] GetSongs(string filter, int start, int count) {

			return HandleQuery(session => session.Linq<Song>()
				.Where(s => string.IsNullOrEmpty(filter) 
					|| s.LocalizedName.Japanese.Contains(filter) 
					|| s.NicoId == filter)
				.OrderBy(s => s.LocalizedName.Japanese)
				.Skip(start)
				.Take(count)
				.ToArray()
				.Select(s => new SongContract(s))
				.ToArray());

		}

	}

}
