using System;
using System.Linq;
using NHibernate.Linq;
using NHibernate;
using VocaVoter.Model.DataContracts;
using VocaVoter.Model.Domain;
using VocaVoter.Model.Domain.Songs;

namespace VocaVoter.Model.Service {

	public class PollService : ServiceBase {

		public PollService(ISessionFactory sessionFactory)
			: base(sessionFactory) {
		}

		public PollContract AddVote(int songInPollId) {

			return HandleTransaction(session => {
				var songInPoll = session.Load<SongInPoll>(songInPollId);
				songInPoll.VoteCount++;
				return new PollContract(songInPoll.Poll);
			});

		}

		public void CreateWVRPoll(WVRPollContract contract) {

			HandleTransaction(session => {

				var poll = new WVRPoll(contract);

				foreach (var songContract in contract.Songs) {

					var c = songContract;
					var song = session.Linq<Song>().FirstOrDefault(s => s.NicoId == c.NicoId);

					if (song == null) {
						song = new Song { Name = songContract.Name, NicoId = songContract.NicoId };
						session.Save(song);
					}

					poll.AddSong(song, songContract.SortIndex);
					session.Save(poll);
					
				}
			});

		}

		public PollContract[] GetActivePolls() {

			return HandleQuery(session => session.Linq<Poll>()
				.Where(m => m.EndTime >= DateTime.Now)
				.OrderByDescending(m => m.CreateDate)
				.ToArray()
				.Select(m => new PollContract(m)).ToArray());

		}

		public PollContract GetDefault() {

			return HandleQuery(session => new PollContract(session.Linq<Poll>().First()));

		}

		public int GetLatestWVRId() {

			return HandleQuery(session => session.Linq<WVRPoll>().Select(m => m.WVRId).OrderByDescending(m => m).First());

		}

		public PollContract GetPoll(int id) {

			return HandleQuery(session => new PollContract(session.Load<Poll>(id)));

		}

		public PollContract[] GetPolls() {

			return HandleQuery(session => session.Linq<Poll>()
				.OrderByDescending(m => m.CreateDate)
				.ToArray()
				.Select(m => new PollContract(m)).ToArray());

		}

		public SongInPollContract GetSongInPoll(int id) {

			return HandleQuery(session => new SongInPollContract(session.Load<SongInPoll>(id)));

		}

	}
}
