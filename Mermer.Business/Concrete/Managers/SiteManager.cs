using System.Linq;
using Mermer.Business.Abstract;
using Mermer.Core.Aspects.AuthorizationAspects;
using Mermer.DataAccess.Abstract;
using Mermer.Entity.ComplexType;
using Mermer.Entity.Concrete;

namespace Mermer.Business.Concrete.Managers
{
    public class SiteManager : ISiteService
    {
        private ISiteDal _siteDal;
        public SiteManager(ISiteDal siteDal)
        {
            _siteDal = siteDal;
        }

        [SecuredOperationAspect(Roles = "Admin")]
        public IndexViewModel IndexPageCalculate()
        {
            return _siteDal.GetIndexPage();
        }

        public Site GetBasicData() => _siteDal.GetList().SingleOrDefault();

        [SecuredOperationAspect(Roles = "Admin")]
        public bool EditBasicData(Site site)
        {
            _siteDal.Update(site);
            return true;
        }
    }
}