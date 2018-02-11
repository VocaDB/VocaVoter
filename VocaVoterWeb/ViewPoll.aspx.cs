using System;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using VocaVoter.Model.DataContracts;

namespace VocaVoter.Web {

	public partial class ViewPoll : BasePage {

		protected PollContract Poll { get; private set; }

		protected bool CanVote {
			get {
				return !HasVoted;
			}
		}

		protected bool HasVoted {
			get {
				return (Request.Cookies[VoteCookieKey] != null || JustVoted);
			}
		}

		protected int PollId {
			get {
				return RequestParser.GetIntFromRequest("pollId");
			}
		}

		private string VoteCookieKey {
			get {
				return "HasVotedInPoll" + Poll.Id;
			}
		}

		protected bool JustVoted { get; set; }

		protected string CreateNicoEmbedUrl(string nicoId) {

			return "ViewNicoVideo.aspx?NicoId=" + nicoId;

		}

		protected string CreateYoutubeSearchUrl(string query) {

			return "http://www.youtube.com/results?search_query=" + query;

		}

		private void LoadPoll() {

			Poll = Services.Polls.GetPoll(PollId);
			/*Poll = new PollContract {
				Name = "WVRTest",
				Songs = new[] {
					new SongInPollContract { Id = 0, Name = "Song1", NicoId = "1290582619", VoteCount = 3 }, 
					new SongInPollContract { Id = 1, Name = "Song2", NicoId = "1290582619", VoteCount = 0 }, 
					new SongInPollContract { Id = 2, Name = "Song3", NicoId = "1290582619", VoteCount = 1 }, 
					new SongInPollContract { Id = 3, Name = "Song4", NicoId = "1290582619", VoteCount = 0 }, 
				}
			};*/

			int val = 1;
			var songSeries = resultChart.Series["Songs"];
			var chartArea = resultChart.ChartAreas["ChartArea"];

			foreach (var song in Poll.Songs) {

				songSeries.Points.Add(new DataPoint(val, song.VoteCount));
				chartArea.AxisX.CustomLabels.Add(val - 0.5, val + 0.5, "#" + song.SortIndex + ": " + song.Name);

				val++;

			}

		}

		protected void AddVote(object sender, CommandEventArgs e) {

			int songInPollId = int.Parse(e.CommandArgument.ToString());

			JustVoted = true;
			Poll = Services.Polls.AddVote(songInPollId);
			LoadPoll();
			//Response.Cookies.Set(new HttpCookie(VoteCookieKey, "true"));
			DataBind();

		}

		protected void Page_Load(object sender, EventArgs e) {

			LoadPoll();

			DataBind();

		}
	}
}