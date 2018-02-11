using FluentNHibernate.Mapping;
using VocaVoter.Model.Domain.Security;

namespace VocaVoter.Model.Mapping.Security {

	public class UserMap : ClassMap<User> {

		public UserMap() {
			
			Schema("dbo");
			Id(m => m.Id);

		}

	}

}
