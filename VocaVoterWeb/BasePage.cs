using System.Web.UI;
using VocaVoter.Model.Service;
using VocaVoter.Model.Service.Security;
using VocaVoter.Web.Code;

namespace VocaVoter.Web {

	public class BasePage : Page {

		protected LoginManager LoginManager {
			get {
				return new LoginManager();
			}
		}

		protected PageMapper PageMapper {
			get {
				return new PageMapper(Request);
			}
		}

		protected HttpRequestParser RequestParser {
			get {
				return new HttpRequestParser(Request);
			}
		}

		protected ServiceModel Services {
			get {
				return new ServiceModel(Global.SessionFactory);
			}
		}

		protected string CreateNicoUrl(string nicoId) {

			return "http://www.nicovideo.jp/watch/" + nicoId;

		}

	}
}