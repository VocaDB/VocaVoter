using System.Linq;
using VocaVoter.Model.Domain.Artists;

namespace VocaVoter.Model.DataContracts.Songs {

	public class ArtistWithAdditionalNamesContract : ArtistContract {

		public ArtistWithAdditionalNamesContract(Artist artist)
			: base(artist) {

			AdditionalNames = string.Join(", ", artist.AllNames.Where(n => n != artist.Name));

		}

		public string AdditionalNames { get; private set; }

	}

}
