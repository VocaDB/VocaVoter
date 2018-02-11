using System;
using System.Collections.Generic;
using VocaVoter.Model.DataContracts;
using VocaVoter.Model.Domain.Songs;

namespace VocaVoter.Model.Domain {

	public class Poll {

		private string name;
		private IList<SongInPoll> songs = new List<SongInPoll>();

		public Poll() {
			Description = string.Empty;
			NicoId = string.Empty;
		}

		public Poll(PollContract contract) {

			ParamIs.NotNull(contract, "contract");

			CreateDate = DateTime.Now;
			Description = contract.Description;
			Name = contract.Name;
			NicoId = contract.NicoId;

			/*foreach (var songContract in contract.Songs) {
				Songs.Add(new SongInPoll(this, songContract));
			}*/

		}

		public virtual DateTime CreateDate { get; set; }

		public virtual string Description { get; set; }

		public virtual DateTime EndTime { get; set; }

		public virtual int Id { get; set; }

		public virtual bool IsActive {
			get { return EndTime >= DateTime.Now; }
		}

		public virtual string Name {
			get { return name; }
			set {
				
				ParamIs.NotNullOrEmpty(value, "value");
				name = value;

			}
		}

		public virtual string NicoId { get; set; }

		public virtual IList<SongInPoll> Songs {
			get { return songs; }
			set { songs = value; }
		}

		public virtual SongInPoll AddSong(Song song, int sortIndex) {

			ParamIs.NotNull(song, "song");

			var songInPoll = new SongInPoll(this, song, sortIndex);
			Songs.Add(songInPoll);

			return songInPoll;

		}

	}

}
