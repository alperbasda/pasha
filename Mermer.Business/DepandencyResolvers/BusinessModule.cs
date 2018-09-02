using System.Data.Entity;
using Mermer.Business.Abstract;
using Mermer.Business.Concrete.Managers;
using Mermer.DataAccess.Abstract;
using Mermer.DataAccess.Concrete;
using Ninject.Modules;

namespace Mermer.Business.DepandencyResolvers
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserDal>().To<UserDal>();
            Bind<IUserService>().To<UserManager>();
            Bind<IProductService>().To<ProductManager>();
            Bind<IProductDal>().To<ProductDal>();
            Bind<IOrderDal>().To<OrderDal>();
            Bind<IOrderService>().To<OrderManager>();
            Bind<ICategoryService>().To<CategoryManager>();
            Bind<ICategoryDal>().To<CategoryDal>();
            Bind<ISiteService>().To<SiteManager>();
            Bind<ISiteDal>().To<SiteDal>();
            Bind<IGalleryDal>().To<GalleryImageDal>();
            Bind<IGalleryImageService>().To<GalleryImageManager>();

            Bind<DbContext>().To<MermerContext>();
        }
    }
}