using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace VocaVoter.Model.DataContracts {

	[DataContract]
	public class WVRPollContract : PollContract {

		[DataMember]
		public int WVRId { get; set; }

	}

}
