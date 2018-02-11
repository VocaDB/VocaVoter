using FluentNHibernate.Mapping;
using VocaVoter.Model.Domain.Artists;

namespace VocaVoter.Model.Mapping.Artists {

	public class ArtistMetadataEntryMap : ClassMap<ArtistMetadataEntry> {

		public ArtistMetadataEntryMap() {

			Schema("dbo");
			Table("ArtistMetadata");
			Id(m => m.Id);
			Map(m => m.MetadataType).Column("[Type]").Not.Nullable();
			Map(m => m.Value).Not.Nullable();
			References(m => m.Artist).Not.Nullable();

		}

	}

}
