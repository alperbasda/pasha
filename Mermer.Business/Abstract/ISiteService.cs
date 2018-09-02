using Mermer.Entity.ComplexType;
using Mermer.Entity.Concrete;

namespace Mermer.Business.Abstract
{
    public interface ISiteService
    {
        IndexViewModel IndexPageCalculate();
        Site GetBasicData();
        bool EditBasicData(Site site);
    }
}