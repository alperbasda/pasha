using System.Collections.Generic;
using Mermer.Business.Abstract;
using Mermer.Core.Aspects.AuthorizationAspects;
using Mermer.DataAccess.Abstract;
using Mermer.Entity.Concrete;

namespace Mermer.Business.Concrete.Managers
{
    public class GalleryImageManager : IGalleryImageService
    {
        private IGalleryDal _galleryDal;
        public GalleryImageManager(IGalleryDal galleryDal)
        {
            _galleryDal = galleryDal;
        }
        [SecuredOperationAspect(Roles = "Admin")]
        public void AddImage(GalleryImage image)
        {
            _galleryDal.Add(image);
        }
        [SecuredOperationAspect(Roles = "Admin")]
        public void RemoveImage(int id)
        {
            _galleryDal.Delete( _galleryDal.Get(s => s.Id==id));
        }

        public List<GalleryImage> GetImages(int count=0)
        {
            if (count==0)
            {
                return _galleryDal.GetList();
            }
            else
            {
                return _galleryDal.GetList(0, count);
            }
            
        }
    }
}