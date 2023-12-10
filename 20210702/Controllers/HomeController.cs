using Bai4.Data;
using Bai4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Linq;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace Bai4.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly DataContext _db;
		public HomeController(ILogger<HomeController> logger, DataContext db)
		{
			_logger = logger;
			_db = db;

		}

		public IActionResult Index()
		{
			var products = _db.Products.OrderByDescending(u => u.UnitPrice).Take(3).ToList();

			ViewBag.NavItems = _db.NavItems.ToList();
			ViewBag.Categories = _db.Categories.ToList().Select(u => new SelectListItem
			{
				Text = u.Name,
				Value = u.Id.ToString()
			});
			return View(products);
		}

		public IActionResult SearchProduct(string keyword)
		{
			var products = _db.Products.Where(u => u.Name.Contains(keyword)).ToList();

			return PartialView("DuongMinhHieu_MainContent", products);
		}

		public IActionResult SearchProductByCategory(int id)
		{
			var products = new List<Product>();
			if(id == -1)
			{
				 products = _db.Products.ToList();

			} else
			{
				 products = _db.Products.Where(u => u.CategoryId == id).ToList();

			}

			return PartialView("DuongMinhHieu_MainContent", products);
		}

		public IActionResult Create()
		{
			ViewBag.NavItems = _db.NavItems.ToList();
			ProductVM model = new ProductVM()
			{
				Category = _db.Categories.ToList().Select(u  => new SelectListItem
				{
					Text = u.Name,
					Value = u.Id.ToString()
				}),
				Product = new Product()
			};
			return View(model);
		}

		[HttpPost]
		public IActionResult Create(ProductVM model)
		{
			if(ModelState.IsValid && model.Product.CategoryId != null)
			{
				_db.Products.Add(model.Product);
				_db.SaveChanges();
			}
			model.Category = _db.Categories.ToList().Select(u => new SelectListItem
			{
				Text = u.Name,
				Value = u.Id.ToString()
			});
			ViewBag.NavItems = _db.NavItems.ToList();
			return View(model);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}