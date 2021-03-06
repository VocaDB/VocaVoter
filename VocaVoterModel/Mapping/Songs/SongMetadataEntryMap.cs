﻿using FluentNHibernate.Mapping;
using VocaVoter.Model.Domain.Songs;

namespace VocaVoter.Model.Mapping.Songs {

	public class SongMetadataEntryMap : ClassMap<SongMetadataEntry> {

		public SongMetadataEntryMap() {

			Schema("dbo");
			Table("SongMetadata");
			Id(m => m.Id);
			Map(m => m.MetadataType).CustomType(typeof(SongMetadataType)).Not.Nullable();
			Map(m => m.Value).Not.Nullable();
			References(m => m.Song).Not.Nullable();

		}

	}

}
