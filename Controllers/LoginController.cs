using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using mvc_mom2.Models;

namespace mvc_mom2.Controllers
{

	public class LoginController : Controller
	{

		public IActionResult Index()
		{
			return View(new LoginModel());
		}

		[HttpPost]
		public IActionResult LoginAttempt([FromForm] LoginModel user)
		{
			if (!ModelState.IsValid)
			{
				return View("Index", user);
			}
			else
			{
				var userData = JsonConvert.SerializeObject(user);
				HttpContext.Session.SetString("user", userData);
				return RedirectToAction("Index", "Profile");
			}
		}
	}
}