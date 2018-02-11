using FluentNHibernate.Mapping;
using VocaVoter.Model.Domain.Artists;

namespace VocaVoter.Model.Mapping.Artists {

	public class ArtistMap : ClassMap<Artist> {

		public ArtistMap() {

			Schema("dbo");
			Id(m => m.Id);
			Map(m => m.ArtistType).Not.Nullable();
			HasMany(m => m.Metadata).Inverse().Cascade.AllDeleteOrphan();
			Component(m => m.LocalizedName, c => {
				c.Map(m => m.DefaultLanguage, "DefaultNameLanguage").Not.Nullable();
				c.Map(m => m.Japanese, "JapaneseName");
				c.Map(m => m.English, "EnglishName");
				c.Map(m => m.Romaji, "RomajiName");
			});

		}

	}

}
