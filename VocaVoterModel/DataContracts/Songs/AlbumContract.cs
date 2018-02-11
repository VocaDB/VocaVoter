using VocaVoter.Model.Domain.Songs;

namespace VocaVoter.Model.DataContracts.Songs {

	public class AlbumContract {

		public AlbumContract() { }

		public AlbumContract(Album album) {

			Id = album.Id;
			Name = album.Name;

		}

		public int Id { get; set; }

		public string Name { get; set; }

	}

}
