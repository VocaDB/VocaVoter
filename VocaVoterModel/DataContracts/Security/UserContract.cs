using VocaVoter.Model.Domain.Security;

namespace VocaVoter.Model.DataContracts.Security {

	public class UserContract {

		public UserContract(User user) {
			Id = user.Id;
		}

		public int Id { get; set; }

	}

}
