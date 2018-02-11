using NHibernate;

namespace VocaVoter.Model.Service {

	public class ServiceModel {

		private readonly ISessionFactory sessionFactory;

		public ServiceModel(ISessionFactory sessionFactory) {
			this.sessionFactory = sessionFactory;
		}

		public PollService Polls {
			get {
				return new PollService(sessionFactory);
			}
		}

		public SongService Songs {
			get {
				return new SongService(sessionFactory);
			}
		}

	}
}
