using System;
using VocaVoter.Model.DataContracts;

namespace VocaVoter.Model.Domain {

	public class WVRPoll : Poll {

		public WVRPoll() {}

		public WVRPoll(WVRPollContract contract)
			: base(contract) {

			WVRId = contract.WVRId;
			EndTime = DateTime.Now.AddDays(7);

		}
			 
		public virtual int WVRId { get; set; }

	}

}
