using Mermer.Core.DataAccess.EntityFramework;
using Mermer.DataAccess.Abstract;
using Mermer.Entity.Concrete;

namespace Mermer.DataAccess.Concrete
{
    public class GalleryImageDal : EfRepositoryBase<GalleryImage,MermerContext>,IGalleryDal
    {
        
    }
}