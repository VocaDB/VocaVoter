using System;
using System.Web.UI.WebControls;
using VocaVoter.Model.DataContracts.Songs;

namespace VocaVoter.Web {

	public partial class ListSongs : BasePage {

		protected int PageIndex { get; private set; }

		protected int PageSize {
			get {
				return 30;
			}
		}

		protected int SongCount {
			get {
				return Services.Songs.GetSongCount(nameFilterBox.Text);
			}			
		}

		protected SongContract[] Songs {
			get {
				return Services.Songs.GetSongs(nameFilterBox.Text, (PageIndex - 1) * PageSize, PageSize);
			}
		}

		protected void Page_Load(object sender, EventArgs e) {

			PageIndex = 1;

			if (!IsPostBack) {

				if (!string.IsNullOrEmpty(Request["nameFilter"]))
					nameFilterBox.Text = Request["nameFilter"];

				DataBind();

			}
		}

		protected void ChangePage(object sender, CommandEventArgs e) {

			PageIndex = int.Parse(e.CommandArgument.ToString());
			DataBind();

		}

		protected void Search(object sender, EventArgs e) {

			PageIndex = 1;
			DataBind();

		}

	}
}