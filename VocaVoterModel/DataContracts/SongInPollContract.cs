using System.Runtime.Serialization;
using VocaVoter.Model.Domain;

namespace VocaVoter.Model.DataContracts {

	[DataContract]
	public class SongInPollContract {

		public SongInPollContract() {}

		public SongInPollContract(SongInPoll songInPoll) {

			Id = songInPoll.Id;
			Name = songInPoll.Song.Name;
			NicoId = songInPoll.Song.NicoId;
			SongId = songInPoll.Song.Id;
			SortIndex = songInPoll.SortIndex;
			VoteCount = songInPoll.VoteCount;

		}

		[DataMember]
		public int Id { get; set; }

		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public string NicoId { get; set; }

		[DataMember]
		public int SongId { get; set; }

		[DataMember]
		public int SortIndex { get; set; }

		[DataMember]
		public int VoteCount { get; set; }

	}
}
