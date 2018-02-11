namespace VocaVoter.Model.Domain.Security {

	public class User {

		public virtual int Id { get; set; }

		public virtual RoleTypes Roles { get; set; }

	}

}
