using FluentNHibernate.Mapping;
using VocaVoter.Model.Domain;

namespace VocaVoter.Model.Mapping {

	public class VoteMap : ClassMap<Vote> {

		public VoteMap() {

			Id(m => m.Id);
			Map(m => m.CreateDate).Not.Nullable();
			References(m => m.Song).Not.Nullable();
			References(m => m.User).Not.Nullable();

		}

	}

}
