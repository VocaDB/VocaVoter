using System.Collections.Generic;
using VocaVoter.Model.Domain.Songs;

namespace VocaVoter.Model.Domain {

	public class SongInPoll {

		private IList<Vote> votes = new List<Vote>();

		public SongInPoll() {}

		public SongInPoll(Poll poll, Song song, int sortIndex) {

			ParamIs.NotNull(poll, "poll");
			ParamIs.NotNull(song, "song");

			Poll = poll;
			Song = song;
			SortIndex = sortIndex;
		}

		public virtual int Id { get; set; }

		public virtual Poll Poll { get; set; }

		public virtual Song Song { get; set; }

		public virtual int SortIndex { get; set; }

		public virtual int VoteCount { get; set; }

		public virtual IList<Vote> Votes {
			get { return votes; }
			set { votes = value; }
		}
	}

}
