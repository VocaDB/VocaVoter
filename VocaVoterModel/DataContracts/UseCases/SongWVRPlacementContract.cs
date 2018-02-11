using VocaVoter.Model.Domain;

namespace VocaVoter.Model.DataContracts.UseCases {

	public class SongWVRPlacementContract {

		public SongWVRPlacementContract(SongInPoll songInPoll) {
			PollId = songInPoll.Poll.Id;
			PollName = songInPoll.Poll.Name;
			SortIndex = songInPoll.SortIndex;
		}

		public int PollId { get; private set; }

		public string PollName { get; private set; }

		public int SortIndex { get; private set; }

	}

}
