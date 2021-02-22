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

	public class GuestController : Controller
	{

		public IActionResult Index()
		{
			List<GuestModel> guestposts = getData();
			guestposts.Reverse();
			ViewData["options"] = guestposts;
			if(HttpContext.Session.GetString("user") == null)
			{
				return RedirectToAction("Index", "Login");
			}
			string user = HttpContext.Session.GetString("user");
			LoginModel userData = JsonConvert.DeserializeObject<LoginModel>(user);
			ViewBag.userData = userData;

			return View();
		}
		[HttpPost]
		public IActionResult AddPost([FromForm] GuestModel Post)
		{
			//checks if the data supplied from the view is valid
			if(ModelState.IsValid){
				List<GuestModel> posts = getData();
				Post.Id = posts.Count() + 1;
				posts.Add(Post);
				saveJson(posts);
				ViewBag.okmsg = "Inlägg sparat!";
				return RedirectToAction("Index");
			} else{
				ViewBag.okmsg = "Fyll i all fält korrekt!";
				return View();
			}
		}

		public void saveJson(List<GuestModel> Post)
		{
            var updatedList = JsonConvert.SerializeObject(Post);
            System.IO.File.WriteAllText("data.json", updatedList);
		}

		public List<GuestModel> getData()
		{
			var jsonString = System.IO.File.ReadAllText("data.json");
			var jsonObj = JsonConvert.DeserializeObject<List<GuestModel>>(jsonString);
			return jsonObj;
		} 
	}
}