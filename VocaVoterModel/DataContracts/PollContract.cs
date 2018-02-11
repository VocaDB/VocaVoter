using System;
using System.Linq;
using System.Runtime.Serialization;
using VocaVoter.Model.Domain;

namespace VocaVoter.Model.DataContracts {

	[DataContract]
	public class PollContract {

		public PollContract() {
			Description = string.Empty;
			NicoId = string.Empty;
		}

		public PollContract(Poll poll) {

			ParamIs.NotNull(poll, "poll");

			CreateDate = poll.CreateDate;
			Description = poll.Description;
			EndDate = poll.EndTime;
			Id = poll.Id;
			IsActive = poll.IsActive;
			Name = poll.Name;
			NicoId = poll.NicoId;
			Songs = poll.Songs.Select(m => new SongInPollContract(m)).ToArray();

		}

		[DataMember]
		public DateTime CreateDate { get; set; }

		[DataMember]
		public string Description { get; set; }

		[DataMember]
		public DateTime EndDate { get; set; }

		[DataMember]
		public int Id { get; set; }

		[DataMember]
		public bool IsActive { get; set; }

		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public string NicoId { get; set; }

		[DataMember]
		public SongInPollContract[] Songs { get; set; }

	}
}
