using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VocaVoter.Model.Service.Security {

	public class LoginManager {

		public bool IsAdmin {
			get {
				return false;
			}
		}

		public bool IsLoggedIn {
			get {
				return true;
			}
		}

	}

}
