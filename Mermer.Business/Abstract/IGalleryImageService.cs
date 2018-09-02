using System.Collections.Generic;
using Mermer.Entity.Concrete;

namespace Mermer.Business.Abstract
{
    public interface IGalleryImageService
    {
        void AddImage(GalleryImage image);
        void RemoveImage(int id);
        List<GalleryImage> GetImages(int count=0);
    }
}