using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using VocaVoter.Model.DataContracts.Security;
using VocaVoter.Model.DataContracts.Songs;
using VocaVoter.Model.Domain.Security;

namespace VocaVoter.Model.Service {

	public class UserService : ServiceBase {

		public UserService(ISessionFactory sessionFactory)
			: base(sessionFactory) {

		}

		/*public UserContract GetUser(int userId) {

			return HandleQuery(session => session.Linq<User>());

		}*/

	}

}
