﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using VocaVoter.Model.DataContracts.Songs;
using VocaVoter.Model.Domain;
using VocaVoter.Model.Domain.Songs;

namespace VocaVoter.Model.DataContracts.UseCases {

	[DataContract]
	public class SongDetailsContract {

		public SongDetailsContract(Song song, IEnumerable<SongInPoll> songInPolls) {
			Song = new SongContract(song);
			WVRPlacements = songInPolls.Select(s => new SongWVRPlacementContract(s)).ToArray();
		}

		[DataMember]
		public SongContract Song { get; private set; }

		[DataMember]
		public SongWVRPlacementContract[] WVRPlacements { get; private set; }

	}

}
