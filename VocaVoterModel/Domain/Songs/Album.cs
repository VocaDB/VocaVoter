using VocaVoter.Model.Domain.Globalization;

namespace VocaVoter.Model.Domain.Songs {

	public class Album {

		public Album() {
			LocalizedName = new LocalizedString();
		}

		public virtual int Id { get; set; }

		public virtual LocalizedString LocalizedName { get; set; }

		public virtual string Name {
			get {
				return LocalizedName.Current;
			}
			set {
				LocalizedName.Current = value;
			}
		}

	}

}
