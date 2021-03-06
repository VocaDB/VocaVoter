﻿using FluentNHibernate.Mapping;
using VocaVoter.Model.Domain.Songs;

namespace VocaVoter.Model.Mapping.Songs {

	public class SongMap : ClassMap<Song> {

		public SongMap() {

			Id(m => m.Id);
			Map(m => m.ArtistString).Not.Nullable();
			Map(m => m.CreateDate).Not.Nullable();
			Map(m => m.NicoId);
			HasMany(m => m.Metadata).Inverse().Cascade.AllDeleteOrphan();
			Component(m => m.LocalizedName, c => {
				c.Map(m => m.DefaultLanguage, "DefaultNameLanguage");
				c.Map(m => m.Japanese, "Name");
				c.Map(m => m.English, "EnglishName");
				c.Map(m => m.Romaji, "RomajiName");
			});

			HasMany(m => m.Albums).Table("SongsInAlbums").Inverse().Cascade.All();
			HasMany(m => m.Artists).Table("ArtistsForSongs").Inverse().Cascade.All();

		}

	}

	public class ArtistForSongMap : ClassMap<ArtistForSong> {

		public ArtistForSongMap() {

			Schema("dbo");
			Table("ArtistsForSongs");
			Id(m => m.Id);
			References(m => m.Artist).Not.Nullable();
			References(m => m.Song).Not.Nullable();

		}

	}

	public class SongInAlbumMap : ClassMap<SongInAlbum> {

		public SongInAlbumMap() {

			Schema("dbo");
			Table("SongsInAlbums");
			Id(m => m.Id);
			Map(m => m.TrackNumber).Not.Nullable();
			References(m => m.Album).Not.Nullable();
			References(m => m.Song).Not.Nullable();

		}

	}

}
