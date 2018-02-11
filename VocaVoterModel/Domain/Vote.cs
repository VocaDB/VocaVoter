using System;
using VocaVoter.Model.Domain.Security;

namespace VocaVoter.Model.Domain {

	public class Vote {

		public virtual DateTime CreateDate { get; set; }

		public virtual int Id { get; set; }

		public virtual SongInPoll Song { get; set; }

		public virtual User User { get; set; }

	}
}
