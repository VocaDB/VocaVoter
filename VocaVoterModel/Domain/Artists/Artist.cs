using System.Collections.Generic;
using System.Linq;
using VocaVoter.Model.Domain.Globalization;

namespace VocaVoter.Model.Domain.Artists {

	public class Artist {

		private IList<ArtistMetadataEntry> metadata = new List<ArtistMetadataEntry>();

		public Artist() {
			ArtistType = ArtistType.Unknown;
			LocalizedName = new LocalizedString();
		}

		public virtual ArtistType ArtistType { get; set; }

		public virtual int Id { get; set; }

		public virtual LocalizedString LocalizedName { get; set; }

		public virtual IList<ArtistMetadataEntry> Metadata {
			get { return metadata; }
			set {
				ParamIs.NotNull(() => value);
				metadata = value;
			}
		}

		public virtual string Name {
			get {
				return LocalizedName.Current;
			}
			set {
				LocalizedName.Current = value;
			}
		}

		public virtual IEnumerable<string> AllNames {
			get {
				return LocalizedName.All
					.Concat(Metadata.Where(m => m.MetadataType == ArtistMetadataType.AlternateName).Select(m => m.Value))
					.Distinct();
			}
		}

	}

}
