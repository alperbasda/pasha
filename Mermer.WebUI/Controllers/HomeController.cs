using System.Linq;
using System.Net.Mail;
using System.Web.Mvc;
using Mermer.Business.Abstract;
using Mermer.Entity.ComplexType;
using Mermer.Entity.Concrete;
using Microsoft.JScript;
using WebGrease.Css.Extensions;

namespace Mermer.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly IGalleryImageService _galleryImageService;
        private readonly ISiteService _siteService;
        private readonly IOrderService _orderService;
        private readonly ICategoryService _categoryService;

        public HomeController(ICategoryService categoryService,ISiteService siteService, IGalleryImageService galleryImageService, IProductService productService, IOrderService orderService)
        {
            _categoryService = categoryService;
            _siteService = siteService;
            _galleryImageService = galleryImageService;
            _productService = productService;
            _orderService = orderService;
        }

        public ActionResult DeviceControl()
        {
            return View();
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Anasayfa()
        {
            OnepageModel model = new OnepageModel();
            model.Categories = _categoryService.GetCategories();
            model.Products = _productService.GetAllProducts();
            model.Images = _galleryImageService.GetImages(30);
            model.Site = _siteService.GetBasicData();
            return View(model);
        }
       

        public ActionResult Error(string error)
        {
            ViewBag.Error = error;
            return View();
        }

        public ActionResult SendMail(string email,string name ,string text,string telephone)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(text) || string.IsNullOrEmpty(email))
                return RedirectToAction("Error", new { hata = "Mail Gönderilemedi. Lütfen Tüm alanları eksiksiz doldurunuz" });

            SmtpClient _client = new SmtpClient();
            _client.Host = "mailhost";
            _client.Credentials = new System.Net.NetworkCredential("sender", "senderpass");
            _client.Port = 587;
            MailMessage _mail = new MailMessage();
            _mail.From = new MailAddress("sender");
            _mail.To.Add("receiver");
            _mail.Subject = name + " Kişisinden";
            _mail.Body = text + "\n kişi iletişim bilgileri : " + email +"\n Telefon : "+ telephone;
            _client.Send(_mail);
            return RedirectToAction("Index");
        }

        
        public ActionResult ProductDetail(int Id)
        {
            return View(_productService.GetById(Id));
        }

        [HttpPost]
        public ActionResult ProductDetail(UserOrderSetModel order)
        {
            return _orderService.AddUserOrder(order) ? RedirectToAction("Index", "Home") : RedirectToAction("Error", "Home", new{ error="Sipariş alınamadı tekrar deneyin"});

        }
        

        [HttpPost]
        public ActionResult SaveOrder(UserOrderSetModel model)
        {
            
            if (_orderService.AddUserOrder(model))
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Error", "Home",new {error="Sipariş sırasında hata oluştu tekrar deneyin"});
        }

    }
}