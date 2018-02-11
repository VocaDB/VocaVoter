using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace VocaVoter.Model.Mapping {

	public class ClassConventions : IClassConvention, IIdConvention, IReferenceConvention, IPropertyConvention {

		public void Apply(IClassInstance instance) {
		
			instance.Cache.ReadWrite();
			instance.Schema("voter");
			instance.Table(instance.EntityType.Name + "s");

		}

		public void Apply(IIdentityInstance instance) {

			instance.Column("Id");
			instance.GeneratedBy.Identity();
	
		}

		public void Apply(IManyToOneInstance instance) {
			instance.Column(string.Format("[{0}]", instance.Name));
		}

		public void Apply(IPropertyInstance instance) {
			instance.Column(string.Format("[{0}]", instance.Name));
		}

	}

}
