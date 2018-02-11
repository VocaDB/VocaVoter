using FluentNHibernate.Mapping;
using VocaVoter.Model.Domain;

namespace VocaVoter.Model.Mapping {

	public class PollMap : ClassMap<Poll> {

		public PollMap() {

			DiscriminateSubClassesOnColumn("[Type]");
			Id(m => m.Id);
			Map(m => m.CreateDate).Not.Nullable();
			Map(m => m.Description).Not.Nullable();
			Map(m => m.EndTime).Not.Nullable();
			Map(m => m.Name).Not.Nullable();
			Map(m => m.NicoId).Not.Nullable();
			HasMany(m => m.Songs).OrderBy("SortIndex").Cascade.All();

		}

	}

	public class WVRPollMap : SubclassMap<WVRPoll> {
	
		public WVRPollMap() {
			
			DiscriminatorValue("WVR");
			Map(m => m.WVRId).Not.Nullable();

		}

	}

}
