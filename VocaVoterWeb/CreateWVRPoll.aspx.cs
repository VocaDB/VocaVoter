using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using VocaVoter.Model.DataContracts;
using VocaVoter.Model.Domain;
using VocaVoter.Model.Service.Rankings;

namespace VocaVoter.Web {

	public partial class CreatePoll : BasePage {

		private string StripHTML(string htmlString) {

			//This pattern Matches everything found inside html tags;
			//(.|\n) - > Look for any character or a new line
			// *?  -> 0 or more occurences, and make a non-greedy search meaning
			//That the match will stop at the first available '>' it sees, and not at the last one
			//(if it stopped at the last one we could have overlooked
			//nested HTML tags inside a bigger HTML tag..)
			// Thanks to Oisin and Hugh Brown for helping on this one...

			return Regex.Replace(htmlString, @"<(.|\n)*?>", string.Empty);

		}

		protected string ErrorMsg { get; private set; }

		protected bool HasErrors {
			get {
				return !string.IsNullOrEmpty(ErrorMsg);
			}
		}

		protected bool ImportedSuccessfully { get; private set; }

		protected void Page_Load(object sender, EventArgs e) {

			ErrorMsg = null;
			ImportedSuccessfully = false;
			DataBind();

		}

		protected void AcceptPoll(object sender, EventArgs e) {

			int wvrId = int.Parse(wvrIdBox.Text);
			var songs = new List<SongInPollContract>();

			foreach (var songRow in songList.Text.Split('\n')) {

				var stripped = StripHTML(songRow);
				stripped = stripped.Replace("\r", "");

				var parts = stripped.Split('|');

				if (parts.Length < 3)
					continue;

				int orderNum = int.Parse(parts[0]);
				var name = parts[1];
				var nicoId = parts[2];
				songs.Add(new SongInPollContract { SortIndex = orderNum, Name = name, NicoId = nicoId });

			}

			var pollContract = new WVRPollContract { Name = pollNameBox.Text, Songs = songs.ToArray(), WVRId = wvrId };
			Services.Polls.CreateWVRPoll(pollContract);

			Response.Redirect("Default.aspx?lastAction=pollCreated");

		}

		protected void ImportFromArticle(object sender, EventArgs e) {

			Uri uri;

			if (!Uri.TryCreate(articleUrlBox.Text, UriKind.Absolute, out uri)) {
				ErrorMsg = "Unable to parse URI";
			}

			if (!HasErrors) {

				var parser = new VocaloidismWVRParser();
				var poll = parser.GetSongs(uri);

				wvrIdBox.Text = poll.WVRId.ToString();
				pollNameBox.Text = poll.Name;
				songList.Text = string.Join("\n", poll.Songs.Select(s => s.SortIndex + "|" + s.Name + "|" + s.NicoId));
				ImportedSuccessfully = true;
	
			}

			DataBind();

		}

	}
}