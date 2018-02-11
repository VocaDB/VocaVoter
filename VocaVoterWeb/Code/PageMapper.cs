using System.Web;

namespace VocaVoter.Web.Code {

	public class PageMapper {

		private readonly HttpRequest request;

		private string GetAbsoluteUrl(string url) {
			return request.ApplicationPath + (request.ApplicationPath.EndsWith("/") ? "" : "/") + url;
		}

		public PageMapper(HttpRequest request) {
			this.request = request;
		}

		public string CreatePollUrl(int pollId) {
			return GetAbsoluteUrl("ViewPoll.aspx?pollId=" + pollId);
		}

		public string CreateSongDetailsUrl(int songId) {
			return GetAbsoluteUrl("Database/SongDetails.aspx?songId=" + songId);
		}

	}
}