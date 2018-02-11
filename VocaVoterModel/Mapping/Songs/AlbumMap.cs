using FluentNHibernate.Mapping;
using VocaVoter.Model.Domain.Songs;

namespace VocaVoter.Model.Mapping.Songs {

	public class AlbumMap : ClassMap<Album> {

		public AlbumMap() {

			Schema("dbo");
			Id(m => m.Id);
			Component(m => m.LocalizedName, c => {
				c.Map(m => m.DefaultLanguage, "DefaultNameLanguage");
				c.Map(m => m.Japanese, "JapaneseName");
				c.Map(m => m.English, "EnglishName");
				c.Map(m => m.Romaji, "RomajiName");
			});

		}

	}

}
