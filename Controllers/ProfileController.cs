using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using mvc_mom2.Models;

namespace mvc_mom2.Controllers
{
	public class ProfileController : Controller
	{
		public IActionResult Index()
		{
			if(HttpContext.Session.GetString("user") == null)
			{
				return RedirectToAction("Index", "Login");
			}
			string user = HttpContext.Session.GetString("user");
			LoginModel userData = JsonConvert.DeserializeObject<LoginModel>(user);
			ViewBag.userData = userData;

			return View();
		}
	}
}