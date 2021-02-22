using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace mvc_mom2.Models
{
	public class LoginModel
	{

		[Required(ErrorMessage = "Please set your genre.")]
		public string Genre { get; set; }
				
		[Required(ErrorMessage = "Please set your gender.")]
		public string Gender { get; set; }

		[Required(ErrorMessage = "You need to set a username!")]
		[MinLength(3, ErrorMessage = "At least three characters in the username.")]
		public string Username { get; set; }

		public string[] Genders = new[] { "Male", "Female", "Metalhead", "Other" };
		
		[Required(ErrorMessage = "Please choose one!")]
		public List<SelectListItem> Genres { get; } = new List<SelectListItem>
		{
			new SelectListItem { Value = "Western", Text = "Western" },
			new SelectListItem { Value = "Comedy", Text = "Comedy" },
			new SelectListItem { Value = "Drama", Text = "Drama"  },
			new SelectListItem { Value = "Animated", Text = "Animated"  },
			new SelectListItem { Value = "Action", Text = "Action"  },
			new SelectListItem { Value = "Romance", Text = "Romance"  },
			new SelectListItem { Value = "Fantasy", Text = "Fantasy"  },
			new SelectListItem { Value = "Sci-fi", Text = "Sci-fi"  },
		};

		public LoginModel()
		{


		}
	}
}
