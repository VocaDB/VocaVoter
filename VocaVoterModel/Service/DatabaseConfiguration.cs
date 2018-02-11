using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using VocaVoter.Model.Mapping;

namespace VocaVoter.Model.Service {

	public class DatabaseConfiguration {

		public static ISessionFactory BuildSessionFactory() {

			var config = Fluently.Configure()
				.Database(
				MsSqlConfiguration.MsSql2008
					.ConnectionString(c => c.FromConnectionStringWithKey("Jupiter"))
					.Cache(c => c.ProviderClass("NHibernate.Caches.SysCache2.SysCacheProvider, NHibernate.Caches.SysCache2")))
				.Mappings(m => m.FluentMappings.AddFromAssemblyOf<PollMap>().Conventions.AddFromAssemblyOf<ClassConventions>());

			return config.BuildSessionFactory();

		}

	}

}
