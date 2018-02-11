using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VocaVoter.Model.Domain.Artists {

	public class ArtistMetadataEntry : MetadataEntry {

		public virtual ArtistMetadataType MetadataType { get; set; }

		public virtual Artist Artist { get; set; }
	}
}

