using FluentNHibernate.Mapping;
using VocaVoter.Model.Domain;

namespace VocaVoter.Model.Mapping {

	public class SongInPollMap : ClassMap<SongInPoll> {

		public SongInPollMap() {
			
			Table("SongsInPoll");
			Id(m => m.Id);
			Map(m => m.SortIndex).Not.Nullable();
			Map(m => m.VoteCount).Not.Nullable();
			References(m => m.Poll);
			References(m => m.Song);

		}

	}

}
